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
    public partial class RegistrarCambios : Form
    {
        string Equipo1, Equipo2, idPartido;
        public RegistrarCambios(string E1, string E2, string idP)
        {
            InitializeComponent();
            this.Equipo1 = E1;
            this.Equipo2 = E2;
            this.idPartido = idP;
        }

        private void RegistrarCambios_Load(object sender, EventArgs e)
        {

        }
    }
}