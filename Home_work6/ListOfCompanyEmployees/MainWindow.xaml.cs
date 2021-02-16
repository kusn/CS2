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

namespace ListOfCompanyEmployees
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Employee employee = new Employee();
        Department department = new Department();

        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public class StringToDepartmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new Department(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }
    }
}
