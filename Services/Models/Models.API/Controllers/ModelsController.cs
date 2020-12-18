using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Models.API.Commands;
using Models.API.Queries;
using Models.Domain;
using System.Collections.Generic;
using Models.API.DTO;
using Microsoft.AspNetCore.Authorization;

namespace Models.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly ILogger<ModelsController> _logger;

        public ModelsController(IMediator mediator, ILogger<ModelsController> logger)
        {
            this._logger = logger;
            this._mediator = mediator;
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> Create(CreateModelsAggregateCommand command)
        {
            try { 
                await _mediator.Send(command);

                return Ok();
            } catch (Exception e) {
                return BadRequest(e.Message);
            };
        } 

        [HttpGet("list")]
        [Authorize]
        public async Task<ActionResult<List<ModelsAggregateResponseDTO>>> GetAll()
        {
            try {
                var result = await _mediator.Send(new GetModelsAggregateQuery());

                return Ok(result);
            } catch (Exception e) {
                return BadRequest(e.Message);
            };
        }
    }
}
