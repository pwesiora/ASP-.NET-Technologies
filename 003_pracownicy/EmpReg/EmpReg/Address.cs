using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpReg
{
    public class Address
    {
        public string Street { get; set; }
        public int BuildingNumber { get; set; }
        public int? ApartmentNumber { get; set; }
        public string City { get; set; }

        public Address(){}
        public Address (string street, int buildingNumber, int? apartmentNumber, string city)
        {
            Street = street;
            BuildingNumber = buildingNumber;
            ApartmentNumber = apartmentNumber;
            City = city;
        }
    }
}
