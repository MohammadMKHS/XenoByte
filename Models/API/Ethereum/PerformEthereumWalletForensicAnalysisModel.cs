namespace XenoByte.Models.API.Ethereum
{
    public class PerformEthereumWalletForensicAnalysisModel
    {
        public string status { get; set; }
        public string wallet_address { get; set; }
        public int max_depth { get; set; }
        public WalletInfo wallet_info { get; set; }
        public List<TransactionNode> transaction_graph { get; set; }
        public ForensicSummary forensic_summary { get; set; }
        public List<RiskIndicator> risk_indicators { get; set; }
        public string disclaimer { get; set; }
    }

    public class WalletInfo
    {
        public string address { get; set; }
        public string balance_eth { get; set; }
        public string balance_usd { get; set; }
        public int transaction_count { get; set; }
        public string first_seen { get; set; }
        public string last_seen { get; set; }
    }

    public class TransactionNode
    {
        public string transaction_hash { get; set; }
        public string from_address { get; set; }
        public string to_address { get; set; }
        public string value_eth { get; set; }
        public string value_usd { get; set; }
        public string timestamp { get; set; }
        public int depth_level { get; set; }
        public string direction { get; set; }
        public string gas_fee { get; set; }
        public string block_number { get; set; }
    }

    public class ForensicSummary
    {
        public int total_transactions { get; set; }
        public string total_value_eth { get; set; }
        public string total_value_usd { get; set; }
        public int unique_addresses { get; set; }
        public List<string> connected_exchanges { get; set; }
        public List<string> connected_mixers { get; set; }
        public string risk_score { get; set; }
    }

    public class RiskIndicator
    {
        public string indicator_type { get; set; }
        public string description { get; set; }
        public string severity { get; set; }
        public string confidence { get; set; }
        public List<string> evidence { get; set; }
    }
}