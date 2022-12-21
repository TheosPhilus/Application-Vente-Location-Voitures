using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoBaloo.Models
{
    public class NewStockVM
    {
        public int Id { get; set; }
        [Display(Name = "Date de stock ")]
        public string DateStock { get; set; }
        [Display(Name = "Quantité de stock ")]
        public int QteStock { get; set; }


        [Display(Name = "Ajouter Vehicule ")]
        [Required(ErrorMessage = "La marque de Vehicule est Obligatoire  ")]
      
        public int IdVehicule { get; set; }


    }
}
