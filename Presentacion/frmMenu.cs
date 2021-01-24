using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aerolinea1.Presentacion
{
    public partial class frmMenu : Form
    {
    
        //mtd para preguntar si desea cerrar
        private void iconCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro de cerrar?", "Cerrar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                Application.Exit();
            }
            else
            {

            }
        }

        public frmMenu(string Nombre, string rol)
        {
            InitializeComponent();
            lblMensaje.Text = Nombre;
            lblRol.Text = rol;
           
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void BarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void iconMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void iconmaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void iconrestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
        }

        private void btnmenu_Click(object sender, EventArgs e)
        {

            if (MenuV.Width == 57)
            {
                MenuV.Width = 250;
            }
            else

                MenuV.Width = 57;

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            if (SubmenuRegistrar.Visible == true)
            {
                SubmenuRegistrar.Visible = false;
            }
            else
            {
                SubmenuRegistrar.Visible = true;
            }

            btnRegistrar.Location = new Point(4, 92);
            SubmenuRegistrar.Location = new Point(56, 140);
            btnVuelo.Location = new Point(2, 345);
            btnAviones.Location = new Point(2, 380);
            btnAeropuer.Location = new Point(2, 415);
            btnEnviarCorreo.Location = new Point(2, 445);
            btnInformes.Location = new Point(2, 475);


            if (SubmenuRegistrar.Visible == false)
            {
                btnRegistrar.Location = new Point(4, 89);
                btnVuelo.Location = new Point(4, 130);
                btnAviones.Location = new Point(4,175);
                btnAeropuer.Location = new Point(4,215);
                btnEnviarCorreo.Location = new Point(4, 255);
                btnInformes.Location = new Point(4, 295);
            }


        }
        private void mostrarlogo()
        {
            AbrirFormInPanel(new frmLogo());
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

            if (lblRol.Text == "Empleado")
            {
                btnInformes.Visible = false;
            }


            mostrarlogo();

            btnRegistrar.Location = new Point(4, 89);
            btnVuelo.Location = new Point(4, 130);
            btnAviones.Location = new Point(4,170);
            btnAeropuer.Location = new Point(4,210);
            btnEnviarCorreo.Location = new Point(4, 250);
            btnInformes.Location = new Point(4,290);
            SubmenuRegistrar.Hide();


            //if (lblMensaje.Text == "Empleado")
            //{
            //    btnInformes.Enabled = false;

            //}

        }

        private void AbrirFormInPanel(object formHijo)
        {
            if (this.lblHora.Controls.Count > 0)
                this.lblHora.Controls.RemoveAt(0);
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.lblHora.Controls.Add(fh);
            this.lblHora.Tag = fh;
            fh.Show();
        }
        private void mostrarlogoAlCerrarForm(object sender, FormClosedEventArgs e)
        {
            mostrarlogo();
        }

        private void btnINICIO_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmLogo());
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MenuV.Width == 57)
            {
                MenuV.Width = 250;
            }
            else

                MenuV.Width = 57;

        }

        private void btnRegistrarClientes_Click(object sender, EventArgs e)
        {
            frmRegistrarClientes objRegisClientes = new frmRegistrarClientes();
            objRegisClientes.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
            AbrirFormInPanel(objRegisClientes);
        }

        private void btnrptcompra_Click(object sender, EventArgs e)
        {
            frmVuelos objvuelos = new frmVuelos();
            objvuelos.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
            AbrirFormInPanel(objvuelos);

        }

        private void btnrptpagos_Click(object sender, EventArgs e)
        {
            frmPasaje objPasaje = new frmPasaje();
            objPasaje.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
            AbrirFormInPanel(objPasaje);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAvion objavion = new frmAvion();
            objavion.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
            AbrirFormInPanel(objavion);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmUsuarios objusuarios = new frmUsuarios();
            objusuarios.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
            AbrirFormInPanel(objusuarios);
        }

        private void btnVuelo_Click(object sender, EventArgs e)
        {
            btnbuscar objetoestadov = new btnbuscar();
            objetoestadov.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
            AbrirFormInPanel(objetoestadov);
        }

        

        private void CerrarSesion_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro de cerrar Sesion ?", "Cerrar Sesion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                frmLogin objlogin = new frmLogin();
                objlogin.Show();
                this.Hide();
            }
            else
            {
            }
        }

        private void btnAviones_Click(object sender, EventArgs e)
        {
            frmEstadoAvion objestadoavion = new frmEstadoAvion();
            objestadoavion.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
            AbrirFormInPanel(objestadoavion);
        }
  
        private void btnAeropuer_Click(object sender, EventArgs e)
        {
            frmAeropuertos objAeropuertos = new frmAeropuertos();
            objAeropuertos.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
            AbrirFormInPanel(objAeropuertos);
        }

        private void btnEnviarCorreo_Click(object sender, EventArgs e)
        {
            frmEnviarTicket objEnviarTicket = new frmEnviarTicket();
            objEnviarTicket.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
            AbrirFormInPanel(objEnviarTicket);
        }

        private void btnRegistrarRutas_Click(object sender, EventArgs e)
        {
            frmRuta objRegiRuta = new frmRuta();
            objRegiRuta.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
            AbrirFormInPanel(objRegiRuta);
        }

       
        private void btnInformes_Click(object sender, EventArgs e)
        {
            frmInformeRegisroPasaje objInformes = new frmInformeRegisroPasaje();
            objInformes.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
            AbrirFormInPanel(objInformes);

        }

        private void lblHora_Paint(object sender, PaintEventArgs e)
        {

        }
    }


}


