namespace proyecto2
{
    partial class RegistrarCambios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrarCambios));
            this.registrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.saliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.entrante = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Minutostext = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SegundosText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // registrar
            // 
            this.registrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registrar.Location = new System.Drawing.Point(154, 259);
            this.registrar.Name = "registrar";
            this.registrar.Size = new System.Drawing.Size(125, 49);
            this.registrar.TabIndex = 0;
            this.registrar.Text = "registrar";
            this.registrar.UseVisualStyleBackColor = true;
            this.registrar.Click += new System.EventHandler(this.registrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(167, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione el Equipo ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Equipo 1",
            "Equipo 2"});
            this.comboBox1.Location = new System.Drawing.Point(181, 64);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 26);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // saliente
            // 
            this.saliente.Location = new System.Drawing.Point(36, 164);
            this.saliente.Name = "saliente";
            this.saliente.Size = new System.Drawing.Size(100, 20);
            this.saliente.TabIndex = 3;
            this.saliente.TextChanged += new System.EventHandler(this.saliente_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 36);
            this.label2.TabIndex = 4;
            this.label2.Text = "Indique el Id del\r\nJugador saliente";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(300, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 36);
            this.label3.TabIndex = 6;
            this.label3.Text = "Indique el Id del\r\nJugador entrante";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // entrante
            // 
            this.entrante.Location = new System.Drawing.Point(303, 164);
            this.entrante.Name = "entrante";
            this.entrante.Size = new System.Drawing.Size(100, 20);
            this.entrante.TabIndex = 5;
            this.entrante.TextChanged += new System.EventHandler(this.entrante_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(60, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Minutos";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Minutostext
            // 
            this.Minutostext.Location = new System.Drawing.Point(36, 239);
            this.Minutostext.Name = "Minutostext";
            this.Minutostext.Size = new System.Drawing.Size(100, 20);
            this.Minutostext.TabIndex = 7;
            this.Minutostext.TextChanged += new System.EventHandler(this.Minutostext_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(318, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Segundos";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // SegundosText
            // 
            this.SegundosText.Location = new System.Drawing.Point(303, 239);
            this.SegundosText.Name = "SegundosText";
            this.SegundosText.Size = new System.Drawing.Size(100, 20);
            this.SegundosText.TabIndex = 9;
            this.SegundosText.TextChanged += new System.EventHandler(this.SegundosText_TextChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(303, 319);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 32);
            this.button1.TabIndex = 11;
            this.button1.Text = "Continuar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RegistrarCambios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(462, 363);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SegundosText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Minutostext);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.entrante);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.saliente);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.registrar);
            this.Name = "RegistrarCambios";
            this.Text = "RegistrarCambios";
            this.Load += new System.EventHandler(this.RegistrarCambios_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button registrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox saliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox entrante;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Minutostext;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SegundosText;
        private System.Windows.Forms.Button button1;
    }
}