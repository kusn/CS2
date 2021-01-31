using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    public class TimeBasedWorker : Worker
    { 
        public TimeBasedWorker()
        { }

        public TimeBasedWorker(int n):base(n)
        {
        }

        public TimeBasedWorker(string name, string lastname, double salary) : base(name, lastname, salary)
        {
        }

        public override double GetAverageMonthlySalary()
        {
            return 20.8 * 8 * salary;
        }

        public override string ToString()
        {
            return firstName + " " + lastName;
        }

        /*public TimeBasedWorker this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
                this[index] = value;
            }
        }*/

        /*public override object Current => throw new NotImplementedException();*/

        /*public override IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }*/

        /*public override bool MoveNext()
        {
            throw new NotImplementedException();
        }*/

        /*public override void Reset()
        {
            throw new NotImplementedException();
        }*/
    }
}
