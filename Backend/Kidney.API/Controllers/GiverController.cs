using Kidney.Business.Models;
using Kidney.Business.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Kidney.API.Controllers
{
    [Route("giver/")]
    [ApiController]
    public class GiverController : ControllerBase
    {
        private IGiverService _giverService;
        public GiverController(IGiverService giverService)
        {
            _giverService = giverService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] Giver giver)
        {
            try
            {
                var result = await _giverService.Register(giver);
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }

        [HttpGet]
        [Route("info")]
        public async Task<IActionResult> GiverInformation([FromQuery] int id)
        {
            try 
            { 
                var result = await _giverService.GetInformations(id);
                return Ok(result);
            }
            catch(Exception exception)
            {
                return BadRequest(exception.Message);
            }
             
        }

    }
}
