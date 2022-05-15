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
    public partial class Form1 : Form
    {
        Socket server;
        Thread atender;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            passwordBox.PasswordChar = '*';
            contraBox.PasswordChar = '*';
            RegistrarseBtn.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IniciarBtn.Visible = false;
            //RegistrarseBtn.Visible = false;
            groupBox1.Visible = false;

        }

        private void AtenderServidor()
        {
            while (true)
            {
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                string[] trozos = mensaje.Split('/');
                int codigo = Convert.ToInt32(trozos[0]);

                switch (codigo)
                {
                    case 1:
                        MessageBox.Show(trozos[1]);
                        break;

                    case 2:
                        MessageBox.Show(trozos[1]);
                        break;

                    case 3:
                        MessageBox.Show(trozos[1]);
                        break;

                    case 4:
                        if (trozos[1] == "Has iniciado sesion\n")
                            groupBox1.Visible = true;
                        else if (trozos[1] == "No existe ese usuario, registrate\n")
                            RegistrarseBtn.Visible = true;
                        break;

                    case 5:
                        MessageBox.Show(trozos[1]);
                        break;

                    case 6:
                        string[] partes = trozos[2].Split('-');

                        Conectados.RowCount = partes.Length;
                        Conectados.ColumnCount = 1;

                        for (int i = 0; i < partes.Length; i++)
                            Conectados.Rows[i].Cells[0].Value = partes[i];
                        break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 9300);
            

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
    }
}
