using ProductoApp.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoApp.Model
{
    public class ProductoModel
    {
        int Id = 1;
        private Producto[] productos;

        public ProductoModel() { }

        public void AddElemets(Producto p)
        {
            p.Id = Id;
            if (productos == null)
            {
                productos = new Producto[1];
                productos[0] = p;
                Id++;
                return;
            }
            Producto[] temp = new Producto[productos.Length + 1];
            Array.Copy(productos, temp, productos.Length);
            temp[temp.Length - 1] = p;

            productos = temp;
            Id++;
        }

        public void Remove(int index)
        {
            if (index < 0)
            {
                return;
            }
            if (productos == null)
            {
                return;
            }
            if (index == 0 && productos.Length == 1)
            {
                productos = null;
                return;
            }

            Producto[] temp = new Producto[productos.Length - 1];
            if (index == 0)
            {
                Array.Copy(productos, index + 1, temp, 0, temp.Length);
                productos = temp;
                return;
            }
            if (index == productos.Length - 1)
            {
                Array.Copy(productos, 0, temp, 0, temp.Length);
                productos = temp;
                return;
            }

            if (index == 0)
            {
                Array.Copy(productos, index + 1, temp, 0, temp.Length);
                productos = temp;
                return;
            }

            Array.Copy(productos, 0, temp, 0, index);
            Array.Copy(productos, index + 1, temp, index, (temp.Length - index));
            productos = temp;
        }

        public Producto[] GetAll()
        {
            return productos;
        }
        public Producto GetProducto(int id)
        {
            foreach (Producto p in productos)
                if (p.Id == id)
                    return p;
            return null;
        }
        public void Update(int index, Producto e)
        {
            productos[index].Id = e.Id;
            productos[index].Nombre = e.Nombre;
            productos[index].NumeroExistencias = e.NumeroExistencias;
            productos[index].Marca = e.Marca;
            productos[index].Modelo = e.Modelo;
            productos[index].Precio = e.Precio;
            productos[index].Descripcion = e.Descripcion;
            productos[index].Imagen = e.Imagen;
        }
    }
}
