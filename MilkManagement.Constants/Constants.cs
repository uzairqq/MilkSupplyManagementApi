using System;
using System.Collections.Generic;
using System.Text;

namespace MilkManagement.Constants
{
        public static class ResponseMessages
        {
            public const string InsertionSuccessMessage = "Record has SuccessFully Inserted";
            public const string InsertionFailureMessage = "Record Insertion Failed";
            public const string UpdateSuccessMessage = "Record Successfully Updated";
            public const string UpdateFailureMessage = "Record Updation Failed";
            public const string DeleteSuccessMessage = "Record SuccessFully Deleted";
            public const string DeleteFailureMessage =  "Record Deletion Failed";
            public const string CustomerNameAvailable = "Customer Name Not In Use";
            public const string CustomerNameNotAvailable = "Customer Name Already In Use";
            public const string RatesAssignedToCustomer = "Rates Already Assigned To Customer";
        }
    }

