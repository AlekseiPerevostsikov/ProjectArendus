using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaduDB
{
    public class SisseTulebArv
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public long SisseTulebFK { get; set; }
        public DateTime Date { get; set; }
        public long PakkujaFK { get; set; }


        public virtual SisseTuleb SisseTuleb { get; set; }
        public virtual Pakkuja Pakkuja { get; set; }
    }
}
