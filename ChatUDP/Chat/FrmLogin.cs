using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Chat
{
        /********************************
         *  Aplicaciones Distribuidas   *
         *  Francisco Gualli            *
         *  Gr1                         *
         *  Practica 02                 *
         *  Chat                        *
         /*******************************/


    //      Preguntas
    //Prueba la aplicación. Lanza el programa desde otro PC, puedes ver los mensajes en los dos PC?
    //          Si, es posible enviar mensajes entre ambos PCs.
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            txtNombreUsuario.Focus();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtNombreUsuario.Focus();            
        }

        private void txtNombreUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConectar_Click(sender,e);
            }
        }

        

        private void btnConectar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombreUsuario.Text))
            {
                UdpClient cliente = new UdpClient();
                Byte[] buferTx = Encoding.ASCII.GetBytes(txtNombreUsuario.Text + " ha entrado a la sala...");
                IPEndPoint sitioRemoto = new IPEndPoint(IPAddress.Broadcast, 1800);
                cliente.Send(buferTx, buferTx.Length, sitioRemoto);
                cliente.Close();
                this.Hide(); FrmMensaje formMensaje = new FrmMensaje();
                formMensaje.nombre = txtNombreUsuario.Text;
                formMensaje.Show();
            }
        }
    }
}
