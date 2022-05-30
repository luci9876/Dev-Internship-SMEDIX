using Smedix.RecruitmentFunnel.Models;

namespace Smedix.RecruitmentFunnel.Services
{
    public interface IFileService
    {
        Task<bool> FileExists(CandidateFile file, int candidateId);
        Task UpdateFile(CandidateFile file);
        Task<ICollection<CandidateFile>?> GetFilesByCandidateId(int id);
        Task<CandidateFile> GetFileByNameAndCandidateId(string name, int candidateId);
    }
}
