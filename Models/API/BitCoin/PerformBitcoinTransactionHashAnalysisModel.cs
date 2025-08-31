namespace XenoByte.Models.API.BitCoin
{
    public class ChainabuseReports
    {
        public int total_reports_count { get; set; }
        public List<object> reports { get; set; }
    }

    public class ReceiverWallet
    {
        public string address { get; set; }
        public int amount_received_satoshi { get; set; }
        public double amount_received_btc { get; set; }
        public string inferred_type { get; set; }
        public List<string> reputation_flags { get; set; }
        public ChainabuseReports chainabuse_reports { get; set; }
    }

    public class Report
    {
        public string category { get; set; }
        public string description { get; set; }
        public string submitted_by { get; set; }
        public string submitted_date { get; set; }
        public List<string> reported_addresses { get; set; }
    }

    public class PerformBitcoinTransactionHashAnalysisModel
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
        public int amount_sent_satoshi { get; set; }
        public double amount_sent_btc { get; set; }
        public string inferred_type { get; set; }
        public List<object> reputation_flags { get; set; }
        public ChainabuseReports chainabuse_reports { get; set; }
    }

    public class TransactionSummary
    {
        public string hash { get; set; }
        public string time_utc { get; set; }
        public int block_height { get; set; }
        public int transaction_fee_satoshi { get; set; }
        public double transaction_fee_btc { get; set; }
        public int size_bytes { get; set; }
        public int total_input_value_satoshi { get; set; }
        public double total_input_value_btc { get; set; }
        public int total_output_value_satoshi { get; set; }
        public double total_output_value_btc { get; set; }
    }
}
