using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpReg
{
    public class OfficeValidator: IEmployeeValidator
    {
        private HashSet<int> _officeTitles = new HashSet<int>();

        public void BeforeAddition(Employee employee)
        {
            if (employee is OfficeEmployee officeEmployee)
            {
                if (_officeTitles.Contains(officeEmployee.PositionId))
                {
                    throw new Exception("Office positon is already taken");
                }
            }
        }
        public void PostAddition(Employee employee)
        {
            if (employee is OfficeEmployee officeEmployee)
            {
                _officeTitles.Add(officeEmployee.PositionId);
            }
        }
        public void PostDeletion(Employee employee)
        {
            if (employee is OfficeEmployee officeEmployee)
            {
                _officeTitles.Remove(officeEmployee.PositionId);
            }
        }
    }
}
