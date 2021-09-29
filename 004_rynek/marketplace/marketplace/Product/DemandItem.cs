using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marketplace
{
    public class DemandProduct : Product, IProduct
    {
        private decimal _demandPrice;
        private decimal _demandNetPrice;
        private int _desiredQuantity;

        public DemandProduct(string name, decimal demandNetPrice, int desiredQuantity)
        {
            this._name = name;
            _demandNetPrice = demandNetPrice;
            _desiredQuantity = desiredQuantity;
        }

        public decimal DemandPrice
        {
            get => _demandPrice;
            set => _demandPrice = value;
        }

        public decimal DemandNetPrice
        {
            get => _demandNetPrice;
            set => _demandNetPrice = value;
        }

        public int DesiredQuantity
        {
            get => _desiredQuantity;
            set => _desiredQuantity = value;
        }

        public decimal Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

}
