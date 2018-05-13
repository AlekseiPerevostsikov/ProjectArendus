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
        public long ID { get; set; }
        public long KlientFK { get; set; }
        public long ToodeFK { get; set; }
        public int Kogus { get; set; }

        
        public virtual Klient Klient { get; set; }
        public virtual Toode Toode { get; set; }

        
    }
}
