using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpReg
{
    public class TraderValidator: IEmployeeValidator
    {
        public void BeforeAddition(Employee employee) { }
        public void PostAddition(Employee employee) { }
        public void PostDeletion(Employee employee) { }
    }
}
