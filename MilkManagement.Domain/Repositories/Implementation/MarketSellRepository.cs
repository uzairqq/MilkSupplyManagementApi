using AutoMapper;
using MilkManagement.Domain.Entities.Market;
using MilkManagement.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilkManagement.Domain.Repositories.Implementation
{
   public class MarketSellRepository : EfRepository<MarketSell>, IMarketSellRepository
    {
        private readonly MilkManagementDbContext _dbContext;

        public MarketSellRepository(MilkManagementDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
        }
    }
}
