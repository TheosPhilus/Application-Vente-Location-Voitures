using AutoBaloo.Data.Base;

using AutoBaloo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AutoBaloo.Data.Service
{
    public interface IStockService: IEntityBaseRepository<Stock>
    {
        Task<Stock> GetStockByIdAsync(int id);
        Task<NewStockDropdownsVM> GetNewStockDropdownsValues();
        Task AddNewStockAsync(NewStockVM data);
        Task UpdateStockAsync(NewStockVM data);
        
        
    }
}
