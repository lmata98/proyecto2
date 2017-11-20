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
    public partial class MinutosExtra : Form
    {
        string equipo1, equipo2, idPartido;
        public MinutosExtra(string e1, string E2, string id)
        {
            InitializeComponent();
            this.equipo1 = e1;
            this.equipo2 = E2;
            this.idPartido = id;
        }

        private void MinutosExtra_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void registrarExtras(string tiempo, string minuto)
        {
            string oradb = "DATA SOURCE=localhost:1521/XE;USER ID=SYSTEM; Password = toma;";
            OracleConnection conn = new OracleConnection(oradb); // C#
            conn.Open();

            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;

            MessageBox.Show("update partidos set " + tiempo + " = '" + minuto + "'  where numeropartido = " + idPartido);
            try
            {
                cmd.CommandText = "update partidos set " + tiempo + " = '" + minuto + "' "+"\n"+" where numeropartido = " + idPartido; 
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


        private void registrar_Click(object sender, EventArgs e)
        {


            string minutoA = Minutostext.Text;
           
            int cont = 0;
            string tiempo;
            Boolean ExJ1;
            if (comboBox1.Text == "primer tiempo")
            {
                tiempo = "MINREPOSICIONT1";

            }
            else
            {
                tiempo = "MINREPOSICIONT2";
            }
          
            MessageBox.Show("cantidad         " );

            //string instruccion ="update partidos set "+tiempo+" = '" +minutoA+"'  where numeropartido = " +idPartido;
                registrarExtras(tiempo, minutoA);
           
        }
    }
}
