using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crearClases
{
    class LineaPedido
    {
        private Producto producto;
        private int cant;
        private int nPed;
        private int id;

        public int Cant { get { return cant; } }
        public int NPed { get { return nPed; } }
        public int Id { get { return id; } }
        public Producto Producto { get { return producto; } }

        public LineaPedido(int canti, int numPed, Producto prod)
        {
            cant = canti;
            nPed = numPed;
            producto = prod;
        }

        public LineaPedido(int canti, int numPed, int ident, Producto prod)
        {
            cant = canti;
            nPed = numPed;
            id = ident;
            producto = prod;
        }
    }
}
