namespace Smedix.RecruitmentFunnel.Models
{
    public class CandidateFile
    {
        public int Id { get; set; }
        public Candidate Candidate { get; set; }
        public string FileName { get; set; }
        public byte[] Content { get; set; }
        public string ContentType { get; set; }
    }
}
