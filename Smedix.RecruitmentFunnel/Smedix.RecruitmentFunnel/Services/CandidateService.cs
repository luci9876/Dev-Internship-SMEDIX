using AutoMapper;
using Smedix.RecruitmentFunnel.DTOs;
using Smedix.RecruitmentFunnel.Helpers;
using Smedix.RecruitmentFunnel.Models;
using Smedix.RecruitmentFunnel.Repository;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Smedix.RecruitmentFunnel.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepo;
        private readonly IMapper _mapper;

        public CandidateService(ICandidateRepository candidateRepo, IMapper mapper)
        {
            _candidateRepo = candidateRepo;
            _mapper = mapper;
        }

        public async Task<Candidate> GetCandidateById(int id)
        {
            return await _candidateRepo.GetCandidate(id);
        }



        public async Task CreateAsync(Candidate candidate)
        {
            candidate.Role = (await GetAllRoles()).FirstOrDefault();
            candidate.CandidateStatus = (await GetAllStatuses()).FirstOrDefault();

            await _candidateRepo.Create(candidate);
            await _candidateRepo.CreateDefaultCandidateTechnlogy(candidate);
        }

        public void Save()
        {
            _candidateRepo.Save();
        }

        public async Task<PagedList<CandidateDto>> GetAllCandidates(CandidateParams candidateParams)
        {
            var listModel = await _candidateRepo.GetAllCandidates(candidateParams.SearchName, candidateParams.OrderBy);
            var pagedList = new PagedList<CandidateDto>(listModel.ProjectTo<CandidateDto>
                (_mapper.ConfigurationProvider).AsNoTracking(), listModel.Count(), candidateParams.PageNumber, candidateParams.PageSize);

            return pagedList;
        }


        public async Task<List<Candidate>> GetAll()
        {
            return await _candidateRepo.GetAll();
        }

        public async Task DeleteByIdAsync(int candidateId)
        {
            await _candidateRepo.Delete(candidateId);
        }

        public async Task DeleteCandidateHistory(int candidateHistoryId)
        {
            await _candidateRepo.DeleteCandidateHistory(candidateHistoryId);
        }

        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            return await _candidateRepo.GetAllRoles();
        }

        public async Task<IEnumerable<CandidateStatus>> GetAllStatuses()
        {
            return await _candidateRepo.GetAllCandidateStatuses();
        }

        public async Task<IEnumerable<Technology>> GetAllTechnologies()
        {
            return await _candidateRepo.GetAllTechnologies();
        }
        public async Task UpdateCandidate(CandidateDto candidateDto)
        {
            await _candidateRepo.UpdateCandidate(candidateDto);
        }
        public async Task UpdateCandidateDetails(Candidate candidate)
        {
            await _candidateRepo.UpdateCandidateDetails(candidate);
        }

        public async Task UpdateCandidateHistory(CandidateHistory candidateHistory)
        {
            await _candidateRepo.UpdateCandidateHistoryStep(candidateHistory);
        }

        public async Task<CandidateFile> GetCandidateFile(int candidateId, string fileName)
        {
            return await _candidateRepo.GetCandidateFile(candidateId, fileName);
        }

        public async Task<IEnumerable<StageWithStatusesDto>> GetAllStagesStatuses()
        {
            var stages = await _candidateRepo.GetAllStages();
            List<StageWithStatusesDto> stageWithStatusesDto = new List<StageWithStatusesDto>();
            var stageStatuses = _candidateRepo.GetAllStagesStatuses();

            foreach (var stage in stages)
            {
                var statuses = new List<Status>();
                if (stageStatuses.ContainsKey(stage.Id))
                {
                    stageStatuses.TryGetValue(stage.Id, out statuses);
                }
                var stageWithStatuses = new StageWithStatusesDto()
                {
                    Id = stage.Id,
                    Name = stage.Name,
                    Statuses = _mapper.Map<List<StatusDto>>(statuses)
                };
                stageWithStatusesDto.Add(stageWithStatuses);
            }

            return stageWithStatusesDto;
        }

        public async Task<IEnumerable<Stage>> GetAllStages()
        {
            return await _candidateRepo.GetAllStages();
        }

        public async Task<Stage> GetStageById(int stageId)
        {
            return await _candidateRepo.GetStageById(stageId);
        }
    }
}


