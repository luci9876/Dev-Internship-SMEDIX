using Microsoft.AspNetCore.Mvc;
using Smedix.RecruitmentFunnel.DTOs;
using Smedix.RecruitmentFunnel.Models;
using Smedix.RecruitmentFunnel.Services;

namespace Smedix.RecruitmentFunnel.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CandidateFileController : ControllerBase
    {
		private readonly ICandidateService _candidateService;
        private readonly IFileService _fileService;

        public CandidateFileController(
            ICandidateService candidateService, IFileService fileService)
        {
            _candidateService = candidateService;
            _fileService = fileService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetCandidateFile([FromQuery] CandidateFileDetailsDto candidateFile)
        {
            var file = (await _candidateService.GetCandidateFile(candidateFile.CandidateId, candidateFile.FileName));
            if (file == null) return NotFound("File not found!");
            return Ok(file);
        }

        [HttpPost()]
        public async Task<ActionResult> CreateCandidateFile([FromForm] CandidateFileDto candidateFileDto)
        {
            var candidate = await _candidateService.GetCandidateById(candidateFileDto.CandidateId);

            if (candidate == null) return NotFound("Candidate not found!");

            List<int> candidateFileIds = new();

            foreach (IFormFile file in candidateFileDto.Files)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);

                    CandidateFile candidateFile = new CandidateFile
                    {
                        FileName = file.FileName,
                        Candidate = candidate,
                        Content = memoryStream.ToArray(),
                        ContentType = file.ContentType
                    };

                    candidate.CandidateFiles = await _fileService.GetFilesByCandidateId(candidate.Id);

                    if (candidate.CandidateFiles == null)
                    {
                        candidate.CandidateFiles = new List<CandidateFile>();
                    }

                    if (await _fileService.FileExists(candidateFile, candidateFileDto.CandidateId))
                    {
                        var existingFile = await _fileService.GetFileByNameAndCandidateId(candidateFile.FileName, candidateFileDto.CandidateId);
                        try
                        {
                            candidateFile.Id = existingFile.Id;
                            await _fileService.UpdateFile(candidateFile);
                        }
                        catch (Exception ex)
                        {
                            return BadRequest(ex.Message);
                        }
                    }
                    else
                    {
                        candidate.CandidateFiles.Add(candidateFile);
                    }

                    _candidateService.Save();

                    candidateFileIds.Add(candidateFile.Id);
                }
            }

            return Ok(candidateFileIds);
		}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            return Ok(await _fileService.GetFilesByCandidateId(id));
        }
    }
}
