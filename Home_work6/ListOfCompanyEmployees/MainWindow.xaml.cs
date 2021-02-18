// Кудряшов Сергей

// Создать WPF-приложение для ведения списка сотрудников компании.
// 1. Создать сущности Employee и Department и заполните списки сущностей начальными данными.
// 2. Для списка сотрудников и списка департаментов предусмотреть визуализацию (отображение). 
//   Это можно сделать, например, с использованием ComboBox или ListView.
// 3. Предусмотреть возможность редактирования сотрудников и департаментов. 
//   Должна быть возможность изменить департамент у сотрудника. 
//   Список департаментов для выбора, можно выводить в ComboBox, 
//   это все можно выводить на дополнительной форме.
// 4. Предусмотреть возможность создания новых сотрудников и департаментов. 
//   Реализовать данную возможность либо на форме редактирования, либо сделать новую форму.

using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace ListOfCompanyEmployees
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Employee> ListOfEmployees { get; set; } = new ObservableCollection<Employee>();
        public ObservableCollection<Department> ListOfDepartments { get; set; } = new ObservableCollection<Department>();

        public MainWindow()
        {
            InitializeComponent();
            ListOfDepartments.Add(new Department("Главного конструктора"));
            ListOfEmployees.Add(new Employee("Петр", "Петров", 23, 23000, ListOfDepartments[0]));
            dgOfEmployee.ItemsSource = ListOfEmployees;
        }

        private void mnItemUserEdit_Click(object sender, RoutedEventArgs e)
        {
            bool edit = true;
            Employee emp = new Employee();
            emp = (Employee)dgOfEmployee.SelectedItem;
            int index = ListOfEmployees.IndexOf(emp);
            WindowEditOfEmployee wndEditOfEmployee = new WindowEditOfEmployee(emp, edit);
            wndEditOfEmployee.cbDepartment.ItemsSource = ListOfDepartments;
            wndEditOfEmployee.ShowDialog();            
            if (wndEditOfEmployee.DialogResult.HasValue && wndEditOfEmployee.DialogResult.Value)
            {
                ListOfEmployees[index] = wndEditOfEmployee.EditEmployee;
            }
        }

        private void mnItemDepartmentEdit_Click(object sender, RoutedEventArgs e)
        {
            bool edit = true;
            Employee emp = new Employee();
            emp = (Employee)dgOfEmployee.SelectedItem;
            int index = ListOfDepartments.IndexOf(emp.Department);
            WindowEditOfDepartment wndEditOfDepartment = new WindowEditOfDepartment(emp, edit);
            wndEditOfDepartment.ShowDialog();
            if(wndEditOfDepartment.DialogResult.HasValue && wndEditOfDepartment.DialogResult.Value)
            {
                ListOfDepartments[index] = wndEditOfDepartment.NewNameOfDepartment;
                ListOfEmployees[emp.ID].Department = wndEditOfDepartment.NewNameOfDepartment;
            }
        }

        private void mnItemDepartmentAdd_Click(object sender, RoutedEventArgs e)
        {
            bool edit = false;
            Employee emp = new Employee();
            WindowEditOfDepartment wndEditOfDepartment = new WindowEditOfDepartment(emp, edit);
            wndEditOfDepartment.ShowDialog();
            if (wndEditOfDepartment.DialogResult.HasValue && wndEditOfDepartment.DialogResult.Value)
            {
                ListOfDepartments.Add(wndEditOfDepartment.NewNameOfDepartment);                
            }
        }

        private void mnItemUserAdd_Click(object sender, RoutedEventArgs e)
        {
            bool edit = false;
            Employee emp = new Employee();
            emp = (Employee)dgOfEmployee.SelectedItem;
            WindowEditOfEmployee wndEditOfEmployee = new WindowEditOfEmployee(emp, edit);
            wndEditOfEmployee.cbDepartment.ItemsSource = ListOfDepartments;
            wndEditOfEmployee.ShowDialog();
            if (wndEditOfEmployee.DialogResult.HasValue && wndEditOfEmployee.DialogResult.Value)
            {
                ListOfEmployees.Add(wndEditOfEmployee.EditEmployee);
            }
        }
    }

    /*public class StringToDepartmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new Department(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }
    }*/
}
