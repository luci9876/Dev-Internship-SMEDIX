using Smedix.RecruitmentFunnel.Models;

namespace Smedix.RecruitmentFunnel.Repository
{
    public interface IFileRepository : IGenericRepository<CandidateFile>
    {
        Task<ICollection<CandidateFile>?> GetFilesByCandidateId(int id);
        Task UpdateFile(CandidateFile file);
        Task<bool> FileExist(CandidateFile file, int candidateId);
        Task<CandidateFile> GetFileByNameAndCandidateId(string name, int candidateId);
    }
}
