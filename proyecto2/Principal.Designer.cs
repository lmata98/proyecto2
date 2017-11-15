namespace proyecto2
{
    partial class Principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.Confe_Equipo = new System.Windows.Forms.Button();
            this.BtnRegPartido = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Confe_Equipo
            // 
            this.Confe_Equipo.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Confe_Equipo.Location = new System.Drawing.Point(23, 433);
            this.Confe_Equipo.Name = "Confe_Equipo";
            this.Confe_Equipo.Size = new System.Drawing.Size(110, 64);
            this.Confe_Equipo.TabIndex = 0;
            this.Confe_Equipo.Text = "Consultar Equipos por Confederaciones";
            this.Confe_Equipo.UseVisualStyleBackColor = true;
            this.Confe_Equipo.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnRegPartido
            // 
            this.BtnRegPartido.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegPartido.ImageKey = "(ninguno)";
            this.BtnRegPartido.Location = new System.Drawing.Point(23, 28);
            this.BtnRegPartido.Name = "BtnRegPartido";
            this.BtnRegPartido.Size = new System.Drawing.Size(75, 46);
            this.BtnRegPartido.TabIndex = 1;
            this.BtnRegPartido.Text = "Registrar partido";
            this.BtnRegPartido.UseVisualStyleBackColor = true;
            this.BtnRegPartido.Click += new System.EventHandler(this.BtnRegPartido_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(725, 509);
            this.Controls.Add(this.BtnRegPartido);
            this.Controls.Add(this.Confe_Equipo);
            this.Name = "Principal";
            this.Text = "Principal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Confe_Equipo;
        private System.Windows.Forms.Button BtnRegPartido;
    }
}