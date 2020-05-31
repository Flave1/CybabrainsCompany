using App.Contracts.Queries.settings;
using App.Contracts.Response;
using App.Contracts.Response.Slider;
using App.Repository.Interface;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Handlers.Settings
{
    public class GetAllSlidersQueryHandler : IRequestHandler<GetAllSlidersQuery , SliderRespObj>
    {
        private readonly ISliderServices _sliderServices;
        private readonly IMapper _mapper;
        public GetAllSlidersQueryHandler(ISliderServices sliderServices, IMapper mapper)
        {
            _mapper = mapper;
            _sliderServices = sliderServices;
        }

        public async Task<SliderRespObj> Handle(GetAllSlidersQuery request, CancellationToken cancellationToken)
        {
            var result = await _sliderServices.GetAllSlidersAsync();
            return new SliderRespObj
            {
                Sliders = _mapper.Map<List<SliderObj>>(result),
                Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage { FriendlyMessage = result.Count() > 0? null : "Search Complete!! No Record found"} }
            };
        }
    }
}
