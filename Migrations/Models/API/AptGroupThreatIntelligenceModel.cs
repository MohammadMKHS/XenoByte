namespace XenoByte.Models.API
{
    public class AssociatedCampaign
    {
        public string name { get; set; }
        public string description { get; set; }
        public string url { get; set; }
    }

    public class AssociatedSoftware
    {
        public string name { get; set; }
        public string id { get; set; }
        public string description { get; set; }
        public string url { get; set; }
    }

    public class Citation
    {
        public string url { get; set; }
        public string description { get; set; }
    }

    public class IndicatorsOfCompromise
    {
        public List<string> cves { get; set; }
        public List<string> ips { get; set; }
        public List<string> domains { get; set; }
        public List<string> hashes { get; set; }
        public List<string> others { get; set; }
    }

    public class MitreAttackInfo
    {
        public string name { get; set; }
        public string description { get; set; }
        public string aliases { get; set; }
        public string external_id { get; set; }
        public string source_url { get; set; }
        public string country { get; set; }
        public bool revoked { get; set; }
        public DateTime created { get; set; }
        public DateTime modified { get; set; }
        public List<Citation> citations { get; set; }
        public List<AssociatedSoftware> associated_software { get; set; }
        public List<TechniquesUsed> techniques_used { get; set; }
        public List<AssociatedCampaign> associated_campaigns { get; set; }
    }

    public class AptGroupThreatIntelligenceModel
    {
        public string requested_group { get; set; }
        public MitreAttackInfo mitre_attack_info { get; set; }
        public IndicatorsOfCompromise indicators_of_compromise { get; set; }
        public List<string> ransomware_wallet_addresses { get; set; }
        public string otx_query_status { get; set; }
        public string disclaimer { get; set; }
    }

    public class TechniquesUsed
    {
        public string name { get; set; }
        public string id { get; set; }
        public string description { get; set; }
        public string url { get; set; }
    }

}
