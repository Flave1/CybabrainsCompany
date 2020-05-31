using App.Contracts.Response.Slider;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Contracts.Queries.settings
{
    public class GetAllSlidersQuery : IRequest<SliderRespObj> { }
}
