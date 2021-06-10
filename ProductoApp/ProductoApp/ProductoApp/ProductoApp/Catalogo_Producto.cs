using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductoApp
{
    public partial class Catalogo_Producto : Form
    {
        private ProductoModel.ProductoModel productoModel;
        
        public Catalogo_Producto()
        {
            InitializeComponent();
            ReadProducto();
        }

        private void ReadProducto()
        {
            productoModel = new ProductoModel.ProductoModel();
        }
    }
}
