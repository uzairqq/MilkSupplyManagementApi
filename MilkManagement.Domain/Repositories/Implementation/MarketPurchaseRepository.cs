﻿using Microsoft.EntityFrameworkCore;
using MilkManagement.Domain.Dto.ResponseDto;
using MilkManagement.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkManagement.Domain.Repositories.Implementation
{
    public class MarketPurchaseRepository : IMarketPurchaseRepository
    {
        private readonly MilkManagementDbContext _dbContext;

        public MarketPurchaseRepository(MilkManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<MarketPurchaseResponseDto>> GetGrid(DateTime date)
        {
            try
            {
                var result = await _dbContext.MarketPurchase
                    .AsNoTracking()
                    .Where(i => i.CreatedOn.Date == date && !i.IsDeleted)
                    .Select(i => new MarketPurchaseResponseDto()
                    {
                        Id=i.Id,
                        MarketSupplierId=i.MarketSupplierId,
                        MarketSupplierName=i.MarketSupplier.MarketSupplierName,
                        MorningPurchase=i.MorningPurchase,
                        MorningRate=i.MorningRate,
                        MorningAmount=i.MorningAmount,
                        AfternoonPurchase=i.AfternoonPurchase,
                        AfternoonAmount=i.AfternoonAmount,
                        AfternoonRate=i.AfternoonRate,
                        TotalMilk=i.TotalMilk,
                        TotalAmount=i.TotalAmount
                    }).ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public async Task<IEnumerable<MarketSupplierDropDownResponseDto>> GetMarketPurchasetDropDownValues(DateTime dateTime)
        {
            try
            {
                var result = await _dbContext.MarketSupplier
                    .AsNoTracking()
                    .Where(i=>!i.IsDeleted)
                    .Select(i => new MarketSupplierDropDownResponseDto()
                    {
                        MarketSupplierId = i.Id,
                        MarketSupplierName = i.MarketSupplierName
                    }).ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}