using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio6
{
    internal class Infos
    {
        string nombre;
        string placa;
        string marca;
        string modelo;
        string color;
        int precio;
        string f_devolucion;
        int total;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Placa { get => placa; set => placa = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Color { get => color; set => color = value; }
        public int Precio { get => precio; set => precio = value; }
        public string F_devolucion { get => f_devolucion; set => f_devolucion = value; }
        public int Total { get => total; set => total = value; }
    }
}
