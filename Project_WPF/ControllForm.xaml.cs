using LaduDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        Toode ProductControllStatuss;
        Pakkuja ProviderControllStatuss;
        Kategooria CategoryControllStatuss;
        Alamkategooria SubCategoryControllStatuss;
        Klient ClientControllStatuss;

        private static Tax tax = new Tax(5, 20);
        int productId;
        int providerId;
        int categoryId;
        int subCategoryId;
        int clientId;

        public ControllForm()
        {
            InitializeComponent();
        }

        public class StaticTax
        {
           

            internal static Tax Tax { get => tax; set => tax = value; }
        }

        private void FormActivated(object sender, EventArgs e)
        {
            LoadProductData();
            LoadProviderData();
            LoadCategoryData();
            LoadSubCategoryData();
            LoadClientData();
        }



        //      Load data to grid


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

        public void LoadProviderData()
        {
            ObservableCollection<Pakkuja> providerItems = new ObservableCollection<Pakkuja>();
            foreach (var i in DB.GetAllProviders().OrderBy(a => a.Nimi))
            {
                providerItems.Add(i);
            }
            providerlList.ItemsSource = providerItems;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(providerlList.ItemsSource);
            view.Filter = ProviderFilter;
        }


        public void LoadCategoryData()
        {
            ObservableCollection<Kategooria> categoryItems = new ObservableCollection<Kategooria>();
            foreach (var i in DB.GetAllCategory().OrderBy(a => a.Nimi))
            {
                categoryItems.Add(i);
            }
            categorylList.ItemsSource = categoryItems;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(categorylList.ItemsSource);
            view.Filter = CategoryFilter;
        }


        public void LoadSubCategoryData()
        {
            ObservableCollection<Alamkategooria> subCategoryItems = new ObservableCollection<Alamkategooria>();
            foreach (var i in DB.GetAllSubCategory().OrderBy(a => a.Nimi))
            {
                subCategoryItems.Add(i);
            }
            subCategorylList.ItemsSource = subCategoryItems;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(subCategorylList.ItemsSource);
            view.Filter = SubCategoryFiltr;
        }


        public void LoadClientData()
        {
            ObservableCollection<Klient> klientItems = new ObservableCollection<Klient>();
            foreach (var i in DB.GetAllKlients().OrderBy(a => a.Perekonnanimi))
            {
                klientItems.Add(i);
            }
            clientList.ItemsSource = klientItems;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(clientList.ItemsSource);
            view.Filter = ClientFilter;
        }



        //      Selection changed

        private void ProductSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (productlList.SelectedIndex >= 0)
            {
                ProductControllStatuss = (Toode)productlList.SelectedItems[0];
                productId = ProductControllStatuss.ID;
               // subCategoryId = ProductControllStatuss.Alamkategooria.ID;
            }
        }


        private void ProviderSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (providerlList.SelectedIndex >= 0)
            {
                ProviderControllStatuss = (Pakkuja)providerlList.SelectedItems[0];
                providerId = ProviderControllStatuss.ID;
            }
        }

        private void CategorySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (categorylList.SelectedIndex >= 0)
            {
                CategoryControllStatuss = (Kategooria)categorylList.SelectedItems[0];
                categoryId = CategoryControllStatuss.ID;
            }
        }

        private void SubCategorySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (subCategorylList.SelectedIndex >= 0)
            {
                SubCategoryControllStatuss = (Alamkategooria)subCategorylList.SelectedItems[0];
                subCategoryId = SubCategoryControllStatuss.ID;
            }
        }



        private void KleintSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (clientList.SelectedIndex >= 0)
            {
                ClientControllStatuss = (Klient)clientList.SelectedItems[0];
                clientId = ClientControllStatuss.ID;
            }
        }






        //      Btn Edit Or Delete


        private void btnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (productlList.SelectedIndex >= 0)
            {
                AddOrEdit addOrEdit = new AddOrEdit();
                Controll.Name = "editProduct";
                Controll.ProductId = productId;
                addOrEdit.Show();
                
            }
            else
            {
                MessageBox.Show("Product not choosed!", "Error");
            }
        }

        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (productlList.SelectedIndex >= 0)
            {
                if (MessageBox.Show("Delete Product \"" + DB.GetProductByProductId(productId).Nimi + "\"?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                }
                else
                {
                    Toode deleteProduct = DB.GetProductByProductId(productId);

                    int arv = DB.DeleteProduct(deleteProduct);

                    if (arv != 0)
                    {
                        MessageBox.Show("Was deleted!", "Succesful");
                        productlList.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("Error while deleting!", "Error");
                    }

                }
            }
            else
            {
                MessageBox.Show("Product not choosed!", "Error");
            }
        }

        private void btnEditProvider_Click(object sender, RoutedEventArgs e)
        {
            if (providerlList.SelectedIndex >= 0)
            {
                AddOrEdit addOrEdit = new AddOrEdit();
                Controll.Name = "editProvider";
                Controll.ProviderId = providerId;
                addOrEdit.Show();
                
            }
            else
            {
                MessageBox.Show("Provider not choosed!", "Error");
            }
        }

        private void btnDeleteProvider_Click(object sender, RoutedEventArgs e)
        {
            if (providerlList.SelectedIndex >= 0)
            {
                if (MessageBox.Show("Delete Provider \"" + DB.GetProviderByProviderId(providerId).Nimi + "\"?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                }
                else
                {
                    Pakkuja deleteProvider = DB.GetProviderByProviderId(providerId);

                    int arv = DB.DeleteProvider(deleteProvider);

                    if (arv != 0)
                    {
                        MessageBox.Show("Was deleted!", "Succesful");
                        providerlList.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("Error while deleting!", "Error");
                    }

                }
            }
            else
            {
                MessageBox.Show("Provider not choosed!", "Error");
            }
        }

        private void btnEditCategory_Click(object sender, RoutedEventArgs e)
        {
            if (categorylList.SelectedIndex >= 0)
            {
                AddOrEdit addOrEdit = new AddOrEdit();
                Controll.Name = "editCategory";
                Controll.CategoryId = categoryId;
                addOrEdit.Show();
                
            }
            else
            {
                MessageBox.Show("Category not choosed!", "Error");
            }
        }

        private void btnDeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            if (categorylList.SelectedIndex >= 0)
            {
                if (MessageBox.Show("Delete Category \"" + DB.GetCategoryByCategoryId(categoryId).Nimi + "\"?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                }
                else
                {
                    Kategooria deleteCategory = DB.GetCategoryByCategoryId(categoryId);

                    int arv = DB.DeleteCategory(deleteCategory);

                    if (arv != 0)
                    {
                        MessageBox.Show("Was deleted!", "Succesful");
                        categorylList.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("Error while deleting!", "Error");
                    }

                }
            }
            else
            {
                MessageBox.Show("Category not choosed!", "Error");
            }
        }

        private void btnEditSubCategory_Click(object sender, RoutedEventArgs e)
        {
            if (subCategorylList.SelectedIndex >= 0)
            {
                AddOrEdit addOrEdit = new AddOrEdit();
                Controll.Name = "editSubCategory";
                Controll.SubCategoryId = subCategoryId;
                addOrEdit.Show();
                
            }
            else
            {
                MessageBox.Show("Sub Category not choosed!", "Error");
            }
        }

        private void btnDeleteSubCategory_Click(object sender, RoutedEventArgs e)
        {
            if (subCategorylList.SelectedIndex >= 0)
            {
                if (MessageBox.Show("Delete Sub Category \"" + DB.GetSubCategoryBySubCategoryId(subCategoryId).Nimi + "\"?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                }
                else
                {
                    Alamkategooria deleteSubCategory = DB.GetSubCategoryBySubCategoryId(subCategoryId);

                    int arv = DB.DeleteSubCategory(deleteSubCategory);

                    if (arv != 0)
                    {
                        MessageBox.Show("Was deleted!", "Succesful");
                        subCategorylList.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("Error while deleting!", "Error");
                    }

                }
            }
            else
            {
                MessageBox.Show("Sub Category not choosed!", "Error");
            }
        }

        private void btnEditKlient_Click(object sender, RoutedEventArgs e)
        {
            if (clientList.SelectedIndex >= 0)
            {
                AddOrEdit addOrEdit = new AddOrEdit();
                Controll.Name = "editClient";
                Controll.ClientId = clientId;
                addOrEdit.Show();
            }
            else
            {
                MessageBox.Show("Client not choosed!", "Error");
            }
        }

        private void btnDeleteKlient_Click(object sender, RoutedEventArgs e)
        {
            if (clientList.SelectedIndex >= 0)
            {
                if (MessageBox.Show("Delete Klient \"" + DB.GetClientByClientId(clientId).Nimi +" "+ DB.GetClientByClientId(clientId).Perekonnanimi + "\"?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                }
                else
                {
                    Klient deleteKlient = DB.GetClientByClientId(clientId);

                    int arv = DB.DeleteClient(deleteKlient);

                    if (arv != 0)
                    {
                        MessageBox.Show("Was deleted!", "Succesful");
                        clientList.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("Error while deleting!", "Error");
                    }

                }
            }
            else
            {
                MessageBox.Show("Client not choosed!", "Error");
            }
        }











        //          Menu items


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

        /// <summary>
        /// Search panel
        /// </summary>

        private bool ProductFilter(object item)
        {
            var toode = (Toode)item;
            if (String.IsNullOrEmpty(productsearch.Text))
                return true;

            else
                return (toode.Nimi.StartsWith(productsearch.Text, StringComparison.OrdinalIgnoreCase)
                || toode.Alamkategooria.Nimi.StartsWith(productsearch.Text, StringComparison.OrdinalIgnoreCase)
                || toode.Alamkategooria.Kategooria.Nimi.StartsWith(productsearch.Text, StringComparison.OrdinalIgnoreCase)
                || toode.KoodToode.StartsWith(productsearch.Text, StringComparison.OrdinalIgnoreCase));

        }

        private bool CategoryFilter(object item)
        {
            var toode = (Kategooria)item;
            if (String.IsNullOrEmpty(categorysearch.Text))
                return true;

            else
                return (toode.Nimi.StartsWith(categorysearch.Text, StringComparison.OrdinalIgnoreCase));

        }

        private bool ProviderFilter(object item)
        {
            if (String.IsNullOrEmpty(providersearch.Text))
                return true;
            else
                return ((item as Pakkuja).Nimi.IndexOf(providersearch.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private bool SubCategoryFiltr(object item)
        {
            var toode = (Alamkategooria)item;
            if (String.IsNullOrEmpty(subcategorysearch.Text))
                return true;

            else
                return (toode.Nimi.StartsWith(subcategorysearch.Text, StringComparison.OrdinalIgnoreCase)
                || toode.Kategooria.Nimi.StartsWith(subcategorysearch.Text, StringComparison.OrdinalIgnoreCase));
        }
        
        private bool ClientFilter(object item)
        {
            var toode = (Klient)item;
            if (String.IsNullOrEmpty(clientsearch.Text))
                return true;

            else
                return (toode.Nimi.StartsWith(clientsearch.Text, StringComparison.OrdinalIgnoreCase)
                || toode.Perekonnanimi.StartsWith(clientsearch.Text, StringComparison.OrdinalIgnoreCase)
                || toode.Telefon.StartsWith(clientsearch.Text, StringComparison.OrdinalIgnoreCase)
                || toode.Aadress.StartsWith(clientsearch.Text, StringComparison.OrdinalIgnoreCase));
        }
        
        private void productsearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(productlList.ItemsSource).Refresh();
        }

        private void categorysearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(categorylList.ItemsSource).Refresh();
        }

        private void providersearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(providerlList.ItemsSource).Refresh();
        }

        private void subcategorysearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(subCategorylList.ItemsSource).Refresh();
        }

        private void clientsearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(clientList.ItemsSource).Refresh();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }
    }
    /// 
    /// end Search Panel
    /// 



    public static class Controll
    {
        public static string Name { get; set; }
        public static int ProductId { get; set; }
        public static int ProviderId { get; set; }
        public static int CategoryId { get; set; }
        public static int SubCategoryId { get; set; }
        public static int ClientId { get; set; }
        public static DateTime dateTimeArrivedProduct { get; set; }
        public static DateTime dateTimeBuyProduct { get; set; }
    }
}
