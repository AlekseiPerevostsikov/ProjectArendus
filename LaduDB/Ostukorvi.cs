using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaduDB
{
    public class Ostukorvi
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int KlientId { get; set; }
        public int ToodeId { get; set; }
        public int Kogus { get; set; }

        
        public virtual Klient Klient { get; set; }
        public virtual Toode Toode { get; set; }

        
    }
}
