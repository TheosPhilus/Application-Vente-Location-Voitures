using AutoBaloo.Data;
using AutoBaloo.Data.Enums;
using AutoBaloo.Data.Service;
using AutoBaloo.Data.Static;
using AutoBaloo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoBaloo.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class StatutController : Controller
    {
        private readonly IStatutService _StatutRepository;

        public StatutController(IStatutService context)
        {
            _StatutRepository = context;
        }


        //Get : Stock/

        public async Task<IActionResult> Index()
        {
            var allMovies = await _StatutRepository.GetAllAsync(n => n.Vehicule);
            return View(allMovies);
        }

       

        //GET: Stock/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var stockDetail = await _StatutRepository.GetByIdAsync(id);
            return View(stockDetail);
        }

        //GET: Movies/Create
        public async Task<IActionResult> Create()
        {
            var statutDropdownsData = await _StatutRepository.GetNewStatutDropdownsValues();

            ViewBag.Vehicules = new SelectList(statutDropdownsData.Vehicules, "Id", "MarqueVehicule");
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewStatutVM Vehicule)
        {
            if (!ModelState.IsValid)
            {
                var StatutDropdownsData = await _StatutRepository.GetNewStatutDropdownsValues();


                ViewBag.Vehicules = new SelectList(StatutDropdownsData.Vehicules, "Id", "MarqueVehicule");
                return View(Vehicule);
            }

            await _StatutRepository.AddNewStatutAsync(Vehicule);
            return RedirectToAction(nameof(Index));
        }


        //GET: Movies/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var statutDetails = await _StatutRepository.GetByIdAsync(id);
            if (statutDetails == null) return View("NotFound");

            var response = new NewStatutVM()
            {
                Id = statutDetails.Id,
               
                StatutVehicule= statutDetails.StatutVehicule,
                IdVehicule = statutDetails.IdVehicule
            };

            var statutDropdownsData = await _StatutRepository.GetNewStatutDropdownsValues();
            ViewBag.Vehicules = new SelectList(statutDropdownsData.Vehicules, "Id", "MarqueVehicule");
            
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewStatutVM statut)
        {
            if (id != statut.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var StatutDropdownsData = await _StatutRepository.GetNewStatutDropdownsValues();

                ViewBag.Vehicules = new SelectList(StatutDropdownsData.Vehicules, "Id", "MarqueVehicule");
                

                return View(statut);
            }

            await _StatutRepository.UpdateStatutAsync(statut);
            return RedirectToAction(nameof(Index));
        }


        //GET: Movies/delete/1
        public async Task<IActionResult> delete(int id)
        {
            await _StatutRepository.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }


    }
}
