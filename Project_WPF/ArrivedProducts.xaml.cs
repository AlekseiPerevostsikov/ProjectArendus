﻿using LaduDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        Pakkuja ProviderControllStatuss;
        SisseTulebArv ArrivedProductCheckControllStatuss;
        ObservableCollection<SisseTulebArv> arrivedProductCheckItems;

        double productPriceWithoutTax;
        double productPriceWithTaxAndPluss;
        

        // int productId;

        public ArrivedProducts()
        {
            InitializeComponent();
            cbPriceAfterDot.MaxLength = 2;
        }


        private void FormActivated(object sender, EventArgs e)
        {
            LoadProductData();
            LoadProviderData();
            LoadArrivedProductCheckData();
        }

        private void FormLoaded(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i <= 200; i++)
            {
                cbProdyctQuntity.Items.Add(i);
            }
            cbProdyctQuntity.SelectedIndex = 0;

            //for (int i = 1; i <= 1500; i++)
            //{
            //    cbPriceBeforeDot.Items.Add(i);
            //}
            //cbPriceBeforeDot.SelectedIndex = 9;

            //for (int i = 0; i <= 99; i++)
            //{
            //    cbPriceAfterDot.Items.Add(i);
            //}
            //cbPriceAfterDot.SelectedIndex = 0;
        }



        private void btnAddNewProduct_Click(object sender, RoutedEventArgs e)
        {
            AddOrEdit addOrEdit = new AddOrEdit();
            addOrEdit.Title = "Add Product";
            Controll.Name = "addProduct";
            addOrEdit.Show();
        }

    

        private void btnAddToTemp_Click(object sender, RoutedEventArgs e)
        {
            if (productlList.SelectedIndex >= 0 && providerlList.SelectedIndex >= 0)
            {
                    try
                {
                    
                        productPriceWithoutTax = Convert.ToDouble(cbPriceBeforeDot.Text) + (Convert.ToDouble(cbPriceAfterDot.Text) / 100);
                        productPriceWithTaxAndPluss = productPriceWithoutTax + (productPriceWithoutTax * (ControllForm.StaticTax.Tax.Warehousetax / 100)) + (productPriceWithoutTax * (ControllForm.StaticTax.Tax.Statetax / 100));
                        SisseTulebArv temp = new SisseTulebArv();
                        temp.SisseTuleb = new SisseTuleb { toodeId = ProductControllStatuss.ID, Kogus = Convert.ToInt32(cbProdyctQuntity.Text) };

                        //temp.SisseTuleb.Toode.Hind= productPriceWithTaxAndPluss;
                        //.Toode.ID = ProductControllStatuss.ID;
                        //temp.SisseTuleb.Toode.KoodToode = ProductControllStatuss.KoodToode;
                        //temp.SisseTuleb.Toode.Nimi = ProductControllStatuss.Nimi;
                        //temp.SisseTuleb.Kogus = Convert.ToInt16(cbProdyctQuntity.Text);
                        temp.Pakkuja = ProviderControllStatuss;

                        // temp.SisseTuleb.Hind = productPriceWithoutTax;
                        //temp.SisseTuleb.Toode.Hind = productPriceWithTaxAndPluss;
                        temp.Date = DateTime.Now;


                        
                        int error = DB.AddArrivedProductCheck(temp);
                        DB.UpdateProductPriseWInArrived(ProductControllStatuss.ID, productPriceWithTaxAndPluss);

                        DB.UpdateProductPriseWithTaxInArrived(temp.SisseTuleb.ID, productPriceWithoutTax);
                        if (error != 0)
                        {
                            MessageBox.Show("Was Added!", "Succesful",MessageBoxButton.OK,MessageBoxImage.Question);
                        lTemp.Content = "Temporary data(" + arrivedProductCheckItems.Count() + ")";
                        }
                        else
                        {
                            MessageBox.Show("Error while adding!", "Error", MessageBoxButton.OK,MessageBoxImage.Error);
                        }
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error!", "Error", MessageBoxButton.OK,MessageBoxImage.Error); ;
                }


            }
            else
            {
                MessageBox.Show("Error product or provider not choosed!", "Error");
            }
        }








        public void LoadProductData()
        {
            ObservableCollection<Toode> productItems = new ObservableCollection<Toode>();
            foreach (Toode i in DB.GetAllProducts().OrderBy(a => a.Nimi))
            {
                productItems.Add(i);
            }
            productlList.ItemsSource = productItems;
            lbl.Content = "Products(" + productItems.Count() + ")";

        }

        public void LoadProviderData()
        {
            ObservableCollection<Pakkuja> providerItems = new ObservableCollection<Pakkuja>();
            foreach (Pakkuja i in DB.GetAllProviders().OrderBy(a => a.Nimi))
            {
                providerItems.Add(i);
            }
            providerlList.ItemsSource = providerItems;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(providerlList.ItemsSource);
            view.Filter = ProviderFilter;
            lProvider.Content = "Provider(" + providerItems.Count() + ")";
        }



        public void LoadArrivedProductCheckData()
        {
            arrivedProductCheckItems = new ObservableCollection<SisseTulebArv>();
            foreach (SisseTulebArv i in DB.GetAllArrivedProductChecksWhereDate(Controll.dateTimeArrivedProduct).OrderBy(a => a.SisseTuleb.Toode.Nimi))
            {
                arrivedProductCheckItems.Add(i);
            }
            ArrivedProductChecklList.ItemsSource = arrivedProductCheckItems;
            lTemp.Content = "Temporary data(" + arrivedProductCheckItems.Count() + ")";
        }






        private void ProductSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (productlList.SelectedIndex >= 0)
            {
                ProductControllStatuss = (Toode)productlList.SelectedItems[0];
            }

        }



        private void ProviderSelectionCHanged(object sender, SelectionChangedEventArgs e)
        {
            if (providerlList.SelectedIndex >= 0)
            {
                ProviderControllStatuss = (Pakkuja)providerlList.SelectedItems[0];
            }
        }


        private void ArrivedProductCheckSelectionCHanged(object sender, SelectionChangedEventArgs e)
        {
            if (ArrivedProductChecklList.SelectedIndex >= 0)
            {
                ArrivedProductCheckControllStatuss = (SisseTulebArv)ArrivedProductChecklList.SelectedItems[0];
            }
        }



        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (productlList.SelectedIndex >= 0 && ArrivedProductChecklList.SelectedIndex >= 0)
            {
                if (ProductControllStatuss.Kogus >= 0)
                {
                    //DB.Add1QuantityFromProductInArrived(ProductControllStatuss.ID); //Add1QuantityFromProductInBuy(ProductControllStatuss.ID);
                    //cbProdyctQuntity.Items.Clear();
                    // LoadProductData();

                    DB.Remove1QuantityFromProductInArrivedTempData(ArrivedProductCheckControllStatuss.ID);//Remove1QuantityFromProductInBasket(BasketControllStatuss.ID);
                    LoadArrivedProductCheckData();
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
            if (productlList.SelectedIndex >= 0 && ArrivedProductChecklList.SelectedIndex >= 0)
            {
                if (ArrivedProductCheckControllStatuss.SisseTuleb.Kogus > 1)
                {
                    // DB.Remove1QuantityFromProductInArrived(ProductControllStatuss.ID);//Remove1QuantityFromProductInBuy(ProductControllStatuss.ID);
                    // cbProdyctQuntity.Items.Clear();
                    //LoadProductData();

                    DB.Add1QuantityFromProductInArrivedTempData(ArrivedProductCheckControllStatuss.ID);//Add1QuantityFromProductInBasket(BasketControllStatuss.ID);
                    LoadArrivedProductCheckData();
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




        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (ArrivedProductChecklList.SelectedIndex >= 0)
            {
                if (MessageBox.Show("Confirm temp products?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                }
                else
                {
                    try
                    {
                        foreach (var i in arrivedProductCheckItems)
                        {
                            DB.UpdateProductQuantity(i.SisseTuleb.Toode.ID, i.SisseTuleb.Kogus);
                        }
                        Controll.dateTimeArrivedProduct = DateTime.Now;
                        arrivedProductCheckItems.Clear();
                        LoadProductData();
                        lTemp.Content = "Temporary data(" + arrivedProductCheckItems.Count() + ")";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex.ToString() + "!", "Error");
                    }
                }
            }
            else
            {
                MessageBox.Show("Arrived product check is empty!", "Error");
            }

        }

        private void btnDeleteTempProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ArrivedProductChecklList.SelectedIndex >= 0)
            {
                if (MessageBox.Show("Delete temp data?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                }
                else
                {
                    SisseTulebArv deleteArrivedProductCheck = DB.GetArrivedProductCheckByArrivedProductCheckId(ArrivedProductCheckControllStatuss.ID);

                    int arv = DB.DeleteArrivedProductCheck(deleteArrivedProductCheck);

                    if (arv != 0)
                    {
                        MessageBox.Show("Was deleted!", "Succesful");
                        ArrivedProductChecklList.SelectedIndex = 0;
                        lTemp.Content = "Temporary data(" + arrivedProductCheckItems.Count() + ")";
                    }
                    else
                    {
                        MessageBox.Show("Error while deleting!", "Error");
                    }

                }
            }
            else
            {
                MessageBox.Show("Arrived product check not choosed!", "Error");
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

        private bool TempProductFilter(object item)
        {
            var toode = (SisseTulebArv)item;
            if (String.IsNullOrEmpty(txtProductName_Copy.Text))
                return true;

            else
                return (toode.SisseTuleb.Toode.Nimi.StartsWith(txtProductName_Copy.Text, StringComparison.OrdinalIgnoreCase)
                || toode.SisseTuleb.Toode.Alamkategooria.Nimi.StartsWith(txtProductName_Copy.Text, StringComparison.OrdinalIgnoreCase)
                || toode.SisseTuleb.Toode.Alamkategooria.Kategooria.Nimi.StartsWith(txtProductName_Copy.Text, StringComparison.OrdinalIgnoreCase)
                || toode.SisseTuleb.Toode.KoodToode.StartsWith(txtProductName_Copy.Text, StringComparison.OrdinalIgnoreCase)
                || toode.Pakkuja.Nimi.StartsWith(txtProductName_Copy.Text, StringComparison.OrdinalIgnoreCase)
                || toode.Date.Year.ToString().StartsWith(txtProductName_Copy.Text, StringComparison.OrdinalIgnoreCase)
                || toode.Date.Month.ToString().StartsWith(txtProductName_Copy.Text, StringComparison.OrdinalIgnoreCase)
                || toode.Date.Day.ToString().StartsWith(txtProductName_Copy.Text, StringComparison.OrdinalIgnoreCase));

        }

        private bool ProviderFilter(object item)
        {
            if (String.IsNullOrEmpty(txtProviderName.Text))
                return true;
            else
                return ((item as Pakkuja).Nimi.IndexOf(txtProviderName.Text, StringComparison.OrdinalIgnoreCase) >= 0);

        }




        private void txtProductName_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(productlList.ItemsSource);
            view.Filter = ProductFilter;
            CollectionViewSource.GetDefaultView(productlList.ItemsSource).Refresh();
        }

        private void txtProviderName_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(providerlList.ItemsSource).Refresh();
        }

        private void txtProductName_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ArrivedProductChecklList.ItemsSource);
            view.Filter = TempProductFilter;
            CollectionViewSource.GetDefaultView(ArrivedProductChecklList.ItemsSource).Refresh();
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }

        private void cbPriceAfterDot_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void cbPriceBeforeDot_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
    }
}
