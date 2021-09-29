using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marketplace
{
    public class VisitorImplementation : IVisitor
    {
        public decimal _shopTax = .23m;
        public decimal _buyerTax = .17m;
    
        public decimal SellerTax
        {
            get => _shopTax;
            set => _shopTax = value;
        }

        public decimal BuyerTax
        {
            get => _buyerTax;
            set => _buyerTax = value;
        }

        public decimal Visit(SupplyProduct product)
        {
            return product.Price * (1 + _shopTax);
        }

        public decimal Visit(DemandProduct product)
        {
            return product.DemandPrice * (1 + _buyerTax);
        }

        public decimal Visit(SupplyProduct product, decimal margin, decimal inflation)
        {
            if (inflation > 1)
                return product.Margin * 3.5m;
            else if (inflation < -1)
                return product.Margin * 0.9m;
            else return
                    product.Margin;
        }
        public decimal Visit(DemandProduct product, decimal money)
        {
            if (money < product.DemandPrice)
                return product.DemandPrice * (0.9m * (money / product.DemandPrice));
            else
                return product.DemandPrice;
        }
    }
}
