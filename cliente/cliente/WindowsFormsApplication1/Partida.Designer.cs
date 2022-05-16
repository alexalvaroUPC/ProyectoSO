
namespace WindowsFormsApplication1
{
    partial class Partida
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
            this.JugadoresPartida = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.JugadoresPartida)).BeginInit();
            this.SuspendLayout();
            // 
            // JugadoresPartida
            // 
            this.JugadoresPartida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.JugadoresPartida.Location = new System.Drawing.Point(209, 53);
            this.JugadoresPartida.Name = "JugadoresPartida";
            this.JugadoresPartida.RowHeadersWidth = 51;
            this.JugadoresPartida.RowTemplate.Height = 24;
            this.JugadoresPartida.Size = new System.Drawing.Size(374, 313);
            this.JugadoresPartida.TabIndex = 0;
            // 
            // Partida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.JugadoresPartida);
            this.Name = "Partida";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Partida_Load);
            ((System.ComponentModel.ISupportInitialize)(this.JugadoresPartida)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView JugadoresPartida;
    }
}