using AutoBaloo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoBaloo.Models
{
    public class GetNewStockDropdownsValues
    {

        public GetNewStockDropdownsValues()
        {
            Vehicules = new List<Vehicule>();
            
        }

        public List<Vehicule> Vehicules { get; set; }
        
    }
}
