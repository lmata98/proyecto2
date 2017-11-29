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

    public partial class InformePartido : Form
    {
        string idPartido;
        public InformePartido()
        {
            InitializeComponent();
        }

        private void InformePartido_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private string consultas(string instruccion)
        {

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

            cmd.CommandText = instruccion;

            cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();

            string valores = "";
            int cont = 0;
            while (dr.Read())
            {
                valor += (dr.GetString(0)).ToString();
                                 //   MessageBox.Show(valor);
                cont += 1;
                //MessageBox.Show(cont.ToString());
            }
            conn.Dispose();
            return valor;



        }


        private string consultaslista(string instruccion)
        {

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

            cmd.CommandText = instruccion;

            cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();

            string valores = "";
            int cont = 0;
            while (dr.Read())
            {
                valor += (dr.GetString(0)).ToString();
                valor += "  " + (dr.GetString(1)).ToString();
                valor += "    ";


               // MessageBox.Show(valor);
                cont += 1;
               // MessageBox.Show(cont.ToString());
            }
            conn.Dispose();
            return valor;



        }



        private string consultaslistaGoles(string instruccion)
        {

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

            cmd.CommandText = instruccion;

            cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();

            string valores = "";
            int cont = 0;
            while (dr.Read())
            {
                valor += "ID del jugador que anotó el gol ";
                valor += (dr.GetString(1)).ToString() +"  Minuto: ";
                valor += (dr.GetString(4)).ToString()+ "  Segundo: ";
                valor += (dr.GetString(5)).ToString();
                valor += "    ////";


                // MessageBox.Show(valor);
                cont += 1;
                // MessageBox.Show(cont.ToString());
            }
            if (cont ==1)
            {
                valor += " No Hiceron goles ";
            }
            conn.Dispose();
            return valor;



        }

        private string consultaslistaArbitros(string instruccion)
        {

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

            cmd.CommandText = instruccion;

            cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();

            string valores = "";
            int cont = 0;
            while (dr.Read())
            {
                valor += "ID Arbitro ";
                valor += (dr.GetString(0)).ToString() + "  Nombre: ";
                valor += (dr.GetString(1)).ToString() + "  Puesto: ";
                valor += (dr.GetString(2)).ToString();
                valor += "    ////";


                // MessageBox.Show(valor);
                cont += 1;
                // MessageBox.Show(cont.ToString());
            }
            if (cont == 1)
            {
                valor += " No Se registraron ";
            }
            conn.Dispose();
            return valor;



        }

        private string consultaslistaCambios(string instruccion)
        {

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

            cmd.CommandText = instruccion;

            cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();

            string valores = "";
            int cont = 0;
            while (dr.Read())
            {
                valor += "Se cambió el jugador ";
                valor += (dr.GetString(1)).ToString() + "  por el jugador ";
                valor += (dr.GetString(5)).ToString() + "  al minuto: ";
                valor += (dr.GetString(3)).ToString();
                valor += "    ////";


                // MessageBox.Show(valor);
                cont += 1;
                // MessageBox.Show(cont.ToString());
            }
            if (cont == 1)
            {
                valor += " No Se registraron ";
            }
            conn.Dispose();
            return valor;



        }




        private string consultaslistaTarjetas(string instruccion)
        {

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

            cmd.CommandText = instruccion;

            cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();

            string valores = "";
            int cont = 0;
            while (dr.Read())
            {
                valor += "   Tipo de tarjeta  ";
                valor += (dr.GetString(3)).ToString() + "  al jugador ";
                valor += (dr.GetString(1)).ToString() + "  al minuto: ";
                valor += (dr.GetString(5)).ToString();
                valor += "    ////";


                // MessageBox.Show(valor);
                cont += 1;
                // MessageBox.Show(cont.ToString());
            }
            if (cont == 0)
            {
                valor += " No Se registraron ";
            }
            conn.Dispose();
            return valor;



        }

        private string consultaslistaPenales(string instruccion)
        {

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

            cmd.CommandText = instruccion;

            cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();
            int numeroPenal = 0;
            string valores = "";
            int cont = 0;
            while (dr.Read())
            {
                valor += "   Numero de penal  ";
                numeroPenal += dr.GetInt32(0);
                valor += numeroPenal.ToString() + "   Lo hizo el jugador ";
                valor += (dr.GetString(1)).ToString() + " ¿Anotado? ";
                valor += (dr.GetString(4)).ToString();
                valor += "    ////";


                // MessageBox.Show(valor);
                cont += 1;
                // MessageBox.Show(cont.ToString());
            }
            if (cont == 0)
            {
                valor += " No Se registraron ";
            }
            conn.Dispose();
            return valor;

        }

        private string consultaslistaAsistentes(string instruccion)
        {

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

            cmd.CommandText = instruccion;

            cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();
            int numeroPenal = 0;
            string valores = "";
            int cont = 0;
            while (dr.Read())
            {
                valor += "   Asistente1:   ";
                valor += dr.GetString(1).ToString() + "   Asistente2 ";
                valor += (dr.GetString(3)).ToString() + " Medico ";
                valor += (dr.GetString(4)).ToString()+ "  Delegado";
                valor += (dr.GetString(5)).ToString();
                valor += "    ////";


                // MessageBox.Show(valor);
                cont += 1;
                // MessageBox.Show(cont.ToString());
            }
            if (cont == 0)
            {
                valor += " No Se registraron ";
            }
            conn.Dispose();
            return valor;

        }

        private string consultasNumerico(string instruccion)
        {

            List<string> lista = new List<string>();
            //string[] lista;
            //lista.Add("");
            //lista[0] = "d";
            //MessageBox.Show(lista[0]);
            string oradb = "DATA SOURCE=localhost:1521/XE;USER ID=SYSTEM; Password = toma;";
            int valor =0;
            OracleConnection conn = new OracleConnection(oradb); // C#

            conn.Open();

            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;

            cmd.CommandText = instruccion;

            cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();

            string valores = "";
            int cont = 0;
            while (dr.Read())
            {
               valor=  dr.GetInt32(0);
              
                Console.WriteLine(valor);
               // MessageBox.Show(valor.ToString());
                cont += 1;
               // MessageBox.Show(cont.ToString());
            }
            conn.Dispose();
            return valor.ToString();



        }

        private string coneccion(string valor)
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
                return "1";
            }
            else
            {
                return "0";
            }
            // label1.Text = dr.GetString(0);




        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.ClearSelected();
            listBox1.Items.Clear();
            idPartido = IDPartido.Text;
            string validarPartido = coneccion(idPartido);
            if (validarPartido != "0")
            {
                string instruccion;
                instruccion = "select etapa from partidos where numeropartido =" + idPartido;// , fecha,horainicio,  equipo1, equipo2";
                string valor = consultas(instruccion);

                listBox1.Items.Add("Numero Partido " + idPartido);
                listBox1.Items.Add("Etapa del partido: " + valor);

                instruccion = "select fecha from partidos where numeropartido =" + idPartido;
                valor = consultas(instruccion);
                listBox1.Items.Add("Fecha " + valor);

                instruccion = "select horainicio from partidos where numeropartido =" + idPartido;
                valor = consultas(instruccion);
                listBox1.Items.Add("Hora " + valor);

                instruccion = "select equipo1 from partidos where numeropartido =" + idPartido;
                valor = consultas(instruccion);
                listBox1.Items.Add("Equipo1 " + valor);
                string equipo1 = valor;

                instruccion = "select equipo2 from partidos where numeropartido = " + idPartido;
                valor = consultas(instruccion);
                string equipo2 = valor;
                listBox1.Items.Add("Equipo 2 " + valor);

                instruccion = "select cantaficionado from partidos where numeropartido =" + idPartido;
                valor = consultasNumerico(instruccion);
                listBox1.Items.Add("Cantidad de aficionados " + valor);


                instruccion = "select NombreJugadoresTitulares.nombreP, jugador.pasaporte from NombreJugadoresTitulares,jugador where  NombreJugadoresTitulares.idjugador = JUGADOR.PASAPORTE and JUGADOR.IDEQUIPO= '" + equipo1 + "'";
                valor = consultaslista(instruccion);
                listBox1.Items.Add("Titulares EQUIPO1: " + valor);
                /* string[] substrings = valor.Split(',');
                 int cont = 0;
                 while (substrings.Length > cont)
                 {
                     listBox1.Items.Add(substrings[cont]);
                     cont++;
                 }*/

                instruccion = "select NombreJugadoresTitulares.nombreP, jugador.pasaporte from NombreJugadoresTitulares,jugador where  NombreJugadoresTitulares.idjugador = JUGADOR.PASAPORTE and JUGADOR.IDEQUIPO= '" + equipo2 + "'";
                valor = consultaslista(instruccion);
                listBox1.Items.Add("Titulares EQUIPO 2: " + valor);
                /* string[] substrings1 = valor.Split(',');
                 int cont1 = 0;
                 while (substrings1.Length > cont1)
                 {
                     listBox1.Items.Add(substrings1[cont1]);
                     cont++;
                 }*/

                instruccion = "select * from goles where idpartido = " + idPartido + " and IDEQUIPO= '" + equipo1 + "'";
                valor = consultaslistaGoles(instruccion);
                listBox1.Items.Add("GOLES EQUIPO 1: " + valor);

                instruccion = "select * from goles where idpartido = " + idPartido + " and IDEQUIPO= '" + equipo2 + "'";
                valor = consultaslistaGoles(instruccion);
                listBox1.Items.Add("GOLES EQUIPO 1: " + valor);

                instruccion = "select idarbitro, nombreP, puesto from cuerpoarbitral,persona  where idpartido = " + idPartido + " and idarbitro = pasaporte";
                valor = consultaslistaArbitros(instruccion);
                listBox1.Items.Add("Cuerpo Arbitral: " + valor);

                instruccion = "select * from cambios where idpartido = " + idPartido + "  and IDEQUIPO= '" + equipo1 + "'";
                valor = consultaslistaCambios(instruccion);
                listBox1.Items.Add("Cambios EQUIPO1: " + valor);

                instruccion = "select * from cambios where idpartido = " + idPartido + "  and IDEQUIPO= '" + equipo2 + "'";
                valor = consultaslistaCambios(instruccion);
                listBox1.Items.Add("Cambios EQUIPO2: " + valor);

                instruccion = "select * from tarjetas where idpartido = " + idPartido;
                valor = consultaslistaTarjetas(instruccion);
                listBox1.Items.Add("Tarjetas: " + valor);

                instruccion = "select * from penales where idpartido = " + idPartido;
                valor = consultaslistaPenales(instruccion);
                listBox1.Items.Add("Penales: " + valor);

                instruccion = "select * from asistenciapartidos where idpartido = " + idPartido + " and idequipo = '" + equipo1 + "'";
                valor = consultaslistaAsistentes(instruccion);
                listBox1.Items.Add("Asistentes: " + valor);

                instruccion = "select * from asistenciapartidos  where idpartido = " + idPartido + " and idequipo = '" + equipo2 + "'";
                valor = consultaslistaAsistentes(instruccion);
                listBox1.Items.Add("Asistentes: " + valor);
                listBox1.Items.Add("####################################################################################################################");
            }

            else
            {
                MessageBox.Show(" El numero partido ingresado no existe " );
            }
        }
        }
}
