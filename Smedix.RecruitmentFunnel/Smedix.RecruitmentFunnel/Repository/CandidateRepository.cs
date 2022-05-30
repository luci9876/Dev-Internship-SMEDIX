using Microsoft.EntityFrameworkCore;
using Smedix.RecruitmentFunnel.Context;
using Smedix.RecruitmentFunnel.DTOs;
using Smedix.RecruitmentFunnel.Helpers;
using Smedix.RecruitmentFunnel.Helpers.Interface;
using Smedix.RecruitmentFunnel.Models;

namespace Smedix.RecruitmentFunnel.Repository
{
    public class CandidateRepository : GenericRepository<Candidate>, ICandidateRepository
    {
        private ISortHelper<Candidate> _sortHelper;
        public CandidateRepository(RecruitmentContext context, ISortHelper<Candidate> sortHelper) : base(context)
        {
            _sortHelper = sortHelper;
        }

        public async Task<IQueryable<Candidate>> GetAllCandidates(string? searchName, string? orderQuery)
        {
            if (string.IsNullOrEmpty(searchName))
            {
                var candidates = _context.Candidates.Include(r => r.Role)
                    .Include(s => s.CandidateStatus).Include(x => x.CandidateTechnologies)
                    .ThenInclude(x => x.Technology).AsQueryable();
                return _sortHelper.ApplySort(candidates, orderQuery);
            }
            else
            {
                var candidates = _context.Candidates.Where(x => x.Name.Contains(searchName))
                    .Include(r => r.Role).Include(s => s.CandidateStatus)
                    .Include(x => x.CandidateTechnologies).ThenInclude(x => x.Technology)
                    .AsQueryable();
                return _sortHelper.ApplySort(candidates, orderQuery);
            }
        }

        public async Task<Candidate> GetCandidate(int id)
        {
            var candidate = await _context.Candidates.Where(x => x.Id == id).Include(r => r.Role)
                .Include(s => s.CandidateStatus).Include(d => d.Department)
                .Include(t => t.CandidateTechnologies).ThenInclude(x => x.Technology)
                .Include(f => f.CandidateFiles).Include(h => h.CandidateHistories)
                .FirstOrDefaultAsync();
            return candidate;
        }

        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<IEnumerable<CandidateStatus>> GetAllCandidateStatuses()
        {
            return await _context.CandidateStatuses.ToListAsync();
        }

        public async Task<IEnumerable<Technology>> GetAllTechnologies()
        {
            return await _context.Technologies.ToListAsync();
        }

        public async Task UpdateCandidate(CandidateDto candidateDto)
        {
            var candidate = await _context.Candidates.Include(c => c.CandidateTechnologies).Where(c => c.Id == candidateDto.Id).FirstOrDefaultAsync();

            if (candidate != null)
            {
                if (candidateDto.Technology != null)
                {
                    var candidateTechnology = new CandidateTechnology
                    {
                        Candidate = candidate,
                        Technology = candidateDto.Technology
                    };

                    if (candidate.CandidateTechnologies == null)
                    {
                        candidate.CandidateTechnologies = new List<CandidateTechnology>();
                    }
                    else
                    {
                        candidate.CandidateTechnologies.Clear();
                    }

                    candidate.CandidateTechnologies.Add(candidateTechnology);
                    this.Save();
                }
                candidate.Role = candidateDto.Role;
                candidate.CandidateStatus = candidateDto.LastStatus;
                candidate.LastUpdated = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCandidateHistory(int candidateHistoryId)
        {
            var entity = await _context.CandidateHistories.FindAsync(candidateHistoryId);
            _context.CandidateHistories.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<CandidateFile> GetCandidateFile(int candidateId, string fileName)
        {
            return await _context.CandidateFiles.Where(f => f.Candidate.Id == candidateId && f.FileName == fileName).FirstOrDefaultAsync();
        }

        public async Task UpdateCandidateDetails(Candidate candidate)
        {
            var candidateUpdated = await _context.Candidates.FirstOrDefaultAsync(x => x.Id == candidate.Id);
            if (candidateUpdated != null)
            {
                candidateUpdated.Name = candidate.Name;
                candidateUpdated.Email = candidate.Email;
                candidateUpdated.Phone = candidate.Phone;
                candidateUpdated.Address = candidate.Address;
                candidateUpdated.Company = candidate.Company;
                candidateUpdated.LinkedIn = candidate.LinkedIn;
                candidateUpdated.ReferredBy = candidate.ReferredBy;
                candidateUpdated.Source = candidate.Source;
                candidateUpdated.YearsOfExperience = candidate.YearsOfExperience;
                candidateUpdated.Notes = candidate.Notes;
                await _context.SaveChangesAsync();
            }
        }

        public Dictionary<int, List<Status>> GetAllStagesStatuses()
        {
            var stagesWithStatuses = _context.StageStatuses
                .Include(s => s.Status)
                .AsEnumerable()
                .GroupBy(s => s.StageId)
                .ToDictionary(s => s.Key, s => s.Where(s => s.Status?.Name != "None").Select(s => s.Status).ToList());
            return stagesWithStatuses;
        }

        public async Task<IEnumerable<Stage>> GetAllStages()
        {
            return await _context.Stages.ToListAsync();
        }
        public async Task UpdateCandidateHistoryStep(CandidateHistory candidateHistory)
        {
            var candidateHistoryStep = await _context.CandidateHistories.Include(x => x.StageStatus).FirstOrDefaultAsync(x => x.Id == candidateHistory.Id);
            if (candidateHistoryStep != null)
            {
                candidateHistoryStep.Notes = candidateHistory.Notes;
                candidateHistoryStep.Issuer = candidateHistory.Issuer;
                candidateHistoryStep.Manager = candidateHistory.Manager;
                candidateHistoryStep.PlannedDate = candidateHistory.PlannedDate;
                if (candidateHistory.StageStatus != null)
                {
                    var stageStatus = await _context.StageStatuses.FirstOrDefaultAsync(x => x.StageId == candidateHistory.StageStatus.StageId && x.StatusId == candidateHistory.StageStatus.StatusId);

                    if (stageStatus == null)
                    {
                        var noneStatus = await _context.Statuses.FirstOrDefaultAsync(status => status.Name == "None");

                        if (noneStatus != null)
                        {
                            stageStatus = await _context.StageStatuses.
                                FirstOrDefaultAsync(x => x.StageId == candidateHistory.StageStatus.StageId &&
                                x.StatusId == noneStatus.Id);
                        }

                        if (stageStatus != null)
                        {
                            candidateHistoryStep.StageStatus = stageStatus;
                        }
                    }
                    else
                    {
                        candidateHistoryStep.StageStatus = stageStatus;
                    }
                }
                await _context.SaveChangesAsync();
            }
        }

        public async Task<CandidateTechnology> CreateDefaultCandidateTechnlogy(Candidate candidate)
        {
            CandidateTechnology candidateTechnology = new()
            {
                Candidate = candidate,
                Technology = await GetTechnologyById(1)
            };

            _context.CandidateTechnologies.Add(candidateTechnology);
            _context.SaveChanges();

            return candidateTechnology;
        }

        public async Task<Technology> GetTechnologyById(int id)
        {
            return await _context.Technologies.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Stage> GetStageById(int stageId)
        {
            return await _context.Stages.FirstOrDefaultAsync(stage => stage.Id == stageId);
        }
    }
}
