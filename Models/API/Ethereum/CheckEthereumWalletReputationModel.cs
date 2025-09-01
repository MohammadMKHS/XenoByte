namespace XenoByte.Models.API.Ethereum
{
    public class CheckEthereumWalletReputationModel
    {
        public string status { get; set; }
        public string wallet_address { get; set; }
        public string reputation_score { get; set; }
        public string risk_level { get; set; }
        public WalletBasicInfo wallet_basic_info { get; set; }
        public List<ReputationFlag> reputation_flags { get; set; }
        public List<KnownAssociation> known_associations { get; set; }
        public TransactionProfile transaction_profile { get; set; }
        public List<SecurityAlert> security_alerts { get; set; }
        public string disclaimer { get; set; }
    }

    public class WalletBasicInfo
    {
        public string address { get; set; }
        public string balance_eth { get; set; }
        public string balance_usd { get; set; }
        public int transaction_count { get; set; }
        public string creation_date { get; set; }
        public string last_activity { get; set; }
    }

    public class ReputationFlag
    {
        public string flag_type { get; set; }
        public string description { get; set; }
        public string severity { get; set; }
        public string source { get; set; }
        public string date_flagged { get; set; }
    }

    public class KnownAssociation
    {
        public string entity_name { get; set; }
        public string entity_type { get; set; }
        public string association_type { get; set; }
        public string confidence_level { get; set; }
        public string last_interaction { get; set; }
    }

    public class TransactionProfile
    {
        public string average_transaction_value { get; set; }
        public string total_volume_eth { get; set; }
        public string total_volume_usd { get; set; }
        public int incoming_transactions { get; set; }
        public int outgoing_transactions { get; set; }
        public List<string> frequent_counterparties { get; set; }
    }

    public class SecurityAlert
    {
        public string alert_type { get; set; }
        public string message { get; set; }
        public string severity { get; set; }
        public string timestamp { get; set; }
        public List<string> related_addresses { get; set; }
    }
}