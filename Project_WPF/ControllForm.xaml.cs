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
    /// Логика взаимодействия для ControllForm.xaml
    /// </summary>
    public partial class ControllForm : Window
    {
        public ControllForm()
        {
            InitializeComponent();
        }

        private void MenuItem_Exit(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }




        //Add value


        private void MenuItem_AddProduct(object sender, RoutedEventArgs e)
        {
            AddOrEdit addOrEdit = new AddOrEdit();
            addOrEdit.Title = "Add Product";
            Controll.Name = "addProduct";
            addOrEdit.Show();
        }

        private void MenuItem_AddCategory(object sender, RoutedEventArgs e)
        {
            AddOrEdit addOrEdit = new AddOrEdit();
            addOrEdit.Title = "Add Category";
            Controll.Name = "addCategory";
            addOrEdit.Show();
        }

        private void MenuItem_AddSubCategory(object sender, RoutedEventArgs e)
        {
            AddOrEdit addOrEdit = new AddOrEdit();
            addOrEdit.Title = "Add SubCategory";
            Controll.Name = "addSubCategory";
            addOrEdit.Show();
        }

        private void MenuItem_AddClient(object sender, RoutedEventArgs e)
        {
            AddOrEdit addOrEdit = new AddOrEdit();
            addOrEdit.Title = "Add Client";
            Controll.Name = "addClient";
            addOrEdit.Show();
        }

        private void MenuItem_AddProvider(object sender, RoutedEventArgs e)
        {
            AddOrEdit addOrEdit = new AddOrEdit();
            addOrEdit.Title = "Add Provider";
            Controll.Name = "addProvider";
            addOrEdit.Show();
        }







        //Edit value


        private void MenuItem_EditProduct(object sender, RoutedEventArgs e)
        {
            AddOrEdit addOrEdit = new AddOrEdit();
            addOrEdit.Title = "Edit Product";
            Controll.Name = "editProduct";
            addOrEdit.Show();
        }

        private void MenuItem_EditCategory(object sender, RoutedEventArgs e)
        {
            AddOrEdit addOrEdit = new AddOrEdit();
            addOrEdit.Title = "Edit Category";
            Controll.Name = "editCategory";
            addOrEdit.Show();
        }

        private void MenuItem_EditSubCategory(object sender, RoutedEventArgs e)
        {
            AddOrEdit addOrEdit = new AddOrEdit();
            addOrEdit.Title = "Edit SubCategory";
            Controll.Name = "editSubCategory";
            addOrEdit.Show();
        }

        private void MenuItem_EditClient(object sender, RoutedEventArgs e)
        {
            AddOrEdit addOrEdit = new AddOrEdit();
            addOrEdit.Title = "Edit Client";
            Controll.Name = "editClient";
            addOrEdit.Show();
        }

        private void MenuItem_EditProvider(object sender, RoutedEventArgs e)
        {
            AddOrEdit addOrEdit = new AddOrEdit();
            addOrEdit.Title = "Edit Provider";
            Controll.Name = "editProvider";
            addOrEdit.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MenuItemEditProduct.IsEnabled = false;
            MenuItemEditClient.Visibility = Visibility.Hidden;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MenuItemEditProduct.IsEnabled = true;
            MenuItemEditClient.Visibility = Visibility.Visible;
        }

        private void MenuItem_ShowProducts(object sender, RoutedEventArgs e)
        {
            ShowProducts showProducts = new ShowProducts();
            showProducts.Show();
        }

        private void MenuItem_AddArrivedProducts(object sender, RoutedEventArgs e)
        {
            ArrivedProducts arrivedProducts = new ArrivedProducts();
            arrivedProducts.Show();
        }

        private void MenuItem_BuyProduct(object sender, RoutedEventArgs e)
        {
            BuyProduct buyProduct = new BuyProduct();
            buyProduct.Show();
        }

        private void MenuItem_ShowChecks(object sender, RoutedEventArgs e)
        {
            Check check = new Check();
            check.Show();
        }
    }

    public static class Controll
    {
        public static string Name { get; set; }
    }
}
