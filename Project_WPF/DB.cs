using LaduDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_WPF
{
     public class DB
    {
        static Context c = new Context();




        /// 
        ///         Select
        /// 
        ///


            
        public static List<Alamkategooria> GetAllSubCategory()
        {
            return c.Alamkategoorias.ToList();
        }


        public static List<Arve> GetAllCkecks()
        {
            return c.Arves.ToList();
        }


        public static List<Kategooria> GetAllCategory()
        {
            return c.Kategoorias.ToList();
        }


        public static List<Klient> GetAllKlients()
        {
            return c.Klients.ToList();
        }


        public static List<Ostukorvi> GetAllBaskets()
        {
            return c.Ostukorvis.ToList();
        }


        public static List<Pakkuja> GetAllProviders()
        {
            return c.Pakkujas.ToList();
        }


        public static List<SisseTuleb> GetAllArrivedProducts()
        {
            return c.SisseTulebs.ToList();
        }


        public static List<SisseTulebArv> GetAllArrivedProductChecks()
        {
            return c.SisseTulebArvs.ToList();
        }



        public static List<SisseTulebArv> GetAllArrivedProductChecksWhereDate(DateTime date)
        {
            return c.SisseTulebArvs.Where(a=>a.Date>=date).ToList();
        }


        public static List<Toode> GetAllProducts()
        {
            return c.Toodes.ToList();
        }






        ///
        ///         Find klass by Id
        ///
        ///



        public static Alamkategooria GetSubCategoryBySubCategoryId(int subCategoryId)
        {
            return c.Alamkategoorias.Where(a => a.ID == subCategoryId).First();
        }


        public static Arve GetCheckByCheckId(int checkId)
        {
            return c.Arves.Where(a => a.ID == checkId).First();
        }


        public static Kategooria GetCategoryByCategoryId(int categoryId)
        {
            return c.Kategoorias.Where(a => a.ID == categoryId).First();
        }


        public static Klient GetClientByClientId(int clientId)
        {
            return c.Klients.Where(a => a.ID == clientId).First();
        }


        public static Ostukorvi GetBasketByBasketId(int basketId)
        {
            return c.Ostukorvis.Where(a => a.ID == basketId).First();
        }


        public static Pakkuja GetProviderByProviderId(int providerId)
        {
            return c.Pakkujas.Where(a => a.ID == providerId).First();
        }


        public static SisseTuleb GetArrivedProductByArrivedProductId(int arrivedProductId)
        {
            return c.SisseTulebs.Where(a => a.ID == arrivedProductId).First();
        }


        public static SisseTulebArv GetArrivedProductCheckByArrivedProductCheckId(int arrivedProductCheckId)
        {
            return c.SisseTulebArvs.Where(a => a.ID == arrivedProductCheckId).First();
        }


        public static Toode GetProductByProductId(int productId)
        {
            return c.Toodes.Where(a => a.ID == productId).First();
        }












        /// 
        ///         Insert
        /// 
        ///



        public static int AddSubCategory(Alamkategooria subCategory)
        {
            int error = 0;
            try
            {
                c.Alamkategoorias.Add(subCategory);
                c.SaveChanges();
                error = 1;
            }
            catch
            {
                error = 0;
            }
            return error;
        }


        public static int AddCkeck(Arve check)
        {
            int error = 0;
            try
            {
                c.Arves.Add(check);
                c.SaveChanges();
                error = 1;
            }
            catch
            {
                error = 0;
            }
            return error;
        }


        public static int AddCategory(Kategooria category)
        {
            int error = 0;
            try
            {
                c.Kategoorias.Add(category);
                c.SaveChanges();
                error = 1;
            }
            catch
            {
                error = 0;
            }
            return error;
        }


        public static int AddKlient(Klient klient)
        {
            int error = 0;
            try
            {
                c.Klients.Add(klient);
                c.SaveChanges();
                error = 1;
            }
            catch
            {
                error = 0;
            }
            return error;
        }


        public static int AddBasket(Ostukorvi basket)
        {
            int error = 0;
            try
            {
                c.Ostukorvis.Add(basket);
                c.SaveChanges();
                error = 1;
            }
            catch
            {
                error = 0;
            }
            return error;
        }


        public static int AddProvider(Pakkuja provider)
        {
            int error = 0;
            try
            {
                c.Pakkujas.Add(provider);
                c.SaveChanges();
                error = 1;
            }
            catch
            {
                error = 0;
            }
            return error;
        }


        public static int AddArrivedProduct(SisseTuleb arrivedProduct)
        {
            int error = 0;
            try
            {
                c.SisseTulebs.Add(arrivedProduct);
                c.SaveChanges();
                error = 1;
            }
            catch
            {
                error = 0;
            }
            return error;
        }


        public static int AddArrivedProductCheck(SisseTulebArv arrivedProductCheck)
        {
            int error = 0;
            try
            {
                c.SisseTulebArvs.Add(arrivedProductCheck);
                c.SaveChanges();
                error = 1;
            }
            catch
            {
                error = 0;
            }
            return error;
        }


        public static int AddProduct(Toode product)
        {
            int error = 0;
            try
            {
                c.Toodes.Add(product);
                c.SaveChanges();
                error = 1;
            }
            catch
            {
                error = 0;
            }
            return error;
        }




        /// 
        ///         Update
        /// 
        ///



        public static int UpdateProductQuantity(int productId, int quantity)
        {
            int error = 0;
            try
            {
                var original = c.Toodes.Find(productId);
                Toode temp = DB.GetProductByProductId(productId);
                temp.Kogus += quantity;
                c.Entry(original).CurrentValues.SetValues(temp);
                c.SaveChanges();
                error = 1;
            }
            catch
            {
                error = 0;
            }
            return error;
        }



        public static int UpdateSubCategory(Alamkategooria subCategory)
        {
            int error = 0;
            try
            {
                var original = c.Alamkategoorias.Find(subCategory.ID);
                c.Entry(original).CurrentValues.SetValues(subCategory);
                c.SaveChanges();
                error = 1;
            }
            catch
            {
                error = 0;
            }
            return error;
        }


        public static int UpdateCkeck(Arve check)
        {
            int error = 0;
            try
            {
                var original = c.Arves.Find(check.ID);
                c.Entry(original).CurrentValues.SetValues(check);
                c.SaveChanges();
                error = 1;
            }
            catch
            {
                error = 0;
            }
            return error;
        }


        public static int UpdateCategory(Kategooria category)
        {
            int error = 0;
            try
            {
                var original = c.Kategoorias.Find(category.ID);
                c.Entry(original).CurrentValues.SetValues(category);
                c.SaveChanges();
                error = 1;
            }
            catch
            {
                error = 0;
            }
            return error;
        }


        public static int UpdateClient(Klient klient)
        {
            int error = 0;
            try
            {
                var original = c.Klients.Find(klient.ID);
                c.Entry(original).CurrentValues.SetValues(klient);
                c.SaveChanges();
                error = 1;
            }
            catch
            {
                error = 0;
            }
            return error;
        }


        public static int UpdateBasket(Ostukorvi basket)
        {
            int error = 0;
            try
            {
                var original = c.Ostukorvis.Find(basket.ID);
                c.Entry(original).CurrentValues.SetValues(basket);
                c.SaveChanges();
                error = 1;
            }
            catch
            {
                error = 0;
            }
            return error;
        }


        public static int UpdateProvider(Pakkuja provider)
        {
            int error = 0;
            try
            {
                var original = c.Pakkujas.Find(provider.ID);
                c.Entry(original).CurrentValues.SetValues(provider);
                c.SaveChanges();
                error = 1;
            }
            catch
            {
                error = 0;
            }
            return error;
        }


        public static int UpdateArrivedProduct(SisseTuleb arrivedProduct)
        {
            int error = 0;
            try
            {
                var original = c.SisseTulebs.Find(arrivedProduct.ID);
                c.Entry(original).CurrentValues.SetValues(arrivedProduct);
                c.SaveChanges();
                error = 1;
            }
            catch
            {
                error = 0;
            }
            return error;
        }


        public static int UpdateArrivedProductCheck(SisseTulebArv arrivedProductCheck)
        {
            int error = 0;
            try
            {
                var original = c.SisseTulebArvs.Find(arrivedProductCheck.ID);
                c.Entry(original).CurrentValues.SetValues(arrivedProductCheck);
                c.SaveChanges();
                error = 1;
            }
            catch
            {
                error = 0;
            }
            return error;
        }


        public static int UpdateProduct(Toode product)
        {
            int error = 0;
            try
            {
                var original = c.Toodes.Find(product.ID);
                c.Entry(original).CurrentValues.SetValues(product);
                c.SaveChanges();
                error = 1;
            }
            catch
            {
                error = 0;
            }
            return error;
        }






        /// 
        ///         Delete
        /// 
        ///



        public static int DeleteSubCategory(Alamkategooria subCategory)
        {
            int error = 0;
            try
            {
                c.Alamkategoorias.Remove(subCategory);
                c.SaveChanges();
                error = 1;
            }
            catch
            {
                error = 0;
            }
            return error;
        }


        public static int DeleteCkeck(Arve check)
        {
            int error = 0;
            try
            {
                c.Arves.Remove(check);
                c.SaveChanges();
                error = 1;
            }
            catch
            {
                error = 0;
            }
            return error;
        }


        public static int DeleteCategory(Kategooria category)
        {
            int error = 0;
            try
            {
                c.Kategoorias.Remove(category);
                c.SaveChanges();
                error = 1;
            }
            catch
            {
                error = 0;
            }
            return error;
        }


        public static int DeleteClient(Klient klient)
        {
            int error = 0;
            try
            {
                c.Klients.Remove(klient);
                c.SaveChanges();
                error = 1;
            }
            catch
            {
                error = 0;
            }
            return error;
        }


        public static int DeleteBasket(Ostukorvi basket)
        {
            int error = 0;
            try
            {
                c.Ostukorvis.Remove(basket);
                c.SaveChanges();
                error = 1;
            }
            catch
            {
                error = 0;
            }
            return error;
        }


        public static int DeleteProvider(Pakkuja provider)
        {
            int error = 0;
            try
            {
                c.Pakkujas.Remove(provider);
                c.SaveChanges();
                error = 1;
            }
            catch
            {
                error = 0;
            }
            return error;
        }


        public static int DeleteArrivedProduct(SisseTuleb arrivedProduct)
        {
            int error = 0;
            try
            {
                c.SisseTulebs.Remove(arrivedProduct);
                c.SaveChanges();
                error = 1;
            }
            catch
            {
                error = 0;
            }
            return error;
        }


        public static int DeleteArrivedProductCheck(SisseTulebArv arrivedProductCheck)
        {
            int error = 0;
            try
            {
                c.SisseTulebArvs.Remove(arrivedProductCheck);
                c.SaveChanges();
                error = 1;
            }
            catch
            {
                error = 0;
            }
            return error;
        }


        public static int DeleteProduct(Toode product)
        {
            int error = 0;
            try
            {
                c.Toodes.Remove(product);
                c.SaveChanges();
                error = 1;
            }
            catch
            {
                error = 0;
            }
            return error;
        }








        public static void Save()
        {
            c.SaveChanges();
        }
    }
}
