using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Partida : Form
    {
        string[] jugadores;

        public string[] GetJugadores()
        { return this.jugadores; }
        public void SetJugadores(string[] j)
        { this.jugadores = j; }
        
        
        public Partida()
        {
            InitializeComponent();
        }

        private void Partida_Load(object sender, EventArgs e)
        {
            JugadoresPartida.RowCount = jugadores.Length;
            JugadoresPartida.ColumnCount = 1;

            for (int i = 0; i < jugadores.Length; i++)
                JugadoresPartida.Rows[i].Cells[0].Value = jugadores[i];
        }
    }
}
