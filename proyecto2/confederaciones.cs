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



namespace proyecto2
{
    public partial class confederaciones : Form
    {
        public confederaciones()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider =OraOLEDB.Oracle ;DATA SOURCE=localhost:1521/XE;USER ID=SYSTEM; Password = toma; unicode = true");

        private void button1_Click(object sender, EventArgs e)
        {

           /* string oradb = "DATA SOURCE=localhost:1521/XE;USER ID=SYSTEM; Password = toma;";

            OracleConnection conn = new OracleConnection(oradb); // C#

            conn.Open();

            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;

            cmd.CommandText = "select CONFEDERACIONES.NOMBRE as Confederación, CODIGO ,EQUIPOS.NOMBREPAIS as Países  from EQUIPOS,CONFEDERACIONES where  EQUIPOS.IDCONFEDERACIONES = CONFEDERACIONES.CODIGO order by (CONFEDERACIONES.NOMBRE )  "; cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();

            dr.Read();

           // label1.Text = dr.GetString(0);
            MessageBox.Show(dr.GetString(0));
            conn.Dispose();
        }*/
        
        
        con.Open();
            String valor = textBox1.Text;
            if (valor == "")
            {
                try
                {
                    OleDbDataAdapter oda = new OleDbDataAdapter("select CONFEDERACIONES.NOMBRE as Confederación, CODIGO ,EQUIPOS.NOMBREPAIS as Países  from EQUIPOS,CONFEDERACIONES where  EQUIPOS.IDCONFEDERACIONES = CONFEDERACIONES.CODIGO order by (CONFEDERACIONES.NOMBRE )  ", con);
                    DataTable dt = new DataTable();
                    oda.Fill(dt);
                    dataGridView1.DataSource = dt;
                   
                }
                catch ( Exception m)
                {
                    MessageBox.Show("Se presentó un error durante la consulta ");

                }
                
  

            }
            else
            {
                try
                {


                    OleDbDataAdapter oda = new OleDbDataAdapter("select EQUIPOS.NOMBREPAIS as Países from EQUIPOS,CONFEDERACIONES where '" + valor + "' = CONFEDERACIONES.CODIGO AND EQUIPOS.IDCONFEDERACIONES = CONFEDERACIONES.CODIGO  ", con);
                    DataTable dt = new DataTable();
                    oda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception m)
                {
                    MessageBox.Show("El dato ingresado no es correcto. ");
                }
            }

            con.Close();
        } 

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
