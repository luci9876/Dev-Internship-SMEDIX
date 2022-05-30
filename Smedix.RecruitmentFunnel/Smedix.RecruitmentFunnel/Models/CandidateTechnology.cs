namespace Smedix.RecruitmentFunnel.Models
{
    public class CandidateTechnology
    {
        public int Id { get; set; }
        public Technology Technology { get; set; }
        public Candidate Candidate { get; set; }
    }
}
