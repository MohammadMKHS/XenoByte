namespace XenoByte.Models.API.Ethereum
{
    public class CheckEthereumWalletReputationModel
    {
        public string requested_address { get; set; }
        public OverallReputation overall_reputation { get; set; }
        public BasicInfo basic_info { get; set; }
        public ThreatIntelligence threat_intelligence { get; set; }
        public List<string> behavioral_patterns { get; set; }
        public WalletChainabuseReports chainabuse_reports { get; set; }
        public string disclaimer { get; set; }

        // Computed properties for backward compatibility with the view
        public string wallet_address => requested_address;
        public string status => overall_reputation?.@class;
        public string reputation_score => overall_reputation?.text;
        public string risk_level => overall_reputation?.@class;
    }

    public class OverallReputation
    {
        public string @class { get; set; }
        public string text { get; set; }
    }

    public class BasicInfo
    {
        public decimal current_balance_eth { get; set; }
        public int total_transactions { get; set; }
        public string last_transaction_time_utc { get; set; }
        public string blockchain_type { get; set; }
        public string inferred_wallet_type { get; set; }
    }

    public class ThreatIntelligence
    {
        public bool is_known_ransomware_address_local_db { get; set; }
        public bool is_known_ransomware_address_api { get; set; }
        public string ransomware_families_identified { get; set; }
    }

    public class WalletChainabuseReports
    {
        public string address { get; set; }
        public string url_scraped { get; set; }
        public int total_reports_count { get; set; }
        public List<WalletChainabuseReport> reports { get; set; }
    }

    public class WalletChainabuseReport
    {
        public string category { get; set; }
        public string description { get; set; }
        public string submitted_date { get; set; }
        public string submitted_by { get; set; }
        public List<string> reported_addresses { get; set; }
    }

    // Legacy classes for backward compatibility (can be removed later)
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