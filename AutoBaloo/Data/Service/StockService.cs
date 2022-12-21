using AutoBaloo.Data.Base;

using AutoBaloo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AutoBaloo.Data.Service
{
    public class StockService : EntityBaseRepository<Stock>, IStockService
    {

        private readonly AppDbContext _context;
        public StockService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewStockAsync(NewStockVM data)
        {
            var newStock = new Stock()
            {
                DateStock = data.DateStock,
                QteStock =data.QteStock,
                IdVehicule = data.IdVehicule
            };
            await _context.Stocks.AddAsync(newStock);
            await _context.SaveChangesAsync();
        }

       

        
        

        public async Task<Stock> GetStockByIdAsync(int id)
        {
            var stockDetails = await _context.Stocks
                 .Include(c => c.Vehicule)
                 .FirstOrDefaultAsync(n => n.Id == id);

            return stockDetails;
        }

        public async Task<NewStockDropdownsVM> GetNewStockDropdownsValues()
        {
            var response = new NewStockDropdownsVM()
            {
                Vehicules = await _context.Vehicules.OrderBy(n => n.MarqueVehicule).ToListAsync(),
               
            };

            return response;
        }

        public async Task UpdateStockAsync(NewStockVM data)
        {
            var dbStock = await _context.Stocks.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbStock != null)
            {
                dbStock.DateStock = data.DateStock;
                dbStock.QteStock = data.QteStock;
                dbStock.IdVehicule = data.IdVehicule;
                await _context.SaveChangesAsync();
            }
        }
    }
}
        