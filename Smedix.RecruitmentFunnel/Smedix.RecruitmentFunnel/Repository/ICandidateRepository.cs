using Smedix.RecruitmentFunnel.DTOs;
using Smedix.RecruitmentFunnel.Helpers;
using Smedix.RecruitmentFunnel.Models;

namespace Smedix.RecruitmentFunnel.Repository
{
    public interface ICandidateRepository : IGenericRepository<Candidate>
    {
        Task<IQueryable<Candidate>> GetAllCandidates(string? searchName, string? orderQuery);
        Task<Candidate> GetCandidate(int id);
        Task<IEnumerable<Role>> GetAllRoles();
        Task<IEnumerable<CandidateStatus>> GetAllCandidateStatuses();
        Task<IEnumerable<Technology>> GetAllTechnologies();
        Task UpdateCandidate(CandidateDto candidateDto);
        Task UpdateCandidateDetails(Candidate candidate);
        Task<CandidateFile> GetCandidateFile(int candidateId, string fileName);
        Task DeleteCandidateHistory(int candidateId);
        Dictionary<int, List<Status>> GetAllStagesStatuses();
        Task<IEnumerable<Stage>> GetAllStages();
        Task<Technology> GetTechnologyById(int id);
        Task<CandidateTechnology> CreateDefaultCandidateTechnlogy(Candidate candidate);
        Task<Stage> GetStageById(int stageId);
        Task UpdateCandidateHistoryStep(CandidateHistory candidateHistory);
    }
}
