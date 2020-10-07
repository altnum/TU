using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook_Dictionary
{
    class People
    {
        private string name;
        private string telephoneNumber;

        public People(string name, string telephoneNumber)
        {
            this.name = name;
            this.telephoneNumber = telephoneNumber;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string TelephoneNumber
        {
            get
            {
                return telephoneNumber;
            }
        }

        public override string ToString()
        {
            return "Name: " + name + ", " + "Phone: " + telephoneNumber;
        }
    }
}
