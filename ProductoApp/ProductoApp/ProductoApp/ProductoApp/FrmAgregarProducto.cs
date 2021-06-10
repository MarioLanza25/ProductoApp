using ProductoApp.Enums;
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
    public partial class FrmAgregarProducto : Form
    {
        public ProductoModel.ProductoModel ProductoModel { get; set; }
        public FrmAgregarProducto()
        {
            InitializeComponent();
        }

        private void FrmAgregarProducto_Load(object sender, EventArgs e)
        {
            cmbMarca.Items.AddRange(Enum.GetValues(typeof(Marca)).Cast<object>().ToArray());
            cmbModelo.Items.AddRange(Enum.GetValues(typeof(Modelo)).Cast<object>().ToArray());

            cmbMarca.SelectedIndex = 0;
            cmbModelo.SelectedIndex = 0;
        }
    }
}
