using Microsoft.AspNetCore.Mvc;
using Smedix.RecruitmentFunnel.DTOs;
using Smedix.RecruitmentFunnel.Helpers;
using Smedix.RecruitmentFunnel.Models;
using Smedix.RecruitmentFunnel.Services;

namespace Smedix.RecruitmentFunnel.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        private readonly ICandidateHistoryService _candidateHistoryService;
        public CandidateController(ICandidateService candidateService, ICandidateHistoryService candidateHistoryService)
        {
            _candidateService = candidateService;
            _candidateHistoryService = candidateHistoryService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<CandidateDto>>> GetCandidates([FromQuery] CandidateParams candidateParams)
        {
            try
            {
                return Ok(await _candidateService.GetAllCandidates(candidateParams));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateCandidate(Candidate candidate)
        {
            candidate.LastUpdated = DateTime.Now;
            await _candidateService.CreateAsync(candidate);
            return Ok(candidate.Id);
        }

        [HttpGet("/getById")]
        public async Task<Candidate> GetCandidateById(int id)
        {
            return await _candidateService.GetCandidateById(id);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCandidate(int id)
        {
            if (id < 0)
            {
                return BadRequest("Id must be positive!");
            }

            try
            {
                await _candidateService.DeleteByIdAsync(id);
                return Ok($"Candidate with id {id} was deleted successfully!");
            }
            catch (OperationCanceledException)
            {
                return BadRequest("Operation canceled!");
            }
            catch (NullReferenceException)
            {
                return BadRequest("There is no candidate with this Id!");
            }
            catch (Exception ex)
            {
                return BadRequest("Unhandled exception: " + ex.Message);
            }
        }

        [HttpDelete("/CandidateHistory")]
        public async Task<ActionResult> DeleteCandidateHistory(int id)
        {
            if (id < 0)
            {
                return BadRequest("Id must be positive!");
            }

            try
            {
                await _candidateService.DeleteCandidateHistory(id);
                return Ok($"Candidate history with id {id} was deleted successfully!");
            }
            catch (OperationCanceledException)
            {
                return BadRequest("Operation canceled!");
            }
            catch (NullReferenceException)
            {
                return BadRequest("There is no candidate with this Id!");
            }
            catch (Exception ex)
            {
                return BadRequest("Unhandled exception: " + ex.Message);
            }
        }

        [HttpGet("/getCandidateStatuses")]
        public async Task<ActionResult<List<Status>>> GetStatuses()
        {
            try
            {
                return Ok(await _candidateService.GetAllStatuses());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/getRoles")]
        public async Task<ActionResult<List<Role>>> GetRoles()
        {
            try
            {
                return Ok(await _candidateService.GetAllRoles());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/getTechnologies")]
        public async Task<ActionResult<List<Technology>>> GetTechnologies()
        {
            try
            {
                return Ok(await _candidateService.GetAllTechnologies());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCandidate(CandidateDto candidateDto)
        {
            await _candidateService.UpdateCandidate(candidateDto);
            return Ok();
        }

        [HttpPut("/candidate-details")]
        public async Task<ActionResult> UpdateCandidateDetails(Candidate candidate)
        {
            await _candidateService.UpdateCandidateDetails(candidate);
            return Ok();
        }

        [HttpGet("/getStageStatuses")]
        public async Task<ActionResult> GetAllStagesStatuses()
        {
            return Ok(await _candidateService.GetAllStagesStatuses());
        }

        [HttpPost("/CandidateHistory")]
        public async Task<IActionResult> CreateCandidateHistory(int candidateId)
        {
            var candidate = await _candidateService.GetCandidateById(candidateId);

            if (candidate == null)
            {
                return BadRequest("Candidate not found!");
            }

            var candidateHistory = new CandidateHistory
            {
                EntryDateTime = DateTime.Now,
                CandidateId = candidateId
            };

            await _candidateHistoryService.CreateAsync(candidateHistory);
            return Ok(candidateHistory.Id);
        }

        [HttpPut("/candidate-history")]
        public async Task<ActionResult> UpdateCandidateHistory(CandidateHistory candidateHistory)
        {
            await _candidateService.UpdateCandidateHistory(candidateHistory);
            return Ok();
        }

        [HttpGet("/getHistorySteps")]
        public async Task<ActionResult<List<CandidateHistory>>> GetCandidateHistorySteps([FromQuery] int candidateId)
        {
            var candidate = await _candidateService.GetCandidateById(candidateId);

            if (candidate == null)
            {
                return BadRequest($"There is no candidate with the Id {candidateId}. Try again with an existing Id!");
            }

            var steps = await _candidateHistoryService.GetCandidateHistoryStepsAsync(candidateId);

            return Ok(steps);
        }
    }
}
