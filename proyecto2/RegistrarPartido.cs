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


namespace proyecto2
{
    public partial class RegistrarPartido : Form
    {
        public RegistrarPartido()
        {
            InitializeComponent();
        }

        private void RegistrarPartido_Load(object sender, EventArgs e)
        {

        }


        private int coneccion ( string valor)
        {
            string oradb = "DATA SOURCE=localhost:1521/XE;USER ID=SYSTEM; Password = toma;";

            OracleConnection conn = new OracleConnection(oradb); // C#

            conn.Open();

            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;

            cmd.CommandText = valor;

            cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();

            dr.Read();

           Int32 cantidad = Convert.ToInt32(dr.GetString(0));
            MessageBox.Show(dr.GetString(0));
            conn.Dispose();
            return cantidad;
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string idPartido=  NumPartido.Text;
            string sede = sedeNom.Text;
            string etapa = etapaNom.Text;
            string horaI= HoraInicio.Text;
            string horaF = HoraFin.Text;
            int cantAficionados = Convert.ToInt32(CantAfi.Text);

            string ValidarPartido = "select  numeropartido  from partidos where numeropartido = '" + idPartido + "'";
            int ValidarExistenciaPartido = coneccion(ValidarPartido);
            string validarSede = "select  *  from sedes where nombresede = '" + sede + "'";
            int ValidarExistenciaSedes = coneccion(validarSede);
            string validarEquipo = "select * from " ;
            if (ValidarExistenciaPartido == 0  && ValidarExistenciaSedes == 0)
            {
               
                

            }else
            {
                MessageBox.Show(" Error el partido ya se encuentra registrado ");
            }
        }
    }
}
