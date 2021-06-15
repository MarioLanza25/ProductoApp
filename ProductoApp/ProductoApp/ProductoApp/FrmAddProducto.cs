using ProductoApp.Marca;
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
        private int id_editable = -1;
        public DataGridView dgv;
        public FrmAddProducto()
        {

            InitializeComponent();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (editar == true)
            {
                string nombre = txtNombre.Text;
                string modelo = txtModelo.Text;
                string descripcion = txtDescrip.Text;
                string imagen = txtImagen.Text;
                validarEmpleado(out int numeroExistencias, out decimal precio);
                Tipo_Marca tipo_Marca = (Tipo_Marca)Enum.GetValues(typeof(Tipo_Marca)).GetValue(cmbMarca.SelectedIndex);
                Producto p = new Producto()
                {
                    Id = id_editable,
                    Nombre = nombre,
                    NumeroExistencias = numeroExistencias,
                    Marca = tipo_Marca,
                    Modelo = modelo,
                    Precio = precio,
                    Descripcion = descripcion,
                    Imagen = imagen
                };
                dgv.DataSource = productoModel.GetAll();
                productoModel.Update(FilaEditableIndex, p);
                dgv.Refresh();
                end = true;
                this.Dispose(true);

                MessageBox.Show("Estas actualizando "+ FilaEditableIndex);
            }
            else
            {
                try
                {
                    string nombre = txtNombre.Text;
                    string modelo = txtModelo.Text;
                    string descripcion = txtDescrip.Text;
                    string imagen = txtImagen.Text;
                    validarEmpleado(out int numeroExistencias, out decimal precio);
                    Tipo_Marca tipo_Marca = (Tipo_Marca)Enum.GetValues(typeof(Tipo_Marca)).GetValue(cmbMarca.SelectedIndex);
                    Producto p = new Producto()
                    {
                        Nombre = nombre,
                        NumeroExistencias = numeroExistencias,
                        Marca = tipo_Marca,
                        Modelo = modelo,
                        Precio = precio,
                        Descripcion = descripcion,
                        Imagen = imagen
                    };
                    productoModel.AddElemets(p);
                    MessageBox.Show("Producto agregado correctamente!!");
                    dgv.DataSource = productoModel.GetAll();
                    dgv.Refresh();
                    end = true;
                    this.Dispose(true);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Mensaje de Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void CargarCamposProducto(int id)
        {
            Producto producto = productoModel.GetProducto(id);

            txtNombre.Text = producto.Nombre;
            cmbMarca.SelectedItem = producto.Marca;
            txtModelo.Text = producto.Modelo;
            txtDescrip.Text = producto.Descripcion;
            txtImagen.Text = producto.Imagen;
            txtExistencias.Text = producto.NumeroExistencias + "";
            txtPrecio.Text = producto.Precio + "";
            FilaEditableIndex = id;
        }

        private void validarEmpleado(out int numeroExistencias, out decimal precio )
        {
            if(!int.TryParse(txtExistencias.Text, out int existencias))
            {
                throw new ArgumentException($"El valor {txtExistencias.Text} no es correcto!");
            }
            numeroExistencias = existencias;
            if (!decimal.TryParse(txtPrecio.Text, out decimal p))
            {
                throw new ArgumentException($"El valor {txtPrecio.Text} no es correcto!");
            }
            precio = p;
        }

        public void LoadDataProducto(int index)
        {
            Producto producto = productoModel.GetProducto(index);

            txtNombre.Text = producto.Nombre;
            cmbMarca.SelectedItem = producto.Marca;
            txtModelo.Text = producto.Modelo;
            txtDescrip.Text = producto.Descripcion;
            txtExistencias.Text = producto.NumeroExistencias + "";
            txtPrecio.Text = producto.Precio + "";
            FilaEditableIndex = index;
            id_editable = producto.Id;
        }

        private void FrmAddProducto_Load(object sender, EventArgs e)
        {
            cmbMarca.Items.AddRange(Enum.GetValues(typeof(Tipo_Marca)).Cast<object>().ToArray());
            cmbMarca.SelectedIndex = 0;
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            string rutaImagen = string.Empty;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Elige la ruta de la imagen";
            ofd.Filter = "Archivos de Imagen (*.jpg)(*.jpeg)|*.jpg;*.jpeg|PNG(*.png)|*.png|GIF(*.gif)|*.gif";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                rutaImagen = ofd.FileName;
            }

            txtImagen.Text = rutaImagen;
        }
    }
}
