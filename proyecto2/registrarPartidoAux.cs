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

        public registrarPartidoAux(string e1, string e2, string idP)
        {
            InitializeComponent();
            this.equipo1 = e1;
            this.equipo2 = e2;
            this.idPartido = idP;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
