// --- Theme Toggle Logic ---
const themeToggleBtn = document.getElementById('themeToggleBtn');
const themeIcon = document.getElementById('themeIcon');
const body = document.body;

// Function to set the theme
function setTheme(theme) {
    if (theme === 'light') {
        body.classList.add('light-theme');
        themeIcon.textContent = 'light_mode'; // sun icon
    } else {
        body.classList.remove('light-theme');
        themeIcon.textContent = 'dark_mode'; // moon icon
    }
    localStorage.setItem('theme', theme);
}

// Check for saved theme preference on load
document.addEventListener('DOMContentLoaded', () => {
    const savedTheme = localStorage.getItem('theme') || 'dark'; // Default to dark
    setTheme(savedTheme);
});

if (themeToggleBtn) {
    themeToggleBtn.addEventListener('click', () => {
        const isLight = body.classList.contains('light-theme');
        setTheme(isLight ? 'dark' : 'light');
    });
}

// --- Typewriter Effect Logic ---
const typewriterElement = document.getElementById('typewriter');
const taglines = [
    "Empowering investigators with actionable insights into illicit cryptocurrency flows.",
    "Tracing cryptocurrency transactions and detecting malicious patterns.",
    "Integrating blockchain data extraction with transaction graph analysis.",
    "Correlating suspicious activities with known APT groups and cyber adversaries.",
    "Bridging critical gaps in blockchain forensic capabilities."
];
let taglineIndex = 0;
let charIndex = 0;
let isDeleting = false;
const typingSpeed = 50; // milliseconds per character
const deletingSpeed = 30; // milliseconds per character
const delayBetweenTaglines = 2000; // milliseconds

function typeWriter() {
    if (typewriterElement) {
        const currentTagline = taglines[taglineIndex];
        if (isDeleting) {
            // Deleting text
            typewriterElement.textContent = currentTagline.substring(0, charIndex - 1);
            charIndex--;
        } else {
            // Typing text
            typewriterElement.textContent = currentTagline.substring(0, charIndex + 1);
            charIndex++;
        }

        let typeSpeed = isDeleting ? deletingSpeed : typingSpeed;

        if (!isDeleting && charIndex === currentTagline.length) {
            // Finished typing, start deleting after a delay
            typeSpeed = delayBetweenTaglines;
            isDeleting = true;
        } else if (isDeleting && charIndex === 0) {
            // Finished deleting, move to next tagline
            isDeleting = false;
            taglineIndex = (taglineIndex + 1) % taglines.length;
            typeSpeed = typingSpeed;
        }

        setTimeout(typeWriter, typeSpeed);
    }

}

// Start the typewriter effect
document.addEventListener('DOMContentLoaded', typeWriter);

// --- Simulated Live Data Streams ---

// Function to generate a random hex string (for hashes/addresses)
function getRandomHexString(length) {
    let result = '';
    const characters = 'abcdef0123456789';
    for (let i = 0; i < length; i++) {
        result += characters.charAt(Math.floor(Math.random() * characters.length));
    }
    return result;
}

// 1. Live Transaction Stream
const transactionList = document.getElementById('transactionList');
function addRandomTransaction() {
    if (transactionList) {
        const txHash = '0x' + getRandomHexString(64);
        const fromAddr = '0x' + getRandomHexString(40);
        const toAddr = '0x' + getRandomHexString(40);
        const amount = (Math.random() * 1000 + 0.001).toFixed(4); // Random amount
        const currency = Math.random() > 0.5 ? 'ETH' : 'BTC';

        const listItem = document.createElement('li');
        listItem.innerHTML = `
                <span class="hash">Tx: ${txHash.substring(0, 10)}...${txHash.substring(txHash.length - 8)}</span>
                <span class="value">${amount} ${currency}</span>
                <span class="from-to">From: ${fromAddr.substring(0, 8)}... To: ${toAddr.substring(0, 8)}...</span>
            `;
        transactionList.prepend(listItem); // Add to top

        // Keep only a certain number of transactions to prevent overflow
        if (transactionList.children.length > 20) {
            transactionList.removeChild(transactionList.lastChild);
        }
    }
    
}
setInterval(addRandomTransaction, 1500); // Add a new transaction every 1.5 seconds

// 2. Threat Intelligence: APT Activity
const aptList = document.getElementById('aptList');
const aptGroups = [
    "APT28 (Fancy Bear)", "APT29 (Cozy Bear)", "Lazarus Group", "Equation Group",
    "Sandworm Team", "DarkSide", "FIN7", "Conti", "BlackMatter", "Wizard Spider"
];
const aptActivities = [
    "Ransomware Deployment", "Supply Chain Attack", "Phishing Campaign",
    "Data Exfiltration", "DDoS Attack", "Zero-day Exploitation",
    "Cryptojacking", "Insider Threat", "Espionage"
];
function addRandomAPTActivity() {
    if (aptList) {
        const group = aptGroups[Math.floor(Math.random() * aptGroups.length)];
        const activity = aptActivities[Math.floor(Math.random() * aptActivities.length)];
        const timestamp = new Date().toLocaleTimeString();

        const listItem = document.createElement('li');
        listItem.innerHTML = `
                <span class="apt-group">${group}</span>
                <span class="apt-activity">${activity} - ${timestamp}</span>
            `;
        aptList.prepend(listItem);

        if (aptList.children.length > 15) {
            aptList.removeChild(aptList.lastChild);
        }
    }

}
setInterval(addRandomAPTActivity, 2000); // Add new APT activity every 2 seconds

// 3. Vulnerability Watch: Latest CVEs
const cveList = document.getElementById('cveList');
const cvePrefixes = ["CVE-2024-", "CVE-2023-", "CVE-2025-"];
const cveDescriptions = [
    "Remote Code Execution vulnerability in Web Server.",
    "Cross-Site Scripting (XSS) in User Dashboard.",
    "Privilege Escalation in Operating System Kernel.",
    "SQL Injection in Database Management System.",
    "Denial of Service (DoS) in Network Protocol.",
    "Information Disclosure in API Endpoint.",
    "Buffer Overflow in Legacy Application."
];
function addRandomCVE() {
    if (cveList) {
        const year = cvePrefixes[Math.floor(Math.random() * cvePrefixes.length)];
        const cveId = year + Math.floor(1000 + Math.random() * 9000);
        const description = cveDescriptions[Math.floor(Math.random() * cveDescriptions.length)];
        const severity = Math.random() > 0.7 ? 'CRITICAL' : (Math.random() > 0.4 ? 'HIGH' : 'MEDIUM');
        let severityColor = '';
        switch (severity) {
            case 'CRITICAL': severityColor = 'text-red-500'; break;
            case 'HIGH': severityColor = 'text-orange-500'; break;
            case 'MEDIUM': severityColor = 'text-yellow-500'; break;
        }

        const listItem = document.createElement('li');
        listItem.innerHTML = `
                <span class="cve-id">${cveId}</span>
                <span class="cve-desc">${description}</span>
                <span class="${severityColor} font-bold">Severity: ${severity}</span>
            `;
        cveList.prepend(listItem);

        if (cveList.children.length > 15) {
            cveList.removeChild(cveList.lastChild);
        }
    }

}
setInterval(addRandomCVE, 2500); // Add new CVE every 2.5 seconds

// --- Live Cyber Attack List (Countries Attacked/Attacking) ---
const targetedCountriesList = document.getElementById('targeted-countries');
const attackingCountriesList = document.getElementById('attacking-countries');

const sampleTargets = ['USA', 'Germany', 'France', 'Tanzania', 'India', 'Brazil', 'Canada', 'Australia', 'UK', 'South Korea', 'Japan', 'Egypt', 'Nigeria', 'South Africa', 'Mexico', 'Argentina', 'Italy', 'Spain', 'Sweden', 'Norway'];
const sampleAttackers = ['Russia', 'China', 'Iran', 'North Korea', 'Turkey', 'Vietnam', 'Brazil', 'USA', 'Germany', 'France', 'Israel', 'Pakistan', 'India', 'Ukraine', 'Syria', 'Venezuela', 'Cuba', 'Sudan', 'Somalia', 'Yemen'];

function generateAttackActivity() {
    if (targetedCountriesList) {
        const target = sampleTargets[Math.floor(Math.random() * sampleTargets.length)];
        const attacker = sampleAttackers[Math.floor(Math.random() * sampleAttackers.length)];
        const time = new Date().toLocaleTimeString();

        // Add to Targeted Countries
        const targetItem = document.createElement('li');
        targetItem.textContent = `${target} - Under attack at ${time}`;
        targetedCountriesList.prepend(targetItem);
        if (targetedCountriesList.children.length > 10) targetedCountriesList.removeChild(targetedCountriesList.lastChild);

        // Add to Attacking Countries
        const attackerItem = document.createElement('li');
        attackerItem.textContent = `${attacker} - Launched attack at ${time}`;
        attackingCountriesList.prepend(attackerItem);
        if (attackingCountriesList.children.length > 10) attackingCountriesList.removeChild(attackingCountriesList.lastChild);
    }

}

setInterval(generateAttackActivity, 3000); // Update every 3 seconds

// --- Global Activity Map (Custom Canvas Visualization) ---
const globalActivityMapCanvas = document.getElementById('globalActivityMapCanvas');
const mapCtx = globalActivityMapCanvas?.getContext('2d');

let attackLines = []; // Array to hold active attack lines for the map

// Define simplified country/region centers for visualization
// These are illustrative coordinates on a 1000x500 canvas
const mapCountries = [
    { name: "USA", x: 180, y: 180 },
    { name: "Canada", x: 200, y: 100 },
    { name: "Brazil", x: 300, y: 380 },
    { name: "UK", x: 480, y: 150 },
    { name: "France", x: 520, y: 170 },
    { name: "Germany", x: 550, y: 140 },
    { name: "Nigeria", x: 550, y: 300 },
    { name: "South Africa", x: 580, y: 420 },
    { name: "Russia", x: 750, y: 100 },
    { name: "China", x: 850, y: 200 },
    { name: "India", x: 700, y: 280 },
    { name: "Australia", x: 900, y: 400 },
    { name: "Japan", x: 950, y: 180 },
    { name: "Egypt", x: 600, y: 250 },
    { name: "Argentina", x: 280, y: 450 },
    { name: "Mexico", x: 150, y: 250 },
    { name: "Italy", x: 540, y: 200 },
    { name: "Spain", x: 500, y: 220 },
    { name: "Sweden", x: 550, y: 80 },
    { name: "Norway", x: 530, y: 70 },
    { name: "Ukraine", x: 600, y: 160 },
    { name: "Syria", x: 620, y: 220 },
    { name: "Pakistan", x: 680, y: 250 },
    { name: "Venezuela", x: 250, y: 300 },
    { name: "Cuba", x: 120, y: 220 },
    { name: "Sudan", x: 600, y: 300 },
    { name: "Somalia", x: 680, y: 320 },
    { name: "Yemen", x: 650, y: 280 },
    { name: "Israel", x: 580, y: 230 },
    { name: "Tanzania", x: 620, y: 380 },
    { name: "South Korea", x: 900, y: 250 },
];


// Function to draw a very simplified world map outline
function drawWorldMap() {
    mapCtx.strokeStyle = 'rgba(0, 245, 212, 0.3)'; // Border color
    mapCtx.lineWidth = 0.8;
    mapCtx.fillStyle = 'rgba(18, 18, 18, 0.7)'; // Country fill color

    // North America
    mapCtx.beginPath();
    mapCtx.moveTo(100, 100); mapCtx.lineTo(250, 50); mapCtx.lineTo(300, 150);
    mapCtx.lineTo(250, 250); mapCtx.lineTo(150, 200); mapCtx.closePath();
    mapCtx.fill(); mapCtx.stroke();

    // South America
    mapCtx.beginPath();
    mapCtx.moveTo(250, 300); mapCtx.lineTo(350, 280); mapCtx.lineTo(320, 450);
    mapCtx.lineTo(200, 400); mapCtx.closePath();
    mapCtx.fill(); mapCtx.stroke();

    // Europe
    mapCtx.beginPath();
    mapCtx.moveTo(450, 80); mapCtx.lineTo(600, 50); mapCtx.lineTo(650, 150);
    mapCtx.lineTo(580, 200); mapCtx.lineTo(480, 180); mapCtx.closePath();
    mapCtx.fill(); mapCtx.stroke();

    // Africa
    mapCtx.beginPath();
    mapCtx.moveTo(500, 200); mapCtx.lineTo(650, 180); mapCtx.lineTo(700, 350);
    mapCtx.lineTo(550, 450); mapCtx.lineTo(450, 300); mapCtx.closePath();
    mapCtx.fill(); mapCtx.stroke();

    // Asia
    mapCtx.beginPath();
    mapCtx.moveTo(680, 80); mapCtx.lineTo(950, 50); mapCtx.lineTo(980, 250);
    mapCtx.lineTo(850, 300); mapCtx.lineTo(700, 250); mapCtx.closePath();
    mapCtx.fill(); mapCtx.stroke();

    // Australia
    mapCtx.beginPath();
    mapCtx.moveTo(850, 350); mapCtx.lineTo(950, 320); mapCtx.lineTo(960, 450);
    mapCtx.lineTo(880, 480); mapCtx.closePath();
    mapCtx.fill(); mapCtx.stroke();
}

// Function to resize canvas
function resizeMapCanvas() {
    if (globalActivityMapCanvas) {
        globalActivityMapCanvas.width = globalActivityMapCanvas.offsetWidth;
        globalActivityMapCanvas.height = globalActivityMapCanvas.offsetHeight;
        drawWorldMap(); // Redraw map on resize
    }

}

// Attack Line class for the map
class MapAttackLine {
    constructor(startX, startY, endX, endY, targetCountryName, startTime) {
        this.startX = startX;
        this.startY = startY;
        this.endX = endX;
        this.endY = endY;
        this.targetCountryName = targetCountryName;
        this.startTime = startTime;
        this.duration = 1500; // milliseconds
    }

    draw(currentTime) {
        const elapsed = currentTime - this.startTime;
        const progress = elapsed / this.duration;

        if (progress < 1) {
            // Draw the line
            mapCtx.beginPath();
            mapCtx.moveTo(this.startX, this.startY);
            mapCtx.lineTo(this.endX, this.endY);
            mapCtx.strokeStyle = `rgba(255, 0, 0, ${1 - progress})`; // Red, fading
            mapCtx.lineWidth = 2;
            mapCtx.stroke();

            // Draw pulsing circle at target
            const pulseRadius = 3 + (progress * 10); // Expands from 3 to 13
            mapCtx.beginPath();
            mapCtx.arc(this.endX, this.endY, pulseRadius, 0, Math.PI * 2);
            mapCtx.fillStyle = `rgba(255, 0, 0, ${0.7 - (progress * 0.7)})`; // Red, fading
            mapCtx.fill();
        }
    }
}

// Function to add a new attack to the map
function addMapAttack() {
    if (globalActivityMapCanvas) {
        if (mapCountries.length < 2) return;

        const sourceCountry = mapCountries[Math.floor(Math.random() * mapCountries.length)];
        const targetCountry = mapCountries[Math.floor(Math.random() * mapCountries.length)];

        if (sourceCountry === targetCountry) {
            addMapAttack(); // Try again if source and target are the same
            return;
        }

        attackLines.push(new MapAttackLine(sourceCountry.x, sourceCountry.y, targetCountry.x, targetCountry.y, targetCountry.name, performance.now()));

        // Display country name briefly
        const nameDisplayDuration = 1000; // ms
        const textElement = document.createElement('div');
        textElement.textContent = targetCountry.name;
        textElement.style.position = 'absolute';
        // Calculate position relative to the canvas parent
        const canvasRect = globalActivityMapCanvas.getBoundingClientRect();
        const parentRect = globalActivityMapCanvas.parentNode.getBoundingClientRect();

        textElement.style.left = `${(canvasRect.left - parentRect.left) + (targetCountry.x / globalActivityMapCanvas.width) * canvasRect.width}px`;
        textElement.style.top = `${(canvasRect.top - parentRect.top) + (targetCountry.y / globalActivityMapCanvas.height) * canvasRect.height - 20}px`; // 20px above point
        textElement.style.transform = 'translateX(-50%)';
        textElement.style.color = 'var(--accent)';
        textElement.style.fontSize = '12px';
        textElement.style.fontWeight = 'bold';
        textElement.style.pointerEvents = 'none'; // Ensure it doesn't block clicks
        textElement.style.opacity = '1';
        textElement.style.transition = 'opacity 0.5s ease-out';
        globalActivityMapCanvas.parentNode.appendChild(textElement);

        setTimeout(() => {
            textElement.style.opacity = '0';
        }, nameDisplayDuration);

        setTimeout(() => {
            textElement.remove();
        }, nameDisplayDuration + 500); // Remove after fade out
    }

}

// Animation loop for the map
function animateMap(currentTime) {
    if (globalActivityMapCanvas) {
        mapCtx.clearRect(0, 0, globalActivityMapCanvas.width, globalActivityMapCanvas.height); // Clear canvas
        drawWorldMap(); // Redraw static map

        // Update and draw attack lines, filter out expired ones
        attackLines = attackLines.filter(line => {
            line.draw(currentTime);
            return (currentTime - line.startTime) < line.duration;
        });

        requestAnimationFrame(animateMap);
    }

}

// Initialize and start map animation on window load
window.onload = function () {
    resizeMapCanvas(); // Set initial canvas size
    setInterval(addMapAttack, 2000); // Add new attacks periodically
    animateMap(performance.now()); // Start animation loop
};

// Resize canvas when window is resized
window.addEventListener('resize', () => {
    resizeMapCanvas();
});


// --- Trace Button Click (Placeholder for future functionality) ---
if (document.getElementById('traceButton')) {
    document.getElementById('traceButton').addEventListener('click', () => {
        const address = document.getElementById('addressInput').value;
        if (address) {
            console.log('Tracing address/hash:', address);
        } else {
            console.log('Please enter an address or transaction hash.');
        }
    });
}



// --- Modal Logic ---
const detailModal = document.getElementById('detailModal');
const modalTitle = document.getElementById('modalTitle');
const modalBody = document.getElementById('modalBody');
const closeModalBtn = document.getElementById('closeModalBtn');
const transactionCard = document.getElementById('transactionCard');
const aptCard = document.getElementById('aptCard');
const cveCard = document.getElementById('cveCard');

function showModal(title, content) {
    modalTitle.textContent = title;
    modalBody.innerHTML = content;
    detailModal.classList.add('show');
}

function hideModal() {
    detailModal.classList.remove('show');
}

// Close modal when close button is clicked
closeModalBtn.addEventListener('click', hideModal);

// Close modal when clicking outside the modal content (on the overlay)
detailModal.addEventListener('click', (e) => {
    if (e.target === detailModal) {
        hideModal();
    }
});

if (transactionCard) {
    // Click handler for Transaction Card
    transactionCard.addEventListener('click', () => {
        const title = "Detailed Live Transaction Stream";
        let content = `
                <p>This section provides a more in-depth look at recent blockchain transactions.</p>
                <ul class="list-disc list-inside space-y-2 mt-4">
            `;
        for (let i = 0; i < 10; i++) { // Generate 10 detailed transactions
            const txHash = '0x' + getRandomHexString(64);
            const fromAddr = '0x' + getRandomHexString(40);
            const toAddr = '0x' + getRandomHexString(40);
            const amount = (Math.random() * 5000 + 0.01).toFixed(6);
            const currency = Math.random() > 0.5 ? 'BTC' : 'ETH';
            const gasFee = (Math.random() * 0.001).toFixed(8);
            const blockNum = Math.floor(Math.random() * 10000000);
            const timestamp = new Date(Date.now() - Math.random() * 3600000).toLocaleString(); // Last hour

            content += `
                    <li>
                        <strong>Transaction Hash:</strong> <span class="text-accent break-all">${txHash}</span><br>
                        <strong>Amount:</strong> <span class="text-white">${amount} ${currency}</span><br>
                        <strong>From:</strong> <span class="text-gray-400 break-all">${fromAddr}</span><br>
                        <strong>To:</strong> <span class="text-gray-400 break-all">${toAddr}</span><br>
                        <strong>Block:</strong> ${blockNum}<br>
                        <strong>Gas Fee:</strong> ${gasFee} ${currency === 'BTC' ? 'BTC' : 'GWEI'}<br>
                        <strong>Timestamp:</strong> ${timestamp}
                    </li>
                `;
        }
        content += `</ul>`;
        showModal(title, content);
    });
}


if (aptCard) {
    // Click handler for APT Card
    aptCard.addEventListener('click', () => {
        const title = "Detailed Threat Intelligence: APT Activity";
        let content = `
                <p>Here you'll find comprehensive reports on Advanced Persistent Threat (APT) group activities detected globally.</p>
                <ul class="list-disc list-inside space-y-2 mt-4">
            `;
        const aptDetails = [
            { group: "Lazarus Group", activity: "Recent phishing campaign targeting financial institutions in APAC region. Observed use of custom malware 'AppleJeus'.", date: "2025-07-20" },
            { group: "APT28 (Fancy Bear)", activity: "Exploitation of zero-day vulnerability in popular VPN software. Data exfiltration suspected from government entities.", date: "2025-07-18" },
            { group: "Conti", activity: "New ransomware variant deployed against healthcare sector. Demanding large cryptocurrency payments.", date: "2025-07-22" },
            { group: "Equation Group", activity: "Discovery of sophisticated supply chain attack impacting critical infrastructure components. Highly evasive techniques observed.", date: "2025-07-15" },
            { group: "Sandworm Team", activity: "DDoS attacks targeting energy sector websites. Coordinated efforts to disrupt online services.", date: "2025-07-24" },
        ];

        aptDetails.forEach(detail => {
            content += `
                    <li>
                        <strong>APT Group:</strong> <span class="text-accent">${detail.group}</span><br>
                        <strong>Activity:</strong> ${detail.activity}<br>
                        <strong>Date:</strong> ${detail.date}
                    </li>
                `;
        });
        content += `</ul>`;
        showModal(title, content);
    });
}


if (cveCard) {
    // Click handler for CVE Card
    cveCard.addEventListener('click', () => {
        const title = "Detailed Vulnerability Watch: Latest CVEs";
        let content = `
                <p>This provides an expanded view of critical and high-severity Common Vulnerabilities and Exposures (CVEs).</p>
                <ul class="list-disc list-inside space-y-2 mt-4">
            `;
        const cveDetails = [
            { id: "CVE-2025-1234", desc: "Critical RCE in widely used web framework. Patch immediately.", severity: "CRITICAL", affected: "Web Servers, APIs" },
            { id: "CVE-2025-5678", desc: "High severity XSS vulnerability in client-side authentication module. User session hijacking possible.", severity: "HIGH", affected: "Web Applications" },
            { id: "CVE-2024-9101", desc: "Medium severity DoS in network load balancer. Can be exploited with crafted packets.", severity: "MEDIUM", affected: "Network Infrastructure" },
            { id: "CVE-2025-2233", desc: "Critical SQL Injection in e-commerce platform. Allows full database compromise.", severity: "CRITICAL", affected: "Databases, E-commerce" },
            { id: "CVE-2024-4567", desc: "High severity privilege escalation in Linux kernel. Affects multiple distributions.", severity: "HIGH", affected: "Linux Systems" },
        ];

        cveDetails.forEach(detail => {
            let severityColor = '';
            switch (detail.severity) {
                case 'CRITICAL': severityColor = 'text-red-500'; break;
                case 'HIGH': severityColor = 'text-orange-500'; break;
                case 'MEDIUM': severityColor = 'text-yellow-500'; break;
            }
            content += `
                    <li>
                        <strong>CVE ID:</strong> <span class="text-accent">${detail.id}</span><br>
                        <strong>Description:</strong> ${detail.desc}<br>
                        <strong>Severity:</strong> <span class="${severityColor} font-bold">${detail.severity}</span><br>
                        <strong>Affected Systems:</strong> ${detail.affected}
                    </li>
                `;
        });
        content += `</ul>`;
        showModal(title, content);
    });
}


function SendWhatsappMessage() {
    let name = document.getElementById('contact_name').value;
    let email = document.getElementById('contact_email').value;
    let message = document.getElementById('contact_message').value;

    if (name == '' || email == '' || message == '') {
        return;
    }

    let fullMessage = `Name: ${name}%0AEmail: ${email}%0AMessage: ${message}`;
    let whatsappUrl = `https://wa.me/962790123456?text=${fullMessage}`;

    window.open(whatsappUrl, "_blank");
}

//const okBtn = document.getElementById('okBtn'); // Your Ok button
//const modalLoader = document.getElementById('modalLoader');

//okBtn.addEventListener('click', function() {
//    modalLoader.style.display = 'flex'; // Show loader

//    // Call your API (example with fetch)
//    fetch('/your/api/endpoint', { method: 'POST', body: ... })
//        .then(response => response.json())
//        .then(data => {
//            // handle response
//        })
//        .finally(() => {
//            modalLoader.style.display = 'none'; // Hide loader
//        });
//});
