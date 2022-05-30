using Smedix.RecruitmentFunnel.DTOs;
using Smedix.RecruitmentFunnel.Helpers;
using Smedix.RecruitmentFunnel.Models;

namespace Smedix.RecruitmentFunnel.Services
{
	public interface ICandidateService
	{
		Task<PagedList<CandidateDto>> GetAllCandidates(CandidateParams candidateParams);
        Task<Candidate> GetCandidateById(int id);
		Task CreateAsync(Candidate candidate);
		void Save();
		Task DeleteByIdAsync(int candidateId);
		Task DeleteCandidateHistory(int historyId);
		Task<List<Candidate>> GetAll();
		Task<IEnumerable<Role>> GetAllRoles();
		Task<IEnumerable<CandidateStatus>> GetAllStatuses();
		Task<IEnumerable<Technology>> GetAllTechnologies();
		Task UpdateCandidate(CandidateDto candidateDto);
		Task UpdateCandidateDetails(Candidate candidate);
		Task<CandidateFile> GetCandidateFile(int candidateId, string fileName);
		Task<IEnumerable<StageWithStatusesDto>> GetAllStagesStatuses();
		Task<IEnumerable<Stage>> GetAllStages();
		Task<Stage> GetStageById(int stageId);
		Task UpdateCandidateHistory(CandidateHistory candidateHistory);
	}
}
