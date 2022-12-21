using AutoBaloo.Data.Base;
using AutoBaloo.Data.Enums;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoBaloo.Models
{
    public class Statut:IEntityBase
    {
        [Key]

        public int Id  { get; set; }
        [Display(Name = "Satut Véhicule  ")]
        public StatutVehicule StatutVehicule { get; set; }
       
        


        //Vehicule 
        [Display(Name = "Marque Véhicule  ")]
        [Required(ErrorMessage = "Il faut choisir une Véhicule ")]
        public int IdVehicule { get; set; }
        [ForeignKey("IdVehicule")]
        public Vehicule Vehicule { get; set; }




    }
}
