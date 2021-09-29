using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marketplace
{
    public interface IVisitor
    {
        decimal Visit(SupplyProduct product);
        decimal Visit(DemandProduct product);
    }
}
