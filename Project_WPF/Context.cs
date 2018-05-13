using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using LaduDB;

namespace Project_WPF
{
    class Context : DbContext
    {
        public Context(string connectionName)
            : base(connectionName)
        {
        }

        public Context()
            : base("LaduDB")
        {
        }

        public DbSet<Alamkategooria> Alamkategoorias { get; set; }
        public DbSet<Arve> Arves { get; set; }
        public DbSet<Kategooria> Kategoorias { get; set; }
        public DbSet<Klient> Klients { get; set; }
        public DbSet<Ostukorvi> Ostukorvis { get; set; }
        public DbSet<Pakkuja> Pakkujas { get; set; }
        public DbSet<SisseTuleb> SisseTulebs { get; set; }
        public DbSet<SisseTulebArv> SisseTulebArvs { get; set; }
        public DbSet<Toode> Toodes { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
