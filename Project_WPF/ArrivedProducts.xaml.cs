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
    /// Логика взаимодействия для ArrivedProducts.xaml
    /// </summary>
    public partial class ArrivedProducts : Window
    {
        public ArrivedProducts()
        {
            InitializeComponent();
        }

        private void btnAddNewProduct_Click(object sender, RoutedEventArgs e)
        {
            AddOrEdit addOrEdit = new AddOrEdit();
            addOrEdit.Title = "Add Product";
            Controll.Name = "addProduct";
            addOrEdit.Show();
        }
    }
}
