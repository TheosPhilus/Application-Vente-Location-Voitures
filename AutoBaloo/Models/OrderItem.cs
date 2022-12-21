using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoBaloo.Models
{
    public class OrderItem
    {

        [Key]
        public int Id { get; set; }

        public int montant { get; set; }
        public double Prix { get; set; }

        public double Prix_par_jour { get; set; }



        public int IdReservation{ get; set; }
        [ForeignKey("IdReservation")]
        public Reservation Reservation { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
