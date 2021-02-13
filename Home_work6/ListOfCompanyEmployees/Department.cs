using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfCompanyEmployees
{
    class Department
    {
        string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                value = name;
            }
        } 

        public Department(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
