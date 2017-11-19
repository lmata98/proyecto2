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
    public partial class EquipoTecnico : Form
    {
        string equipo1, equipo2, idPartido;
        int contAux=0;
        public EquipoTecnico(string E1, string E2, string IdP)
        {
            InitializeComponent();
            this.equipo1 = E1;
            this.equipo2 = E2;
            this.idPartido = IdP;
        }

        private List<string> listar(string tipo)
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

            cmd.CommandText = "select * from "+tipo;

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


        private bool ValidarEntrenadorEquipo(string equipo)
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

            cmd.CommandText = "select idequipo from entrenador where entrenador.idequipo = '"+ equipo+"'";

            cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();

            string valores = "";
            int cont = 0;
            while (dr.Read())
            {
                valor +=dr.GetString(0);
                Console.WriteLine(dr.GetString(0));
                MessageBox.Show(valor);
                
            }
            conn.Dispose();
            if (valor != "")
            {
                return true; 
            }else
            {
                return false;
            }


        }



        private bool ValidarFedeativoEquipo(string equipo, string idFedera)
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

            cmd.CommandText = "select * from cuerpofederativos where idequipo = '" + equipo + "' and idfederativos = '"+ idFedera +"'";

            cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();

            string valores = "";
            int cont = 0;
            while (dr.Read())
            {
                valor += dr.GetString(0);
                Console.WriteLine(dr.GetString(0));
                MessageBox.Show(valor);

            }
            conn.Dispose();
            if (valor != "")
            {
                return true;
            }
            else
            {
                return false;
            }


        }






        private bool consultarExistencia(List<string> lista, string arbitro)
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





        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        public void registroEquipoTecnico(string Instruccion)
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
            string Entre, doctor, asiste1, asiste2, delegado;
            Entre = Entrenador.Text;
            doctor = Medico.Text;
            asiste1 = AsisTecnico1.Text;
            asiste2 = AsisTecnico2.Text;
            delegado = Delegado.Text;
            List<string> asistentes =listar("asistente");
            List<string> federativos = listar("federativo");
            List<string> entrenadores = listar("entrenador");
            bool ExisteEntrenador = consultarExistencia(entrenadores,Entre);
            bool existeMedico = consultarExistencia(asistentes, doctor);
            bool existeAsiste1 = consultarExistencia(asistentes, asiste1);
            bool existeAsiste2 = consultarExistencia(asistentes, asiste2);
            bool existeDelegado = consultarExistencia(asistentes, delegado);
            string equipo;
            if(comboBox1.Text == "Equipo 1")
            {
                equipo = equipo1;
            }
            else
            {
                equipo = equipo2;
            }
            MessageBox.Show(equipo);
            MessageBox.Show(ExisteEntrenador.ToString() +existeMedico.ToString() +existeAsiste1+ existeAsiste2  );
            if (ExisteEntrenador && existeMedico && existeAsiste1 && existeAsiste2 && existeDelegado ) {
                bool validarFederativo = ValidarFedeativoEquipo(equipo, delegado);
                bool ValidacionEntrenadorEquipo = ValidarEntrenadorEquipo(equipo);
                MessageBox.Show( ValidacionEntrenadorEquipo.ToString()  );
                if (ValidacionEntrenadorEquipo)
                {

                    string instruccion; /*= "insert into cuerpoasistentes values ('" + doctor+"','"+equipo +"','03/02/08' ,"+idPartido+")";
                    registroEquipoTecnico(instruccion);
                    instruccion = "insert into cuerpoasistentes values ('" + asiste1 + "','" + equipo + "','03/02/08' ," + idPartido +")";
                    registroEquipoTecnico(instruccion);
                    instruccion = "insert into cuerpoasistentes values ('" + asiste2 + "','" + equipo + "','03/02/08' ," + idPartido+")";
                    registroEquipoTecnico(instruccion);
                    instruccion = "insert into cuerpoasistentes values ('" + delegado + "','" + equipo +  "','03/02/08' ,"+idPartido +" )";
                    registroEquipoTecnico(instruccion);*/
                    instruccion = "insert into asistenciapartidos values ( '"+equipo+ "','"+ asiste1+ "',"+idPartido +",'"+asiste2+"', '" +doctor+ "', '"+delegado+ "')";
                    registroEquipoTecnico(instruccion);
                    MessageBox.Show("Listo");
                    contAux++;
                    if (contAux!=2)
                    {
                        MessageBox.Show("Debe de ingresar los valores para el otro equipo");
                    }
                    else
                    {
                        registrarPartidoAux aux = new registrarPartidoAux(equipo1, equipo2, idPartido);
                        aux.Show();
                        contAux = 0;
                    }
                    
                }
                else
                {
                  
                    if (ValidacionEntrenadorEquipo)
                    {
                        MessageBox.Show("El id del entrenador ingresado no es correcto");
                    }
                }

              }
            else
            {
                if(ExisteEntrenador == false)
                {
                    MessageBox.Show("El id del entrenador ingresado no es correcto");
                }

                if (existeMedico == false)
                {
                    MessageBox.Show("El id del medico ingresado no es correcto");
                }
                if (existeAsiste1== false)
                {
                    MessageBox.Show("El id del Asistente 1 ingresado no es correcto");
                }

                if (existeAsiste2 == false)
                {
                    MessageBox.Show("El id del Asistente 2 ingresado no es correcto");
                }

                if (existeDelegado == false)
                {
                    MessageBox.Show("El id del delegado ingresado no es correcto");
                }
            }
        }
    }
}
