namespace XenoByte.Models.API.BitCoin
{

    public class ChainabuseReports2
    {
        public string address { get; set; }
        public string url_scraped { get; set; }
        public int total_reports_count { get; set; }
        public List<object> reports { get; set; }
    }

    public class CheckBitcoinWalletReputationModel
    {
        public string blockchain_type { get; set; }
        public double balance_btc { get; set; }
        public int total_transactions { get; set; }
        public string last_transaction_time_utc { get; set; }
        public string wallet_type_inferred { get; set; }
        public bool is_ransomware_local { get; set; }
        public bool is_ransomware_api { get; set; }
        public List<string> ransomware_family_api { get; set; }
        public bool automated_transactions_detected { get; set; }
        public bool extremely_rapid_transactions_detected { get; set; }
        public bool rapid_transactions_detected { get; set; }
        public bool frequent_transactions_detected { get; set; }
        public string automated_transactions_time_diff { get; set; }
        public bool dormant_for_over_a_year { get; set; }
        public bool high_transaction_count { get; set; }
        public bool large_amount_received { get; set; }
        public bool dust_attack_pattern { get; set; }
        public bool high_transaction_fee_detected { get; set; }
        public List<string> red_flags { get; set; }
        public ChainabuseReports2 chainabuse_reports { get; set; }
    }
}
