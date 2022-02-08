using Business.Models;
using Kidney.Business.Enums;
using Kidney.Business.Models;
using Kidney.Business.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Kidney.API.Controllers
{
    [Route("receiver/")]
    [ApiController]
    public class ReceiverController : ControllerBase
    {
        private IReceiverService _receiverService;
        public ReceiverController(IReceiverService receiverService)
        {
            _receiverService = receiverService;
        }
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _receiverService.GetAll();
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] Receiver receiver)
        {
            try
            {
                var result = await _receiverService.UpdateReceiver(id, receiver);
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] Receiver receiver)
        {
            try
            {
                var result = await _receiverService.Register(receiver);
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
        [HttpGet]
        [Route("info")]
        public async Task<IActionResult> ReceiverInformations([FromQuery] string id)
        {
            try
            {
                var result = await _receiverService.GetInformations(int.Parse(id));
                return Ok(result);
            }
            catch (Exception exception)
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
                var result = await _receiverService.DeleteReceiver(id);
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost]
        [Route("filter")]
        public async Task<IActionResult> Filter([FromBody] ReceiverFilter parameters)
        {
            try
            {
                var result = await _receiverService.FilterReceivers(parameters);
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
