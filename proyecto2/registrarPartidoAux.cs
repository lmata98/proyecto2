using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto2
{
    public partial class registrarPartidoAux : Form
    {
        string equipo1, equipo2, idPartido;

        private void Cambios_Click(object sender, EventArgs e)
        {
            RegistrarCambios cambio = new RegistrarCambios(equipo1,equipo2,idPartido);
            cambio.Show();
        }

        private void registroGoles_Click(object sender, EventArgs e)
        {
            registroGoles goles = new registroGoles(equipo1, equipo2,idPartido);
            goles.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            registrarPenales penal = new registrarPenales(equipo1,equipo2, idPartido);
            penal.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MinutosExtra extra = new MinutosExtra(equipo1,equipo2,idPartido);
            extra.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Principal nP = new Principal();
            nP.Show();
           // this.Close();
        }

        public registrarPartidoAux(string e1, string e2, string idP)
        {
            InitializeComponent();
            this.equipo1 = e1;
            this.equipo2 = e2;
            this.idPartido = idP;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            registroTarjetas tarjeta = new registroTarjetas(equipo1,equipo2,idPartido);
            tarjeta.Show();
        }
    }
}
