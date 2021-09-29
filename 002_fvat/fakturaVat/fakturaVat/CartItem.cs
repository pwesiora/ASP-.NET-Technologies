using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fvat
{
    public class CartItem
    {
        private Product  _product { get; set; }
        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            private set
            {
                if (value > 0)
                    _quantity = value;
                else
                    throw new ArgumentException();
            }
        }
        public decimal TotalPrice => _product.Price * Quantity;
        public decimal TotalGrossPrice => _product.AfterTaxPrice * _quantity;
        public CartItem (Product product, int quantity)
        {
            _product = product;
            Quantity = quantity;
        }

    }
}
