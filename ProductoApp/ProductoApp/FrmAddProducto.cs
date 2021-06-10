using ProductoApp.Enums;
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
    public partial class FrmAddProducto : Form
    {
        public FrmAddProducto()
        {
            InitializeComponent();
        }

        internal ProductoModel ProductoModel { get; set; }

        private void FrmAddProducto_Load(object sender, EventArgs e)
        {
            cmbMarca.Items.AddRange(Enum.GetValues(typeof(Marca)).Cast<object>().ToArray());
            cmbMarca.SelectedIndex = 0;

            cmbModelo.Items.AddRange(Enum.GetValues(typeof(Modelo)).Cast<object>().ToArray());
            cmbModelo.SelectedIndex = 0;
        }
    }
}
