namespace XenoByte.Models.API
{
    public class ReportData
    {
        public string address { get; set; }
        public string balance { get; set; }
        public string total_sent { get; set; }
        public string total_received { get; set; }
        public int transaction_count { get; set; }
        public string last_seen { get; set; }
    }

    public class TraceCryptocurrencyAddressorTransactionModel
    {
        public string requested_input { get; set; }
        public string input_category { get; set; }
        public string crypto_type { get; set; }
        public ReportData report_data { get; set; }
        public string status { get; set; }
        public string disclaimer { get; set; }
    }
}
