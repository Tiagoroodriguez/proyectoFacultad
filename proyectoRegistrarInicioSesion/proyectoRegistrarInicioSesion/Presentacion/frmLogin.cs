using proyectoRegistrarInicioSesion.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoRegistrarInicioSesion
{
    public partial class frmLogin : Form
    {
        //private string usuario="admin";
        //private string clave="1234";

        private Usuario oUsuario = new Usuario();
        // hacemos una prop del obejto usuario (para poder usarlo en el frmPrincipal)
        internal Usuario OUsuario { get { return oUsuario; } set { oUsuario = value; } }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text=="")
            {
                MessageBox.Show("Debe ingresar usuario...");
                txtUsuario.Focus();
                return;
            }
            if (txtPassword.Text==String.Empty)
            {
                MessageBox.Show("Debe ingresar contraseña...");
                txtPassword.Focus();
                return;
            }

            
            oUsuario.Nombre = txtUsuario.Text;
            oUsuario.Password = txtPassword.Text;

            //if (this.validar(txtUsuario.Text,txtClave.Text))

            oUsuario.IdUsuaruaio = oUsuario.validar();
            if (oUsuario.IdUsuaruaio != 0)
            {
                MessageBox.Show("Login OK",
                    "Ingreso al sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario y/o password incorrectos",
                    "Validaciòn de datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                this.oUsuario.Nombre = "";
                this.oUsuario.Password = "";

            }

        }

        //private bool validar(string u,string c)
        //{
        //    //if (txtUsuario.Text == this.usuario && txtClave.Text == this.clave)
        //    if (u == this.usuario && c == this.clave)
        //        return true;
        //    else
        //        return false;
        //}

        private void lblUsuario_Click(object sender, EventArgs e)
        {

        }

        private void frmLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }
    }
}
