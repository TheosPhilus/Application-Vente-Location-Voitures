using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoBaloo.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Le nom complet")]
        [Required(ErrorMessage = "Le nom complet est requis")]
        public string FullName { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Adresse e-mail est nécessaire")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirmez le mot de passe")]
        [Required(ErrorMessage = "Confirmer le mot de passe est requis")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Les mots de passe ne correspondent pas")]
        public string ConfirmPassword { get; set; }
    }
}
