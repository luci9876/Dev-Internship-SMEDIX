using Smedix.RecruitmentFunnel.Models;

namespace Smedix.RecruitmentFunnel.DTOs
{
    public class CandidateDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public CandidateStatus? LastStatus { get; set; }
        public Role? Role { get; set; }
        public Technology? Technology { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
