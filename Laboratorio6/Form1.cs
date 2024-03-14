using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio6
{
    public partial class Form1 : Form
    {

        List<Clientes> cli = new List<Clientes>();
        List<Vehiculos> veh = new List<Vehiculos>();
        List<Alquileres> alq = new List<Alquileres>();
        List<Infos> info = new List<Infos>();

        public Form1()
        {
            InitializeComponent();
        }

        private void carga_clientes() {
            string fileName = "Clientes.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Clientes cliente = new Clientes();
                cliente.Nit = Convert.ToInt16(reader.ReadLine());
                cliente.Nombre = reader.ReadLine();
                cliente.Direccion = reader.ReadLine();

                cli.Add(cliente);

            }
            reader.Close();
        }

        private void cargar_alquileres() {
            string fileName = "Alquileres.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Alquileres alquiler = new Alquileres();
                alquiler.Nit = Convert.ToInt16(reader.ReadLine());
                alquiler.Placa = reader.ReadLine();
                alquiler.F_alquiler = reader.ReadLine();
                alquiler.F_devolucion = reader.ReadLine();
                alquiler.Kilometraje = Convert.ToInt16(reader.ReadLine());

                alq.Add(alquiler);
            }
            reader.Close();
        }

        private void cargar_vehiculos() {
            string fileName = "Vehiculos.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Vehiculos vehiculo = new Vehiculos();
                vehiculo.Placa = reader.ReadLine();
                vehiculo.Marca = reader.ReadLine();
                vehiculo.Modelo = reader.ReadLine();
                vehiculo.Color = reader.ReadLine();
                vehiculo.Precio = Convert.ToInt32(reader.ReadLine());

                veh.Add(vehiculo);
            }
            reader.Close();
        }

        private void guardar(string fileName) {
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            foreach (var vehiculo in veh)
            {
                writer.WriteLine(vehiculo.Placa);
                writer.WriteLine(vehiculo.Marca);
                writer.WriteLine(vehiculo.Modelo);
                writer.WriteLine(vehiculo.Color);
                writer.WriteLine(vehiculo.Precio);
            }
            writer.Close();
        }

        private void mostrar_clientes() {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = cli;
            dataGridView1.Refresh();
        }

        private void mostrar_vehiculos() {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = veh;
            dataGridView2.Refresh();
        }

        private void mostrar_alquileres()
        {
            dataGridView4.DataSource = null;
            dataGridView4.DataSource = alq;
            dataGridView4.Refresh();
        }

        private void mostrar_info() { 
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = info;
            dataGridView3.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            carga_clientes();
            cargar_alquileres();
            mostrar_clientes();
            mostrar_alquileres();
            //mostrar_vehiculos();
        }

        private void eliminar() {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vehiculos agregarvehiculo = new Vehiculos();
            agregarvehiculo.Placa = textBox1.Text;
            agregarvehiculo.Marca = textBox2.Text;
            agregarvehiculo.Modelo = textBox3.Text;
            agregarvehiculo.Color = textBox4.Text;
            agregarvehiculo.Precio = Convert.ToInt16(textBox5.Text);
            veh.Add(agregarvehiculo);
            guardar("Vehiculos.txt");
            eliminar();
            mostrar_vehiculos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            veh.Clear();
            cargar_vehiculos();
            mostrar_vehiculos();
            //cargar_alquileres();
            if (info.Count == 0)
            {
                foreach (var alquiler in alq)
                {
                    Clientes cliente = cli.FirstOrDefault(c => c.Nit == alquiler.Nit);
                    if (cliente != null)
                    {
                        Vehiculos vehiculo = veh.FirstOrDefault(c => c.Placa == alquiler.Placa);
                        if (vehiculo != null)
                        {
                            Infos datos = new Infos();
                            datos.Nombre = cliente.Nombre;
                            datos.Placa = vehiculo.Placa;
                            datos.Marca = vehiculo.Marca;
                            datos.Modelo = vehiculo.Modelo;
                            datos.Color = vehiculo.Color;
                            datos.Precio = vehiculo.Precio;
                            datos.F_devolucion = alquiler.F_devolucion;
                            datos.Total = vehiculo.Precio * alquiler.Kilometraje;
                            info.Add(datos);

                        }
                    }
                }
            }
            int mayor = alq.Max(a => a.Kilometraje);
            Infos datosAlquiler1 = info.OrderByDescending(a => a.Total).First();
            label6.Text = mayor.ToString();
            mostrar_info();
        }
    }
}
