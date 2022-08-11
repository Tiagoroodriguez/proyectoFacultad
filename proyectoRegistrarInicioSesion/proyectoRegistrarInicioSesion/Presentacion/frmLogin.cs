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

            Usuario oUsuario = new Usuario();
            oUsuario.Nombre = txtUsuario.Text;
            oUsuario.Password = txtPassword.Text;

            //if (this.validar(txtUsuario.Text,txtClave.Text))
            if (oUsuario.validar())
            {
                MessageBox.Show("Login OK",
                    "Ingreso al sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Usuario y/o password incorrectos",
                    "Validaciòn de datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
