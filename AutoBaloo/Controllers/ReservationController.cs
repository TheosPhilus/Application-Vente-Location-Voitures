using AutoBaloo.Data;
using AutoBaloo.Data.Cart;
using AutoBaloo.Data.Service;
using AutoBaloo.Data.Services;
using AutoBaloo.Data.ViewModels;
using AutoBaloo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AutoBaloo.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        private readonly IReservationService _context;
        private readonly IOrdersService _ordersService;

        private readonly ShoppingCart _shoppingCart;
        public ReservationController(IReservationService context, ShoppingCart shoppingCart, IOrdersService ordersService)
        {
            _context = context;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
        }


        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetReservationCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetReservationCartTotal()
            };
            return View(response);
        }


        //public async Task<IActionResult> AddItemToShoppingCart(int id)
        //{

        //    var item = await _context.GetByIdAsync(id);

        //    if (item != null)
        //    {
        //        _shoppingCart.AddReservationToCart(item);
        //    }
        //    return RedirectToAction(nameof(ShoppingCart));
        //}


        public async Task<IActionResult> Index()
        {
            var allReservations = await _context.GetAllAsync(n => n.Vehicule);
            return View(allReservations); ;
        }


        //public async Task<IActionResult> List()
        //{
        //    string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    string userRole = User.FindFirstValue(ClaimTypes.Role);

        //    await _context.GetReservationByUserIdAndRoleAsync(userId, userRole);

        //        var items = await _context.GetAllAsync(n => n.Vehicule);

        //    return View(items);
        //}

        //Get: Reservation/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(NewReservationVM Reservation)
        {
            var item=await _context.GetAllAsync(n => n.Vehicule);
            
            if (!ModelState.IsValid)
            {
                return View(Reservation);
            }
            if (item != null)
            {
                await _context.AddNewReservationAsync(Reservation);
            }
            return RedirectToAction("Index", new { id = Reservation.Id});
        }





        //GET: Reservation/delete/1
        public async Task<IActionResult> delete(int id)
        {
            await _context.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }



        //Mettre la Reservation dans le panier pour effactuer l'achat 
        public async Task<IActionResult> AddReservationToShoppingCart(int id)
        {
            var item = await _context.GetByIdAsync(id);
            await _context.GetAllAsync(n => n.Vehicule);


            if (item != null)
            {
                _shoppingCart.AddReservationToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }



    }
}
