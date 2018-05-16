﻿using LaduDB;
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
        Pakkuja ProviderControllStatuss;
        SisseTulebArv ArrivedProductCheckControllStatuss;

        // int productId;

        public ArrivedProducts()
        {
            InitializeComponent();
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
                //try
                //{
                SisseTulebArv temp = new SisseTulebArv();
                temp.SisseTuleb = new SisseTuleb { toodeId = ProductControllStatuss.ID, Kogus = Convert.ToInt16(cbProdyctQuntity.Text) };
                //.Toode.ID = ProductControllStatuss.ID;
                //temp.SisseTuleb.Toode.KoodToode = ProductControllStatuss.KoodToode;
                //temp.SisseTuleb.Toode.Nimi = ProductControllStatuss.Nimi;
                //temp.SisseTuleb.Kogus = Convert.ToInt16(cbProdyctQuntity.Text);
                temp.Pakkuja = ProviderControllStatuss;

                //temp.Hind = 10;
                temp.Date = DateTime.Now;

                int error = DB.AddArrivedProductCheck(temp);
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



        public void LoadArrivedProductCheckData()
        {
            ObservableCollection<SisseTulebArv> arrivedProductCheckItems = new ObservableCollection<SisseTulebArv>();
            foreach (SisseTulebArv i in DB.GetAllArrivedProductChecks().OrderBy(a => a.SisseTuleb.Toode.Nimi))
            {
                arrivedProductCheckItems.Add(i);
            }
            ArrivedProductChecklList.ItemsSource = arrivedProductCheckItems;
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


        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteTempProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ArrivedProductChecklList.SelectedIndex>=0)
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

       
    }
}
