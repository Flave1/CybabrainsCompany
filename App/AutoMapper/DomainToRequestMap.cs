using App.Contracts.Response.Slider;
using App.DomainObjects.Silders;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.AutoMapper
{
    public class DomainToRequestMap : Profile
    {
        public DomainToRequestMap()
        {
            CreateMap<Slider, SliderObj>();
        }
    }
}
