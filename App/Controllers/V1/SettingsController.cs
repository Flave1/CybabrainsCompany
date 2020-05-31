using App.Contracts.Commands.Settings;
using App.Contracts.Queries.settings;
using App.Contracts.V1;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers.V1
{
    public class SettingsController : Controller
    {
        private readonly IMediator _meditor;
        public SettingsController(IMediator mediator)
        {
            _meditor = mediator;
        }
        [HttpPost(ApiRoutes.SliderEndpoint.ADD_UPDATE_SLIDER)]
        public async Task<IActionResult> ADD_UPDATE_SLIDER([FromBody] AddUpdateSliderCommand command)
        {
            var res = await _meditor.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }

        [HttpGet(ApiRoutes.SliderEndpoint.GET_ALL_SLIDERS)]
        public async Task<IActionResult> GET_ALL_SLIDERS()
        {
            var query = new GetAllSlidersQuery();
            return Ok(await _meditor.Send(query));
        }
    }
}
