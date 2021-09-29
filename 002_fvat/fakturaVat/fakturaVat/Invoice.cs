using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fvat
{
    public class Invoice
    {
        private static int id = 1;
        public int invId { get;}
        private DateTime DateOfPrint { get; set; }
        private DateTime DateOfPayment { get; set; }
        private DateTime DateOfSale { get; set; }
        private decimal FinalPrice { get; set; }
        private Cart Cart { get; set; }
        public Invoice() { invId = ++id; }
        public Invoice(Cart cart, DateTime dateOfPrint, DateTime dateOfPayment, DateTime dateOfSale)
        {
            invId = ++id;
            Cart = cart;
            DateOfPrint = dateOfPrint;
            FinalPrice = calculateFinalPrice(cart);
            DateOfSale = dateOfSale;
            DateOfPayment = dateOfPayment;
        }
        public decimal calculateFinalPrice(Cart Cart)
        {
            decimal sum = 0m;
            Cart.CartItems.ForEach(CartItem => sum += CartItem.TotalGrossPrice);
            return sum;
        }
    }
}
