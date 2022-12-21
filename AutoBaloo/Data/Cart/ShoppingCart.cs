using AutoBaloo.Data;
using AutoBaloo.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoBaloo.Data.Cart
{
    public class ShoppingCart
    {


        public AppDbContext _context { get; set; }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }
        
        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };

        }

        // Ajouter la voiture dans le panier 
        public void AddItemToCart(Vehicule vehicule)
        {

            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Vehicule.Id == vehicule.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Vehicule = vehicule,
                  
                    montant = 1
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
          
            _context.SaveChanges();
        }

        //Supprimer la voiture  du panier
        public void RemoveItemFromCart(Vehicule vehicule)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Vehicule.Id == vehicule.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
                if(shoppingCartItem.montant > 1)
                {
                    shoppingCartItem.montant--;
                } else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            _context.SaveChanges();
        }

        internal void AddReservationToCart(Reservation reservation)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Reservation.Id == reservation.Id  && n.ShoppingCartId == ShoppingCartId );

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Reservation = reservation,
                    Vehicule=reservation.Vehicule,
                    //Resevation.reservationId=reservation.Id,
                    montant = 1,
                    
                    
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }

            _context.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.Vehicule).ToList());
        }

        public List<ShoppingCartItem> GetReservationCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.Reservation).Include(n=>n.Vehicule).ToList()) ;
        }

        public double GetShoppingCartTotal() => _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Select(n => n.Vehicule.PrixVehicule * n.montant+(n.Vehicule.PrixVehicule * n.montant /100 * n.Vehicule.OptionVehicule)).Sum();
       public double GetReservationCartTotal() => _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId ).Select(n =>/*double.Parse(n.duree)**/n.Vehicule.Prix_par_jour ).FirstOrDefault();
        public async Task ClearShoppingCartAsync()
        {
            var items = await _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).ToListAsync();
            _context.ShoppingCartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
    }
}

    