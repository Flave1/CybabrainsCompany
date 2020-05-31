using App.Contracts.Response.Slider;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Contracts.Commands.Settings
{
    public class AddUpdateSliderCommand : IRequest<SliderRegRespObj>
    {
        public int SliderId { get; set; }
        [Required]
        public string FileName { get; set; }
        public int Status { get; set; }
        [Required]
        public byte[] File { get; set; }
        public DateTime ExpectedChangeDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SliderLink { get; set; }
    }
}
