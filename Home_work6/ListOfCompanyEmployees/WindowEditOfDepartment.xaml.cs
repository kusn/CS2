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
    /// Логика взаимодействия для WindowEditOfDepartment.xaml
    /// </summary>
    public partial class WindowEditOfDepartment : Window
    {
        public Department NewNameOfDepartment { get; set; }

        public WindowEditOfDepartment(Employee employee, bool edit)
        {
            MainWindow mainWindow = new MainWindow();
            InitializeComponent();
            if (edit)
            {
                try
                {
                    tbxName.Text = employee.Department.Name;
                }
                catch
                {
                    MessageBox.Show("Выберите работника");
                    this.Close();
                }
            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            NewNameOfDepartment = new Department(tbxName.Text);            
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
