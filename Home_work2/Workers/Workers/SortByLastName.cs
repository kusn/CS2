using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Workers
{
    class SortByLastName : IComparer
    {
        public int Compare(object x, object y)
        {
            return string.Compare((x as Worker).LastName, (y as Worker).LastName);
        }
    }
}
