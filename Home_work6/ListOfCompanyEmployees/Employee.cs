﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ListOfCompanyEmployees
{
    public class Employee : INotifyPropertyChanged
    {
        static int Count = 0;
        string name;
        string lastname;
        int age;
        int salary;
        Department department;
        DateTime startOfVacation;
        DateTime endOfVacation;

        public event PropertyChangedEventHandler PropertyChanged;

        public int ID { get; private set; }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
        }

        public string LastName
        {
            get { return this.lastname; }
            set
            {
                if (this.lastname != value)
                {
                    this.lastname = value;
                    this.NotifyPropertyChanged("LastName");
                }
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (this.age != value)
                {
                    this.age = value;
                    this.NotifyPropertyChanged("Age");
                }
            }
        }

        public int Salary
        {
            get { return this.salary; }
            set
            {
                if (this.salary != value)
                {
                    this.salary = value;
                    this.NotifyPropertyChanged("Salary");
                }
            }
        }

        public Department Department
        {
            get { return this.department; }
            set
            {
                if (this.department != value)
                {
                    this.department = value;
                    this.NotifyPropertyChanged("Department");
                }
            }
        }

        public DateTime StartOfVacation
        {
            get { return this.startOfVacation; }
            set
            {
                if (this.startOfVacation != value)
                {
                    this.startOfVacation = value;
                    this.NotifyPropertyChanged("StartOfVacation");
                }
            }
        }

        public DateTime EndOfVacation
        {
            get { return this.endOfVacation; }
            set
            {
                if (this.endOfVacation != value)
                {
                    this.endOfVacation = value;
                    this.NotifyPropertyChanged("EndOfVacation");
                }
            }
        }

        public Employee()
        {
        }

        public Employee(string name, string lastName, int age, int salary)
        {
            Name = name;
            LastName = lastName;
            Age = age;
            Salary = salary;
            Department = new Department("");
            StartOfVacation = DateTime.Now;
            EndOfVacation = DateTime.Now;
        }

        public Employee(string name, string lastName, int age, int salary, Department department)
        {
            Name = name;
            LastName = lastName;
            Age = age;
            Salary = salary;
            Department = department;
            StartOfVacation = DateTime.Now;
            EndOfVacation = DateTime.Now;
        }

        public Employee(string name, string lastName, int age, int salary, string department)
        {
            Name = name;
            LastName = lastName;
            Age = age;
            Salary = salary;
            Department = new Department(department);
            StartOfVacation = DateTime.Now;
            EndOfVacation = DateTime.Now;
        }

        public Employee(string name, string lastName, int age, int salary, Department department, DateTime start, DateTime end)
        {
            Name = name;
            LastName = lastName;
            Age = age;
            Salary = salary;
            Department = department;
            StartOfVacation = start;
            EndOfVacation = end;
        }

        public override string ToString()
        {
            return $@"{Name} {LastName}";
        }

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

    }
}
