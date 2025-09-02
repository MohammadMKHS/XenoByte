using Microsoft.AspNetCore.Mvc;
using XenoByte.AppManager;
using XenoByte.Helpers;
using XenoByte.Models.Entity.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using XenoByte.Services;

namespace XenoByte.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ApplicationContext applicationContext;
        private readonly IEmailService emailService;

        public AuthenticationController(ApplicationContext ApplicationContext, IEmailService emailService)
        {
            applicationContext = ApplicationContext;
            this.emailService = emailService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            // 1 - Get user from DB by email
            var user = await applicationContext.User.Include(x => x.UserRoles).ThenInclude(x => x.Role).FirstOrDefaultAsync(u => u.Email == email || u.Username == email);

            // 2 - Check if user exists
            if (user == null)
            {
                ViewBag.Error = "User not found.";
                return View();
            }

            // 3 - Verify password using PasswordHelper
            bool isPasswordValid = PasswordHelper.VerifyPassword(password, user.PasswordHash, user.PasswordSalt);

            if (!isPasswordValid)
            {
                ViewBag.Error = "Invalid password.";
                return View();
            }

            // 4 - Authorize the user and set the cookies
            await SignInUser(user);

            // 5 - No errors → Redirect to Home
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(string username, string email, string password, string confirmPassword)
        {
            // 1. Check password confirmation
            if (password != confirmPassword)
            {
                ViewBag.Error = "Passwords do not match!";
                return View();
            }

            // 2. Check if user already exists
            var existingUser = applicationContext.User.FirstOrDefault(u => u.Email == email || u.Username == username);
            if (existingUser != null)
            {
                ViewBag.Error = "Email Or Username is already registered!";
                return View();
            }

            // 3. Hash password + generate salt
            var Password = PasswordHelper.HashPassword(password);

            // 4. Create new user
            var newUser = new User
            {
                Username = username,
                Email = email,
                PasswordHash = Password.hashedPassword,
                PasswordSalt = Password.salt,
                UserRoles = new List<UserRoles>
                {
                    new UserRoles
                    {
                        RoleId = 2,
                    }
                }
            };

            applicationContext.User.Add(newUser);
            applicationContext.SaveChanges();

            // 5. Redirect to Login after success
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var user = await applicationContext.User.FirstOrDefaultAsync(u => u.Email == email);
            
            if (user == null)
            {
                ViewBag.Error = "No account found with that email address.";
                return View();
            }

            // Generate reset token
            string resetToken = Guid.NewGuid().ToString();
            user.ResetToken = resetToken;
            user.ResetTokenExpiry = DateTime.UtcNow.AddHours(1); // Token expires in 1 hour
            
            await applicationContext.SaveChangesAsync();

            // Send reset email using the existing email service
            var baseUrl = $"{Request.Scheme}://{Request.Host}";
            await emailService.SendPasswordResetEmailAsync(user.Email, resetToken, baseUrl);

            ViewBag.Success = "Password reset link has been sent to your email address.";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ResetPassword(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest("Invalid reset token.");
            }

            var user = await applicationContext.User.FirstOrDefaultAsync(u => u.ResetToken == token);
            
            if (user == null || user.ResetTokenExpiry < DateTime.UtcNow)
            {
                ViewBag.Error = "Invalid or expired reset token.";
                return View();
            }

            ViewBag.Token = token;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(string token, string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                ViewBag.Error = "Passwords do not match.";
                ViewBag.Token = token;
                return View();
            }

            var user = await applicationContext.User.FirstOrDefaultAsync(u => u.ResetToken == token);
            
            if (user == null || user.ResetTokenExpiry < DateTime.UtcNow)
            {
                ViewBag.Error = "Invalid or expired reset token.";
                return View();
            }

            // Hash new password
            var hashedPassword = PasswordHelper.HashPassword(password);
            user.PasswordHash = hashedPassword.hashedPassword;
            user.PasswordSalt = hashedPassword.salt;
            user.ResetToken = null;
            user.ResetTokenExpiry = null;

            await applicationContext.SaveChangesAsync();

            ViewBag.Success = "Your password has been reset successfully. You can now login with your new password.";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        // ---------------- Helper function ----------------
        private async Task SignInUser(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email)
            };

            // Add roles if user has them
            foreach (var role in user.UserRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Role.Name));
            }

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddHours(2)
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }
    }
}
