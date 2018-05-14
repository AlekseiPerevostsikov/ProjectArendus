using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaduDB
{
    public class Toode
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public String Nimi { get; set; }
        public long AlamKategoriaFK { get; set; }
        public int Kogus { get; set; }
        public String KoodToode { get; set; }
        public double Hind { get; set; }
        

        public virtual Alamkategooria Alamkategooria { get; set; }
        public virtual ICollection<SisseTuleb> SisseTulebs { get; set; }
        public virtual ICollection<Ostukorvi> Ostukorvis { get; set; }
    }
}
