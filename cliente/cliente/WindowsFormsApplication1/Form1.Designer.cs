namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DimeContraseña = new System.Windows.Forms.RadioButton();
            this.MasPartidasGanadas = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.duracionBox = new System.Windows.Forms.TextBox();
            this.JugadorDatos = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.IniciarBtn = new System.Windows.Forms.Button();
            this.RegistrarseBtn = new System.Windows.Forms.Button();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.usuario = new System.Windows.Forms.TextBox();
            this.contraBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(691, 360);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username";
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(855, 371);
            this.username.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(244, 26);
            this.username.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(37, 61);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(224, 48);
            this.button1.TabIndex = 4;
            this.button1.Text = "conectar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(500, 237);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 35);
            this.button2.TabIndex = 5;
            this.button2.Text = "Enviar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.DimeContraseña);
            this.groupBox1.Controls.Add(this.MasPartidasGanadas);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.duracionBox);
            this.groupBox1.Controls.Add(this.JugadorDatos);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(35, 160);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(632, 311);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Peticion";
            // 
            // DimeContraseña
            // 
            this.DimeContraseña.AutoSize = true;
            this.DimeContraseña.Location = new System.Drawing.Point(61, 140);
            this.DimeContraseña.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DimeContraseña.Name = "DimeContraseña";
            this.DimeContraseña.Size = new System.Drawing.Size(252, 24);
            this.DimeContraseña.TabIndex = 7;
            this.DimeContraseña.TabStop = true;
            this.DimeContraseña.Text = "Dime la contraseña del usuario";
            this.DimeContraseña.UseVisualStyleBackColor = true;
            // 
            // MasPartidasGanadas
            // 
            this.MasPartidasGanadas.AutoSize = true;
            this.MasPartidasGanadas.Location = new System.Drawing.Point(61, 174);
            this.MasPartidasGanadas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MasPartidasGanadas.Name = "MasPartidasGanadas";
            this.MasPartidasGanadas.Size = new System.Drawing.Size(350, 24);
            this.MasPartidasGanadas.TabIndex = 7;
            this.MasPartidasGanadas.TabStop = true;
            this.MasPartidasGanadas.Text = "Dime el jugador que más partidas ha ganado";
            this.MasPartidasGanadas.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(395, 217);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Duracion";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // duracionBox
            // 
            this.duracionBox.Location = new System.Drawing.Point(389, 246);
            this.duracionBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.duracionBox.Name = "duracionBox";
            this.duracionBox.Size = new System.Drawing.Size(91, 26);
            this.duracionBox.TabIndex = 9;
            this.duracionBox.TextChanged += new System.EventHandler(this.alturaBox_TextChanged);
            // 
            // JugadorDatos
            // 
            this.JugadorDatos.AutoSize = true;
            this.JugadorDatos.Location = new System.Drawing.Point(61, 106);
            this.JugadorDatos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.JugadorDatos.Name = "JugadorDatos";
            this.JugadorDatos.Size = new System.Drawing.Size(563, 24);
            this.JugadorDatos.TabIndex = 8;
            this.JugadorDatos.TabStop = true;
            this.JugadorDatos.Text = "Dime datos de la partida que ha ganado un jugador conociendo la duracion";
            this.JugadorDatos.UseVisualStyleBackColor = true;
            this.JugadorDatos.CheckedChanged += new System.EventHandler(this.JugadorDatos_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(37, 511);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(220, 81);
            this.button3.TabIndex = 10;
            this.button3.Text = "desconectar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // IniciarBtn
            // 
            this.IniciarBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IniciarBtn.Location = new System.Drawing.Point(809, 242);
            this.IniciarBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.IniciarBtn.Name = "IniciarBtn";
            this.IniciarBtn.Size = new System.Drawing.Size(224, 48);
            this.IniciarBtn.TabIndex = 11;
            this.IniciarBtn.Text = "Iniciar Sesión";
            this.IniciarBtn.UseVisualStyleBackColor = true;
            this.IniciarBtn.Click += new System.EventHandler(this.IniciarBtn_Click);
            // 
            // RegistrarseBtn
            // 
            this.RegistrarseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegistrarseBtn.Location = new System.Drawing.Point(356, 61);
            this.RegistrarseBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RegistrarseBtn.Name = "RegistrarseBtn";
            this.RegistrarseBtn.Size = new System.Drawing.Size(224, 48);
            this.RegistrarseBtn.TabIndex = 12;
            this.RegistrarseBtn.Text = "Registrarse";
            this.RegistrarseBtn.UseVisualStyleBackColor = true;
            this.RegistrarseBtn.Click += new System.EventHandler(this.RegistrarseBtn_Click);
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(854, 322);
            this.passwordBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(244, 26);
            this.passwordBox.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(691, 325);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Escribe tu contraseña";
            // 
            // usuario
            // 
            this.usuario.Location = new System.Drawing.Point(749, 97);
            this.usuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(244, 26);
            this.usuario.TabIndex = 13;
            // 
            // contraBox
            // 
            this.contraBox.Location = new System.Drawing.Point(749, 61);
            this.contraBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.contraBox.Name = "contraBox";
            this.contraBox.Size = new System.Drawing.Size(244, 26);
            this.contraBox.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 865);
            this.Controls.Add(this.contraBox);
            this.Controls.Add(this.usuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.RegistrarseBtn);
            this.Controls.Add(this.IniciarBtn);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.username);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton DimeContraseña;
        private System.Windows.Forms.RadioButton JugadorDatos;
        private System.Windows.Forms.RadioButton MasPartidasGanadas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox duracionBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button IniciarBtn;
        private System.Windows.Forms.Button RegistrarseBtn;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox usuario;
        private System.Windows.Forms.TextBox contraBox;
    }
}

