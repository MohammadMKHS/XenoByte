namespace XenoByte.Models.API
{
    public class FileHashes
    {
        public string md5 { get; set; }
        public string sha1 { get; set; }
        public string sha256 { get; set; }
        public int file_size_bytes { get; set; }
    }

    public class ReputationAnalysis
    {
        public string status { get; set; }
        public string hash { get; set; }
        public string hash_type { get; set; }
        public string verdict { get; set; }
        public string message { get; set; }
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

    public class UploadFileScanModel
    {
        public string uploaded_file_name { get; set; }
        public FileHashes file_hashes { get; set; }
        public ReputationAnalysis reputation_analysis { get; set; }
        public string disclaimer { get; set; }

        // Computed properties for easier access in the view
        public string filename => uploaded_file_name;
        public string file_hash => file_hashes?.sha256;
        public string hash_type => reputation_analysis?.hash_type;
        public string verdict => reputation_analysis?.verdict;
        public string status => reputation_analysis?.status;
        public int pulse_count => 0; // Not provided in this API response
        public List<PulseDetail> pulse_details => new List<PulseDetail>(); // Not provided in this API response
        public string md5 => file_hashes?.md5;
        public string sha1 => file_hashes?.sha1;
        public string sha256 => file_hashes?.sha256;
        public string file_size => file_hashes?.file_size_bytes.ToString() + " bytes";
        public string file_type => reputation_analysis?.file_type;
        public string malware_family => reputation_analysis?.malware_family;
        public string first_submission_date => reputation_analysis?.first_submission_date;
        public string last_analysis_date => reputation_analysis?.last_analysis_date;
        public RelatedIocs related_iocs => reputation_analysis?.related_iocs;
        public string upload_timestamp => null;
        public string scan_duration => null;
    }
}