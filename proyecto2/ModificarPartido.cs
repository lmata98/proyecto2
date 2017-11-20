using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using Oracle.DataAccess.Client; // ODP.NET Oracle managed provider
using Oracle.DataAccess.Types;
using System.Text.RegularExpressions;


namespace proyecto2
{
    public partial class ModificarPartido : Form
    {
        public ModificarPartido()
        {
            InitializeComponent();
        }


        private bool coneccion(string valor)
        {
            string oradb = "DATA SOURCE=localhost:1521/XE;USER ID=SYSTEM; Password = toma;";


            OracleConnection conn = new OracleConnection(oradb); // C#
            conn.Open();

            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;

            cmd.CommandText = " select SEDES.NOMBRESEDE from partidos,sedes  where SEDES.NOMBRESEDE = PARTIDOS.NOMBRESEDE and PARTIDOS.NUMEROPARTIDO =" + valor + ""; cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();

            string datos = "";
            //dr.Read();
            //  datos += dr.GetString(0);
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
            // label1.Text = dr.GetString(0);




        }


        private string Equipos1(string valor)
        {
            string oradb = "DATA SOURCE=localhost:1521/XE;USER ID=SYSTEM; Password = toma;";


            OracleConnection conn = new OracleConnection(oradb); // C#
            conn.Open();

            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;

            cmd.CommandText = " select equipo1 from partidos where numeropartido = "+valor; cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();

            string datos = "";
            //dr.Read();
            //  datos += dr.GetString(0);
            while (dr.Read())
            {
                datos += dr.GetString(0);
            }
            conn.Dispose();
            MessageBox.Show(datos);
            return datos;
            // label1.Text = dr.GetString(0);




        }


        private string Equipos2(string valor)
        {
            string oradb = "DATA SOURCE=localhost:1521/XE;USER ID=SYSTEM; Password = toma;";


            OracleConnection conn = new OracleConnection(oradb); // C#
            conn.Open();

            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;

            cmd.CommandText = " select equipo2 from partidos where numeropartido = " + valor; cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();

            string datos = "";
            //dr.Read();
            //  datos += dr.GetString(0);
            while (dr.Read())
            {
                datos += dr.GetString(0);
            }
            conn.Dispose();
            MessageBox.Show(datos);
            return datos;
            // label1.Text = dr.GetString(0);




        }
        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            bool v = coneccion(id);
            string equipo1, equipo2;
            MessageBox.Show(v.ToString());
            if ( v )
            {
                equipo1 = Equipos1(id);
                equipo2 = Equipos2(id);
                registrarPartidoAux aux = new registrarPartidoAux(equipo1,equipo2,id);
                aux.Show();
            }else
            {
                MessageBox.Show("NO existe el partido " + id);
            }


        }
    }
}
