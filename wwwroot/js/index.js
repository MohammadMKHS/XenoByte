function callXenoByteAPIs(sender) {
    let currentValue = sender.value;

    if (currentValue == 1) {
        showXenoByteAPICallModalWithCallbackFunction(
            "GetAPTGroupThreatIntelligenceModal",
            "Alert",
            "(Required) The name of the APT group (e.g., APT28, Fancy Bear, Lazarus Group).",
            "Ok",
            "Cancle",
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
            "Cancle",
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
            "PerformBitcoinTransactionHashAnalysisModal",
            "Alert",
            "(Required) The Bitcoin transaction hash for analysis.",
            "Ok",
            "Cancle",
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
    } else if (currentValue == 4) {
        showXenoByteAPICallModalWithCallbackFunction(
            "PerformBitcoinWalletForensicAnalysisModal",
            "Alert",
            "(Required) The Bitcoin wallet address for forensic analysis.<br> Maximum tracing depth (e.g., 1, 2, 3, or -1 for full depth). Default is 2.",
            "Ok",
            "Cancle",
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
    }
}