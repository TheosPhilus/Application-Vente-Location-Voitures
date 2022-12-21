using AutoBaloo.Data.Base;
using AutoBaloo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AutoBaloo.Data.Service
{
    public interface IVehiculeService : IEntityBaseRepository<Vehicule>
    {
        Task<Vehicule> UpdateCarsAsync(Vehicule vehicule);
        
        
    }
}
