using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class MVentaDetalle
    {
        public int ID { get; set; } 
        public int idproducto { get; set; }
        public int cantidad { get; set; }
        public DateTime fecha { get; set; }
        public int id_venta { get; set; }


    }
}
