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
    public partial class FrmCatalogoProducto : Form
    {
        public ProductoModel productoModel { get; set; }
        public FrmCatalogoProducto()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddProducto frmProducto = new FrmAddProducto();
            frmProducto.productoModel = productoModel;
            frmProducto.dgv = dgvDatosProducto;
            frmProducto.Show();
            productoModel = frmProducto.productoModel;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDatosProducto.Rows.Count == 0 || dgvDatosProducto.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("La tabla se encuentra vacia!!");
                return;
            }

            int index = dgvDatosProducto.CurrentCell.RowIndex;
            productoModel.Remove(index);
            dgvDatosProducto.DataSource = productoModel.GetAll();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvDatosProducto.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar productos a la tabla");
                return;
            }

            if (dgvDatosProducto.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una fila de la tabla");
                return;
            }

            int index = dgvDatosProducto.CurrentCell.RowIndex;
            FrmAddProducto frmProducto = new FrmAddProducto();
            frmProducto.productoModel = productoModel;
            frmProducto.dgv = dgvDatosProducto;
            frmProducto.LoadDataProducto(index);
            frmProducto.editar = true;
            frmProducto.Show();
        }
    }
}
