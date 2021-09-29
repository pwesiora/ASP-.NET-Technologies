using EmpReg;
using NUnit.Framework;
using System;

namespace EmpRegTest
{
    class PhysicalEmployeeTest
    {
        [TestCase(0)]
        [TestCase(900)]
        [TestCase(-4)]
        public void CreatePhysicalEmployee_InvalidStrengthThrowsException(int strength)
        {
            PhysicalEmployee physicalEmployee;
            Assert.Throws<System.ArgumentOutOfRangeException>(() => physicalEmployee = EmployeeFactory.GetInstance().CreatePhysicalEmployee("Richard", "Berg", 28, 5, new Address(), strength));
        }
    }
}
