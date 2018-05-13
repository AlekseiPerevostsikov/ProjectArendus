using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaduDB
{
    public class Alamkategooria
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public String Nimi { get; set; }
        public long KategooriaFK { get; set; }

        public virtual Kategooria Kategooria { get; set; }
        public virtual ICollection<Toode> Toodes { get; set; }
    }
}
