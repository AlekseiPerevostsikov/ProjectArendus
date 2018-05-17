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
    /// Логика взаимодействия для BuyProduct.xaml
    /// </summary>
    public partial class BuyProduct : Window
    {
        Toode ProductControllStatuss;
        Ostukorvi BasketControllStatuss;
        ObservableCollection<Ostukorvi> basketItems;


        public BuyProduct()
        {
            InitializeComponent();
        }

        private void FormLoaded(object sender, RoutedEventArgs e)
        {
            Dictionary<int, string> cbClientData = new Dictionary<int, string>();
            var value = DB.GetAllKlients().OrderByDescending(a => a.Perekonnanimi);
            foreach (var item in value)
            {
                cbClientData.Add(item.ID, item.Perekonnanimi + " " + item.Nimi);
            }
            cbClient.ItemsSource = cbClientData;
            cbClient.DisplayMemberPath = "Value";
            cbClient.SelectedValuePath = "Key";
            cbClient.SelectedIndex = 0;

            productlList.SelectedIndex = 0;
            cbProdyctQuntity.SelectedIndex = 0;
        }

        private void FormActivated(object sender, EventArgs e)
        {
            LoadProductData();
            LoadBasketData();
            
        }


        public void LoadProductData()
        {
            ObservableCollection<Toode> productItems = new ObservableCollection<Toode>();
            foreach (Toode i in DB.GetAllProducts().OrderBy(a => a.Nimi))
            {
                productItems.Add(i);
            }
            productlList.ItemsSource = productItems;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(productlList.ItemsSource);
            view.Filter = ProductFilter;
            CollectionView view1 = (CollectionView)CollectionViewSource.GetDefaultView(productlList.ItemsSource);
            view1.Filter = CategoryFilter;
        }


        public void LoadBasketData()
        {
            basketItems = new ObservableCollection<Ostukorvi>();
            foreach (Ostukorvi i in DB.GetAllBasketsWhereDate(Controll.dateTimeBuyProduct).OrderByDescending(a => a.Date))
            {
                basketItems.Add(i);
            }
            basketList.ItemsSource = basketItems;

        }



        private void QuantityProductUpdateWhenProductChange()
        {
            for (int i = 1; i <= ProductControllStatuss.Kogus; i++)
            {
                cbProdyctQuntity.Items.Add(i);
            }
            cbProdyctQuntity.SelectedIndex = 0;
        }

        private void ProductSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (productlList.SelectedIndex >= 0)
            {
                cbProdyctQuntity.Items.Clear();
                ProductControllStatuss = (Toode)productlList.SelectedItems[0];
                QuantityProductUpdateWhenProductChange();
            }
        }

        private void BasketSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (basketList.SelectedIndex >= 0)
            {
                BasketControllStatuss = (Ostukorvi)basketList.SelectedItems[0];
            }
        }







        private void btnAddToBasket_Click(object sender, RoutedEventArgs e)
        {
            if (productlList.SelectedIndex >= 0 && cbProdyctQuntity.SelectedIndex >= 0)
            {
                //try
                //{
                Ostukorvi temp = new Ostukorvi();
                temp.Klient = DB.GetClientByClientId(((KeyValuePair<int, string>)cbClient.SelectedItem).Key);
                temp.Toode = ProductControllStatuss;
                temp.Date = DateTime.Now;
                temp.Kogus = Convert.ToInt16(cbProdyctQuntity.SelectedValue);

                //temp.SisseTuleb = new SisseTuleb { toodeId = ProductControllStatuss.ID, Kogus = Convert.ToInt16(cbProdyctQuntity.Text) };
                ////.Toode.ID = ProductControllStatuss.ID;
                ////temp.SisseTuleb.Toode.KoodToode = ProductControllStatuss.KoodToode;
                ////temp.SisseTuleb.Toode.Nimi = ProductControllStatuss.Nimi;
                ////temp.SisseTuleb.Kogus = Convert.ToInt16(cbProdyctQuntity.Text);
                //temp.Pakkuja = ProviderControllStatuss;

                ////temp.Hind = 10;
                //temp.Date = DateTime.Now;

                int error = DB.AddBasket(temp);

                int error2 = DB.UpdateProductQuantityWhenAddToBasket(ProductControllStatuss.ID, Convert.ToInt16(cbProdyctQuntity.SelectedValue));
                cbProdyctQuntity.Items.Clear();
                QuantityProductUpdateWhenProductChange();
                LoadProductData();
                if (error != 0)
                {
                    MessageBox.Show("Was Added!", "Succesful");
                   
                }
                else
                {
                    MessageBox.Show("Error while adding!", "Error");
                }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Error " + ex.ToString() + "!", "Error"); ;
                //}
            }
            else
            {
                MessageBox.Show("Error product not choosed or product quantity is empty!", "Error");
            }
        }

        private void btnDeleteFromBasket_Click(object sender, RoutedEventArgs e)
        {
            if (basketList.SelectedIndex >= 0)
            {
                if (MessageBox.Show("Delete product from basket ?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                }
                else
                {
                    try
                    {
                        int error2 = DB.UpdateProductQuantityWhenDeleteFromBasket(BasketControllStatuss.Toode.ID, BasketControllStatuss.Kogus);
                        cbProdyctQuntity.Items.Clear();
                        QuantityProductUpdateWhenProductChange();

                        Ostukorvi deleteBasket = BasketControllStatuss;

                        int arv = DB.DeleteBasket(deleteBasket);
                        basketList.SelectedIndex = 0;
                       
                        if (arv != 0)
                        {
                            MessageBox.Show("Was deleted!", "Succesful");
                           
                        }
                        else
                        {
                            MessageBox.Show("Error while deleting!", "Error");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex.ToString() + "!", "Error");
                    }

                }
            }
            else
            {
                MessageBox.Show("Product not choosed!", "Error");
            }
        }

        private void btnConfirmBasket_Click(object sender, RoutedEventArgs e)
        {
            if (basketList.SelectedIndex >= 0)
            {
                if (MessageBox.Show("Confirm basket?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                }
                else
                {
                    try
                    {
                        //foreach (var i in arrivedProductCheckItems)
                        //{
                        //    DB.UpdateProductQuantity(i.SisseTuleb.Toode.ID, i.SisseTuleb.Kogus);
                        //}
                        //Controll.dateTimeArrivedProduct = DateTime.Now;
                        //arrivedProductCheckItems.Clear();
                        //LoadProductData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex.ToString() + "!", "Error");
                    }
                }
            }
            else
            {
                MessageBox.Show("Basket is empty!", "Error");
            }
        }

        private bool ProductFilter(object item)
        {

            if (String.IsNullOrEmpty(txtProductName.Text))
                return true;
            else
                return ((item as Toode).Nimi.IndexOf(txtProductName.Text, StringComparison.OrdinalIgnoreCase) >= 0);


        }

        private bool CategoryFilter(object item)
        {

            if (String.IsNullOrEmpty(txtSubCategoryName.Text))
                return true;
            else
                return ((item as Alamkategooria).Nimi.IndexOf(txtSubCategoryName.Text, StringComparison.OrdinalIgnoreCase) >= 0);


        }



        private void txtProductName_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(productlList.ItemsSource).Refresh();
        }

        private void txtSubCategoryName_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(productlList.ItemsSource).Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            test.Content = Convert.ToInt16(cbProdyctQuntity.SelectedValue);
        }
    }
}
