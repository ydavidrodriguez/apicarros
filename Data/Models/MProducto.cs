using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Data.Models
{
    public class MProducto
    {
        public int id { get; set; }    
        public string nombre { get; set; }    
        public string descripcion { get; set; }    
        public int valor { get; set; }    
        public int stock { get; set; }    

    }
}
