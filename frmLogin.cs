using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerolinea1.Presentacion;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Aerolinea1
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }


        SqlConnection objconexion = new SqlConnection("Data Source=.;Initial Catalog=Aerolinea;Integrated Security=True");

        public void mtdIniciar(string Documento, string Clave)
        {
            try
            {

                objconexion.Open();
                SqlCommand cmd = new SqlCommand("select Nombre,Clave, Rol from Usuario Where Documento = @documento and Clave = @clave ", objconexion);
                cmd.Parameters.AddWithValue("documento",Documento);
                cmd.Parameters.AddWithValue("clave", Clave);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 1)

                    this.Hide();

                if (dt.Rows[0][2].ToString() == "Administrador" )
                {
                    new frmMenu(dt.Rows[0][0].ToString(), dt.Rows[0][2].ToString()).Show();
                }
                else if (dt.Rows[0][2].ToString() == "Empleado")
                {
                    new frmMenu(dt.Rows[0][0].ToString(),dt.Rows[0][2].ToString()).Show();

                }

            }
            catch (Exception )
            {

                MessageBox.Show("Documento o Clave Incorrectas");
            }
            finally
            {
                objconexion.Close();
            }
        }
   

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            mtdIniciar(this.txtDocumento.Text, this.txtClave.Text);
        }
    }
}
