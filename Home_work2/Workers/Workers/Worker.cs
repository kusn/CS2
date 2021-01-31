using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Workers
{
    abstract public class Worker : IEnumerable, IEnumerator
    {
        protected string firstName;
        protected string lastName;
        protected double salary;

        private int[] a;

        public string FirstName
        {
            get { return firstName; } 
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public Worker()
        { }

        public Worker(int n)
        {
            a = new int[n];
            for (int i = 0; i < n; i++) a[i] = i;
        }

        public Worker(string name, string lastname, double salary)
        {
            firstName = name;
            lastName = lastname;
            this.salary = salary;
        }

        public abstract double GetAverageMonthlySalary();

        int i = -1;
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (i == a.Length - 1)
            {
                Reset();
                return false;
            }
            i++;
            return true;
        }

        public void Reset()
        {
            i = -1;
        }

        public object Current
        {
            get
            {
                return a[i];
            }
        }
    }
}
