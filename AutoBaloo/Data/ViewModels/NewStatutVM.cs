using AutoBaloo.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoBaloo.Models
{
    public class NewStatutVM
    {
        public int Id { get; set; }
        public StatutVehicule StatutVehicule { get; set; }

        //Vehicule 
        [ForeignKey("IdVehicule")]
        public int IdVehicule { get; set; }
       
        
    }
}
