namespace Chat
{
    partial class FrmMensaje
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMensaje));
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.txtMensajeParaEnviar = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMensaje
            // 
            this.txtMensaje.Location = new System.Drawing.Point(1, 0);
            this.txtMensaje.Multiline = true;
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMensaje.Size = new System.Drawing.Size(428, 208);
            this.txtMensaje.TabIndex = 0;
            this.txtMensaje.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMensaje_KeyDown);
            // 
            // txtMensajeParaEnviar
            // 
            this.txtMensajeParaEnviar.Location = new System.Drawing.Point(1, 214);
            this.txtMensajeParaEnviar.Multiline = true;
            this.txtMensajeParaEnviar.Name = "txtMensajeParaEnviar";
            this.txtMensajeParaEnviar.Size = new System.Drawing.Size(310, 60);
            this.txtMensajeParaEnviar.TabIndex = 1;
            this.txtMensajeParaEnviar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMensajeParaEnviar_KeyDown);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(317, 244);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(100, 30);
            this.btnEnviar.TabIndex = 2;
            this.btnEnviar.Text = "Enviar!";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // FrmMensaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 286);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txtMensajeParaEnviar);
            this.Controls.Add(this.txtMensaje);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMensaje";
            this.Text = "Mensaje";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMensaje_FormClosing);
            this.Load += new System.EventHandler(this.FrmMensaje_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.TextBox txtMensajeParaEnviar;
        private System.Windows.Forms.Button btnEnviar;
    }
}

