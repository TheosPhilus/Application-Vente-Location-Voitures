using AutoBaloo.Data.Base;
using AutoBaloo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoBaloo.Data.Service
{
    public class VehiculeService : EntityBaseRepository<Vehicule>, IVehiculeService
    {

        private readonly AppDbContext _context;
        public VehiculeService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Vehicule> UpdateCarsAsync(Vehicule vehicule)
        {
            _context.Update(vehicule);
            await _context.SaveChangesAsync();
            return vehicule;
        }
    }
}
