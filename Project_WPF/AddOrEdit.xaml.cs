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
        int productId;
        int providerId;
        int categoryId;
        int subCategoryId;
        int clientId;





        public AddOrEdit()
        {
            InitializeComponent();
        }

        private void AddFormLoaded(object sender, RoutedEventArgs e)
        {
            productId = Controll.ProductId;
            providerId = Controll.ProviderId;
            categoryId = Controll.CategoryId;
            subCategoryId = Controll.SubCategoryId;
            clientId = Controll.ClientId;



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


            Dictionary<int, string> cbProductData = new Dictionary<int, string>();
            var value = DB.GetAllSubCategory().OrderBy(a => a.Kategooria.Nimi);
            foreach (var item in value)
            {
                cbProductData.Add(item.ID, item.Nimi + " (" + item.Kategooria.Nimi + ")");
            }


            Dictionary<int, string> cbCategoryData = new Dictionary<int, string>();
            var valued = DB.GetAllCategory().OrderBy(a => a.Nimi);
            foreach (var item in valued)
            {
                cbCategoryData.Add(item.ID, item.Nimi);
            }

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
                //lbl3.Visibility = Visibility.Visible;
                //lbl4.Visibility = Visibility.Visible;
                lbl5.Visibility = Visibility.Visible;

                lbl1.Content = "Product name";
                lbl2.Content = "Product code";
                //lbl3.Content = "Quantity";
                //lbl4.Content = "Product price";
                lbl5.Content = "Category";

                txt1.Visibility = Visibility.Visible;
                txt2.Visibility = Visibility.Visible;
                // txt3.Visibility = Visibility.Visible;
                //txt4.Visibility = Visibility.Visible;
                cb5.Visibility = Visibility.Visible;

                txt1.Text = "Product name";
                txt2.Text = "Product code";
                //txt3.Text = "Quantity";
                //txt4.Text = "Product Price";

                cb5.ItemsSource = cbProductData;
                cb5.DisplayMemberPath = "Value";
                cb5.SelectedValuePath = "Key";
                //item.ID, item.Nimi + " (" + item.Kategooria.Nimi + ")"

                Toode tempProduct = DB.GetProductByProductId(productId);
                txt1.Text = tempProduct.Nimi;
                txt2.Text = tempProduct.KoodToode;

                //надо исправить сначала связь между товаром и категориями
                cb5.SelectedItem = new KeyValuePair<int, string>(DB.GetProductByProductId(productId).Alamkategooria.ID, DB.GetProductByProductId(productId).Alamkategooria.Nimi + " (" + DB.GetProductByProductId(productId).Alamkategooria.Kategooria.Nimi + ")");


                btn.Content = "Update Product";
            }



            else if (Controll.Name == "editCategory")
            {
                lbl1.Visibility = Visibility.Visible;
                lbl1.Content = "Category name";

                txt1.Visibility = Visibility.Visible;
                txt1.Text = "category";

                btn.Content = "Update Category";

                Kategooria tempCategory = DB.GetCategoryByCategoryId(categoryId);
                txt1.Text = tempCategory.Nimi;
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

                Alamkategooria tempSubCategory = DB.GetSubCategoryBySubCategoryId(subCategoryId);
                txt1.Text = tempSubCategory.Nimi;

                cb2.ItemsSource = cbCategoryData;
                cb2.DisplayMemberPath = "Value";
                cb2.SelectedValuePath = "Key";
                cb2.SelectedItem = new KeyValuePair<int, string>(DB.GetSubCategoryBySubCategoryId(subCategoryId).Kategooria.ID, DB.GetSubCategoryBySubCategoryId(subCategoryId).Kategooria.Nimi);

                btn.Content = "Update Sub Category";
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

                Klient tempKlient = DB.GetClientByClientId(clientId);

                txt1.Text = tempKlient.Nimi;
                txt2.Text = tempKlient.Perekonnanimi;
                txt3.Text = tempKlient.Telefon;
                txt4.Text = tempKlient.Aadress;
                txt5.Text = tempKlient.Email;



                btn.Content = "Update Client";
            }



            else if (Controll.Name == "editProvider")
            {
                Pakkuja tempProvider = DB.GetProviderByProviderId(providerId);
                txt1.Text = tempProvider.Nimi;
                txt2.Text = tempProvider.FN;
                txt3.Text = tempProvider.Aadress;


                lbl1.Visibility = Visibility.Visible;
                lbl2.Visibility = Visibility.Visible;
                lbl3.Visibility = Visibility.Visible;


                lbl1.Content = "Name";
                lbl2.Content = "FN";
                lbl3.Content = "Address";



                txt1.Visibility = Visibility.Visible;
                txt2.Visibility = Visibility.Visible;
                txt3.Visibility = Visibility.Visible;



                btn.Content = "Update Provider";
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
                    newProduct.AlamkategooriaId = ((KeyValuePair<int, string>)cb5.SelectedItem).Key;

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

                    MessageBox.Show("Error " + ex.ToString() + "!", "Error");
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
                    newSubCategory.KategooriaId = ((KeyValuePair<int, string>)cb2.SelectedItem).Key;

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
                try
                {
                    lbl1.Content = "Product name";
                    lbl2.Content = "Product code";
                    //lbl3.Content = "Quantity";
                    //lbl4.Content = "Product price";
                    lbl5.Content = "Category";

                    Toode updateToode = new Toode();
                    updateToode.ID = productId;
                    updateToode.Nimi = txt1.Text;
                    updateToode.KoodToode = txt2.Text;
                    updateToode.AlamkategooriaId = ((KeyValuePair<int, string>)cb5.SelectedItem).Key;


                    int error = DB.UpdateProduct(updateToode);
                    if (error != 0)
                    {
                        MessageBox.Show("Was Updated!", "Succesful");
                    }
                    else
                    {
                        MessageBox.Show("Error while updating!", "Error");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.ToString() + "!", "Error"); ;
                }
            }



            else if (Controll.Name == "editCategory")
            {
                try
                {
                    Kategooria updateCategory = new Kategooria();
                    updateCategory.ID = categoryId;
                    updateCategory.Nimi = txt1.Text;


                    int error = DB.UpdateCategory(updateCategory);
                    if (error != 0)
                    {
                        MessageBox.Show("Was Updated!", "Succesful");
                    }
                    else
                    {
                        MessageBox.Show("Error while updating!", "Error");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.ToString() + "!", "Error"); ;
                }
            }




            else if (Controll.Name == "editSubCategory")
            {
                try
                {
                    Alamkategooria updateSubCategory = new Alamkategooria();
                    updateSubCategory.ID = subCategoryId;
                    updateSubCategory.Nimi = txt1.Text;
                    updateSubCategory.KategooriaId = ((KeyValuePair<int, string>)cb2.SelectedItem).Key;



                    int error = DB.UpdateSubCategory(updateSubCategory);
                    if (error != 0)
                    {
                        MessageBox.Show("Was Updated!", "Succesful");
                    }
                    else
                    {
                        MessageBox.Show("Error while updating!", "Error");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.ToString() + "!", "Error"); ;
                }
            }



            else if (Controll.Name == "editClient")
            {
                try
                {
                    Klient updateClient = new Klient();
                    updateClient.ID = clientId;
                    updateClient.Nimi = txt1.Text;
                    updateClient.Perekonnanimi = txt2.Text;
                    updateClient.Telefon = txt3.Text;
                    updateClient.Aadress = txt4.Text;
                    updateClient.Email = txt5.Text;

                    int error = DB.UpdateClient(updateClient);
                    if (error != 0)
                    {
                        MessageBox.Show("Was Updated!", "Succesful");
                    }
                    else
                    {
                        MessageBox.Show("Error while updating!", "Error");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.ToString() + "!", "Error"); ;
                }
            }



            else if (Controll.Name == "editProvider")
            {
                try
                {
                    Pakkuja updateProvider = new Pakkuja();
                    updateProvider.ID = providerId;
                    updateProvider.Nimi = txt1.Text;
                    updateProvider.FN = txt2.Text;
                    updateProvider.Aadress = txt3.Text;

                    int error = DB.UpdateProvider(updateProvider);
                    if (error != 0)
                    {
                        MessageBox.Show("Was Updated!", "Succesful");
                    }
                    else
                    {
                        MessageBox.Show("Error while updating!", "Error");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.ToString() + "!", "Error"); ;
                }
            }
        }
    }
}
