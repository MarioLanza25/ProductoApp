using ProductoApp.Marca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoApp.Poco
{
    public class Producto
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public int NumeroExistencias { get; set; }
        public Tipo_Marca Marca { get; set; }
        public String Modelo { get; set; }
        public decimal Precio { get; set; }
        public String Descripcion { get; set; }
        public String Imagen { get; set; }
    }
}
