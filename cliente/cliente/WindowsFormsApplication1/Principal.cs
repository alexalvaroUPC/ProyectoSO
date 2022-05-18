using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Principal : Form
    {
        Socket server;
        Thread atender;

        List<string> invitados = new List<string>();

        public Principal()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            passwordBox.PasswordChar = '*';
            contraBox.PasswordChar = '*';
        }

        private void AtenderServidor()
        {
            while (true)
            {
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                string[] trozos =mensaje.Split('/');
                int codigo = Convert.ToInt32(trozos[0]);

                switch (codigo)
                {
                    case 1:
                            this.Invoke(new Action(() =>
                            {
                                MessageBox.Show(trozos[1]);                           
                            }));
                            break;

                    case 2:
                            this.Invoke(new Action(() =>
                            {
                                MessageBox.Show(trozos[1]);
                            }));
                            break;

                    case 3:
                            this.Invoke(new Action(() =>
                            {
                                MessageBox.Show(trozos[1]);
                            }));
                            break; 

                    case 4:
                            this.Invoke(new Action(() =>
                            {
                                if(trozos[1] == "Has iniciado sesion")
                                {
                                    groupBox1.Visible = true;
                                    Conectados.Visible = true;
                                }


                                else if (trozos[1] == "No existe ese usuario, registrate")
                                {
                                    MessageBox.Show(mensaje);
                                }
                            }));
                            break;
                    
                    case 5:
                            this.Invoke(new Action(() =>
                            {
                                MessageBox.Show(trozos[1]);
                            }));
                            break;

                    case 6:
                            this.Invoke(new Action(() =>
                            {
                                if (Convert.ToInt32(trozos[1]) != 1)
                                {
                                    string[] partes = trozos[2].Split('-');

                                    Conectados.RowCount = partes.Length;
                                    Conectados.ColumnCount = 1;

                                    for (int i = 0; i < partes.Length; i++)
                                        Conectados.Rows[i].Cells[0].Value = partes[i];
                                }
                            }));
                            break;

                    case 7:
                            this.Invoke(new Action(() =>
                            {
                                if (trozos[1] == "No")
                                    MessageBox.Show("eeeeeee");
                                else if (trozos[1] == "EstaYa")
                                {
                                    string invitado = trozos[2];
                                    MessageBox.Show("El jugador " + invitado + " ya está en la partida"); ;
                                }
                                else
                                {
                                    string nombre = Convert.ToString(trozos[1]);
                                    DialogResult dialogResult = MessageBox.Show(nombre + " has invited you. Do you accept?", "", MessageBoxButtons.YesNo);
                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        string m = "7/" + nombre + "/" + username.Text + "/Y";
                                        MessageBox.Show(m);
                                        // Enviamos al servidor el nombre tecleado
                                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(m);
                                        server.Send(msg);
                                    }

                                    else if (dialogResult == DialogResult.No)
                                    {
                                        string m = "7/" + nombre + "/" + username.Text + "/N";
                                        // Enviamos al servidor el nombre tecleado
                                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(m);
                                        server.Send(msg);
                                    }
                                }
                            }));
                            break;

                    case 8:
                            this.Invoke(new Action(() =>
                            {
                                NumJugadores.Text = trozos[1];
                                string[] partes2 = trozos[2].Split('-');

                                Partida Partida = new Partida();
                                Partida.SetJugadores(partes2);
                                Partida.ShowDialog();

                            }));
                            break;
                }
            }                      
        }     

        private void Form1_Load(object sender, EventArgs e)
        {

            IniciarBtn.Visible = false;
            //RegistrarseBtn.Visible = false;
            groupBox1.Visible = false;
            Conectados.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 9200);
            

            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Green;
                MessageBox.Show("Conectado");
                IniciarBtn.Visible = true;

            }
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }

            ThreadStart ts = delegate { AtenderServidor(); };
            atender = new Thread(ts);
            atender.Start();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DimeContraseña.Checked)
            {
                string mensaje = "2/" + username.Text + "/" + passwordBox.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else if (JugadorDatos.Checked)
            {
                string mensaje = "1/" + username.Text + "/" + passwordBox.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

            }
            else
            {
                // Enviamos nombre y altura
                string mensaje = "3/" + username.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
             
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Mensaje de desconexión
            string mensaje = "0/";
        
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Nos desconectamos
            atender.Abort();
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void alturaBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void JugadorDatos_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void IniciarBtn_Click(object sender, EventArgs e)
        {
            string mensaje = "4/" + username.Text + "/" + passwordBox.Text;
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void RegistrarseBtn_Click(object sender, EventArgs e)
        {
            string mensaje = "5/" + usuario.Text + "/" + contraBox.Text;
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void InvitarTodos_Click(object sender, EventArgs e)
        {
            string mensaje = "6/" + username.Text + "/Todos";
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void Conectados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Conectados.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.Green)
            {
                Conectados.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = DefaultBackColor;
                string nombre = Convert.ToString(Conectados.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                invitados.Remove(nombre);
            }

            else 
            {
                Conectados.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;
                string nombre = Convert.ToString(Conectados.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                invitados.Add(nombre);
            }

            Conectados.ClearSelection();
        }

        private void Conectados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Invitar_Click(object sender, EventArgs e)
        {
            string mensaje = "6/" + username.Text + "/";
            for (int i = 0; i < invitados.Count(); i++)
            {
                mensaje += invitados[i] + "-";
            }

            string mensaje2 = mensaje.Split('/')[2];
            string[] mensaje3 = mensaje2.Split('-');
            string m = "";
            for (int i = 0; i < mensaje3.Length; i++)
                m += mensaje3[i] + ",";
            m = m.TrimEnd(',');

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to invite " + m + " for a match?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show(mensaje);
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }

        }
    }
}
