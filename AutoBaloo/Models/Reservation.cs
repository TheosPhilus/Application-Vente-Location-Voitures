
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
    public class Reservation:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string Duree { get; set; }
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        public double montantReservation {get;set;}
        
       

        //Vehicule 
        public int IdVehicule { get; set; }
        [ForeignKey("IdVehicule")]
        public Vehicule Vehicule { get; set; }

       
    }
}
