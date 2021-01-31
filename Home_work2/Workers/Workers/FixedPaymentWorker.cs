using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    class FixedPaymentWorker : Worker
    {
        public FixedPaymentWorker(int n) : base(n)
        {
        }

        public FixedPaymentWorker(string name, string lastname, double salary) : base(name, lastname, salary)
        {
        }

        public override double GetAverageMonthlySalary()
        {
            return salary;
        }
    }
}
