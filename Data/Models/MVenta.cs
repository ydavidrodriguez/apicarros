using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class MVenta
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int id_cliente { get; set; }

    }
}
