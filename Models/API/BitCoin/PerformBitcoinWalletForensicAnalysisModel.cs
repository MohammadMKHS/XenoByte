namespace XenoByte.Models.API.BitCoin
{
    public class PerformBitcoinWalletForensicAnalysisModel
    {
        public string target_address { get; set; }
        public int max_tracing_depth { get; set; }
        public Dictionary<string, AnalyzedWallet> analyzed_wallets { get; set; }
        public List<TransactionGraphEdge> transaction_graph_edges { get; set; }
        public string transaction_graph_svg_base64 { get; set; }
    }

    public class AnalyzedWallet
    {
        public string address { get; set; }
        public int? depth { get; set; }
        public bool? is_ransomware_local { get; set; }
        public bool? is_ransomware_api { get; set; }
        public List<string> ransomware_family_api { get; set; }
        public string blockchain_type { get; set; }
        public double? balance_btc { get; set; }
        public int? total_transactions { get; set; }
        public string last_transaction_time_utc { get; set; }
        public string wallet_type_inferred { get; set; }
        public List<string> red_flags { get; set; }
        public ChainabuseReports1 chainabuse_reports { get; set; }
        public double? incoming_tx_value_sum_traced { get; set; }
        public double? outgoing_tx_value_sum_traced { get; set; }
        public List<string> tx_hashes_involved { get; set; }
        public double? directly_sent_to_target { get; set; }
        public double? directly_received_from_target { get; set; }
        public bool? automated_transactions_detected { get; set; }
        public bool? extremely_rapid_transactions_detected { get; set; }
        public bool? rapid_transactions_detected { get; set; }
        public bool? frequent_transactions_detected { get; set; }
        public string automated_transactions_time_diff { get; set; }
        public bool? dormant_for_over_a_year { get; set; }
        public bool? high_transaction_count { get; set; }
        public bool? large_amount_received { get; set; }
        public bool? dust_attack_pattern { get; set; }
        public bool? high_transaction_fee_detected { get; set; }
    }

    public class ChainabuseReports1
    {
        public string address { get; set; }
        public string url_scraped { get; set; }
        public int total_reports_count { get; set; }
        public List<ChainabuseReportsItems> reports { get; set; }
    }

    public class ChainabuseReportsItems
    {
        public string category { get; set; }
        public string description { get; set; }
        public string submitted_date { get; set; }
        public string submitted_by { get; set; }
        public List<string> reported_addresses { get; set; }
    }

    public class TransactionGraphEdge
    {
        public string sender { get; set; }
        public string receiver { get; set; }
        public double amount_btc { get; set; }
    }
}
