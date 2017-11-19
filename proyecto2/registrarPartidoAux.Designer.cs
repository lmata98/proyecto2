namespace proyecto2
{
    partial class registrarPartidoAux
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(registrarPartidoAux));
            this.registroGoles = new System.Windows.Forms.Button();
            this.registroTarjeta = new System.Windows.Forms.Button();
            this.Cambios = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // registroGoles
            // 
            this.registroGoles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.registroGoles.Location = new System.Drawing.Point(270, 27);
            this.registroGoles.Name = "registroGoles";
            this.registroGoles.Size = new System.Drawing.Size(114, 55);
            this.registroGoles.TabIndex = 0;
            this.registroGoles.Text = "Registrar Goles";
            this.registroGoles.UseVisualStyleBackColor = false;
            // 
            // registroTarjeta
            // 
            this.registroTarjeta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.registroTarjeta.Location = new System.Drawing.Point(45, 137);
            this.registroTarjeta.Name = "registroTarjeta";
            this.registroTarjeta.Size = new System.Drawing.Size(114, 55);
            this.registroTarjeta.TabIndex = 1;
            this.registroTarjeta.Text = "Registrar Tarjetas";
            this.registroTarjeta.UseVisualStyleBackColor = false;
            this.registroTarjeta.Click += new System.EventHandler(this.button2_Click);
            // 
            // Cambios
            // 
            this.Cambios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Cambios.Location = new System.Drawing.Point(45, 27);
            this.Cambios.Name = "Cambios";
            this.Cambios.Size = new System.Drawing.Size(114, 55);
            this.Cambios.TabIndex = 2;
            this.Cambios.Text = "Registrar Cambios";
            this.Cambios.UseVisualStyleBackColor = false;
            this.Cambios.Click += new System.EventHandler(this.Cambios_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.Location = new System.Drawing.Point(270, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 55);
            this.button1.TabIndex = 3;
            this.button1.Text = "Registrar Penales";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button2.Location = new System.Drawing.Point(270, 220);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 55);
            this.button2.TabIndex = 4;
            this.button2.Text = "Agregar minutos de Repo T1";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button3.Location = new System.Drawing.Point(45, 220);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 55);
            this.button3.TabIndex = 5;
            this.button3.Text = "Agregar minutos de Repo T2";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // registrarPartidoAux
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(416, 336);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Cambios);
            this.Controls.Add(this.registroTarjeta);
            this.Controls.Add(this.registroGoles);
            this.Name = "registrarPartidoAux";
            this.Text = " ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button registroGoles;
        private System.Windows.Forms.Button registroTarjeta;
        private System.Windows.Forms.Button Cambios;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}