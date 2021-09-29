using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpReg
{
    public class TraderEmployee:Employee
    {
        public Efficiency Efficiency { get; set;}
        public decimal Provision { get; set; }

        public TraderEmployee(int employeeId, string name, string surname, int age, int experience, Address address, Efficiency efficiency, decimal provision): base(employeeId, name, surname, age, experience, address)
        {
            Efficiency = efficiency;
            Provision = provision;
        }
        public override int EmployeeValue()
        {
            return ((int)Efficiency) * Experience; 
        }
        public override string ToString()
        {
            return base.ToString() + $"Efficiency: {Enum.GetName(Efficiency.GetType(), Efficiency)}; Provision:{Provision}%";
        }
    }
    public enum Efficiency : int
    {
        Low = 60,
        Medium = 90,
        High = 120
    }
}
