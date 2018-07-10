using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
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
    public partial class FrmMensaje : Form
    {
        public string nombre; 
        UdpClient cliente = new UdpClient(1800); 
        IPEndPoint sitioRemoto = new IPEndPoint(IPAddress.Any, 0);
        public FrmMensaje()
        {
            InitializeComponent();
            
        }

        private void FrmMensaje_Load(object sender, EventArgs e)
        {
            txtMensaje.Text = nombre + " se ha unido a la sala..."; 
            Thread hiloTrabajador = new Thread(RecepcionMensajes); 
            hiloTrabajador.Start(); 
            txtMensajeParaEnviar.Focus();
        }

        private void RecepcionMensajes()
        {
            try
            {
                while (true)
                {
                    Byte[] buferRx = cliente.Receive(ref sitioRemoto);
                    string mensaje = Encoding.ASCII.GetString(buferRx);
                    if (mensaje == nombre + " ha salido...")
                    {
                        break;
                    }
                    else
                    {
                        if (mensaje.Contains(nombre + " dice >> "))
                        {
                            mensaje = mensaje.Replace(nombre + " dice >> ", "Yo digo >> ");
                        } PresentarMensaje(mensaje);
                    }
                }
                Thread.CurrentThread.Abort();
                Application.Exit();
            }
            catch (ThreadAbortException ex) 
            { Application.Exit(); }
        }

        private void PresentarMensaje(string mensaje)
        {
            if (this.InvokeRequired) 
                this.Invoke(new MethodInvoker(delegate () { PresentarMensaje(mensaje); }));
            else 
            { 
                txtMensaje.Text = txtMensaje.Text + Environment.NewLine + mensaje;
                txtMensaje.SelectionStart = txtMensaje.TextLength; 
                txtMensaje.ScrollToCaret();
                txtMensaje.Refresh(); 
            }
        
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMensajeParaEnviar.Text))
            {
                string datos = nombre + " dice >> " + txtMensajeParaEnviar.Text;
                EnviarMensaje(datos);
            }
        }

        private void EnviarMensaje(string datos)
        {
            UdpClient envio = new UdpClient(); 
            Byte[] mensaje = Encoding.ASCII.GetBytes(datos); 
            IPEndPoint remoto = new IPEndPoint(IPAddress.Broadcast, 1800); 
            envio.Send(mensaje, mensaje.Length, remoto); 
            envio.Close();
            txtMensajeParaEnviar.Clear(); 
            txtMensajeParaEnviar.Focus();
        }

        private void txtMensaje_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void txtMensajeParaEnviar_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtMensajeParaEnviar.Text))
                {
                    string datos = nombre + " dice >> " + txtMensajeParaEnviar.Text; EnviarMensaje(datos);
                }
            }
        }

        private void FrmMensaje_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            string datos = nombre + " ha salido..."; 
            EnviarMensaje(datos);
        }
    }
}
