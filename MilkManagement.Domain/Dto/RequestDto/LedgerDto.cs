using System.Collections.Generic;
using MilkManagement.Domain.Dto.ResponseDto;
using MilkManagement.Domain.Entities;

namespace MilkManagement.Domain.Dto {
    public class LedgerDto {

        public List<SupplierSuppliedResponseDto> SupplierSupplied { get; set; }

        public List<CustomerSuppliedResponseDto> CustomerSupplied { get; set; }

        public List<DailyExpenseDto> Expenses { get; set; }

        // public int TotalAllHotelIncomeAmount { get; set; }
        // public string TotalAllHotelMilk { get; set; }

        // public int TotalDailyHotelIncomeAmount { get; set; }

        // public string TotalDailyHotelMilk { get; set; }

        // public int TotalWeeklyHotelIncomeAmount { get; set; }

        // public string TotalWeeklyHotelMilk { get; set; }

        // public int TotalExpenseAmount { get; set; }

        // public int TotalMarketPurchaseAmount { get; set; }

        // public string TotalMarketPurchaseMilk { get; set; }

        // public int TotalMarketSellAmount { get; set; }

        // public string TotalMarketSellMilk { get; set; }

    }
}