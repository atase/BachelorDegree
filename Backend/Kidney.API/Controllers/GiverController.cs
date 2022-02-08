using Business.Models;
using Kidney.Business.Enums;
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

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _giverService.GetAll();
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
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

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] Giver giver)
        {
            try
            {
                var result = await _giverService.UpdateGiver(id, giver);
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }

        [HttpGet]
        [Route("info")]
        public async Task<IActionResult> GiverInformation([FromQuery] string id)
        {
            try 
            { 
                var result = await _giverService.GetInformations(int.Parse(id));
                return Ok(result);
            }
            catch(Exception exception)
            {
                return BadRequest(exception.Message);
            }
             
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            try
            {
                var result = await _giverService.DeleteGiver(id);
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost]
        [Route("filter")]
        public async Task<IActionResult> Filter([FromBody] GiverFilter parameters)
        {
            try
            {
                var result = await _giverService.FilterGivers(parameters);
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

    }
}
