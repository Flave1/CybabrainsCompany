using App.Contracts.Commands.Settings;
using App.Contracts.Response;
using App.Contracts.Response.Slider;
using App.DomainObjects.Silders;
using App.ErrorHandler;
using App.LogHandler.Service;
using App.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Handlers.Settings
{
    public class AddUpdateSliderCommandHandler : IRequestHandler<AddUpdateSliderCommand, SliderRegRespObj>
    {
        private readonly ISliderServices _sliderServices;
        private readonly ILoggerService _logger;
        public AddUpdateSliderCommandHandler(ISliderServices sliderServices)
        {
            _sliderServices = sliderServices;
        }
        public async Task<SliderRegRespObj> Handle(AddUpdateSliderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var sliderFrmRepo = new Slider();

                if (request.SliderId < 1)
                    if (await _sliderServices.SliderExistAsync(request.FileName))
                        return new SliderRegRespObj
                        {
                            Status = new APIResponseStatus { IsSuccessful = false, Message = new APIResponseMessage { FriendlyMessage = "Name Already assigned to a slider" } }
                        };
                if (request.SliderId > 0)
                {
                    sliderFrmRepo = await _sliderServices.GetSingleSlidersAsync(request.SliderId);
                }

                var fileSize = _sliderServices.SliderValidationAndRetunSize(request.File);
                if (string.IsNullOrEmpty(fileSize))
                    return new SliderRegRespObj
                    {
                        Status = new APIResponseStatus { IsSuccessful = false, Message = new APIResponseMessage { FriendlyMessage = "Invalid Image upload!! Expected file size (1200*800)" } }
                    };

                var slider = new Slider
                {
                    SliderId = request.SliderId > 0 ? request.SliderId : 0,
                    DateUploaded = request.SliderId > 0 ? sliderFrmRepo.DateUploaded : DateTime.Today,
                    Description = request.Description,
                    ExpectedChangeDate = request.ExpectedChangeDate,
                    File = request.File,
                    FileName = request.FileName,
                    FileSize = fileSize,
                    FileType = _sliderServices.GetFileType(request.File),
                    SliderLink = request.SliderLink,
                    Status = request.Status,
                    Title = request.Title,
                };
                var isDone = await _sliderServices.AddUpdateSliderAsync(slider);
                if (!isDone)
                    return new SliderRegRespObj
                    {
                        Status = new APIResponseStatus { IsSuccessful = false, Message = new APIResponseMessage { FriendlyMessage = "Unable to process request! please make sure changes were made on this item" } }
                    };

                return new SliderRegRespObj
                {
                    Status = new APIResponseStatus { IsSuccessful = false, Message = new APIResponseMessage { FriendlyMessage = "Successful" } }
                };
            }
            catch (Exception ex)
            {
                #region Log error to file 
                var errorCode = ErrorID.Generate(4);
                _logger.Error($"ErrorID : {errorCode} Excemption : {ex?.Message ?? ex?.InnerException?.Message} ");
                return new SliderRegRespObj
                {

                    Status = new APIResponseStatus
                    {
                        IsSuccessful = false,
                        Message = new APIResponseMessage
                        {
                            FriendlyMessage = "Error occured!! Unable to process request",
                            MessageId = errorCode,
                            TechnicalMessage = $"ErrorID : {errorCode} Excemption : {ex?.Message ?? ex?.InnerException?.Message} "
                        }
                    }
                };
                #endregion
            }


        }
    }
}
