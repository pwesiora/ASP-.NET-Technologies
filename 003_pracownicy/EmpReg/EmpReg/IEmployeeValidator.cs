using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpReg
{
    public interface IEmployeeValidator
    {
        void BeforeAddition(Employee employee);
        void PostAddition(Employee employee);
        void PostDeletion(Employee employee);
    }
}
