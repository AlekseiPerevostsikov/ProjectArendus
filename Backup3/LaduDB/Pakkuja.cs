using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaduDB
{
    public class Pakkuja
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public String Nimi { get; set; }
        public String FN { get; set; }
        public String Aadress { get; set; }


       public virtual ICollection<SisseTulebArv> SisseTulebArvs { get; set; }

    }
}
