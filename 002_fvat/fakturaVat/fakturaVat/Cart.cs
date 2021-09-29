using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fvat
{
    public class Cart
    {
        private Company RecipientCompany { get; set; }
        private Seller Seller { get; set; }
        public List<CartItem> CartItems { get; set; }
        public Cart(Company recipientCompany, Seller seller, params CartItem[] cartItems)
        {
            RecipientCompany = recipientCompany;
            Seller = seller;
            CartItems = new List<CartItem>(cartItems) {};
        }
        public void addToCart (params CartItem[] cartItems)
        {
            foreach (CartItem item in cartItems)
                CartItems.Add(item);
        }
    }
}
