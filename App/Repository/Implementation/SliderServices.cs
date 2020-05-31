using App.Data;
using App.DomainObjects.Silders;
using App.Enum;
using App.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repository.Implementation
{
    public class SliderServices : ISliderServices
    {
        private readonly DataContext _dataContext;
        public SliderServices(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> AddUpdateSliderAsync(Slider slider)
        {
            if (slider.SliderId > 0)
            {
                var item = await _dataContext.Sliders.FindAsync(slider.SliderId); 
                _dataContext.Entry(item).CurrentValues.SetValues(slider);
            }
            else
                await _dataContext.Sliders.AddAsync(slider);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Slider>> GetAllSlidersAsync()
        {
            return await _dataContext.Sliders.Where(x => x.Status == (int)SliderStatus.Active).ToListAsync();
        }

        public string GetFileType(byte[] file)
        {
            return string.Empty;
        }

        public async Task<Slider> GetSingleSlidersAsync(int sliderId)
        {
            return await _dataContext.Sliders.FirstOrDefaultAsync(x => x.Status == (int)SliderStatus.Active);
        }

        public async Task<bool> SliderExistAsync(string fileName)
        {
            return await _dataContext.Sliders.AnyAsync(x => x.FileName.Trim().ToLower() == fileName.Trim().ToLower());
        }
        public string SliderValidationAndRetunSize(byte[] file)
        {
            return string.Empty;
        }
    }
}
