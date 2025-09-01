namespace XenoByte.Models.API.Ethereum
{
    public class ChainabuseReports
    {
        public int total_reports_count { get; set; }
        public List<ChainabuseReportsItems> reports { get; set; }
    }

    public class ReceiverWallet
    {
        public string address { get; set; }
        public long amount_received_wei { get; set; }
        public double amount_received_eth { get; set; }
        public string inferred_type { get; set; }
        public List<string> reputation_flags { get; set; }
        public ChainabuseReports chainabuse_reports { get; set; }
    }

    public class PerformEthereumTransactionHashAnalysisModel
    {
        public string requested_input { get; set; }
        public string input_category { get; set; }
        public string crypto_type { get; set; }
        public TransactionSummary transaction_summary { get; set; }
        public List<SenderWallet> sender_wallets { get; set; }
        public List<ReceiverWallet> receiver_wallets { get; set; }
        public string disclaimer { get; set; }
    }

    public class SenderWallet
    {
        public string address { get; set; }
        public long amount_sent_wei { get; set; }
        public double amount_sent_eth { get; set; }
        public string inferred_type { get; set; }
        public List<object> reputation_flags { get; set; }
        public ChainabuseReports chainabuse_reports { get; set; }
    }

    public class TransactionSummary
    {
        public string hash { get; set; }
        public string time_utc { get; set; }
        public string block_height { get; set; }
        public long transaction_fee_wei { get; set; }
        public double transaction_fee_eth { get; set; }
        public string size_bytes { get; set; }
        public long total_input_value_wei { get; set; }
        public double total_input_value_eth { get; set; }
        public long total_output_value_wei { get; set; }
        public double total_output_value_eth { get; set; }
    }

    public class ChainabuseReportsItems
    {
        public string category { get; set; }
        public string description { get; set; }
        public string submitted_by { get; set; }
        public string submitted_date { get; set; }
        public List<string> reported_addresses { get; set; }
    }
}
