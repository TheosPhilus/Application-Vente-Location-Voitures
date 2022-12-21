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
    public class StatutService : EntityBaseRepository<Statut>, IStatutService
    {

        private readonly AppDbContext _context;
        public StatutService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewStatutAsync(NewStatutVM data)
        {
            var newStatut= new Statut()
            {
                StatutVehicule = data.StatutVehicule,
               
                IdVehicule = data.IdVehicule
            };
            await _context.Statuts.AddAsync(newStatut);
            await _context.SaveChangesAsync();
        }

       

        
        

        public async Task<Statut> GetStatutByIdAsync(int id)
        {
            var statutDetails = await _context.Statuts
                 .Include(c => c.Vehicule)
                 .FirstOrDefaultAsync(n => n.Id == id);

            return statutDetails;
        }

        public async Task<NewStatutDropdownsVM> GetNewStatutDropdownsValues()
        {
            var response = new NewStatutDropdownsVM()
            {
                Vehicules = await _context.Vehicules.OrderBy(n => n.MarqueVehicule).ToListAsync(),
               
            };

            return response;
        }

        public async Task UpdateStatutAsync(NewStatutVM data)
        {
            var dbStatut = await _context.Statuts.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbStatut != null)
            {
                dbStatut.StatutVehicule = data.StatutVehicule;
                dbStatut.IdVehicule = data.IdVehicule;
                await _context.SaveChangesAsync();
            }
        }
    }
}
        