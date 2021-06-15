using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductoApp.Model;
using ProductoApp.Poco;

namespace ProductoApp
{
    public partial class UcProducto : UserControl
    {
        public ProductoModel productoModel { get; set; }
        public Producto producto { get; set; }
        public FrmAddProducto frmProducto;
        public DataGridView dgvProducto;
        public UcProducto()
        {
            InitializeComponent();
        }

        private void UcProducto_Load(object sender, EventArgs e)
        {
            pbImgaen.Image = Image.FromFile(producto.Imagen);
            lblId.Text += producto.Id;
            lblNombre.Text += producto.Nombre;
            lblNumeroExistencias.Text += producto.NumeroExistencias;
            lblMarca.Text += producto.Marca;
            lblModelo.Text += producto.Modelo;
            lblPrecio.Text += producto.Precio;
            lblDescripcion.Text += producto.Descripcion;
        }

        private void UcProducto_Click(object sender, EventArgs e)
        {
            frmProducto = new FrmAddProducto();
            frmProducto.productoModel = productoModel;
            frmProducto.dgv = dgvProducto;  // Y aqui la damos valor al frmProducto que se agrego  Al estar hecho asi actualiza en tiempo de ejecucion pero solo en la tabla
            frmProducto.editar = true;
            frmProducto.CargarCamposProducto(producto.Id);
            frmProducto.Show();
        }
    }
}
