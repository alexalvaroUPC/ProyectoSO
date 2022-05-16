namespace WindowsFormsApplication1
{
    partial class Principal
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
            this.Conectados = new System.Windows.Forms.DataGridView();
            this.InvitarTodos = new System.Windows.Forms.Button();
            this.Invitar = new System.Windows.Forms.Button();
            this.JugadoresPartida = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.NumJugadores = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Conectados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JugadoresPartida)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(614, 288);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username";
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(760, 297);
            this.username.Margin = new System.Windows.Forms.Padding(4);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(217, 22);
            this.username.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(33, 49);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(199, 38);
            this.button1.TabIndex = 4;
            this.button1.Text = "conectar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(444, 190);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
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
            this.groupBox1.Location = new System.Drawing.Point(31, 128);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(562, 249);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Peticion";
            // 
            // DimeContraseña
            // 
            this.DimeContraseña.AutoSize = true;
            this.DimeContraseña.Location = new System.Drawing.Point(54, 112);
            this.DimeContraseña.Margin = new System.Windows.Forms.Padding(4);
            this.DimeContraseña.Name = "DimeContraseña";
            this.DimeContraseña.Size = new System.Drawing.Size(225, 21);
            this.DimeContraseña.TabIndex = 7;
            this.DimeContraseña.TabStop = true;
            this.DimeContraseña.Text = "Dime la contraseña del usuario";
            this.DimeContraseña.UseVisualStyleBackColor = true;
            // 
            // MasPartidasGanadas
            // 
            this.MasPartidasGanadas.AutoSize = true;
            this.MasPartidasGanadas.Location = new System.Drawing.Point(54, 139);
            this.MasPartidasGanadas.Margin = new System.Windows.Forms.Padding(4);
            this.MasPartidasGanadas.Name = "MasPartidasGanadas";
            this.MasPartidasGanadas.Size = new System.Drawing.Size(313, 21);
            this.MasPartidasGanadas.TabIndex = 7;
            this.MasPartidasGanadas.TabStop = true;
            this.MasPartidasGanadas.Text = "Dime el jugador que más partidas ha ganado";
            this.MasPartidasGanadas.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(351, 174);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Duracion";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // duracionBox
            // 
            this.duracionBox.Location = new System.Drawing.Point(346, 197);
            this.duracionBox.Margin = new System.Windows.Forms.Padding(4);
            this.duracionBox.Name = "duracionBox";
            this.duracionBox.Size = new System.Drawing.Size(81, 22);
            this.duracionBox.TabIndex = 9;
            this.duracionBox.TextChanged += new System.EventHandler(this.alturaBox_TextChanged);
            // 
            // JugadorDatos
            // 
            this.JugadorDatos.AutoSize = true;
            this.JugadorDatos.Location = new System.Drawing.Point(54, 85);
            this.JugadorDatos.Margin = new System.Windows.Forms.Padding(4);
            this.JugadorDatos.Name = "JugadorDatos";
            this.JugadorDatos.Size = new System.Drawing.Size(506, 21);
            this.JugadorDatos.TabIndex = 8;
            this.JugadorDatos.TabStop = true;
            this.JugadorDatos.Text = "Dime datos de la partida que ha ganado un jugador conociendo la duracion";
            this.JugadorDatos.UseVisualStyleBackColor = true;
            this.JugadorDatos.CheckedChanged += new System.EventHandler(this.JugadorDatos_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(36, 385);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(196, 65);
            this.button3.TabIndex = 10;
            this.button3.Text = "desconectar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // IniciarBtn
            // 
            this.IniciarBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IniciarBtn.Location = new System.Drawing.Point(719, 194);
            this.IniciarBtn.Margin = new System.Windows.Forms.Padding(4);
            this.IniciarBtn.Name = "IniciarBtn";
            this.IniciarBtn.Size = new System.Drawing.Size(199, 38);
            this.IniciarBtn.TabIndex = 11;
            this.IniciarBtn.Text = "Iniciar Sesión";
            this.IniciarBtn.UseVisualStyleBackColor = true;
            this.IniciarBtn.Click += new System.EventHandler(this.IniciarBtn_Click);
            // 
            // RegistrarseBtn
            // 
            this.RegistrarseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegistrarseBtn.Location = new System.Drawing.Point(316, 49);
            this.RegistrarseBtn.Margin = new System.Windows.Forms.Padding(4);
            this.RegistrarseBtn.Name = "RegistrarseBtn";
            this.RegistrarseBtn.Size = new System.Drawing.Size(199, 38);
            this.RegistrarseBtn.TabIndex = 12;
            this.RegistrarseBtn.Text = "Registrarse";
            this.RegistrarseBtn.UseVisualStyleBackColor = true;
            this.RegistrarseBtn.Click += new System.EventHandler(this.RegistrarseBtn_Click);
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(759, 258);
            this.passwordBox.Margin = new System.Windows.Forms.Padding(4);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(217, 22);
            this.passwordBox.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(614, 260);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Escribe tu contraseña";
            // 
            // usuario
            // 
            this.usuario.Location = new System.Drawing.Point(666, 78);
            this.usuario.Margin = new System.Windows.Forms.Padding(4);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(217, 22);
            this.usuario.TabIndex = 13;
            // 
            // contraBox
            // 
            this.contraBox.Location = new System.Drawing.Point(666, 49);
            this.contraBox.Margin = new System.Windows.Forms.Padding(4);
            this.contraBox.Name = "contraBox";
            this.contraBox.Size = new System.Drawing.Size(217, 22);
            this.contraBox.TabIndex = 14;
            // 
            // Conectados
            // 
            this.Conectados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Conectados.Location = new System.Drawing.Point(609, 469);
            this.Conectados.Name = "Conectados";
            this.Conectados.RowHeadersWidth = 51;
            this.Conectados.RowTemplate.Height = 24;
            this.Conectados.Size = new System.Drawing.Size(240, 150);
            this.Conectados.TabIndex = 18;
            this.Conectados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Conectados_CellClick);
            this.Conectados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Conectados_CellContentClick);
            // 
            // InvitarTodos
            // 
            this.InvitarTodos.Location = new System.Drawing.Point(681, 397);
            this.InvitarTodos.Name = "InvitarTodos";
            this.InvitarTodos.Size = new System.Drawing.Size(153, 66);
            this.InvitarTodos.TabIndex = 19;
            this.InvitarTodos.Text = "Invitar a todos";
            this.InvitarTodos.UseVisualStyleBackColor = true;
            this.InvitarTodos.Click += new System.EventHandler(this.InvitarTodos_Click);
            // 
            // Invitar
            // 
            this.Invitar.Location = new System.Drawing.Point(725, 636);
            this.Invitar.Name = "Invitar";
            this.Invitar.Size = new System.Drawing.Size(123, 40);
            this.Invitar.TabIndex = 20;
            this.Invitar.Text = "Invitar";
            this.Invitar.UseVisualStyleBackColor = true;
            this.Invitar.Click += new System.EventHandler(this.Invitar_Click);
            // 
            // JugadoresPartida
            // 
            this.JugadoresPartida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.JugadoresPartida.Location = new System.Drawing.Point(261, 478);
            this.JugadoresPartida.Name = "JugadoresPartida";
            this.JugadoresPartida.RowHeadersWidth = 51;
            this.JugadoresPartida.RowTemplate.Height = 24;
            this.JugadoresPartida.Size = new System.Drawing.Size(227, 175);
            this.JugadoresPartida.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(412, 446);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "Partida";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 21);
            this.label5.TabIndex = 23;
            // 
            // NumJugadores
            // 
            this.NumJugadores.AutoSize = true;
            this.NumJugadores.Location = new System.Drawing.Point(264, 446);
            this.NumJugadores.Name = "NumJugadores";
            this.NumJugadores.Size = new System.Drawing.Size(0, 17);
            this.NumJugadores.TabIndex = 24;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 692);
            this.Controls.Add(this.NumJugadores);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.JugadoresPartida);
            this.Controls.Add(this.Invitar);
            this.Controls.Add(this.InvitarTodos);
            this.Controls.Add(this.Conectados);
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Conectados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JugadoresPartida)).EndInit();
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
        private System.Windows.Forms.DataGridView Conectados;
        private System.Windows.Forms.Button InvitarTodos;
        private System.Windows.Forms.Button Invitar;
        private System.Windows.Forms.DataGridView JugadoresPartida;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label NumJugadores;
    }
}

