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
    public partial class AYUDA : Form
    {
        public AYUDA()
        {
            InitializeComponent();
            conectar();
        }


        private void conectar()
        {
            PDF.src = " C:\\Users\\Leonardo\\Desktop\\manual_de_usuario_campoenato_mundial.pdf";
        }
        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void AYUDA_Load(object sender, EventArgs e)
        {

        }
    }
}
