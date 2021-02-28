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

namespace TicTacToeWCFClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<TextBlock> lstTextBlocks = new List<TextBlock>();
        ServiceReference.ServiceClient service = new ServiceReference.ServiceClient();
        int id;

        public MainWindow()
        {
            InitializeComponent();
            txtBlockId.Text = service.GetId().ToString();
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            
            
            try
            {
                for(int i = 0; i < gridTicTacToe.ColumnDefinitions.Count; i++)
                    for(int j = 0; j < gridTicTacToe.RowDefinitions.Count - 1; j++)
                    {
                        TextBlock textBlock = new TextBlock();
                        textBlock.Text = service.GetValue(i, j).ToString();
                        textBlock.HorizontalAlignment = HorizontalAlignment.Stretch;
                        textBlock.FontSize = 22;
                        textBlock.TextAlignment = TextAlignment.Center;
                        gridTicTacToe.Children.Add(textBlock);
                        Grid.SetColumn(textBlock, i);
                        Grid.SetRow(textBlock, j);
                        lstTextBlocks.Add(new TextBlock());
                    }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
