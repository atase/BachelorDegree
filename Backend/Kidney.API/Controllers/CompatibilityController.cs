using Kidney.Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kidney.API.Controllers
{
    [Route("compatibility/")]
    [ApiController]
    public class CompatibilityController : ControllerBase
    {
        ICompatibilityService _compatibilityService;

        public CompatibilityController(ICompatibilityService compatibilityService)
        {
            _compatibilityService = compatibilityService;
        }

        [HttpGet]
        [Route("generateScores")]
        public async Task<IActionResult> GenerateCompatibilitiesScores() 
        {
            try
            {
                var result = await _compatibilityService.GenerateCompatibilityScores();
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet]
        [Route("statistics")]
        public async Task<IActionResult> GetStatistics()
        {
            try
            {
                var result = await _compatibilityService.GetStatistics();
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet]
        [Route("givers")]
        public async Task<IActionResult> GetCompatibilitiesForGivers()
        {
            try
            {
                var result = await _compatibilityService.GetCompatibilitiesForGivers();
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet]
        [Route("receivers")]
        public async Task<IActionResult> GetCompatibilitiesForReceivers()
        {
            try
            {
                var result = await _compatibilityService.GetCompatibilitiesForReceivers();
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet]
        [Route("givers/{id}")]
        public async Task<IActionResult> GetCompatibilitiesForGiver(int id)
        {
            try
            {
                var result = await _compatibilityService.GetCompatibilitiesForGiver(id);
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet]
        [Route("receivers/{id}")]
        public async Task<IActionResult> GetCompatibilitiesForReceiver(int id)
        {
            try
            {
                var result = await _compatibilityService.GetCompatibilitiesForReceiver(id);
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet]
        [Route("scores")]
        public async Task<IActionResult> GetCompatibilityScores()
        {
            try
            {
                var result = await _compatibilityService.GetCompatibilityScores();
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
