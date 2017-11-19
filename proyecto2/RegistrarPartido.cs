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
    public partial class RegistrarPartido : Form
    {
        public RegistrarPartido()
        {
            InitializeComponent();
        }

        private void RegistrarPartido_Load(object sender, EventArgs e)
        {

        }


        private string coneccion ( string valor)
        {
            string oradb = "DATA SOURCE=localhost:1521/XE;USER ID=SYSTEM; Password = toma;";


            OracleConnection conn = new OracleConnection(oradb); // C#
            conn.Open();

            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;

            cmd.CommandText = " select SEDES.NOMBRESEDE from partidos,sedes  where SEDES.NOMBRESEDE = PARTIDOS.NOMBRESEDE and PARTIDOS.NUMEROPARTIDO ="+valor+""; cmd.CommandType = CommandType.Text;

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
                return "1";
            }
            else
            {
                return "0";
            }
            // label1.Text = dr.GetString(0);
           
            
       

        }
        private string existenciaSede(string valor)
        {
            string oradb = "DATA SOURCE=localhost:1521/XE;USER ID=SYSTEM; Password = toma;";

            OracleConnection conn = new OracleConnection(oradb); // C#

            conn.Open();

            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;

            cmd.CommandText = "select  nombresede  from sedes where nombresede = '" + valor + "'"; cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();

            string datos = "";
          //  dr.Read();
            //datos += dr.GetString(0);
              while (dr.Read())
              {
                  datos += dr.GetString(0);
              }
            MessageBox.Show(datos);
            conn.Dispose();
            if (datos != "")
            {
                return "1";
            }
            else
            {
                return "0";
            }


        }

        private string existenciaEquipos(string valor)
        {
            string oradb = "DATA SOURCE=localhost:1521/XE;USER ID=SYSTEM; Password = toma;";

            OracleConnection conn = new OracleConnection(oradb); // C#

            conn.Open();

            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;

            cmd.CommandText = "select EQUIPOS.CODIGOPAIS from equipos where EQUIPOS.CODIGOPAIS = '" + valor + "'"; cmd.CommandType = CommandType.Text;

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
                return "1";
            }
            else
            {
                return "0";
            }
          
     

        }

        private string existenciaCapitan(string equipo, string pasaporte)
        {
            string oradb = "DATA SOURCE=localhost:1521/XE;USER ID=SYSTEM; Password = toma;";

            OracleConnection conn = new OracleConnection(oradb); // C#

            conn.Open();

            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;

            cmd.CommandText = " select * from jugador where pasaporte = '"+pasaporte+"' and idequipo= '"+equipo+"' "; cmd.CommandType = CommandType.Text;

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
                return "1";
            }
            else
            {
                return "0";
            }



        }


        private string MostrarSedes()
        {
            string oradb = "DATA SOURCE=localhost:1521/XE;USER ID=SYSTEM; Password = toma;";

            OracleConnection conn = new OracleConnection(oradb); // C#

            conn.Open();

            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;

            cmd.CommandText = "select * from sedes";
             
            cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();

            string valores="";
            while (dr.Read())
                {
                valores += dr.GetString(0)+ "\n";
                }
            
            MessageBox.Show(valores);
            conn.Dispose();
            return valores;

        }
        private string crearPartido(string valor)
        {
            
            string oradb = "DATA SOURCE=localhost:1521/XE;USER ID=SYSTEM; Password = toma;";

            OracleConnection conn = new OracleConnection(oradb); // C#

            conn.Open();

            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;

            string valores;

            try
            {
                cmd.CommandText = valor;

                cmd.CommandType = CommandType.Text;

                OracleDataReader dr = cmd.ExecuteReader();
               // dr.Read();
               // valores = dr.GetString(0);
                conn.Dispose();
                return "1";

            }
            catch (Exception e)
            {
                conn.Dispose();
                MessageBox.Show(e.ToString());
                return "0";
            }


        }
        private bool IsNumeric(string num)
        {
            try
            {
                double x = Convert.ToDouble(num);
                if ((x>25000) && (x<150000) )
                {
                    return true;
                }else
                {
                    return false;
                }
                
            }
            catch (Exception)
            {
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string idPartido = NumPartido.Text;
            bool EsNumero;
            string sede = sedeNom.Text; sede = sede.ToUpper();
            string etapa = etapaNom.Text;
            string horaI = HoraInicio.Text;
            string horaF = HoraFin.Text;
            string cantAficionados = CantAfi.Text;

            string equipo1 = Equipo1.Text; equipo1 = equipo1.ToUpper();
            string equipo2 = Equipo2.Text;equipo2 = equipo2.ToUpper();

            string fecha = date.Text;
            string capitanE1 = capitan1.Text;
            string capitanE2 = capitan2.Text;
            //string ValidarPartido = "select  count (sedes.nombresede )  from partidos,sedes where numeropartido = " + idPartido+" and partidos.nombresede = sedes.nombresede " ;
            // MessageBox.Show(ValidarPartido);
            string ValidarExistenciaPartido = coneccion(idPartido);
           // string validarSede = "select  count(nombresede)  from sedes where nombresede = '" + sede + "'";
            string ValidarExistenciaSedes = existenciaSede(sede);
         
            string ValidarExistenciaEquipo1 = existenciaEquipos(equipo1);
            string ValidarExistenciaEquipo2 = existenciaEquipos(equipo2);
            MessageBox.Show(" existe partido = "+ ValidarExistenciaPartido+ " sede "+ ValidarExistenciaSedes + "  equipo 1:  "+ ValidarExistenciaEquipo1+ " equipo 2: "+ ValidarExistenciaEquipo2);
            EsNumero = IsNumeric(cantAficionados);

            string ExisteCap1="";
            string ExisteCap2 = "";
            if ((ValidarExistenciaEquipo1 != "0")&& (ValidarExistenciaEquipo2 != "0"))
            {
                ExisteCap1 = existenciaCapitan(equipo1, capitanE1);
                ExisteCap2 = existenciaCapitan(equipo2, capitanE2);
            }

            if (ValidarExistenciaPartido != "1" && ValidarExistenciaSedes != "0" && ValidarExistenciaEquipo1 != "0" && ValidarExistenciaEquipo2 != "0" && EsNumero)
            {
                if ((ExisteCap1 != "0") && (ExisteCap2 != "0")) { 
                string instruccion = "insert into partidos values(" + idPartido + ",'" + sede + "','" + etapa + "','0','0'," + cantAficionados + ",'" + fecha + "','" + horaI + "','" + horaF + "','" + equipo1 + "','" + equipo2 + "','" + capitanE1 + "','" + capitanE2 + "')";
                    MessageBox.Show(instruccion);
                    string r = crearPartido(instruccion);

                    if (r=="1")
                    {
                        MessageBox.Show("El partido se registró");
                        JugadoresT ListaJugadoresT = new JugadoresT(equipo1,equipo2,idPartido);
                        ListaJugadoresT.Show();

                    }
                    else
                    {
                        MessageBox.Show("No se registró el partido ");
                    }
                }
            }
            else
            {
                if ((ValidarExistenciaPartido == "0") == false)
                {
                    MessageBox.Show(" Error el partido ya se encuentra registrado ");
                }
                if (ValidarExistenciaSedes == "0"  )
                {
                    MessageBox.Show(" Error no se encuentra registrada la sede  "+ "\n"+ "Las sedes disponibles son: "+ MostrarSedes());
                }
                if (ValidarExistenciaEquipo1 == "0")
                {
                    MessageBox.Show("Error el Equipo ingresado " + equipo1 + " no existe ");
                }
                if (ValidarExistenciaEquipo2 == "0")
                {
                    MessageBox.Show("Error el Equipo ingresado " + equipo2 + " no existe ");
                }
                if (EsNumero==false)
                {
                    MessageBox.Show("Error no esta ingresando un valor numerico en la cantidad de afficionados");
                }
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
