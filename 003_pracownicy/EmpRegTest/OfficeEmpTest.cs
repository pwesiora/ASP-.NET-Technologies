using EmpReg;
using NUnit.Framework;

namespace EmpRegTest
{
    class OfficeEmployeeTest
    {
        [TestCase(0)]
        [TestCase(500)]
        [TestCase(50)]
        [TestCase(-1)]
        public void CreateOfficeEmployee_InvalidStrengthThrowsException(int iq)
        {
            OfficeEmployee officeEmployee;
            Assert.Throws<System.ArgumentOutOfRangeException>(() => officeEmployee = EmployeeFactory.GetInstance().CreateOfficeEmployee("Gary", "Gygax", 21, 21, new Address(), 123, iq));
        }
    }
}
