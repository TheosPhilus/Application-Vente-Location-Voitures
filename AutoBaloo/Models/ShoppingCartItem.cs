using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoBaloo.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public Vehicule Vehicule { get; set; }
       
        public Reservation Reservation { get; set; }
        public int montant { get; set; }
        


        public string ShoppingCartId { get; set; }

        
    }
}
