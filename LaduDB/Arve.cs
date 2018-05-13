using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaduDB
{
    public class Arve
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public long OstukorviFK { get; set; }
        public DateTime Date { get; set; }
        

        public virtual Ostukorvi Ostukorvi { get; set; }
    }
}
