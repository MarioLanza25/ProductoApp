using ProductoApp.Model;
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
    public partial class FrmViewProducto : Form
    {
        public ProductoModel productoModel { get; set; }
        public FrmViewProducto()
        {
            InitializeComponent();
        }
    }
}
