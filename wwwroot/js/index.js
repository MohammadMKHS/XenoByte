function callXenoByteAPIs(sender) {
    let currentValue = sender.value;

    if (currentValue == 1) {
        showXenoByteAPICallModalWithCallbackFunction(
            "GetAPTGroupThreatIntelligenceModal",
            "Alert",
            "(Required) The name of the APT group (e.g., APT28, Fancy Bear, Lazarus Group).",
            "Ok",
            "Cancel",
            function () {
                // Show loader
                document.getElementById('modalLoader').style.display = 'flex';

                let apiCallValue = document.getElementById('apiCallVelue').value;
                // Simulate API call or do your fetch here
                // Example: fetch(...).then(...).finally(...)
                window.location.href = `../Home/AptGroupThreatIntelligence?value=${apiCallValue}`;
                // Hide loader if you use fetch, do it in .finally()
                // document.getElementById('modalLoader').style.display = 'none';
            },
            function () {
                console.log("User cancelled.");
            }
        );
    } else if (currentValue == 2) {
        showXenoByteAPICallModalWithCallbackFunction(
            "TraceCryptocurrencyAddressorTransactionModal",
            "Alert",
            "(Required) The cryptocurrency address or transaction hash to trace.",
            "Ok",
            "Cancel",
            function () {
                // Show loader
                document.getElementById('modalLoader').style.display = 'flex';

                let apiCallValue = document.getElementById('apiCallVelue').value;
                window.location.href = `../Home/TraceCryptocurrencyAddressorTransaction?value=${apiCallValue}`;
                // Hide loader if you use fetch, do it in .finally()
                // document.getElementById('modalLoader').style.display = 'none';
            },
            function () {
                console.log("User cancelled.");
            }
        );
    } else if (currentValue == 3) {
        showXenoByteAPICallModalWithCallbackFunction(
            "CheckFileHashReputationModal",
            "Alert",
            "(Required) The file hash (MD5, SHA1, or SHA256) to check.",
            "Ok",
            "Cancel",
            function () {
                // Show loader
                document.getElementById('modalLoader').style.display = 'flex';

                let apiCallValue = document.getElementById('apiCallVelue').value;
                window.location.href = `../Home/CheckFileHashReputation?value=${apiCallValue}`;
                // Hide loader if you use fetch, do it in .finally()
                // document.getElementById('modalLoader').style.display = 'none';
            },
            function () {
                console.log("User cancelled.");
            }
        );
    } else if (currentValue == 4) {
        showXenoByteAPICallModalWithCallbackFunction(
            "PerformBitcoinTransactionHashAnalysisModal",
            "Alert",
            "(Required) The Bitcoin transaction hash for analysis.",
            "Ok",
            "Cancel",
            function () {
                // Show loader
                document.getElementById('modalLoader').style.display = 'flex';

                let apiCallValue = document.getElementById('apiCallVelue').value;
                window.location.href = `../Home/PerformBitcoinTransactionHashAnalysis?value=${apiCallValue}`;
            },
            function () {
                console.log("User cancelled.");
            }
        );
    } else if (currentValue == 5) {
        showXenoByteAPICallModalWithCallbackFunction(
            "PerformBitcoinWalletForensicAnalysisModal",
            "Alert",
            "(Required) The Bitcoin wallet address for forensic analysis.<br> Maximum tracing depth (e.g., 1, 2, 3, or -1 for full depth). Default is 2.",
            "Ok",
            "Cancel",
            function () {
                // Show loader
                document.getElementById('modalLoader').style.display = 'flex';

                let apiCallValue = document.getElementById('apiCallVelue').value;
                window.location.href = `../Home/PerformBitcoinWalletForensicAnalysis?value=${apiCallValue}`;
            },
            function () {
                console.log("User cancelled.");
            }
        );
    } else if (currentValue == 6) {
        showXenoByteAPICallModalWithCallbackFunction(
            "CheckBitcoinWalletReputationModal",
            "Alert",
            "(Required) The Bitcoin wallet address to check for reputation.",
            "Ok",
            "Cancel",
            function () {
                // Show loader
                document.getElementById('modalLoader').style.display = 'flex';

                let apiCallValue = document.getElementById('apiCallVelue').value;
                window.location.href = `../Home/CheckBitcoinWalletReputation?value=${apiCallValue}`;
            },
            function () {
                console.log("User cancelled.");
            }
        );
    } else if (currentValue == 7) {
        showXenoByteAPICallModalWithCallbackFunction(
            "PerformEthereumTransactionHashAnalysisModal",
            "Alert",
            "(Required) The Ethereum transaction hash for analysis (e.g., '0x123...abc').",
            "Ok",
            "Cancel",
            function () {
                // Show loader
                document.getElementById('modalLoader').style.display = 'flex';

                let apiCallValue = document.getElementById('apiCallVelue').value;
                window.location.href = `../Home/PerformEthereumTransactionHashAnalysis?value=${apiCallValue}`;
            },
            function () {
                console.log("User cancelled.");
            }
        );
    } else if (currentValue == 8) {
        //Upload and Scan File for Reputation
        showXenoByteFileUploadModal(
            "UploadFileScanModal",
            "Upload and Scan File for Reputation",
            "(Required) Select a file to upload and scan for reputation analysis. Maximum file size: 10MB.",
            "Upload & Scan",
            "Cancel",
            function () {
                // Show loader
                document.getElementById('modalLoader').style.display = 'flex';

                const fileInput = document.getElementById('fileUploadInput');
                const file = fileInput.files[0];
                
                if (!file) {
                    alert('Please select a file to upload.');
                    document.getElementById('modalLoader').style.display = 'none';
                    return;
                }

                // Validate file size (10MB limit)
                const maxSize = 10 * 1024 * 1024; // 10MB
                if (file.size > maxSize) {
                    alert('File size exceeds 10MB limit. Please select a smaller file.');
                    document.getElementById('modalLoader').style.display = 'none';
                    return;
                }

                // Create form data for file upload
                const formData = new FormData();
                formData.append('file', file);

                // Use fetch to upload the file
                fetch('../Home/UploadAndScanFileForReputation', {
                    method: 'POST',
                    body: formData
                })
                .then(response => {
                    if (response.ok) {
                        // Get the response as text (HTML) and write it to the current document
                        return response.text();
                    } else {
                        throw new Error('Upload failed with status: ' + response.status);
                    }
                })
                .then(html => {
                    // Replace the current page content with the response
                    document.open();
                    document.write(html);
                    document.close();
                })
                .catch(error => {
                    console.error('Error:', error);
                    alert('Failed to upload and scan file. Please try again.');
                    document.getElementById('modalLoader').style.display = 'none';
                });

                // Note: We don't hide the loader here because the page will be replaced
            },
            function () {
                console.log("User cancelled file upload.");
            }
        );
    } else if (currentValue == 9) {
        //Perform Ethereum Wallet Forensic Analysis
        showXenoByteAPICallModalWithCallbackFunction(
            "PerformEthereumWalletForensicAnalysisModal",
            "Perform Ethereum Wallet Forensic Analysis",
            "(Required) The Ethereum wallet address for forensic analysis (e.g., '0x123...abc').<br> Maximum tracing depth (e.g., 1, 2, 3, or -1 for full depth). Default is 2.",
            "Ok",
            "Cancel",
            function () {
                // Show loader
                document.getElementById('modalLoader').style.display = 'flex';

                let apiCallValue = document.getElementById('apiCallVelue').value;
                window.location.href = `../Home/PerformEthereumWalletForensicAnalysis?value=${apiCallValue}`;
            },
            function () {
                console.log("User cancelled.");
            }
        );
    } else if (currentValue == 10) {
        //Check Ethereum Wallet Reputation
        showXenoByteAPICallModalWithCallbackFunction(
            "CheckEthereumWalletReputationModal",
            "Check Ethereum Wallet Reputation",
            "(Required) The Ethereum wallet address to check for reputation (e.g., '0x123...abc').",
            "Ok",
            "Cancel",
            function () {
                // Show loader
                document.getElementById('modalLoader').style.display = 'flex';

                let apiCallValue = document.getElementById('apiCallVelue').value;
                window.location.href = `../Home/CheckEthereumWalletReputation?value=${apiCallValue}`;
            },
            function () {
                console.log("User cancelled.");
            }
        );
    }
}