//Кудряшов Сергей

//Создать БД "Логин-Пароль"

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
        SqlConnection connection;
        SqlDataAdapter adapter;
        DataTable dt;

        //string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = LoginsAndPasswords; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFileName=|DataDirectory|LoginsAndPasswords.mdf; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            DataRow newRow = dt.NewRow();
            EditWindow editWindow = new EditWindow(newRow);
            editWindow.ShowDialog();
            if (editWindow.DialogResult.HasValue && editWindow.DialogResult.Value)
            {
                dt.Rows.Add(editWindow.resultRow);
                adapter.Update(dt);
            }
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (loginsDataGrid.SelectedItem == null) return;
            DataRowView newRow = (DataRowView)loginsDataGrid.SelectedItem;
            newRow.BeginEdit();
            EditWindow editWindow = new EditWindow(newRow.Row);
            editWindow.ShowDialog();
            if (editWindow.DialogResult.HasValue && editWindow.DialogResult.Value)
            {
                newRow.EndEdit();
                adapter.Update(dt);
            }
            else
            {
                newRow.CancelEdit();
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            DataRowView newRow = (DataRowView)loginsDataGrid.SelectedItem;
            newRow.Row.Delete();
            adapter.Update(dt);
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT Id, Login, Password FROM LgnsAndPsswds", connection);
            adapter.SelectCommand = command;            

            //insert
            command = new SqlCommand(@"INSERT INTO LgnsAndPsswds (Login, Password) VALUES (@Login, @Password); SET @ID = @@IDENTITY", connection);
            command.Parameters.Add("@Login", SqlDbType.NChar, -1, "Login");
            command.Parameters.Add("@password", SqlDbType.NChar, -1, "Password");
            SqlParameter param = command.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");
            param.Direction = ParameterDirection.Output;
            adapter.InsertCommand = command;

            //update
            command = new SqlCommand(@"UPDATE LgnsAndPsswds SET Login = @Login, Password = @Password WHERE ID = @ID", connection);
            command.Parameters.Add("@Login", SqlDbType.NChar, -1, "Login");
            command.Parameters.Add("@Password", SqlDbType.NChar, -1, "Password");
            param = command.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");
            param.SourceVersion = DataRowVersion.Original;
            adapter.UpdateCommand = command;

            //delete
            command = new SqlCommand("DELETE FROM LgnsAndPsswds WHERE ID = @ID", connection);
            param = command.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");
            param.SourceVersion = DataRowVersion.Original;
            adapter.DeleteCommand = command;
            
            dt = new DataTable();
            adapter.Fill(dt);

            loginsDataGrid.DataContext = dt.DefaultView;
        }
    }
}
