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
        public Employee EditEmployee { get; private set; } = new Employee();

        public WindowEditOfEmployee(Employee employee, bool edit)
        {
            MainWindow mainWindow = new MainWindow();
            InitializeComponent();
            cbDepartment.ItemsSource = mainWindow.ListOfDepartments;
            if (edit)
            {                
                try
                {
                    tbxName.Text = employee.Name;
                    tbxLastName.Text = employee.LastName;
                    tbxAge.Text = employee.Age.ToString();
                    tbxSalary.Text = employee.Salary.ToString();
                    cbDepartment.Text = employee.Department.ToString();
                    datePStart.DisplayDate = employee.StartOfVacation;
                    datePEnd.DisplayDate = employee.EndOfVacation;
                }
                catch
                {
                    MessageBox.Show("Выберите работника");
                    this.Close();
                }
            }
            /*else if(!edit)
            {
                
            }*/
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            
            EditEmployee.Name = tbxName.Text;
            EditEmployee.LastName = tbxLastName.Text;
            EditEmployee.Age = Convert.ToInt32(tbxAge.Text);
            EditEmployee.Salary = Convert.ToInt32(tbxSalary.Text);
            EditEmployee.Department = new Department(cbDepartment.Text);
            EditEmployee.StartOfVacation = datePStart.SelectedDate.Value;
            EditEmployee.EndOfVacation = datePEnd.SelectedDate.Value;
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
