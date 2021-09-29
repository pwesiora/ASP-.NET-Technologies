using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpReg
{
    public class EmployeeFactory
    {
        private static EmployeeFactory _factory;
        private int _employeeId;

        private EmployeeFactory (int initEmployeeId)
        {
            _employeeId = initEmployeeId;
        }
        public static EmployeeFactory GetInstance()
        {
            if (_factory is null)
            {
                return _factory = new EmployeeFactory(0);
            }
            else
                return _factory;
        }
        public OfficeEmployee CreateOfficeEmployee (string name, string surname, int age, int experience, Address address, int positionId, int iq)
        {
            _employeeId++;
            return new OfficeEmployee(_employeeId, name, surname, age, experience, address, positionId, iq);
        }
        public PhysicalEmployee CreatePhysicalEmployee(string name, string surname, int age, int experience, Address address, int strength)
        {
            _employeeId++;
            return new PhysicalEmployee(_employeeId, name, surname, age, experience, address, strength);
        }
        public TraderEmployee CreateTraderEmployee(string name, string surname, int age, int experience, Address address, decimal provision, Efficiency efficiency)
        {
            _employeeId++;
            return new TraderEmployee(_employeeId, name, surname, age, experience, address, efficiency, provision);
        }
    }
}
