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
    public partial class Form1 : Form
    {
        private ProductoModel productoModel;
        public Form1()
        {
            InitializeComponent();
            productoModel = new ProductoModel();
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddProducto frmProducto= new FrmAddProducto();
            frmProducto.ProductoModel = productoModel;
            frmProducto.MdiParent = this;
            frmProducto.Show();
        }

        private void productoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmCatalogoProducto frmCatalogo = new FrmCatalogoProducto();
            frmCatalogo.ProductoModel = productoModel;
            frmCatalogo.MdiParent = this;
            frmCatalogo.Show();
        }
    }
}
