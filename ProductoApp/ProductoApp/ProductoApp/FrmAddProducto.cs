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
    public partial class FrmAddProducto : Form
    {
        public ProductoModel productoModel { get; set; }
        public Boolean end = false;
        public Boolean editar = false;
        private int FilaEditableIndex = -1;
        public DataGridView dgv;
        public FrmAddProducto()
        {

            InitializeComponent();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text;
                string marca = txtMarca.Text;
                string modelo = txtModelo.Text;
                string descripcion = txtDescrip.Text;
                validarEmpleado(out int numeroExistencias, out decimal precio);
                Producto p = new Producto()
                {
                    Nombre = nombre,
                    NumeroExistencias = numeroExistencias,
                    Marca = marca,
                    Modelo = modelo,
                    Precio = precio,
                    Descripcion = descripcion
                };
                productoModel.AddElemets(p);
                MessageBox.Show("Producto agregado correctamente!!");
                dgv.DataSource = productoModel.GetAll();
                dgv.Refresh();
                end = true;
                this.Dispose(true);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void validarEmpleado(out int numeroExistencias, out decimal precio )
        {
            if(!int.TryParse(txtExistencias.Text, out int existencias))
            {
                throw new ArgumentException($"El valor {txtExistencias.Text} no es correcto!");
            }
            numeroExistencias = existencias;
            if (!decimal.TryParse(txtExistencias.Text, out decimal p))
            {
                throw new ArgumentException($"El valor {txtExistencias.Text} no es correcto!");
            }
            precio = p;
        }

        public void LoadDataProducto(int index)
        {
            Producto producto = productoModel.GetProducto(index);

            txtNombre.Text = producto.Nombre;
            txtMarca.Text = producto.Marca;
            txtModelo.Text = producto.Modelo;
            txtDescrip.Text = producto.Descripcion;
            txtExistencias.Text = producto.NumeroExistencias + "";
            txtPrecio.Text = producto.Precio + "";
            FilaEditableIndex = index;
        }
    }
}
