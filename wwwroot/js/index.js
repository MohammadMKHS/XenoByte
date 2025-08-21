function callXenoByteAPIs(sender) {
    let currentValue = sender.value;

    console.log(currentValue);

    if (currentValue == 1) {
        showXenoByteAPICallModalWithCallbackFunction(
            "GetAPTGroupThreatIntelligenceModal",
            "Alert",
            "(Required) The name of the APT group (e.g., APT28, Fancy Bear, Lazarus Group).",
            "Ok",
            "Cancle",
            function () {
                let apiCallValue = document.getElementById('apiCallVelue').value;

                window.location.href = `../Home/AptGroupThreatIntelligence?value=${apiCallValue}`;
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
                let apiCallValue = document.getElementById('apiCallVelue').value;

                window.location.href = `../Home/TraceCryptocurrencyAddressorTransaction?value=${apiCallValue}`;
            },
            function () {
                console.log("User cancelled.");
            }
        );
    }
}