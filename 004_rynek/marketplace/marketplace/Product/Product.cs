using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marketplace
{
    public abstract class Product
    {
        public Product(){}

        protected string _name;
        protected decimal _tax;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public decimal Tax
        {
            get => _tax;
            set => _tax = value;
        }

    }
}
