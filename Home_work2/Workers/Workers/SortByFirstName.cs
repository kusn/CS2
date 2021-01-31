using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Workers
{
    class SortByFirstName : IComparer
    {
        int IComparer.Compare(object obj1, object obj2)
        {
            return string.Compare((obj1 as Worker).FirstName, (obj2 as Worker).FirstName);
        }
    }
}
