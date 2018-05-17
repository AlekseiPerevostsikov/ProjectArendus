using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaduDB;

namespace Project_WPF
{
    public class DataInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            base.Seed(context);


            var category = new List<Kategooria>
            {
                new Kategooria{Nimi = "Mouse"},
                new Kategooria{Nimi = "Keyboard"},
                new Kategooria{Nimi = "Monitor"},
                new Kategooria{Nimi = "CPU"},
                new Kategooria{Nimi = "Motherboard"}
            };

            category.ForEach(a => context.Kategoorias.Add(a));
            context.SaveChanges();



            var subcategory = new List<Alamkategooria>
            {
                new Alamkategooria{Nimi="Laser", KategooriaId = 1},
                new Alamkategooria{Nimi="Optical", KategooriaId = 1},
                new Alamkategooria{Nimi="Wireless", KategooriaId = 1},
                new Alamkategooria{Nimi="Mechanical",KategooriaId=2},
                new Alamkategooria{Nimi="Membrane", KategooriaId=2},
                new Alamkategooria{Nimi="LCD", KategooriaId=3},
                new Alamkategooria{Nimi="LED", KategooriaId=3},
                new Alamkategooria{Nimi="Intel", KategooriaId=4},
                new Alamkategooria{Nimi="AMD", KategooriaId=4},
                new Alamkategooria{Nimi="ATX", KategooriaId=5},
                new Alamkategooria{Nimi="mATX", KategooriaId=5},
                new Alamkategooria{Nimi="microATX", KategooriaId=5}
            };

            subcategory.ForEach(a => context.Alamkategoorias.Add(a));
            context.SaveChanges();



            var provider = new List<Pakkuja>
            {
                new Pakkuja{Nimi="ELKO Eesti OÜ", Aadress="Pärnu mnt 141, 11314 Tallinn", FN="10674202"},
                new Pakkuja{Nimi="ACC Distribution OÜ", Aadress="A. H. Tammsaare tee 118b Tallinn Harjumaa 12918", FN="11095699"}

            };

            provider.ForEach(a => context.Pakkujas.Add(a));
            context.SaveChanges();



            var clients = new List<Klient>
            {
                new Klient{Nimi="Andrei", Perekonnanimi="Novikov", Aadress="Toome pst. 18-20", Email="andrei.novikov@gmail.com",Telefon="+3725655443"},
                new Klient{Nimi="Anton", Perekonnanimi="Petrov", Aadress="Keskalee 12-46", Email="petrovantob@mail.ru", Telefon="55554313"},
                new Klient{Nimi="Toomas", Perekonnanimi="Ilves", Aadress="Taamsaare 18-200", Email="IlvesToom@hot.ee", Telefon="58454563"}

            };

            clients.ForEach(a => context.Klients.Add(a));
            context.SaveChanges();




            var items = new List<Toode>
            {
                new Toode{Nimi="Philips LCD Monitor 24'",Kogus= 10, KoodToode="T15487", AlamkategooriaId=6, Hind=250},
                new Toode{Nimi="SteelSeries Rival100", Kogus= 50, KoodToode="T15418", AlamkategooriaId=2, Hind=35}
            };
            items.ForEach(a => context.Toodes.Add(a));
            context.SaveChanges();



            var accepts = new List<SisseTuleb>
            {
                new SisseTuleb{Hind=200, Kogus=10,toodeId=1},
                new SisseTuleb{Hind=29, Kogus=50,toodeId=2}
            };

            accepts.ForEach(a => context.SisseTulebs.Add(a));
            context.SaveChanges();


            var arrivedProductChechk = new List<SisseTulebArv>
            {
               new SisseTulebArv{Date = DateTime.Now, PakkujaId = 1 , SisseTulebId=1, },
               new SisseTulebArv{Date = DateTime.Now, PakkujaId = 1 , SisseTulebId=2 }
            };

            arrivedProductChechk.ForEach(a => context.SisseTulebArvs.Add(a));
            context.SaveChanges();




        }
    }
}
