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

namespace Project_WPF
{
    /// <summary>
    /// Interaction logic for Setting.xaml
    /// </summary>
    public partial class Settings : Window
    {

        public Settings()
        {
            InitializeComponent();
            string[] items = new string[101];
            for (int i = 0; i <= 100; i++)
            {
                items[i] = i.ToString();
            }
            listtax.ItemsSource = items;
            listtax.SelectedIndex = Convert.ToInt32(ControllForm.StaticTax.Tax.Statetax);
            listtax2.ItemsSource = items;
            listtax2.SelectedItem = Convert.ToInt32(ControllForm.StaticTax.Tax.Warehousetax);
            testlabel.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ControllForm.StaticTax.Tax.Warehousetax = Convert.ToInt32(listtax.SelectedItem);
            ControllForm.StaticTax.Tax.Statetax = Convert.ToInt32(listtax2.SelectedItem);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


        }

        private void test_Click(object sender, RoutedEventArgs e)
        {
            long a = 10;
            testlabel.Visibility = Visibility.Visible;
            testlabel.Content = a + (a * (ControllForm.StaticTax.Tax.Warehousetax / 100)) + (a * (ControllForm.StaticTax.Tax.Statetax / 100));
        }
    }
}
