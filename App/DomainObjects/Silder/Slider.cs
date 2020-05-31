using System;

namespace App.DomainObjects.Silders
{
    public class Slider
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
}
