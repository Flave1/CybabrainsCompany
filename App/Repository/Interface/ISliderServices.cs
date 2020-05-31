using App.DomainObjects.Silders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repository.Interface
{
    public interface ISliderServices
    {
        Task<bool> AddUpdateSliderAsync(Slider slider);
        Task<IEnumerable<Slider>> GetAllSlidersAsync();
        Task<Slider> GetSingleSlidersAsync(int sliderId);
        Task<bool> SliderExistAsync(string fileName);
        string SliderValidationAndRetunSize(byte[] file);
        string GetFileType(byte[] file);
    }
}
