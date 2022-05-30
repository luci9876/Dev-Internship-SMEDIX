using Smedix.RecruitmentFunnel.Models;

namespace Smedix.RecruitmentFunnel.Repository
{
	public interface ICandidateHistoryRepository : IGenericRepository<CandidateHistory>
	{
		Task<List<CandidateHistory>> GetHistoriesByCandidateId(int candidateId);
	}
}
