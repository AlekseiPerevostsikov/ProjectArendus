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
                cbProdyctQuntity.Items.Clear();
            }
        }




        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (productlList.SelectedIndex >= 0 && basketList.SelectedIndex >= 0)
            {
                if (ProductControllStatuss.Kogus > 0)
                {
                    DB.RefreshBasketSummWhenPlussPressed(BasketControllStatuss.ID, ProductControllStatuss.Hind);
                   

                    DB.Add1QuantityFromProductInBuy(ProductControllStatuss.ID);
                    
                    cbProdyctQuntity.Items.Clear();
                    QuantityProductUpdateWhenProductChange();
                    LoadProductData();

                    DB.Add1QuantityFromProductInBasket(BasketControllStatuss.ID);
                   
                    LoadBasketData();
                }
                else
                {
                    MessageBox.Show("All product is ended!", "Error");
                }

            }
            else
            {
                MessageBox.Show("Product or basket nor choosed!", "Error");
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (productlList.SelectedIndex >= 0 && basketList.SelectedIndex >= 0)
            {
                if (BasketControllStatuss.Kogus > 1)
                {
                    DB.RefreshBasketSummWhenMinusPressed(BasketControllStatuss.ID, ProductControllStatuss.Hind);

                    DB.Remove1QuantityFromProductInBuy(ProductControllStatuss.ID);
                    cbProdyctQuntity.Items.Clear();
                    QuantityProductUpdateWhenProductChange();
                    LoadProductData();

                    DB.Remove1QuantityFromProductInBasket(BasketControllStatuss.ID);
                    LoadBasketData();
                }
                else
                {
                    MessageBox.Show("In basket need minimum 1 value!", "Error");
                }

            }
            else
            {
                MessageBox.Show("Product or basket nor choosed!", "Error");
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
                temp.Summ = ProductControllStatuss.Hind * Convert.ToDouble(cbProdyctQuntity.SelectedValue);
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

                DB.UpdateProductQuantityWhenAddToBasket(ProductControllStatuss.ID, Convert.ToInt16(cbProdyctQuntity.SelectedValue));

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
                        DB.UpdateProductQuantityWhenDeleteFromBasket(BasketControllStatuss.Toode.ID, BasketControllStatuss.Kogus);

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
                        foreach (var i in basketItems)
                        {
                            DB.AddCkeck(new Arve { OstukorviId = i.ID, Date = DateTime.Now });
                        }
                        Controll.dateTimeBuyProduct = DateTime.Now;
                        basketItems.Clear();
                        // LoadProductData();
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
            var toode = (Toode)item;
            if (String.IsNullOrEmpty(txtProductName.Text))
                return true;

            else
                return (toode.Nimi.StartsWith(txtProductName.Text, StringComparison.OrdinalIgnoreCase)
                || toode.Alamkategooria.Nimi.StartsWith(txtProductName.Text, StringComparison.OrdinalIgnoreCase)
                || toode.Alamkategooria.Kategooria.Nimi.StartsWith(txtProductName.Text, StringComparison.OrdinalIgnoreCase)
                || toode.KoodToode.StartsWith(txtProductName.Text, StringComparison.OrdinalIgnoreCase));

        }

        private bool BasketFilter(object item)
        {
            var toode = (Ostukorvi)item;
            if (String.IsNullOrEmpty(txtProductNameInBasket.Text))
                return true;

            else
                return (toode.Toode.Nimi.StartsWith(txtProductNameInBasket.Text, StringComparison.OrdinalIgnoreCase)
                || toode.Toode.Alamkategooria.Nimi.StartsWith(txtProductNameInBasket.Text, StringComparison.OrdinalIgnoreCase)
                || toode.Toode.Alamkategooria.Kategooria.Nimi.StartsWith(txtProductNameInBasket.Text, StringComparison.OrdinalIgnoreCase)
                || toode.Toode.KoodToode.StartsWith(txtProductNameInBasket.Text, StringComparison.OrdinalIgnoreCase)
                || toode.Klient.Nimi.StartsWith(txtProductNameInBasket.Text, StringComparison.OrdinalIgnoreCase)
                || toode.Klient.Perekonnanimi.StartsWith(txtProductNameInBasket.Text, StringComparison.OrdinalIgnoreCase));

        }




        private void txtProductName_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(productlList.ItemsSource);
            view.Filter = ProductFilter;
            CollectionViewSource.GetDefaultView(productlList.ItemsSource).Refresh();

        }

        private void txtProductNameInBasket_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(basketList.ItemsSource);
            view.Filter = BasketFilter;
            CollectionViewSource.GetDefaultView(basketList.ItemsSource).Refresh();
        }


    }
}
