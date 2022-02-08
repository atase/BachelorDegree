using Kidney.Business.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Kidney.API.Controllers
{
    [Route("matching/")]
    [ApiController]
    public class MatchingController : ControllerBase
    {
        IMatchingService _matchingService;
        ICompatibilityService _compatibilityService;

        public MatchingController(IMatchingService matchingService, ICompatibilityService compatibilityService)
        {
            _matchingService = matchingService;
            _compatibilityService = compatibilityService;
            
        }

        [HttpGet]
        [Route("compute")]
        public async Task<IActionResult> ComputeMaximalMatching()
        {
            try
            {
                var compatibilities = await _compatibilityService.GetCompatibilityScores();
                var result = await _matchingService.MaximalMatchingGiversToReceivers(0, compatibilities);
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
