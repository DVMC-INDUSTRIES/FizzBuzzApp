using FizzBuzz.Api.Application.Interfaces;
using FizzBuzz.Api.Domain.Entities;
using FizzBuzz.Api.Infrastructure.Logging;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FizzBuzz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FizzBuzzController : ControllerBase
    {
        private readonly IFizzBuzzAppService _fizzBuzzAppService;
        private readonly IFileRepository _fileRepository;
        private readonly Infrastructure.Logging.ILogger _logger;

        public FizzBuzzController(IFizzBuzzAppService fizzBuzzAppService, IFileRepository fileRepository, Infrastructure.Logging.ILogger logger)
        {
            _fizzBuzzAppService = fizzBuzzAppService;
            _fileRepository = fileRepository;
            _logger = logger;
        }

        [HttpGet("{startNumber}/{endNumber}")]
        public async Task<IActionResult> Get(int startNumber, int endNumber)
        {
            try
            {
                var series = _fizzBuzzAppService.GenerateSeries(startNumber, endNumber);
                await _fileRepository.SaveSeriesAsync(series);
                return Ok(series.Series);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while generating the FizzBuzz series", ex);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}