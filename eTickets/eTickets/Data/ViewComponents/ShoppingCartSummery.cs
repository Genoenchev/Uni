using eTickets.Data.Cart;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.ViewComponents
{
    public class ShoppingCartSummery : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartSummery(ShoppingCart shoppingCart)
        {
            this._shoppingCart = shoppingCart;
        }
        public IViewComponentResult Invoke()
        {
            var items = this._shoppingCart.GetShoppingCartItems();

            return View(items.Count());
        }
    }
}
