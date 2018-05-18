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
        public int ID { get; set; }
        public int SisseTulebId { get; set; }
        public DateTime Date { get; set; }
        public int PakkujaId { get; set; }


        public virtual SisseTuleb SisseTuleb { get; set; }
        public virtual Pakkuja Pakkuja { get; set; }
    }
}
