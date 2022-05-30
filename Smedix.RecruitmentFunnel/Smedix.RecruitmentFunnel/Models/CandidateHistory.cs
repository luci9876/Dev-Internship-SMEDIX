namespace Smedix.RecruitmentFunnel.Models
{
    public class CandidateHistory
    {
        public int Id { get; set; }
        public DateTime EntryDateTime { get; set; }
        public DateTime? PlannedDate { get; set; }
        public string? Notes { get; set; }
        public string? Manager { get; set; }
        public string? Issuer { get; set; }
        public Candidate? Candidate { get; set; }
        public int CandidateId { get; set; }
        public StageStatus? StageStatus { get; set; }
    }
}
