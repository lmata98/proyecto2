﻿using System;
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
    public partial class registroTarjetas : Form
    {
        string Equipo1, Equipo2, idPartido;
        public registroTarjetas(string E1, string E2, string idP)
        {
            InitializeComponent();
            this.Equipo1 = E1;
            this.Equipo2 = E2;
            this.idPartido = idP;
        }

        private void registroTarjetas_Load(object sender, EventArgs e)
        {

        }
    }
}