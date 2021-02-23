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
using System.Data;

namespace SQL_LoginsAndPasswords
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public DataRow resultRow { get; set; }

        public EditWindow(DataRow dataRow)
        {
            InitializeComponent();
            resultRow = dataRow;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loginTextBox.Text = resultRow["Login"].ToString();
            passwordTextBox.Text = resultRow["Password"].ToString();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            resultRow["Login"] = loginTextBox.Text;
            resultRow["Password"] = passwordTextBox.Text;
            DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
