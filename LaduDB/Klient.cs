using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaduDB
{
    public class Klient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public String Nimi { get; set; }
        public String Perekonnanimi { get; set; }
        public String Telefon { get; set; }
        public String Aadress { get; set; }
        public String Email { get; set; }


        public virtual ICollection<Ostukorvi> Ostukorvis {get;set;}
    }
}
