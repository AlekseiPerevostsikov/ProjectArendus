using LaduDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_WPF
{
    class DB
    {
        static Context c = new Context();


        public static List<Kategooria> GetAllCategory()
        {
            return c.Kategoorias.ToList();
        }

        public static List<Alamkategooria> GetAllSubCategory()
        {
            return c.Alamkategoorias.ToList();
        }



    }
}
