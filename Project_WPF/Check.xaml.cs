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
    /// Логика взаимодействия для Check.xaml
    /// </summary>
    public partial class Check : Window
    {
        Arve CheckControllStatuss;


        public Check()
        {
            InitializeComponent();
        }

        private void FormActivated(object sender, EventArgs e)
        {
            LoadProductData();
        }

        public void LoadProductData()
        {
            ObservableCollection<Arve> chechkItems = new ObservableCollection<Arve>();
            foreach (var i in DB.GetAllCkecks().OrderBy(a => a.Date))
            {
                chechkItems.Add(i);
            }
            checklList.ItemsSource = chechkItems;
            lCheck.Content = "Check List(" + chechkItems.Count() + ")";
        }

        private void CheckSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (checklList.SelectedIndex>=0)
            {
                CheckControllStatuss = (Arve)checklList.SelectedItems[0];
            }
        }

        private bool CheckFilter(object item)
        {
            var korv = (Arve)item;
            if (String.IsNullOrEmpty(txtProductName.Text))
                return true;

            else
                return (korv.Ostukorvi.Toode.Nimi.StartsWith(txtProductName.Text, StringComparison.OrdinalIgnoreCase)
                || korv.Ostukorvi.Toode.Alamkategooria.Nimi.StartsWith(txtProductName.Text, StringComparison.OrdinalIgnoreCase)
                || korv.Ostukorvi.Klient.Nimi.StartsWith(txtProductName.Text, StringComparison.OrdinalIgnoreCase)
                || korv.Ostukorvi.Klient.Perekonnanimi.StartsWith(txtProductName.Text, StringComparison.OrdinalIgnoreCase));

        }

        private void txtProductName_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(checklList.ItemsSource);
            view.Filter = CheckFilter;
            CollectionViewSource.GetDefaultView(checklList.ItemsSource).Refresh();
        }
    }
}
