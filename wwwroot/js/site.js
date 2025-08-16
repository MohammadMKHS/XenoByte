// Typewriter effect
const text = "Blockchain Forensics | Cyber Threat Intelligence | Crypto Tracking";
let i = 0;
function typeWriter() {
    if (i < text.length) {
        document.getElementById("typewriter").innerHTML += text.charAt(i);
        i++;
        setTimeout(typeWriter, 50);
    }
}
window.onload = typeWriter;

// Theme toggle
function toggleTheme() {
    document.body.classList.toggle("light-theme");
}