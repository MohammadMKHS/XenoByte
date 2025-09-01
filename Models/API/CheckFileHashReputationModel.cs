namespace XenoByte.Models.API
{
    public class PulseDetail
    {
        public string name { get; set; }
        public string id { get; set; }
        public string tlp { get; set; }
        public string description { get; set; }
        public List<string> tags { get; set; }
    }

    public class RelatedIocs
    {
        public List<string> ips { get; set; }
        public List<object> domains { get; set; }
        public List<string> hashes { get; set; }
        public List<string> urls { get; set; }
        public List<object> emails { get; set; }
        public List<object> cves { get; set; }
        public List<string> others { get; set; }
    }

    public class CheckFileHashReputationModel
    {
        public string status { get; set; }
        public string hash { get; set; }
        public string hash_type { get; set; }
        public string verdict { get; set; }
        public int pulse_count { get; set; }
        public List<PulseDetail> pulse_details { get; set; }
        public string md5 { get; set; }
        public string sha1 { get; set; }
        public string sha256 { get; set; }
        public string file_size { get; set; }
        public string file_type { get; set; }
        public string malware_family { get; set; }
        public string first_submission_date { get; set; }
        public string last_analysis_date { get; set; }
        public RelatedIocs related_iocs { get; set; }
    }


}
