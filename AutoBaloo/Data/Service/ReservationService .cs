using AutoBaloo.Data.Base;
using AutoBaloo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoBaloo.Data.Service
{
    public class ReservationService : EntityBaseRepository<Reservation>, IReservationService
    {

        private readonly AppDbContext _context;
        public ReservationService(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task AddNewReservationAsync(NewReservationVM data)
        {

            var newReservation = new Reservation()
            {
                DateDebut = data.DateDebut,
                DateFin = data.DateFin,
                IdVehicule = data.Id,
                Duree = (data.DateFin - data.DateDebut).ToString(),
               
                //Vehicule=data.IdVehicule,
                //montantReservation = data.Vehicule.Prix_par_jour * double.Parse(data.Duree),
            };
            await _context.Reservations.AddAsync(newReservation);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Reservation>> GetReservationByUserIdAndRoleAsync(string userId, string userRole)
        {
            var orders = await _context.Reservations.Include(n => n.Vehicule).Include(n => n.User).ToListAsync();

            if (userRole != "Admin")
            {
                orders = orders.Where(n => n.UserId == userId).ToList();
            }

            return orders;
        }

        public async Task StoreReservationAsync (List<NewReservationVM> items, string userId)
        {
            var order = new Reservation()
            {
                UserId = userId,
                
            };

            await _context.Reservations.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new Reservation()
                {
                    DateDebut = item.DateDebut,
                    DateFin = item.DateFin,
                    Duree = item.Duree,
                    IdVehicule =item.Id,
                    
                };
                await _context.Reservations.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();

        }

        
    }

}

