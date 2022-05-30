using Microsoft.EntityFrameworkCore;
using Smedix.RecruitmentFunnel.Context;
using Smedix.RecruitmentFunnel.Models;

namespace Smedix.RecruitmentFunnel.Repository
{
	public class CandidateHistoryRepository : GenericRepository<CandidateHistory>, ICandidateHistoryRepository
	{
		public CandidateHistoryRepository(RecruitmentContext context) : base(context)
		{
		}

		public async Task<List<CandidateHistory>> GetHistoriesByCandidateId(int candidateId)
		{
			var steps = await _context.CandidateHistories.Include(c => c.Candidate).Where(c => c.Candidate!.Id == candidateId).Include(s => s.StageStatus).Include(s => s.StageStatus!.Stage)
				.Include(s => s.StageStatus!.Status)
				.ToListAsync();

			return steps;
		}
	}
}