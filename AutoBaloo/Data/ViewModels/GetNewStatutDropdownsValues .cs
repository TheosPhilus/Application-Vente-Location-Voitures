using AutoBaloo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoBaloo.Models
{
    public class GetNewStatutDropdownsValues
    {

        public GetNewStatutDropdownsValues()
        {
            Vehicules = new List<Vehicule>();
            
        }

        public List<Vehicule> Vehicules { get; set; }
        
    }
}
