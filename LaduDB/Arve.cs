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
        public int ID { get; set; }
        public int OstukorviId { get; set; }
        public DateTime Date { get; set; }
        

        public virtual Ostukorvi Ostukorvi { get; set; }
    }
}
