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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace SQL_LoginsAndPasswords
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = LoginsAndPasswords; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFileName=D:\Projects\CS2\Home_work7\SQL_LoginsAndPasswords\bin\Debug\LoginsAndPasswords.mdf; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        SqlConnection connection;
        SqlDataAdapter adapter;
        DataTable dt;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT Id, Login, Password FROM LgnsAndPsswds", connection);
            adapter.SelectCommand = command;
            dt = new DataTable();
            adapter.Fill(dt);

            loginsDataGrid.DataContext = dt.DefaultView;
        }
    }
}
