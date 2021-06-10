using ProductoApp.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoApp.ProductoModel
{
    class ProductoModel
    {
        private Producto[] productos;

        public ProductoModel() { }

        public void AddElements(Producto prod)
        {
            if (productos == null)
            {
                productos = new Producto[1];
                productos[0] = prod;
                return;
            }
            Producto[] temp = new Producto[productos.Length + 1];
            Array.Copy(productos, temp, productos.Length);
            temp[temp.Length - 1] = prod;
            productos = temp;
        }

        public Producto[] GetAll()
        {
            return productos;
        }
        public void Remove(int index)
        {
            if (productos == null)
            {
                return;
            }

            if (index < 0 || index >= productos.Length)
            {
                throw new IndexOutOfRangeException($"El index {index} esta fuera de rango !!");
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
    }
}
