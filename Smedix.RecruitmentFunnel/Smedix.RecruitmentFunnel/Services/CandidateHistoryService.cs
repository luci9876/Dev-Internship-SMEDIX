using Smedix.RecruitmentFunnel.Models;
using Smedix.RecruitmentFunnel.Repository;

namespace Smedix.RecruitmentFunnel.Services
{
	public class CandidateHistoryService : ICandidateHistoryService
	{
		private readonly ICandidateHistoryRepository _repo;

		public CandidateHistoryService(ICandidateHistoryRepository repo)
		{
			_repo = repo;
		}

		public async Task CreateAsync(CandidateHistory history)
		{
			await _repo.Create(history);
		}

		public async Task UpdateAsync(CandidateHistory history)
		{
			await _repo.Update(history);
		}

		public async Task<List<CandidateHistory>> GetCandidateHistoryStepsAsync(int candidateId)
		{
			var steps = await _repo.GetHistoriesByCandidateId(candidateId);
			//have to set candidate to null to avoid infinite cycle in json
			steps.ForEach(s => s.Candidate = null);

			return steps;
		}
	}
}
