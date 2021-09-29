using EmpReg;
using NUnit.Framework;

namespace EmpRegTest
{
    class EmployeeTest
    {
        private Employee[] _sutEmployees;
        
       [SetUp]
       public void Setup()
        {
            var officeEmployee1 = EmployeeFactory.GetInstance().CreateOfficeEmployee("Raymond", "Feist", 21, 0, new Address(), 123, 99);
            var officeEmployee2 = EmployeeFactory.GetInstance().CreateOfficeEmployee("James", "Jacobs", 23, 0, new Address(), 123, 99);
            var officeEmployee3 = EmployeeFactory.GetInstance().CreateOfficeEmployee("Dave", "Arneson", 23, 0, new Address(), 123, 99);
            var officeEmployee4 = EmployeeFactory.GetInstance().CreateOfficeEmployee("Gary", "Gygax", 21, 21, new Address(), 123, 150);
            var physicalEmployee  = EmployeeFactory.GetInstance().CreatePhysicalEmployee("Richard", "Berg", 28, 5, new Address(), 100);
            var trader = EmployeeFactory.GetInstance().CreateTraderEmployee("Aaron", "Allston", 56, 13, new Address(), 23, Efficiency.Low);

            _sutEmployees = new Employee[6] { officeEmployee1, officeEmployee2, officeEmployee3, trader, physicalEmployee, officeEmployee4 };
        }

        [TestCase(0, ExpectedResult = 0)]
        [TestCase(3, ExpectedResult = 780)]
        [TestCase(4, ExpectedResult = 17)]
        [TestCase(5, ExpectedResult = 3150)]
        public int ValueTest_ReturnsCorrectValue(int i)
        {
            return _sutEmployees[i].EmployeeValue();
        }

        [TestCase(0, 1, ExpectedResult = -1)]
        [TestCase(1, 0, ExpectedResult = 1)]
        [TestCase(1, 2, ExpectedResult = 1)]
        [TestCase(2, 1, ExpectedResult = -1)]
        [TestCase(2, 3, ExpectedResult = 1)]
        [TestCase(3, 4, ExpectedResult = -1)]
        public int CompareTest_ReturnsCorrectValue(int i, int j)
        {
            Employee employee1 = _sutEmployees[i];
            Employee employee2 = _sutEmployees[j];
            return employee1.CompareTo(employee2);
        }

    }
}
