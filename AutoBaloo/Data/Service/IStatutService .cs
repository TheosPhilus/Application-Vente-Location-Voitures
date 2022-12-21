using AutoBaloo.Data.Base;

using AutoBaloo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AutoBaloo.Data.Service
{
    public interface IStatutService : IEntityBaseRepository<Statut>
    {
        Task<Statut> GetStatutByIdAsync(int id);
        Task<NewStatutDropdownsVM> GetNewStatutDropdownsValues();
        Task AddNewStatutAsync(NewStatutVM data);
        Task UpdateStatutAsync(NewStatutVM data);
        
        
    }
}
