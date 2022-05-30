using Smedix.RecruitmentFunnel.Models;

namespace Smedix.RecruitmentFunnel.Services
{
	public interface ICandidateHistoryService
	{
		Task CreateAsync(CandidateHistory history);
		Task UpdateAsync(CandidateHistory history);
		Task<List<CandidateHistory>> GetCandidateHistoryStepsAsync(int candidateId);
	}
}
