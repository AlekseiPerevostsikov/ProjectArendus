using LaduDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        Toode ProductControllStatuss;
       // int productId;

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




        private void FormActivated(object sender, EventArgs e)
        {
            LoadProductData();
            LoadProviderData();
        }


        private void FormLoaded(object sender, RoutedEventArgs e)
        {

        }

        public void LoadProductData()
        {
            ObservableCollection<Toode> productItems = new ObservableCollection<Toode>();
            foreach (Toode i in DB.GetAllProducts().OrderBy(a => a.Nimi))
            {
                productItems.Add(i);
            }
            productlList.ItemsSource = productItems;
        }

        public void LoadProviderData()
        {
            ObservableCollection<Pakkuja> providerItems = new ObservableCollection<Pakkuja>();
            foreach (Pakkuja i in DB.GetAllProviders().OrderBy(a => a.Nimi))
            {
                providerItems.Add(i);
            }
            providerlList.ItemsSource = providerItems;
        }

        private void ProductSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (productlList.SelectedIndex >= 0)
            {
                ProductControllStatuss = (Toode)productlList.SelectedItems[0];
                //productId = ProductControllStatuss.ID;

              //  lbl.Content = ProductControllStatuss.Nimi + " " + ProductControllStatuss.KoodToode + " " + ProductControllStatuss.AlamKategoriaId;
            }
           
        }


        
    }
}
