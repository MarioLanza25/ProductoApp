using ProductoApp.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoApp.Model
{ 
    class ProductoModel
    {
        private Producto[] productos;

        public ProductoModel() { }

        public void AddElemets(Producto p)
        {
            if(productos == null)
            {
                productos = new Producto[1];
                productos[0] = p;
                return;
            }
            Producto[] temp = new Producto[productos.Length + 1];
            Array.Copy(productos, temp, productos.Length);
            temp[temp.Length - 1] = p;

            productos = temp;
        }

        public void Remove(int index)
        {
            if(index < 0)
            {
                return;
            }
            if(productos == null)
            {
                return;
            }
            if(index == 0 && productos.Length == 1)
            {
                productos = null;
                return;
            }

            Producto[] temp = new Producto[productos.Length - 1];
            if(index == 0)
            {
                Array.Copy(productos,index + 1, temp, 0, temp.Length);
                productos = temp;
                return;
            }
            if(index == productos.Length -1 )
            {
                Array.Copy(productos, 0, temp, 0, temp.Length);
                productos = temp;
                return;
            }

            if(index == 0)
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
    }
}
