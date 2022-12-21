using AutoBaloo.Data.Base;
using AutoBaloo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoBaloo.Data.Service
{
    public interface IReservationService : IEntityBaseRepository<Reservation>
    {
        Task AddNewReservationAsync(NewReservationVM data);
        Task StoreReservationAsync(List<NewReservationVM> items, string userId);
        Task<List<Reservation>> GetReservationByUserIdAndRoleAsync(string userId, string userRole);
    }
}
