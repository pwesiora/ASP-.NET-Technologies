using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpReg
{
    public class OfficeEmployee : Employee
    {
        public int PositionId { get; }
        private int _iq;
        public int Iq
        {
            get => _iq;
            set
            {
                if (value < 70 || value > 150)
                {
                    throw new ArgumentOutOfRangeException("IQ value is not valid - should be between 70 and 150");
                }
                else
                {
                    _iq = value;
                }
            }
        }
        public decimal Provision { get; set; }

        public OfficeEmployee(int employeeId, string name, string surname, int age, int experience, Address address, int positionId, int iq) : base(employeeId, name, surname, age, experience, address)
        {
            PositionId = positionId;
            Iq = iq;
        }
        public override int EmployeeValue()
        {
            return Iq * Experience;
        }
        public override string ToString()
        {
            return base.ToString() + $"IQ: {Iq};";
        }
    }
}
