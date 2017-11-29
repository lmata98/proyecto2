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
    public partial class DiccionarioDatos : Form
    {
        public DiccionarioDatos()
        {
            InitializeComponent();
        }


        private string coneccion(string valor)
        {
            string oradb = "DATA SOURCE=localhost:1521/XE;USER ID=SYSTEM; Password = toma;";


            OracleConnection conn = new OracleConnection(oradb); // C#
            conn.Open();

            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;

            cmd.CommandText = " SELECT * FROM DBA_TAB_COLUMNS where owner = 'SYSTEM' AND TABLE_NAME = '"+valor+"'"; cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();

            string datos = valor+":  ";
            //dr.Read();

            int aux=0;
            while (dr.Read())
            {
                datos +="Nombre atributo: ";
                datos += dr.GetString(2)+ "  Tipo:"  ;
                datos += " " + dr.GetString(3)+ "  Tamaño: ";
                aux += dr.GetInt32(6);
                datos += aux.ToString() + " ";
                if (dr.GetString(9) == "N" || dr.GetString(9) == "n" )
                {
                    datos += " Llave primaria " ;
                    MessageBox.Show("SI");
                }
                datos += "   /--------/  " ;
            }
            conn.Dispose();
            MessageBox.Show(datos);
            return datos;
       
        }

        private Boolean comprobarExistenciaLista(List<string> lista, string valor)
        {
            Boolean res;
            res = false;
            int cont = 0;
            while(cont < lista.Count())
            {
                if (lista[cont]== valor)
                {
                    cont = lista.Count()+1;
                    res = true;
                }
                else
                {
                    cont++;
                }
            }

            return res;
        }
    

        private void button1_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string datos="";
            List<string> lista = new List<string>();
          
            string ValorIngresado;
            ValorIngresado = NOMBRETABLA.Text.ToUpper();
            MessageBox.Show(ValorIngresado);
            lista.Add("ARBITRO");             lista.Add("ASISTENCIAPARTIDOS");            lista.Add("ASISTENTE");    lista.Add("CAMBIOS");
            lista.Add("CONFEDERACIONES");       lista.Add("CUERPOARBITRAL");      lista.Add("CUERPOASISTENTES");      lista.Add("CUERPOFEDERATIVOS");
            lista.Add("ENTRENADOR");         lista.Add("EQUIPOS");         lista.Add("FEDERATIVO");          lista.Add("GOLES");
            lista.Add("JUGADOR");        lista.Add("PARTIDOS");        lista.Add("PENALES");         lista.Add("PERSONA");
            lista.Add("PRUEBAFECHA");            lista.Add("SEDES");          lista.Add("SUPLENTES");           lista.Add("TARJETAS");    lista.Add("TITULARES");
            Boolean Validar = comprobarExistenciaLista(lista,ValorIngresado);
            if (ValorIngresado != "")
            {
                if (Validar)
                {
                    datos = coneccion(ValorIngresado);
                }
                else
                {
                    datos = "El nombre de la tabla ingresado no es valido";
                }

                listBox1.Items.Add(datos);
            }
            else
            {
                int cont = 0;
                while (cont< lista.Count())
                {
                    ValorIngresado = lista[cont];
                    datos =coneccion(ValorIngresado);
                    listBox1.Items.Add(datos);
                    cont++;
                }


            }
            


        }
    }
}
