using System;
using System.Collections.Generic;
using System.Text;

namespace App.Contracts.Response.Slider
{
    public class SliderObj
    {
        public int SliderId { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public int Status { get; set; }
        public byte[] File { get; set; }
        public string FileSize { get; set; }
        public DateTime ExpectedChangeDate { get; set; }
        public DateTime DateUploaded { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SliderLink { get; set; }
    }
    public class SliderRespObj
    {
        public List<SliderObj> Sliders { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class SliderRegRespObj
    {
        public int SliderId { get; set; }
        public APIResponseStatus Status { get; set; }
    }
}
