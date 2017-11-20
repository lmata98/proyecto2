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
    public partial class registroTarjetas : Form
    {
        string Equipo1, Equipo2, idPartido;


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

        public void registrarTarjeta(string Instruccion)
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

        private int cantidadTarjetas(string equipo)
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

            cmd.CommandText = "select idjugador from tarjetas where IDPARTIDO = " + idPartido;

            cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();

            string valores = "";
            int cont = 0;
            while (dr.Read())
            {
                valor += dr.GetString(0);
                Console.WriteLine(dr.GetString(0));
                MessageBox.Show(valor);
                cont += 1;
                MessageBox.Show(cont.ToString());
            }
            conn.Dispose();
            return cont;



        }



        private void registrar_Click(object sender, EventArgs e)
        {
            string Anotador = saliente.Text;

            string minutoA = Minutostext.Text;
            string segundoA = SegundosText.Text;
            int cont = 0;
            string equipo, tipo;
            Boolean ExJ1;
            if (comboBox1.Text == "ROJA")
            {
                tipo = "ROJA";

            }
            else
            {
               tipo ="AMARILLA";
            }
            bool Exj2;
            ExJ1 = existenciaJugador(Equipo1, Anotador);
            Exj2 = existenciaJugador(Equipo2, Anotador);
            int auxC = cantidadTarjetas(idPartido);
            MessageBox.Show("cantidad         " + auxC.ToString());
            if (ExJ1 )
            {
                cont++;
                string instruccion = "insert into tarjetas values( " + auxC + ", '" + Anotador + "',"+ idPartido+",'" +tipo+ "','" + minutoA + "', '" + segundoA + "' ) ";
                registrarTarjeta(instruccion);
                // MessageBox.Show("Exito!!");

            }

            if (Exj2)
            {
                string instruccion = "insert into tarjetas values( " + auxC + ", '" + Anotador + "'," + idPartido + ",'" + tipo + "','" + minutoA + "', '" + segundoA + "' ) ";
                registrarTarjeta(instruccion);
            }
            

            if ((ExJ1 == false) && (Exj2 == false))
            {
                MessageBox.Show("Error el dato ingresado del jugador anotador es incorrecto");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public registroTarjetas(string E1, string E2, string idP)
        {
            InitializeComponent();
            this.Equipo1 = E1;
            this.Equipo2 = E2;
            this.idPartido = idP;
        }

        private void registroTarjetas_Load(object sender, EventArgs e)
        {

        }
    }
}
