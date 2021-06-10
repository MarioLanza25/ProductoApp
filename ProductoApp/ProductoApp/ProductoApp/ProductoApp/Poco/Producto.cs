using ProductoApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoApp.Poco
{
    public class Producto
    {
        public String Nombre { get; set; }
        public int NumeroExistencias { get; set; }
        public String Marca { get; set; }
        public Modelo Modelo { get; set; }
        public Marca Precio { get; set; }
        public String Descripcion { get; set; }
        public String Imagen { get; set; }
    }
}
