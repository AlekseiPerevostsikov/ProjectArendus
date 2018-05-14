using LaduDB;
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
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class AddOrEdit : Window
    {
        public AddOrEdit()
        {
            InitializeComponent();
        }

        private void AddFormLoaded(object sender, RoutedEventArgs e)
        {
            lbl1.Visibility = Visibility.Hidden;
            lbl2.Visibility = Visibility.Hidden;
            lbl3.Visibility = Visibility.Hidden;
            lbl4.Visibility = Visibility.Hidden;
            lbl5.Visibility = Visibility.Hidden;

            txt1.Visibility = Visibility.Hidden;
            txt2.Visibility = Visibility.Hidden;
            txt3.Visibility = Visibility.Hidden;
            txt4.Visibility = Visibility.Hidden;
            txt5.Visibility = Visibility.Hidden;

            cb2.Visibility = Visibility.Hidden;
            cb5.Visibility = Visibility.Hidden;




            //      Add value


            if (Controll.Name == "addProduct")
            {
                lbl1.Visibility = Visibility.Visible;
                lbl2.Visibility = Visibility.Visible;
               // lbl3.Visibility = Visibility.Visible;
               // lbl4.Visibility = Visibility.Visible;
                lbl5.Visibility = Visibility.Visible;

                lbl1.Content = "Product name";
                lbl2.Content = "Product code";
               // lbl3.Content = "Quantity";
               // lbl4.Content = "Product price";
                lbl5.Content = "Category";

                txt1.Visibility = Visibility.Visible;
                txt2.Visibility = Visibility.Visible;
               // txt3.Visibility = Visibility.Visible;
               // txt4.Visibility = Visibility.Visible;
                cb5.Visibility = Visibility.Visible;



                Dictionary<int, string> cbProductData = new Dictionary<int, string>();
                var value = DB.GetAllSubCategory().OrderBy(a=>a.Kategooria.Nimi);
                foreach (var item in value)
                {
                    cbProductData.Add(item.ID, item.Nimi + " (" + item.Kategooria.Nimi + ")");
                }

                cb5.ItemsSource = cbProductData;
                cb5.DisplayMemberPath = "Value";
                cb5.SelectedValuePath = "Key";
                cb5.SelectedIndex = 0;

                btn.Content = "Add Product";
            }



            else if (Controll.Name == "addCategory")
            {
                lbl1.Visibility = Visibility.Visible;
                lbl1.Content = "Category name";

                txt1.Visibility = Visibility.Visible;

                btn.Content = "Add Category";
            }



            else if (Controll.Name == "addSubCategory")
            {
                lbl1.Visibility = Visibility.Visible;
                lbl2.Visibility = Visibility.Visible;

                lbl1.Content = "Sub category name";
                lbl2.Content = "Category name";

                txt1.Visibility = Visibility.Visible;

                cb2.Visibility = Visibility.Visible;

                Dictionary<int, string> cbCategoryData = new Dictionary<int, string>();
                var value = DB.GetAllCategorys().OrderBy(a => a.Nimi);
                foreach (var item in value)
                {
                    cbCategoryData.Add(item.ID, item.Nimi);
                }

                cb2.ItemsSource = cbCategoryData;
                cb2.DisplayMemberPath = "Value";
                cb2.SelectedValuePath = "Key";
                cb2.SelectedIndex = 0;


                btn.Content = "Add Sub Category";
            }



            else if (Controll.Name == "addClient")
            {
                lbl1.Visibility = Visibility.Visible;
                lbl2.Visibility = Visibility.Visible;
                lbl3.Visibility = Visibility.Visible;
                lbl4.Visibility = Visibility.Visible;
                lbl5.Visibility = Visibility.Visible;

                lbl1.Content = "First name";
                lbl2.Content = "Last name";
                lbl3.Content = "Phone";
                lbl4.Content = "Address";
                lbl5.Content = "eMail";


                txt1.Visibility = Visibility.Visible;
                txt2.Visibility = Visibility.Visible;
                txt3.Visibility = Visibility.Visible;
                txt4.Visibility = Visibility.Visible;
                txt5.Visibility = Visibility.Visible;

                btn.Content = "Add Client";
            }


            else if (Controll.Name == "addProvider")
            {
                lbl1.Visibility = Visibility.Visible;
                lbl2.Visibility = Visibility.Visible;
                lbl3.Visibility = Visibility.Visible;

                lbl1.Content = "Name";
                lbl2.Content = "FN";
                lbl3.Content = "Address";

                txt1.Visibility = Visibility.Visible;
                txt2.Visibility = Visibility.Visible;
                txt3.Visibility = Visibility.Visible;


                btn.Content = "Add Provider";
            }







            //Edit value


            if (Controll.Name == "editProduct")
            {
                lbl1.Visibility = Visibility.Visible;
                lbl2.Visibility = Visibility.Visible;
                lbl3.Visibility = Visibility.Visible;
                lbl4.Visibility = Visibility.Visible;
                lbl5.Visibility = Visibility.Visible;

                lbl1.Content = "Product name";
                lbl2.Content = "Product code";
                lbl3.Content = "Quantity";
                lbl4.Content = "Product price";
                lbl5.Content = "Category";

                txt1.Visibility = Visibility.Visible;
                txt2.Visibility = Visibility.Visible;
                txt3.Visibility = Visibility.Visible;
                txt4.Visibility = Visibility.Visible;
                cb5.Visibility = Visibility.Visible;

                txt1.Text = "Product name";
                txt2.Text = "Product code";
                txt3.Text = "Quantity";
                txt4.Text = "Product Price";
               
                cb5.ItemsSource = new string[] { "Auto", "Phone", "TV" };

                btn.Content = "Edit Product";
            }



            else if (Controll.Name == "editCategory")
            {
                lbl1.Visibility = Visibility.Visible;
                lbl1.Content = "Category name";

                txt1.Visibility = Visibility.Visible;
                txt1.Text = "category";

                btn.Content = "Edit Category";
            }




            else if (Controll.Name == "editSubCategory")
            {
                lbl1.Visibility = Visibility.Visible;
                lbl2.Visibility = Visibility.Visible;

                lbl1.Content = "Sub category name";
                lbl2.Content = "Category name";

                txt1.Visibility = Visibility.Visible;
                cb2.Visibility = Visibility.Visible;

                txt1.Text = "sub category";

               
                cb2.ItemsSource = new string[] { "1", "2", "3" };

                btn.Content = "Edit Sub Category";
            }



            else if (Controll.Name == "editClient")
            {
                lbl1.Visibility = Visibility.Visible;
                lbl2.Visibility = Visibility.Visible;
                lbl3.Visibility = Visibility.Visible;
                lbl4.Visibility = Visibility.Visible;
                lbl5.Visibility = Visibility.Visible;

                lbl1.Content = "First name";
                lbl2.Content = "Last name";
                lbl3.Content = "Phone";
                lbl4.Content = "Address";
                lbl5.Content = "eMail";


                txt1.Visibility = Visibility.Visible;
                txt2.Visibility = Visibility.Visible;
                txt3.Visibility = Visibility.Visible;
                txt4.Visibility = Visibility.Visible;
                txt5.Visibility = Visibility.Visible;

                txt1.Text = "first name";
                txt2.Text = "last name";
                txt3.Text = "phone";
                txt4.Text = "Address";
                txt5.Text = "eMail";

                btn.Content = "Edit Client";
            }



            else if (Controll.Name == "editProvider")
            {
                lbl1.Visibility = Visibility.Visible;
                lbl2.Visibility = Visibility.Visible;
                lbl3.Visibility = Visibility.Visible;


                lbl1.Content = "Name";
                lbl2.Content = "FN";
                lbl3.Content = "Address";


               
                txt1.Visibility = Visibility.Visible;
                txt2.Visibility = Visibility.Visible;
                txt3.Visibility = Visibility.Visible;

                txt1.Text = "Name";
                txt2.Text = "FN";
                txt3.Text = "Address";

                btn.Content = "Edit Provider";
            }




        }



        //          Btn pressed


        private void btn_Click(object sender, RoutedEventArgs e)
        {
            
            //      Add value


            if (Controll.Name == "addProduct")
            {
                try
                {
                    Toode newProduct = new Toode();
                    newProduct.Nimi = txt1.Text;
                    newProduct.KoodToode = txt2.Text;
                    newProduct.AlamKategoriaId = ((KeyValuePair<int, string>)cb5.SelectedItem).Key;

                    int error = DB.AddProduct(newProduct);
                    if (error != 0)
                    {
                        MessageBox.Show("Was Added!", "Succesful");
                    }
                    else
                    {
                        MessageBox.Show("Error while adding!", "Error");
                    }
                }
                catch (Exception ex)
                {

                     MessageBox.Show("Error "+ex.ToString()+"!", "Error");
                }
    }



            else if (Controll.Name == "addCategory")
            {
                try
                {
                    Kategooria newCategory = new Kategooria();
                    newCategory.Nimi = txt1.Text;
                
                    int error = DB.AddCategory(newCategory);
                    if (error != 0)
                    {
                        MessageBox.Show("Was Added!", "Succesful");
                    }
                    else
                    {
                        MessageBox.Show("Error while adding!", "Error");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.ToString() + "!", "Error"); ;
                }
            }



            else if (Controll.Name == "addSubCategory")
            {
                try
                {
                    Alamkategooria newSubCategory = new Alamkategooria();
                    newSubCategory.Nimi = txt1.Text;
                    newSubCategory.KategooriaId= ((KeyValuePair<int, string>)cb2.SelectedItem).Key;

                    int error = DB.AddSubCategory(newSubCategory);
                    if (error != 0)
                    {
                        MessageBox.Show("Was Added!", "Succesful");
                    }
                    else
                    {
                        MessageBox.Show("Error while adding!", "Error");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.ToString() + "!", "Error"); ;
                }
            }



            else if (Controll.Name == "addClient")
            {
                try
                {
                    Klient newKlient = new Klient();
                    newKlient.Nimi = txt1.Text;
                    newKlient.Perekonnanimi = txt2.Text;
                    newKlient.Telefon = txt3.Text;
                    newKlient.Aadress = txt4.Text;
                    newKlient.Email = txt5.Text;

                    int error = DB.AddKlient(newKlient);
                    if (error != 0)
                    {
                        MessageBox.Show("Was Added!", "Succesful");
                    }
                    else
                    {
                        MessageBox.Show("Error while adding!", "Error");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.ToString() + "!", "Error"); ;
                }

            }


            else if (Controll.Name == "addProvider")
            {
                try
                {
                    Pakkuja newProvider = new Pakkuja();
                    newProvider.Nimi = txt1.Text;
                    newProvider.FN = txt2.Text;
                    newProvider.Aadress = txt3.Text;

                    int error = DB.AddProvider(newProvider);
                    if (error != 0)
                    {
                        MessageBox.Show("Was Added!", "Succesful");
                    }
                    else
                    {
                        MessageBox.Show("Error while adding!", "Error");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.ToString() + "!", "Error"); ;
                }


            }







            //Edit value


            if (Controll.Name == "editProduct")
            {
               
            }



            else if (Controll.Name == "editCategory")
            {
               
            }




            else if (Controll.Name == "editSubCategory")
            {
                
            }



            else if (Controll.Name == "editClient")
            {
               
            }



            else if (Controll.Name == "editProvider")
            {
                
            }
        }
    }
}
