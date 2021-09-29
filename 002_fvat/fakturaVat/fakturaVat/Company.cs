using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fvat
{
    public class Company
    {
        private string _name { get; set; }
        private string _address { get; set; }
        private string _nip;
        public string Nip
        {
            get => _nip;
            private set
            {
                if ((value.All(char.IsDigit)) && (value.Length == 10))
                {
                    _nip = value;
                }
                else
                    throw new ArgumentException();
            }
        }

        public Company(string name, string address, string nip)
        {
           _name = name;
           _address = address;
           Nip = nip;
        }

    }
}
