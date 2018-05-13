using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaduDB
{
    public class SisseTuleb
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public long toodeFK { get; set; }
        public double Hind { get; set; }
        public int Kogus { get; set; }

        public virtual Toode Toode { get; set; }
        
    }
}
