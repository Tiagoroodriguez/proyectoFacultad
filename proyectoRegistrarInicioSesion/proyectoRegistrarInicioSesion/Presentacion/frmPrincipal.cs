using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyectoRegistrarInicioSesion.Presentacion;

namespace proyectoRegistrarInicioSesion
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            frmLogin oFL = new frmLogin();
            oFL.ShowDialog();
            // agregamos el nombre del usuario logeado al texto de la ventana del menu principal
            this.Text += " - Usuario: " + oFL.OUsuario;

            oFL.Dispose();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // mensaje que aparece antes de salir.
            if (MessageBox.Show("Està seguro de abandonar la aplicacion"
                                ,"Saliendo"
                                , MessageBoxButtons.YesNo
                                , MessageBoxIcon.Question
                                , MessageBoxDefaultButton.Button1)
                == DialogResult.Yes)
            {
                this.Close();
            }
            
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // abre el formulario de consulta de bugs cuando se entra a la opcion de consulta en el MenuStrp
            frmConsultaBugs oFCB = new frmConsultaBugs();
            oFCB.ShowDialog();
            oFCB.Dispose();
        }

        private void salirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // mensaje que aparece antes de salir.
            if (MessageBox.Show("Està seguro de abandonar la aplicacion"
                                , "Saliendo"
                                , MessageBoxButtons.YesNo
                                , MessageBoxIcon.Question
                                , MessageBoxDefaultButton.Button1)
                == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // abre el formulario de consulta de bugs cuando se entra a la opcion de consulta en el MenuStrp
            frmConsultaBugs oFCB = new frmConsultaBugs();
            oFCB.ShowDialog();
            oFCB.Dispose();
        }
    }
}
