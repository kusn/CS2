using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ListOfCompanyEmployees
{
    /// <summary>
    /// Логика взаимодействия для WindowEditOfEmployee.xaml
    /// </summary>
    public partial class WindowEditOfEmployee : Window
    {
        public string NameOfEmployee { get; set; }
        public string LastNameOfEmployee { get; set; }
        public int AgeOfEmployee { get; set; }
        public int SalaryOfEmployee { get; set; }
        public Department DepartmentOfEmployee { get; set; }

        public Employee EditEmployee { get; set; }

        public WindowEditOfEmployee()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            /*NameOfEmployee = tbxName.Text;
            LastNameOfEmployee = tbxLastName.Text;
            AgeOfEmployee = Convert.ToInt32(tbxAge.Text);
            SalaryOfEmployee = Convert.ToInt32(tbxSalary.Text);
            DepartmentOfEmployee = new Department(cbDepartment.Text);*/
            EditEmployee = new Employee(tbxName.Text, tbxLastName.Text, Convert.ToInt32(tbxAge.Text), Convert.ToInt32(tbxSalary.Text), new Department(cbDepartment.Text));
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
