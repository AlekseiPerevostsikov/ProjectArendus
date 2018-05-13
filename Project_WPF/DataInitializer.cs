using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaduDB;

namespace Project_WPF
{
    class DataInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            base.Seed(context);


            var camp = new List<Kategooria>
            {
                new Kategooria{Nimi = "Mouse"},
                new Kategooria{Nimi = "Keyboard"},
                new Kategooria{Nimi = "Monitor"},
                new Kategooria{Nimi = "CPU"},
                new Kategooria{Nimi = "Motherboard"}
            };

            camp.ForEach(a => context.Kategoorias.Add(a));
            context.SaveChanges();
        }
    }
}
