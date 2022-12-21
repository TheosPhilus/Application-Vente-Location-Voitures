using AutoBaloo.Data.Cart;
using AutoBaloo.Data.Service;
using AutoBaloo.Data.Services;
using AutoBaloo.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AutoBaloo.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IVehiculeService _VehiculeService;
        private readonly IReservationService _ReservationService;
        private readonly IOrdersService _ordersService;


        private readonly ShoppingCart _shoppingCart;
        public OrdersController( ShoppingCart shoppingCart, IVehiculeService vehiculeService , IReservationService reservationService, IOrdersService ordersService)
        {
            _shoppingCart = shoppingCart;
            _VehiculeService = vehiculeService;
            _ordersService = ordersService;
            _ReservationService = reservationService;
        }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
            return View(orders);
        }
        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }

        //Mettre la voiture dans le panier pour effactuer l'achat 
        
        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _VehiculeService.GetByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }


        //Mettre la Reservation dans le panier pour effactuer l'achat 
        public async Task<IActionResult> AddReservationToShoppingCart(int id)
        {
            var item = await _ReservationService.GetByIdAsync(id);
            await _ReservationService.GetAllAsync(n => n.Vehicule);


            if (item != null)
            {
                _shoppingCart.AddReservationToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }



        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _VehiculeService.GetByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();

            return View("OrderCompleted");
        }
    }
}
