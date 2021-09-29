using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpReg
{
    public abstract class Employee: IComparable<Employee>
    {
        public int EmployeeId { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
        public Address Address { get; set; }
        public abstract int EmployeeValue();

        protected Employee(int employeeId, string name, string surname, int age, int experience, Address address)
        {
            EmployeeId = employeeId;
            Name = name;
            Surname = surname;
            Age = age;
            Experience = experience;
            Address = address;
        }
        public override int GetHashCode()
        {
            return EmployeeId;
        }
        public override string ToString()
        {
            return $"Name: {Name}; Surname: { Surname}; Experience: { Experience}; Age: { Age}; Value: { EmployeeValue()}; ";
        }
        public int CompareTo(Employee other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var employeeExperienceComparison = Experience.CompareTo(other.Experience);
            if (employeeExperienceComparison != 0) return -employeeExperienceComparison;
            var ageComparison = Age.CompareTo(other.Age);
            if (ageComparison != 0) return ageComparison;
            var surnameComparison = Surname.CompareTo(other.Surname);
            if (surnameComparison != 0) return surnameComparison;
            return 0;
        }
    }
}
