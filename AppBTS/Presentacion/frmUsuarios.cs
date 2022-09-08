using AppBTS.Negocio;
using AppBTS.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBTS.Presentacion
{
    public partial class frmUsuarios : Form
    {
        enum Acciones
        {
            Alta,
            Modificacion,
            Baja
        }
        Acciones MiAccion;
        PerfilService oPerfil = new PerfilService();
        UsuarioService oUsuario = new UsuarioService();
             
        public frmUsuarios()
        {
            InitializeComponent();
        }
        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            CargarCombo(cboPerfil,oPerfil.traerTodos());
            CargarGrilla(grdUsuarios, oUsuario.traerTodos());
            HabilitarModoEdicion(false);
            MiAccion = Acciones.Modificacion;

        }

        // Metodo para habilitar y deshabilitar los text box y los botones apenas se ejecuta
        private void HabilitarModoEdicion(bool v)
        {
            // no se pone porque el id se genera automaticamente y el usuario no deberia poder cambiarlo.
            //txtId.Enabled = v;
            txtPassword.Enabled = v;
            txtEmail.Enabled = v;
            txtNombre.Enabled = v;
            cboPerfil.Enabled = v;
            btnGrabar.Enabled = v;
            btnCancelar.Enabled = v;
            // Niega el valor de v -> si v es true toma el valor de false
            btnNuevo.Enabled = !v;
            btnEditar.Enabled = !v;
            btnSalir.Enabled = !v;
            grdUsuarios.Enabled = !v;
        }  

        // Pone todos los text box en blanco
        private void LimpiarCampos()
        {
            txtId.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtNombre.Text = String.Empty;
            txtPassword.Text = String.Empty;
            cboPerfil.SelectedIndex = -1;
        }

        private void CargarCombo(ComboBox combo, DataTable tabla)
        {
            combo.DataSource = tabla;
            combo.DisplayMember = tabla.Columns[1].ColumnName;
            combo.ValueMember = tabla.Columns[0].ColumnName;
            combo.SelectedIndex = -1;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void CargarGrilla(DataGridView grilla, DataTable tabla)
        {
            grilla.Rows.Clear();
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                grilla.Rows.Add(tabla.Rows[i]["id_usuario"],
                                tabla.Rows[i]["usuario"],
                                tabla.Rows[i]["email"]);
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MiAccion = Acciones.Alta;
            HabilitarModoEdicion(true);
            LimpiarCampos();
            txtNombre.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //VALIDAR LOS DATOS
            
            //CREAR y CARGAR el obejto
            
            if (MiAccion == Acciones.Alta)
            {
                //INSERT
            }
            else
            {
                //UPDATE
            }
            MiAccion = Acciones.Modificacion;
            HabilitarModoEdicion(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            MiAccion = Acciones.Modificacion;
            LimpiarCampos();
            HabilitarModoEdicion(false);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            
            HabilitarModoEdicion(true);
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void grdUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            CargarCombo((int)grdUsuarios.CurrentRow.Cells[0].Value);
        }

        private void CargarCombo(int idUsuario)
        {
            //DataTable tabla = oUsuario.traerPorId(idUsuario);
            //txtId.Text = tabla.Rows[0]
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de eliminar este usuario?",
                                "ELIMINANDO",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //Delete
            }
        }


    }
}
