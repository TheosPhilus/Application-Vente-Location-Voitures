using AutoBaloo.Data.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AutoBaloo.Models
{
    public class VehiculeCreateViewModel
    {
        [Display(Name = "Marque")]
        [Required(ErrorMessage = "La marque d'une voiture est obligatoire")]
        public string MarqueVehicule { get; set; }


        [Display(Name = "Carburant")]
        [Required(ErrorMessage = "Type de carburant est obligatoire")]
        public string TypeCarbu { get; set; }

        [Display(Name = "Prix")]
        [Required(ErrorMessage = "prix d'une voiture est obligatoire ")]
        public double PrixVehicule { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "la modéle d'une voiture est obligatoire")]
        public string DescriptionVehicule { get; set; }

        [Display(Name = "Date de construction")]
        [Required(ErrorMessage = "Date de construction est obligatoire ")]
        public string DateConstruct { get; set; }

        [Display(Name = "Kilometrage")]
        [Required(ErrorMessage = "Il faut mettre la kilometrage d'une voiture ")]
        public string KM { get; set; }

        [Display(Name = "Remise")]

        public double OptionVehicule { get; set; }

        [Display(Name = "Couleur")]
        [Required(ErrorMessage = "Il faut mettre la couleur d'une voiture ")]
        public string CouleurVehicule { get; set; }


       
        public string Datearrivée  { get; set; }
        [DataType(DataType.Upload)]
        [Display(Name = "Télécharger une photo")]
        [Required(ErrorMessage = "Veuillez choisir l'image à télécharger.")]
        public IFormFile Image { get; set; }


        

        [Display(Name = "prix/Jours ")]
        [Required(ErrorMessage = "Il faut mettre prix par jours ")]
        public double Prix_par_jour { get; set; }

        [Display(Name = "Type D'achat  ")]
        [Required(ErrorMessage = "Il faut mettre le type D'achat  ")]
        public TypeAchat typeAchat { get; set; }

    }
}