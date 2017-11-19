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
    public partial class RegistroCuerpoArbitral : Form
    {
        string Equipo1;
        string Equipo2;
        string IdPartido;

        public RegistroCuerpoArbitral(string E1, string E2, string IdP)
        {
            InitializeComponent();
            this.Equipo1 = E1;
            this.Equipo2 = E2;
            this.IdPartido = IdP; 
        }


        private List<string> listaArbitros()
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

            cmd.CommandText = "select pasaporte from arbitro ";

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

        private bool consultarExistenciaArbitro(List<string> lista, string arbitro)
        {
            bool existe = false;
            int cont = 0;
            Console.WriteLine("-----------------------------------------------------------------------");
            while (lista.Count() > cont)
            {

                Console.WriteLine(lista[cont] + "\n");
                if (lista[cont] == arbitro)
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


        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public void registroArbitro (string Instruccion)
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

        private void button1_Click(object sender, EventArgs e)
        {
            string aPrincipal = Principal.Text;
            string aAsistente1 = AsisT1.Text;
            string aAsistente2 = AsisT2.Text;
            string A4 = Arbitro4.Text;
            string A5 = Arbitro5.Text;
            List<string> ArbitrosRegistrados = listaArbitros();
            bool aP = consultarExistenciaArbitro(ArbitrosRegistrados,aPrincipal);
            bool aS1 = consultarExistenciaArbitro(ArbitrosRegistrados, aAsistente1);
            bool aS2 = consultarExistenciaArbitro(ArbitrosRegistrados, aAsistente2);
            bool AR4 = consultarExistenciaArbitro(ArbitrosRegistrados, A4);
            bool AR5 = consultarExistenciaArbitro(ArbitrosRegistrados, A5);

            if ((aP == true)&& (aS1 == true)&& (aS2 == true)&& (AR4== true)&&(AR5 == true))
            {


                string Instruccion1 = "insert into cuerpoarbitral values ( '" + aPrincipal + "', " + IdPartido + " ," + "'arbitro Principal'" + ")"; 
                string Instruccion2 =    "insert into cuerpoarbitral values ('" + aAsistente1 + "', " + IdPartido + " ," + "'arbitro asistente 1'" + ")";
                string Instruccion3 = "  insert into cuerpoarbitral values ('" + aAsistente2 + "'," + IdPartido + "," + "'arbitro asistente 2'" + ")";
                string Instruccion4 = "  insert into cuerpoarbitral values ('" + A4 + "', " + IdPartido + " , " + "'arbitro 4'" + ")";
                string Instruccion5 = "  insert into cuerpoarbitral values ('" + A5 + "', " + IdPartido + " , " + "'arbitro 5'" + ")";

                registroArbitro(Instruccion1);
                 registroArbitro(Instruccion2);
                 registroArbitro(Instruccion3);
                 registroArbitro(Instruccion4);
                 registroArbitro(Instruccion5);
                EquipoTecnico tecnicos = new EquipoTecnico(Equipo1, Equipo2,IdPartido);
                tecnicos.Show();

            }
            else
            {
                if (aP== false)
                {
                    MessageBox.Show("No existe "+ aPrincipal);
                }
                if (aS1 == false)
                {
                    MessageBox.Show("No existe " + aAsistente1);
                }

                if (aS2 == false)
                {
                    MessageBox.Show("No existe " + aAsistente2);
                }

                if (AR4 == false)
                {
                    MessageBox.Show("No existe " + A4);
                }

                if (AR5 == false)
                {
                    MessageBox.Show("No existe " + A5);
                }
            }


        }

    }

}
