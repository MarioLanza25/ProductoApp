using ProductoApp.Model;
using ProductoApp.Poco;
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
        private ProductoApp.UcProducto ucProducto;
        public DataGridView dgvProducto;
        public FrmViewProducto()
        {
            InitializeComponent();
        }

        private void FrmViewProducto_Load(object sender, EventArgs e)
        {
            if (productoModel.GetAll() == null)
            {
                return;
            }
            Producto[] productos = productoModel.GetAll();

            for (int i = 0; i < productos.Length; i++)
            {
                ucProducto = new UcProducto();
                ucProducto.productoModel = productoModel;
                ucProducto.dgvProducto = dgvProducto; // Aqui la establecemos
                ucProducto.producto = productos[i];
                this.flowLayoutPanel1.Controls.Add(ucProducto);
            }
        }
    }
}
