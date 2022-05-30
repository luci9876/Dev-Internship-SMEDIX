using Smedix.RecruitmentFunnel.Exceptions;
using Smedix.RecruitmentFunnel.Models;
using Smedix.RecruitmentFunnel.Repository;

namespace Smedix.RecruitmentFunnel.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepo;

        public FileService(IFileRepository fileRepo)
        {
            _fileRepo = fileRepo;
        }

        public async Task<bool> FileExists(CandidateFile file, int candidateId)
        {
            if (file != null && file.Candidate != null && file.Candidate.CandidateFiles != null)
            {
                return await _fileRepo.FileExist(file, candidateId);
            }

            return false;
        }

        public async Task UpdateFile(CandidateFile file)
        {
            if (file != null)
            {
                await _fileRepo.UpdateFile(file);
            }
            else
            {
                throw new CandidateFileNotFoundException();
            }
        }

        public async Task<ICollection<CandidateFile>?> GetFilesByCandidateId(int id)
        {
            return await _fileRepo.GetFilesByCandidateId(id);
        }

        public async Task<CandidateFile> GetFileByNameAndCandidateId(string name, int candidateId)
        {
            return await _fileRepo.GetFileByNameAndCandidateId(name, candidateId);
        }
    }
}
