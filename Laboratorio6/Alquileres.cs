using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio6
{
    internal class Alquileres
    {
        int nit;
        string placa;
        string f_alquiler;
        string f_devolucion;
        int kilometraje;

        public int Nit { get => nit; set => nit = value; }
        public string Placa { get => placa; set => placa = value; }
        public string F_alquiler { get => f_alquiler; set => f_alquiler = value; }
        public string F_devolucion { get => f_devolucion; set => f_devolucion = value; }
        public int Kilometraje { get => kilometraje; set => kilometraje = value; }
    }
}
