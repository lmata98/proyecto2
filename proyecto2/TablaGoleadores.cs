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
    public partial class TablaGoleadores : Form
    {

        OleDbConnection con = new OleDbConnection("Provider =OraOLEDB.Oracle ;DATA SOURCE=localhost:1521/XE;USER ID=SYSTEM; Password = toma; unicode = true");
        public TablaGoleadores()
        {
            InitializeComponent();
            conectar();
        }
        public void conectar()
        {
            con.Open();
     
           
                try
                {
                    OleDbDataAdapter oda = new OleDbDataAdapter("  select * from     (select count(idjugador) as cantGol , idjugador as idJ ,idequipo,nombrep as nombre from goles, persona where idjugador = pasaporte group by(idjugador),idjugador, idequipo, nombreP)  order by(cantGol) desc  ", con);
                    DataTable dt = new DataTable();
                    oda.Fill(dt);
                    dataGridView1.DataSource = dt;

                }
                catch (Exception m)
                {
                    MessageBox.Show("Se presentó un error durante la consulta ");

                }

            
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
