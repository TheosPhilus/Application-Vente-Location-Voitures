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
    public class StockController : Controller
    {
        private readonly IStockService _StockRepository;

        public StockController(IStockService context)
        {
            _StockRepository = context;
        }


        //Get : Stock/

        public async Task<IActionResult> Index()
        {
            var allMovies = await _StockRepository.GetAllAsync(n => n.Vehicule);
            return View(allMovies);
        }

       

        //GET: Stock/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var stockDetail = await _StockRepository.GetByIdAsync(id);
            return View(stockDetail);
        }

        //GET: Stock/Create
        public async Task<IActionResult> Create()
        {
            var stockDropdownsData = await _StockRepository.GetNewStockDropdownsValues();

            ViewBag.Vehicules = new SelectList(stockDropdownsData.Vehicules, "Id", "MarqueVehicule");
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewStockVM stock)
        {
            if (!ModelState.IsValid)
            {
                var StockDropdownsData = await _StockRepository.GetNewStockDropdownsValues();


                ViewBag.Vehicules = new SelectList(StockDropdownsData.Vehicules, "Id", "MarqueVehicule");
                return View(stock);
            }

            await _StockRepository.AddNewStockAsync(stock);
            return RedirectToAction(nameof(Index));
        }


        //GET: Stock/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var stockDetails = await _StockRepository.GetByIdAsync(id);
            if (stockDetails == null) return View("NotFound");

            var response = new NewStockVM()
            {
                Id = stockDetails.Id,
                DateStock = stockDetails.DateStock,
                QteStock = stockDetails.QteStock,
                IdVehicule = stockDetails.IdVehicule
            };

            var stockDropdownsData = await _StockRepository.GetNewStockDropdownsValues();
            ViewBag.Vehicules = new SelectList(stockDropdownsData.Vehicules, "Id", "MarqueVehicule");
            
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewStockVM stock)
        {
            if (id != stock.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var StockDropdownsData = await _StockRepository.GetNewStockDropdownsValues();

                ViewBag.Vehicules = new SelectList(StockDropdownsData.Vehicules, "Id", "MarqueVehicule");
                

                return View(stock);
            }

            await _StockRepository.UpdateStockAsync(stock);
            return RedirectToAction(nameof(Index));
        }


        //GET: Stock/delete/1
        public async Task<IActionResult> delete(int id)
        {
            await _StockRepository.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }



    }
}
