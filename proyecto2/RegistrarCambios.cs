using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Sql;
using Oracle.DataAccess.Client; // ODP.NET Oracle managed provider
using Oracle.DataAccess.Types;
using System.Text.RegularExpressions;

namespace proyecto2
{
    public partial class RegistrarCambios : Form
    {
        string Equipo1, Equipo2, idPartido;
        int cant1, cant2;
        private Boolean existenciaJugador(string equipo, string pasaporte)
        {
            string oradb = "DATA SOURCE=localhost:1521/XE;USER ID=SYSTEM; Password = toma;";

            OracleConnection conn = new OracleConnection(oradb); // C#

            conn.Open();

            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;

            cmd.CommandText = " select * from jugador where pasaporte = '" + pasaporte + "' and idequipo= '" + equipo + "' "; cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();

            string datos = "";
            //  dr.Read();
            while (dr.Read())
            {
                datos += dr.GetString(0);
            }
            conn.Dispose();
            MessageBox.Show(datos);
            if (datos != "")
            {
                return true;
            }
            else
            {
                return false;
            }



        }

        public void registrarCambio(string Instruccion)
        {
            string oradb = "DATA SOURCE=localhost:1521/XE;USER ID=SYSTEM; Password = toma;";
            OracleConnection conn = new OracleConnection(oradb); // C#
            conn.Open();

            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;

            MessageBox.Show(Instruccion);
            try
            {
                cmd.CommandText = Instruccion;
                cmd.CommandType = CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();
                MessageBox.Show("Se registró");
                conn.Dispose();

            }

            catch (Exception m)
            {
                conn.Dispose();
                MessageBox.Show("Se presentó un error: " + "\n" + m.ToString());
            }

        }

        private int cantidadCambio(string equipo)
        {
            /*  string oradb = "DATA SOURCE=localhost:1521/XE;USER ID=SYSTEM; Password = toma;";
              int aux=0;
              OracleConnection conn = new OracleConnection(oradb); // C#

              conn.Open();

              try
              {
                  OracleCommand cmd = new OracleCommand();

                  cmd.Connection = conn;
                  cmd.CommandText = " select cambios.idequipo from cambios,jugador where cambios.idequipo = '" + equipo + "' and idpartido = " + idPartido +" and cambios.idjugador = jugador.pasaporte ";
                   string instruccion =  " select cambios.idequipo from cambios,jugador where cambios.idequipo = '" + equipo + "' and idpartido = " + idPartido +" and cambios.idjugador = jugador.pasaporte ";
                  cmd.CommandType = CommandType.Text;
                  MessageBox.Show(instruccion);
                  OracleDataReader dr = cmd.ExecuteReader();

                  string datos = "";
                  //  dr.Read();
                  while (dr.Read())
                  {
                      //datos += dr.GetString(0);
                      aux += 0;
                  }
                  conn.Dispose();
                  MessageBox.Show(aux.ToString());
              }
              catch (Exception m)
              {
                  MessageBox.Show("Error " + m);
              }
              return aux;*/

            List<string> lista = new List<string>();
            //string[] lista;
            //lista.Add("");
            //lista[0] = "d";
            //MessageBox.Show(lista[0]);
            string oradb = "DATA SOURCE=localhost:1521/XE;USER ID=SYSTEM; Password = toma;";
            string valor = "";
            OracleConnection conn = new OracleConnection(oradb); // C#

            conn.Open();

            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;

            cmd.CommandText = "select cambios.idequipo from cambios,jugador where cambios.idequipo = '" + equipo + "' and idpartido = " + idPartido +" and cambios.idjugador = jugador.pasaporte ";

            cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();

            string valores = "";
            int cont = 0;
            while (dr.Read())
            {
                valor += dr.GetString(0);
                Console.WriteLine(dr.GetString(0));
                MessageBox.Show(valor);
                cont +=1;
                MessageBox.Show(cont.ToString());
            }
            conn.Dispose();
            return cont;



        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void SegundosText_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Minutostext_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void entrante_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void saliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void registrar_Click(object sender, EventArgs e)
        {
            string Jsaliente = saliente.Text;
            string Jentrante = entrante.Text;
            string minutoA = Minutostext.Text;
            string segundoA = SegundosText.Text;
            int cont = 0;
            string equipo;
            Boolean ExJ1, ExJ2;
            if (comboBox1.Text == "Equipo 1")
            {
                equipo = Equipo1;
            
            }
            else
            {
                equipo = Equipo2;
            }

            ExJ1 = existenciaJugador(equipo,Jsaliente);
            ExJ2 = existenciaJugador(equipo, Jentrante);
            int auxC = cantidadCambio(equipo);
            MessageBox.Show("cantidad         "+auxC.ToString());
            if (ExJ1 && ExJ2 && (auxC< 3 ))
            {
                cont++;
                string instruccion = "insert into cambios values( "+auxC+", '"+ Jsaliente+"',"+idPartido+",'"+minutoA+"', '"+segundoA+"','"+Jentrante+"','"+equipo+"' )";
                registrarCambio(instruccion);
               // MessageBox.Show("Exito!!");

            }else
            {
                if (ExJ1 == false)
                {
                    MessageBox.Show("Error el dato ingresado del jugador saliente es incorrecto");
                }


                if (ExJ2 == false)
                {
                    MessageBox.Show("Error el dato ingresado del jugador entrante es incorrecto");
                }

                if(auxC >=  3)
                {
                    MessageBox.Show("Ya se realizaron todos los cambios disponibles para el partido "+ equipo);
                }

            }





        }

        public RegistrarCambios(string E1, string E2, string idP)
        {
            InitializeComponent();
            this.Equipo1 = E1;
            this.Equipo2 = E2;
            this.idPartido = idP;
        }

        private void RegistrarCambios_Load(object sender, EventArgs e)
        {

        }
    }
}
