using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Smedix.RecruitmentFunnel.Context;
using Smedix.RecruitmentFunnel.Models;

namespace Smedix.RecruitmentFunnel.Repository
{
    public class FileRepository : GenericRepository<CandidateFile>, IFileRepository
    {
        public FileRepository(RecruitmentContext context) : base(context)
        {
        }

        public async Task<ICollection<CandidateFile>?> GetFilesByCandidateId(int id)
        {
            return await _context.CandidateFiles.Where(x => x.Candidate.Id == id).ToListAsync();
        }

        public async Task UpdateFile(CandidateFile file)
        {
            await Update(file);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> FileExist(CandidateFile file, int candidateId)
        {
            return await _context.CandidateFiles.AnyAsync(x => x.Candidate.Id == candidateId && x.FileName == file.FileName);
        }

        public async Task<CandidateFile> GetFileByNameAndCandidateId(string name, int candidateId)
        {
            var file = await _context.CandidateFiles
                .Where(x => x.FileName.Equals(name) && x.Candidate.Id == candidateId).FirstOrDefaultAsync();
            return file;
        }
    }
}
