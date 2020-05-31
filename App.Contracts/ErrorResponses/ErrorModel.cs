using App.Contracts.Response;
using System;
using System.Collections.Generic;

namespace App.Contracts.ErrorResponses
{
    public class ErrorModel
    {
        public string FieldName { get; set; }
        public string Message { get; set; }
    }

    public class NewErrorModel
    {
        public string FieldName { get; set; }
        public APIResponseStatus Status { get; set; }
    }
}
