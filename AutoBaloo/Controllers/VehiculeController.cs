using Microsoft.AspNetCore.Mvc;
using AutoBaloo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoBaloo.Data.Service;
using AutoBaloo.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using AutoBaloo.Data.Static;

namespace AutoBaloo.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class VehiculeController : Controller
    {
   


        private readonly IVehiculeService _VehiculeRepository;
        [Obsolete]
        private readonly IHostingEnvironment hostingEnvironment;

        [Obsolete]
        public VehiculeController(IVehiculeService service,IHostingEnvironment hostingEnvironment)
        {
            _VehiculeRepository = service;
            this.hostingEnvironment = hostingEnvironment;
        }



        //affihcer la liste les promotions d'un Véhicule 
        [AllowAnonymous]
        public async Task<IActionResult> Promo()
        {

            var data = await _VehiculeRepository.GetAllAsync();
            return View(data);
        }

        //affihcer la liste des vihécule à louer 
        [AllowAnonymous]
        public async Task<IActionResult> Louer()
        {

            var data = await _VehiculeRepository.GetAllAsync();
            return View(data);
        }


        //afficher la liste des véhicule à vendre 
        [AllowAnonymous]
        public async Task<IActionResult> Vendre()
        {

            var data = await _VehiculeRepository.GetAllAsync();
            return View(data);
        }

        //afficher la liste des véhicule 
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
         
            var data = await _VehiculeRepository.GetAllAsync() ;
            return View(data);
        }

        //Filtrer une voiture à partie son marque et son déscription 
        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _VehiculeRepository.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
               

                var filteredResultNew = allMovies.Where(n => string.Equals(n.MarqueVehicule, searchString, StringComparison.CurrentCultureIgnoreCase) || String.Equals(n.DescriptionVehicule, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allMovies);
        }

        //créer une nouvelle véhicule 

        public IActionResult Create()
        {

            return View();
        }


        [HttpPost]
        [Obsolete]
        public async Task<IActionResult> Create(VehiculeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                // Si la propriété Photo sur l'objet de modèle entrant n'est pas nulle, alors l'utilisateur
                // a sélectionné une image à télécharger.
                if (model.Image != null)
                {
                   // L'image doit être téléchargée dans le dossier images de wwwroot
                     // Pour obtenir le chemin du dossier wwwroot, nous utilisons l'inject
                     // Service HostingEnvironment fourni par ASP.NET Core
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    // Pour nous assurer que le nom du fichier est unique, nous ajoutons un nouveau
                    // valeur GUID et un trait de soulignement au nom du fichier
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    // Utilisez la méthode CopyTo() fournie par l'interface IFormFile pour
                    // copie le fichier dans le dossier wwwroot/images
                    model.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Vehicule newVehicule = new Vehicule
                {
                    MarqueVehicule = model.MarqueVehicule,
                    DescriptionVehicule = model.DescriptionVehicule,
                    Prix_par_jour = model.Prix_par_jour,
                    CouleurVehicule = model.CouleurVehicule,
                    KM = model.KM,
                    OptionVehicule = model.OptionVehicule,
                    TypeCarbu = model.TypeCarbu,
                    DateConstruct = model.DateConstruct,
                    PrixVehicule = model.PrixVehicule,
                    Datearrivée = DateTime.Now.ToString(),
                    typeAchat =model.typeAchat,
                    //Stocke le nom du fichier dans la propriété PhotoPath de l'objet voitures
                    // qui est enregistré dans la table de la base de données des voitures
                    ImageURL = uniqueFileName, 
                };

                await _VehiculeRepository.AddAsync(newVehicule);

                return RedirectToAction("Index", new { id = newVehicule.Id });
            }

            return View();
        }

        // afficher une voiture par son ID 
        public async Task<IActionResult> Details(int id)
        {
            var VehiculeDetails = await _VehiculeRepository.GetByIdAsync(id);
            {
                if (VehiculeDetails == null) return View("Empty");
                return View(VehiculeDetails);
            }
        }


        //Modifier les voitures par son Id 

        [HttpGet]
        public async Task<ViewResult> Edit(int id)
        {
            Vehicule vehicule = await _VehiculeRepository.GetByIdAsync(id);
            if (vehicule == null) return View("NotFound");
            VehiculeEditViewModel vehiculeEditViewModel = new VehiculeEditViewModel
            {
                MarqueVehicule = vehicule.MarqueVehicule,
                DescriptionVehicule = vehicule.DescriptionVehicule,
                Prix_par_jour = vehicule.Prix_par_jour,
                OptionVehicule=vehicule.OptionVehicule,
                CouleurVehicule = vehicule.CouleurVehicule,
                KM = vehicule.KM,
                TypeCarbu = vehicule.TypeCarbu,
                DateConstruct = vehicule.DateConstruct,
                PrixVehicule = vehicule.PrixVehicule,
                typeAchat=vehicule.typeAchat,
                

                //Stocke le nom du fichier dans la propriété PhotoPath de l'objet voitures
                // qui est enregistré dans la table de la base de données des voitures
                ExistingPhotoPath = vehicule.ImageURL
            };
            return View(vehiculeEditViewModel);
        }




        // Grâce à la liaison de modèle, le paramètre de méthode d'action
        // VehiculeEditViewModel reçoit les données postées du formulaire d'édition
        [HttpPost]
        [Obsolete]
        public async Task< IActionResult> Edit(VehiculeEditViewModel model)
        {
            // Vérifie si les données fournies sont valides, sinon restitue la vue d'édition
            // afin que l'utilisateur puisse corriger et soumettre à nouveau le formulaire d'édition
            if (ModelState.IsValid)
            {
                // Récupérer les voitures en cours d'édition à partir de la base de données
                Vehicule vehicule = await _VehiculeRepository.GetByIdAsync(model.Id);
                //Mettre à jour l'objet voitures avec les données de l'objet modèle
                vehicule.MarqueVehicule = model.MarqueVehicule;
                vehicule.DescriptionVehicule = model.DescriptionVehicule;
                vehicule.Prix_par_jour = model.Prix_par_jour;
                vehicule.OptionVehicule = model.OptionVehicule;
                vehicule.CouleurVehicule = model.CouleurVehicule;
                vehicule.KM = model.KM;
                vehicule.TypeCarbu = model.TypeCarbu;
                vehicule.DateConstruct = model.DateConstruct;
                vehicule.PrixVehicule = model.PrixVehicule;
                vehicule.ImageURL = model.ExistingPhotoPath; 
                vehicule.typeAchat = model.typeAchat;
                


                // Si l'utilisateur veut changer la photo, une nouvelle photo sera
                // téléchargé et la propriété Photo sur l'objet modèle reçoit
                // la photo téléchargée. Si la propriété Photo est nulle, l'utilisateur a
                // ne télécharge pas de nouvelle photo et conserve sa photo existante
                if (model.Image != null)
                {
                    // If a new photo is uploaded, the existing photo must be
                    // deleted. So check if there is an existing photo and delete
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath,
                            "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    // Enregistrer la nouvelle photo dans le dossier wwwroot/images et mettre à jour
                    // Propriété PhotoPath de l'objet employé qui sera
                    // éventuellement enregistré dans la base de données
                    vehicule.ImageURL = ProcessUploadedFile(model);
                }

                // Appelez la méthode de mise à jour sur le service de référentiel en lui passant le
                // objet Vehicule  pour mettre à jour les données dans la table de la base de données
               Vehicule updatedVehicule = await _VehiculeRepository.UpdateCarsAsync(vehicule);
              

                return RedirectToAction("index");
            }

            return View(model);
        }


        // Supprimer une voiture 
        public async Task<IActionResult> Delete (int Id)
        {
            Vehicule vehicule = await _VehiculeRepository.GetByIdAsync(Id);
            if (vehicule == null) return View("NotFound");
            return View(vehicule);
        }

        //Le route vers la page de vérification pour supprimer une voiture
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            Vehicule vehicule = await _VehiculeRepository.GetByIdAsync(Id);
            if (vehicule == null) return View("NotFound");
            await _VehiculeRepository.DeleteAsync(Id);
             return RedirectToAction("index");
        }

        [Obsolete]
        private string ProcessUploadedFile(VehiculeEditViewModel model)
        {
            string uniqueFileName = null;

            if (model.Image != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

    }




}



