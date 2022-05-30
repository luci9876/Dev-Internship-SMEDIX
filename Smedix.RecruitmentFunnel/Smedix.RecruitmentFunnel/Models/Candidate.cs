namespace Smedix.RecruitmentFunnel.Models
{
	public class Candidate
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Email { get; set; }
		public string? Phone { get; set; }
		public string? Address { get; set; }
		public string? Company { get; set; }
		public string? YearsOfExperience { get; set; }
		public string? LinkedIn { get; set; }
		public string? Notes { get; set; }
		public string? ReferredBy { get; set; }
		public string? Source { get; set; }
		public DateTime? LastUpdated { get; set; }
		public Role? Role { get; set; }
		public Department? Department { get; set; }
		public CandidateStatus? CandidateStatus { get; set; }
		public ICollection<CandidateFile>? CandidateFiles { get; set; }
		public ICollection<CandidateTechnology>? CandidateTechnologies { get; set; }
        public ICollection<CandidateHistory>? CandidateHistories { get; set; }
    }
}
