using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marketplace
{
    public class SupplyProduct : Product, IProduct
    {
        private decimal _price;
        private decimal _margin;
        private decimal _manufacturingCost;

        public SupplyProduct(string name, decimal margin, decimal manufacturingCost)
        {
            this._name = name;
            _margin = margin;
            _manufacturingCost = manufacturingCost;
        }

        public decimal Price
        {
            get => _price;
            set => _price = value;
        }

        public decimal ManufacturingCost
        {
            get => _manufacturingCost;
            set => _manufacturingCost = value;
        }

        public decimal Margin
        {
            get => _margin;
            set => _margin = value;
        }

        public decimal Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

}
