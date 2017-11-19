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
    public partial class JugadoresT : Form
    {
        string Equipo1;
        string Equipo2;
        string idPartido;
        public JugadoresT(string E1, string E2, string partido)
        {
            
            InitializeComponent();
            this.Equipo1 = E1;
            this.Equipo2 = E2;
            this.idPartido = partido;
        }
        OleDbConnection con = new OleDbConnection("Provider =OraOLEDB.Oracle ;DATA SOURCE=localhost:1521/XE;USER ID=SYSTEM; Password = toma; unicode = true");
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private List<string> listaJugadoresEquipos(string equipo)
        {
            List<string> lista = new List<string>();
            //string[] lista;
            //lista.Add("");
            //lista[0] = "d";
            //MessageBox.Show(lista[0]);
            string oradb = "DATA SOURCE=localhost:1521/XE;USER ID=SYSTEM; Password = toma;";

            OracleConnection conn = new OracleConnection(oradb); // C#

            conn.Open();

            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;

            cmd.CommandText = "select pasaporte from jugador where idEquipo = '"+equipo+"' ";

            cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();

            string valores = "";
            int cont = 0;
            while (dr.Read())
            {
               lista.Add(dr.GetString(0));
                Console.WriteLine(dr.GetString(0));
                cont++;
            }

            MessageBox.Show(valores);
            conn.Dispose();
            return lista;


           
        }

        private bool consultarExistenciaJugador(List<string> lista , string jugador)
        {
            bool existe = false;
            int cont = 0;
            Console.WriteLine("-----------------------------------------------------------------------");
            while (lista.Count()>cont)
            {

                Console.WriteLine(lista[cont]+"\n");
                if (lista[cont] == jugador)
                {
                    existe = true;
                    Console.WriteLine("TRUE /////////////" + "\n");
                    cont = lista.Count() + 1;
                }
                else
                {
                    existe = false;
                    Console.WriteLine("FALSE+++++++++++++++" + "\n");
                }

                cont++;
            }

            return existe;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cont = 0;
            string jugadores = textBox1.Text;
            jugadores = jugadores.ToUpper();
            string[] ListaJugadores;
            ListaJugadores = jugadores.Split(',');
            string EquipoSeleccionado = comboBox1.Text;
            string equipo = "";
            if (EquipoSeleccionado == "Equipo 1")
                equipo = Equipo1;
            else
            {
                equipo = Equipo2;
            }
            MessageBox.Show(ListaJugadores[0] + "  .... equipo" + equipo);


            List<string> listaJugadoresE = listaJugadoresEquipos(equipo);

            if (ListaJugadores.Length == 11)
            {
                while (ListaJugadores.Length > cont)
                {
                    bool existeJugador = consultarExistenciaJugador(listaJugadoresE, ListaJugadores[cont]);
                    if (existeJugador)
                    {

                        string valor;
                        valor = ListaJugadores[cont];
                        string Instruccion = " insert into titulares values ('" + valor + "'," + idPartido + ")";
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
                    else
                    {
                        MessageBox.Show("No existe el jugador " + ListaJugadores[cont] + " en el equipo " + equipo);
                    }
                    cont++;

                }



                RegistroCuerpoArbitral arbitros = new RegistroCuerpoArbitral(Equipo1,Equipo2,idPartido);
                arbitros.Show();
                
            }
        
        else
        {

                MessageBox.Show("Debe de ingresar los 11 jugadores titulares");
        }

        }
    }
}
