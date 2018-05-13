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

namespace Project_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataInitializer data = new DataInitializer();
            data.InitializeDatabase(new Context());
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            ControllForm cf = new ControllForm();
            cf.Show();
            this.Close();

        }
    }
}
