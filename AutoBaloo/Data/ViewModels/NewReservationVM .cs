using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoBaloo.Models
{
    public class NewReservationVM
    {
        public int Id { get; set; }

        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string Duree { get; set; }


        public double montantReservation { get; set; }



        //Vehicule 
        public int IdVehicule { get; set; }
        public Vehicule Vehicule { get; set; }

    }
}
