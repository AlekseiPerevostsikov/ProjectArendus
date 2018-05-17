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
    /// Логика взаимодействия для ShowProducts.xaml
    /// </summary>
    public partial class ShowProducts : Window
    {
        public ShowProducts()
        {
            InitializeComponent();

            LoadProductData();
        }

        public void LoadProductData()
        {
            ObservableCollection<Toode> productItems = new ObservableCollection<Toode>();
            foreach (var i in DB.GetAllProducts().OrderBy(a => a.Nimi))
            {
                productItems.Add(i);
            }
            productlList.ItemsSource = productItems;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(productlList.ItemsSource);
            view.Filter = ProductFilter;
        }

        private bool ProductFilter(object item)
        {
            if (String.IsNullOrEmpty(txtProductName.Text))
                return true;
            else
                return ((item as Toode).Nimi.IndexOf(txtProductName.Text, StringComparison.OrdinalIgnoreCase) >= 0);

        }

        private void ProductNameTextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(productlList.ItemsSource).Refresh();
        }
    }
}
