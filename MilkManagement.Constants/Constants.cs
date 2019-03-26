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
        public const string DeleteFailureMessage = "Record Deletion Failed";
        public const string CustomerNameAvailable = "Customer Name Not In Use";
        public const string CustomerNameNotAvailable = "Customer Name Already In Use";
        public const string RatesAssignedToCustomer = "Rates Already Assigned To Customer";
        public const string RatesAssignedToSupplier = "Rates Already Assigned To Supplier";
        public const string CustomerAlreadyInsertedInThisDate = "Customer Already Inserted In This Date";
        public const string ExpenseNameAvailable = "Expense Name Not In Use";
        public const string ExpenseNameNotAvailable = "Expense Name Already In Use";
        public const string SupplierNameNotAvailable = "Supplier Name Already In Use";
        public const string ExpenseAlreadyHaveOnThisDate = "Expense Already Have On This Date";
        public const string ExpenseListSuccessfullyInserted = "Expense Lists Successfully Inserted";
        public const string ExpenseListInsertionFailed = "Expense Lists Insertion Failed";
        public const string CustomerSuppliedListSuccessfullyInserted = "Customer Supplied Successfully Inserted";
        public const string CustomerSuppliedListFailed = "Customer Supplied Failed";
        public const string MarketSupplierNameNotAvailable = "Market Supplier Name Not Available";



    }
}

