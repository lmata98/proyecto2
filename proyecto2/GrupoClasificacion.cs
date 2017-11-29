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
    public partial class GrupoClasificacion : Form
    {
        public GrupoClasificacion()
        {
            InitializeComponent();
            procesar();
        }



        private List<string> listaEquipos(string valor)
        {
            string oradb = "DATA SOURCE=localhost:1521/XE;USER ID=SYSTEM; Password = toma;";

            List<string> lista = new List<string>();

            OracleConnection conn = new OracleConnection(oradb); // C#
            conn.Open();

            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;

            cmd.CommandText = " select codigopais, equipos.NOMBREPAIS, equipos.GRUPOINICIO  from equipos where grupoinicio = '" + valor + "'  "; cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();

            string datos = valor + ":  ";
            //dr.Read();

            int aux = 0;
            while (dr.Read())
            {
                datos = dr.GetString(1);
                lista.Add(datos);
                aux++; datos = "";
                datos = dr.GetString(0);
                lista.Add(datos); aux++;
            }
            conn.Dispose();
            // MessageBox.Show(datos);
            return lista;

        }


        private List<string> listaPartidos(string valor)
        {
            //  MessageBox.Show("Equipo " + valor);
            string oradb = "DATA SOURCE=localhost:1521/XE;USER ID=SYSTEM; Password = toma;";

            List<string> lista = new List<string>();

            OracleConnection conn = new OracleConnection(oradb); // C#
            conn.Open();

            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;

            cmd.CommandText = "  select numeropartido from partidos where equipo1 = '" + valor + "' OR EQUIPO2 = '" + valor + "' "; cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();

            string datos = valor + ":  ";
            //dr.Read();
            int numP = 0;
            int aux = 0;
            while (dr.Read())
            {
                numP = dr.GetInt32(0);
                datos = numP.ToString();
                lista.Add(datos);
                aux++;
            }
            conn.Dispose();
            //   MessageBox.Show(aux.ToString()+ "  cantidad partidos  ");
            return lista;
        }


        private List<string> equiposPartido(string valor)
        {
            string oradb = "DATA SOURCE=localhost:1521/XE;USER ID=SYSTEM; Password = toma;";

            List<string> lista = new List<string>();

            OracleConnection conn = new OracleConnection(oradb); // C#
            conn.Open();

            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;

            cmd.CommandText = "  select equipo1,equipo2 from partidos where numeropartido = '" + valor + "' "; cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();

            string datos = "";
            //dr.Read();

            int aux = 0;
            while (dr.Read())
            {
                datos = dr.GetString(0);
                lista.Add(datos);
                aux++;

                datos = dr.GetString(1);
                lista.Add(datos);
                aux++;

            }
            conn.Dispose();
            //  MessageBox.Show(datos);
            return lista;
        }

        private int cantidadGoles(string partido, string equipo)
        {

            string oradb = "DATA SOURCE=localhost:1521/XE;USER ID=SYSTEM; Password = toma;";

            List<string> lista = new List<string>();
            int cantidad = 0;
            OracleConnection conn = new OracleConnection(oradb); // C#
            conn.Open();

            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;

            cmd.CommandText = "  select idgol from goles where idpartido = '" + partido + "'  and idequipo = '" + equipo + "'"; cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();

            string datos = "";
            //dr.Read();

            int aux = 0;
            while (dr.Read())
            {
                aux++;


            }
            conn.Dispose();
            //   MessageBox.Show(datos);
            return aux;
        }


        private void procesar()

        {
            List<string> grupos = new List<string>();
            grupos.Add("A"); grupos.Add("B"); grupos.Add("C"); grupos.Add("D"); grupos.Add("E"); grupos.Add("F"); grupos.Add("G"); grupos.Add("H");
            int contAux = 0;
            while (grupos.Count() > contAux)
            {
                List<string> aux = new List<string>();
                string ep1, ep2;
                int cont1 = 0, g1, g2, pg1 = 0, pg2 = 0, pg3 = 0, pg4 = 0, cantg1 = 0, cantg2 = 0, cantg3 = 0, cantg4 = 0, pp1 = 0, pp2 = 0, pp3 = 0, pp4 = 0, pe1 = 0, pe2 = 0, pe3 = 0, pe4 = 0, punt1 = 0, punt2 = 0, punt3 = 0, punt4 = 0;
                string e1, e2, e3, e4, c1, c2, c3, c4, d1, d2, d3, d4;
                List<string> equipos = listaEquipos(grupos[contAux]);
                e1 = equipos[0];
                c1 = equipos[1];
                e2 = equipos[2]; c2 = equipos[3]; e3 = equipos[4]; c3 = equipos[5]; e4 = equipos[6]; c4 = equipos[7];
                // MessageBox.Show(c1);
                List<string> partidosJugados = listaPartidos(c1);
                // listBox1.Items.Add(e1 + e2 + e3 + e4 + c4);
                // MessageBox.Show(partidosJugados.Count().ToString());
                int pj1 = 0, pj2 = 0, pj3 = 0, pj4 = 0;
                pj1 = partidosJugados.Count();
                while (partidosJugados.Count() > cont1)
                {
                    //  MessageBox.Show(partidosJugados[cont1]);
                    aux = equiposPartido(partidosJugados[cont1]);
                    ep1 = aux[0];
                    ep2 = aux[1];
                    g1 = cantidadGoles(partidosJugados[cont1], ep1);
                    g2 = cantidadGoles(partidosJugados[cont1], ep2);
                    // MessageBox.Show(partidosJugados[cont1] + " goles 1 "+g1.ToString() + " goles 2 " + g2.ToString());
                    if (ep1 == c1)
                    {

                        // MessageBox.Show(partidosJugados[cont1] + " goles 1 " + g1.ToString() + " goles 2 " + g2.ToString() + "-----" + ep1);
                        if (g1 > g2)
                        {

                            pg1++;
                            cantg1 += g1;

                        }
                        if (g1 == g2)
                        {
                            pe1++;
                        }
                        if (g1 < g2)
                        {
                            pp1++;
                        }

                    }

                    if (ep2 == c1)
                    {
                        // MessageBox.Show(partidosJugados[cont1] + " goles 1 " + g1.ToString() + " goles 2 " + g2.ToString());
                        if (g2 > g1)
                        {

                            pg1++;
                            cantg1 += g2;
                        }
                        if (g1 == g2)
                        {
                            pe1++;
                        }
                        if (g2 < g1)
                        {
                            pp1++;
                        }
                    }
                    cont1++;
                }
                partidosJugados = listaPartidos(c3);
                cont1 = 0;
                pj3 = partidosJugados.Count();
                while (partidosJugados.Count() > cont1)
                {
                    //  MessageBox.Show(partidosJugados[cont1]);
                    aux = equiposPartido(partidosJugados[cont1]);
                    ep1 = aux[0];
                    ep2 = aux[1];
                    g1 = cantidadGoles(partidosJugados[cont1], ep1);
                    g2 = cantidadGoles(partidosJugados[cont1], ep2);
                    // MessageBox.Show(partidosJugados[cont1] + " goles 1 "+g1.ToString() + " goles 2 " + g2.ToString());
                    if (ep1 == c3)
                    {

                        // MessageBox.Show(partidosJugados[cont1] + " goles 1 " + g1.ToString() + " goles 2 " + g2.ToString() + "-----" + ep1);
                        if (g1 > g2)
                        {

                            pg3++;
                            cantg3 += g1;

                        }
                        if (g1 == g2)
                        {
                            pe3++;
                        }
                        if (g1 < g2)
                        {
                            pp3++;
                        }

                    }

                    if (ep2 == c3)
                    {
                        // MessageBox.Show(partidosJugados[cont1] + " goles 1 " + g1.ToString() + " goles 2 " + g2.ToString());
                        if (g2 > g1)
                        {

                            pg3++;
                            cantg3 += g2;
                        }
                        if (g1 == g2)
                        {
                            pe3++;
                        }
                        if (g2 < g1)
                        {
                            pp3++;
                        }
                    }
                    cont1++;
                }

                partidosJugados = listaPartidos(c2);
                cont1 = 0;
                pj2 = partidosJugados.Count();
                while (partidosJugados.Count() > cont1)
                {
                    //  MessageBox.Show(partidosJugados[cont1]);
                    aux = equiposPartido(partidosJugados[cont1]);
                    ep1 = aux[0];
                    ep2 = aux[1];
                    g1 = cantidadGoles(partidosJugados[cont1], ep1);
                    g2 = cantidadGoles(partidosJugados[cont1], ep2);
                    // MessageBox.Show(partidosJugados[cont1] + " goles 1 "+g1.ToString() + " goles 2 " + g2.ToString());
                    if (ep1 == c2)
                    {

                        // MessageBox.Show(partidosJugados[cont1] + " goles 1 " + g1.ToString() + " goles 2 " + g2.ToString() + "-----" + ep1);
                        if (g1 > g2)
                        {

                            pg2++;
                            cantg2 += g1;

                        }
                        if (g1 == g2)
                        {
                            pe2++;
                        }
                        if (g1 < g2)
                        {
                            pp2++;
                        }

                    }

                    if (ep2 == c2)
                    {
                        //  MessageBox.Show(partidosJugados[cont1] + " goles 1 " + g1.ToString() + " goles 2 " + g2.ToString());
                        if (g2 > g1)
                        {

                            pg2++;
                            cantg1 += g2;
                        }
                        if (g1 == g2)
                        {
                            pe2++;
                        }
                        if (g2 < g1)
                        {
                            pp2++;
                        }
                    }
                    cont1++;
                }


                partidosJugados = listaPartidos(c4);
                cont1 = 0;
                pj4 = partidosJugados.Count();
                while (partidosJugados.Count() > cont1)
                {
                    //  MessageBox.Show(partidosJugados[cont1]);
                    aux = equiposPartido(partidosJugados[cont1]);
                    ep1 = aux[0];
                    ep2 = aux[1];
                    g1 = cantidadGoles(partidosJugados[cont1], ep1);
                    g2 = cantidadGoles(partidosJugados[cont1], ep2);
                    // MessageBox.Show(partidosJugados[cont1] + " goles 1 "+g1.ToString() + " goles 2 " + g2.ToString());
                    if (ep1 == c4)
                    {

                        //MessageBox.Show(partidosJugados[cont1] + " goles 1 " + g1.ToString() + " goles 2 " + g2.ToString() + "-----" + ep1);
                        if (g1 > g2)
                        {

                            pg4++;
                            cantg4 += g1;

                        }
                        if (g1 == g2)
                        {
                            pe4++;
                        }
                        if (g1 < g2)
                        {
                            pp4++;
                        }

                    }

                    if (ep2 == c4)
                    {
                        // MessageBox.Show(partidosJugados[cont1] + " goles 1 " + g1.ToString() + " goles 2 " + g2.ToString());
                        if (g2 > g1)
                        {

                            pg4++;
                            cantg4 += g2;
                        }
                        if (g1 == g2)
                        {
                            pe4++;
                        }
                        if (g2 < g1)
                        {
                            pp4++;
                        }
                    }
                    cont1++;
                }


                punt1 += pg1 * 3 + pe1;
                punt2 += pg2 * 3 + pe2;
                punt3 += pg3 * 3 + pe3;
                punt4 += pg4 * 3 + pe4;
                int[] l = { punt1, punt2, punt3, punt4 };
                Array.Sort(l);
                listBox1.Items.Add("GRUPO:  "+ grupos[contAux]);
                listBox1.Items.Add("CODIGO" + "   |        "+ "NOMBRE" + "   |        "+ "PUNTOS"+ "   |        "+"PARTIDOS JUGADOS" + "   |        "+"PARTIDOS GANADOS"+ "   |        "+ "PARTIDOS EMPATADOS"+ "   |        "+ "PARTIDOS PERDIDOS"+ "   |        "+ "CANTIDAD GOLES");
                listBox1.Items.Add(  c1 + "   |        " + e1 + "   |        " +punt1+"   |        " + pj1.ToString() + "   |        " + pg1.ToString() + "   |        " + pe1.ToString() + "   |        " + pp1.ToString() + "   |        " + cantg1);
                listBox1.Items.Add(  c2 + "   |        " + e2 + "   |        " +punt2+"   |        " + pj2.ToString() + "   |        " + pg2.ToString() + "   |        " + pe2.ToString() + "   |        " + pp2.ToString() + "   |        " + cantg2);
                listBox1.Items.Add( c3 + "   |        " + e3 + "   |        " +punt3+"   |        " + pj3.ToString() + "   |        " + pg3.ToString() + "   |        " + pe3.ToString() + "   |        " + pp3.ToString() + "   |        " + cantg3);
                listBox1.Items.Add(  c4 + "   |        " + e4 + "   |        " +punt4+"   |        " + pj4.ToString() + "   |        " + pg4.ToString() + "   |        " + pe4.ToString() + "   |        " + pp4.ToString() + "   |        " + cantg4);

                listBox1.Items.Add("************************************************************************************************************************************************************************************************************************************************************************************************************************************");
                //   listBox1.Items.Add(e1+"codigo "+c1 + " perdidos" + pp1.ToString() + " ganados: " + pg1.ToString() + " goles:" + cantg1.ToString() + " empatados: " + pe1.ToString());
                contAux++;
            }


        }

        private void GrupoClasificacion_Load(object sender, EventArgs e)
        {

        }
    }
}
