using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Aerolinea1.Presentacion
{
    public partial class frmEnviarTicket : Form
    {


        private string archivo;

        public frmEnviarTicket()
        {
            InitializeComponent();
            archivo = "";
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {

            try
            {
                System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();


                mmsg.To.Add(txtPara.Text);
                mmsg.Subject = txtAsunto.Text;
                mmsg.Attachments.Add(new Attachment(archivo));
                mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
                mmsg.Bcc.Add(txtCopia.Text);

                mmsg.Body = txtDescripcion.Text;
                mmsg.BodyEncoding = System.Text.Encoding.UTF8;
                mmsg.IsBodyHtml = true;
                mmsg.From = new System.Net.Mail.MailAddress("alejo001vale@gmail.com");

                System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

                cliente.Credentials = new System.Net.NetworkCredential("alejo001vale@gmail.com", "indeportesFC1");

                cliente.Port = 587;
                cliente.EnableSsl = true;

                cliente.Host = "smtp.gmail.com"; //mail.dominio.com


                try
                {
                    cliente.Send(mmsg);
                    MessageBox.Show("Envio Exitoso");
                }
                catch (Exception exe)
                {
                    MessageBox.Show("Error De Envio"+ exe);

                }

            }
            catch (Exception)
            {

                MessageBox.Show("Complete todos los campos");
            }
           


            





        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            try
            {
                this.caragarArchivo.ShowDialog();
                if (this.caragarArchivo.FileName.Equals("") == false)
                {
                    txtRutaArchivo.Text = this.caragarArchivo.FileName;
                    archivo = caragarArchivo.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el archivo " + ex.ToString());
            }


            //if (caragarArchivo.ShowDialog() == DialogResult.OK)
            //{
            //    archivo = caragarArchivo.FileName;
            //}









        }

        private void frmEnviarTicket_Load(object sender, EventArgs e)
        {

        }
    }
}
