using EmpReg;
using NUnit.Framework;
using System;

namespace EmpRegTest
{
    class RegistryTest
    {
        private Registry _sut;

        private Employee[] _employees;

        [SetUp]
        public void Setup()
        {
            _sut = new Registry(new OfficeValidator());
            var officeEmp1 = EmployeeFactory.GetInstance().CreateOfficeEmployee("Raymond", "Feist", 21, 0, new Address() { City = "Redmond" }, 122, 99);
            var officeEmp2 = EmployeeFactory.GetInstance().CreateOfficeEmployee("James", "Jacobs", 23, 0, new Address() { City = "Kraków" }, 123, 99);
            var officeEmp3 = EmployeeFactory.GetInstance().CreateOfficeEmployee("Dave", "Arneson", 23, 0, new Address() { City = "Redwood City" }, 123, 99);
            var physicalEmp1 = EmployeeFactory.GetInstance().CreatePhysicalEmployee("Richard ", "Berg", 40, 5, new Address() { City = "Redmond" }, 90);
            var trader1 = EmployeeFactory.GetInstance().CreateTraderEmployee("Aaron", "Allston", 56, 13, new Address() { City = "Redwood City" }, 15, Efficiency.Medium);

            _employees = new Employee[5] { officeEmp1, officeEmp2, officeEmp3, trader1, physicalEmp1 };
        }

        [Test]
        public void AddEmployees_ExecutesCorrectly()
            {
                _sut.AddEmployees(_employees[0], _employees[1], _employees[3], _employees[4]);
            }

        [Test]
        public void AddEmployees_ThrowsExcpetionJobTitleError()
            {
                Assert.Throws<Exception>(()=> _sut.AddEmployees(_employees));
            }

        [Test]
        public void DeleteEmployee_ExecutesCorrectly()
            {
                _sut.AddEmployees(_employees[0], _employees[1], _employees[3], _employees[4]);
                _sut.DeleteEmployee(_employees[0].EmployeeId);
                Assert.That(_sut.GetEmployeeList().Count, Is.EqualTo(3));
            }

        [Test]
        public void DeleteEmployee_ThrowsExcpetionNotExisting()
            {
                _sut.AddEmployees(_employees[0], _employees[1], _employees[3], _employees[4]);
                Assert.Throws<Exception>(() => _sut.DeleteEmployee(-1));
            }

        [Test]
        public void SortEmployees_ExecutesCorrectly()
            {
                _sut.AddEmployees(_employees[0], _employees[1], _employees[3], _employees[4]);
                var employeeList = _sut.GetEmployeeList().ToArray();
                Assert.That(employeeList[0], Is.EqualTo(_employees[3]));
                Assert.That(employeeList[1], Is.EqualTo(_employees[4]));
                Assert.That(employeeList[2], Is.EqualTo(_employees[0]));
                Assert.That(employeeList[3], Is.EqualTo(_employees[1]));
        }
        [TestCase("Redmond", ExpectedResult = 2)]
        [TestCase("Redwood City", ExpectedResult = 1)]
        [TestCase("Kraków", ExpectedResult = 1)]
        [TestCase("Austin", ExpectedResult = 0)]
        public int GetEmployeesByCity(string city)
        {
            _sut.AddEmployees(_employees[0], _employees[1], _employees[3], _employees[4]);
            var employeeList = _sut.GetEmployeeListByCity(city);
            return employeeList.Count;
        }
        [Test]
        public void GetEmployeesByCityQuality_ExecutesCorrectly()
        {
            _sut.AddEmployees(_employees[0], _employees[1], _employees[3], _employees[4]);
            var employeeList = _sut.GetEmployeeListByCity("Redmond");
            Assert.That(employeeList[0].Address.City, Is.EqualTo("Redmond"));
            Assert.That(employeeList[1].Address.City, Is.EqualTo("Redmond"));
        }
    }
}
