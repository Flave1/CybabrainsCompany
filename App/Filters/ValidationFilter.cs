﻿using App.Contracts.ErrorResponses;
using App.Contracts.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace App.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errorsInModelState = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage)).ToArray();


                //var errorResponse = new ErrorResponse();
                var errorResponse = new NewErrorModel();

                foreach (var error in errorsInModelState)
                {
                    foreach (var errorValue in error.Value)
                    {
                        var errorModel = new NewErrorModel
                        {
                            FieldName = error.Key,
                            Status = new APIResponseStatus
                            {
                                IsSuccessful = false,
                                Message = new APIResponseMessage
                                {
                                    FriendlyMessage = errorValue,
                                }
                            }
                        };
                        errorResponse = errorModel;
                        break;
                    }
                    if (errorResponse == null)
                        continue;
                    break;
                }
                context.Result = new BadRequestObjectResult(errorResponse);
                return;
            }
            await next();
        }
    }
}
