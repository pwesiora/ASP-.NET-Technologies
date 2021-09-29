using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpReg
{
    public class PhysicalEmployee : Employee
    {
        private int _strength;
        public int Strength
        {
            get => _strength;
            set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("Strength value is not valid - should be between 1 and 100");
                }
                else
                {
                    _strength = value;
                }
            }
        }
        public decimal Provision { get; set; }

        public PhysicalEmployee(int employeeId, string name, string surname, int age, int experience, Address address, int strength) : base(employeeId, name, surname, age, experience, address)
        {
            Strength = strength;
        }
        public override int EmployeeValue()
        {
            return  Experience * Strength / Age;
        }
        public override string ToString()
        {
            return base.ToString() + $"Strength: {Strength};";
        }
    }
}
