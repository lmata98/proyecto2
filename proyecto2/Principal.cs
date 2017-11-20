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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            confederaciones confe = new confederaciones();
            confe.Show();
        }



        private void BtnRegPartido_Click(object sender, EventArgs e)
        {
            RegistrarPartido NuevoPartido = new RegistrarPartido();
            NuevoPartido.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            InformePartido partido = new InformePartido();
            partido.Show();
        }
    }
}
