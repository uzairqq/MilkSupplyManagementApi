using System;
using System.Collections.Generic;
using System.Text;

namespace MilkManagement.Constants
{
   public class ResponseMessageDto
    {
        public int Id { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string SuccessMessage { get; set; }
        public string FailureMessage { get; set; }
        public string ExceptionMessage { get; set; }
    }
}
