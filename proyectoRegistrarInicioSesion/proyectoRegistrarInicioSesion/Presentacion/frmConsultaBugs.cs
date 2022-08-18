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

namespace proyectoRegistrarInicioSesion.Presentacion
{
    public partial class frmConsultaBugs : Form
    {
        Usuario oUsuario;

        public frmConsultaBugs()
        {
            InitializeComponent();
            oUsuario = new Usuario();
        }

        private void frmConsultaBugs_Load(object sender, EventArgs e)
        {
            // establece la fecha incial 7 dias antes y la fecha final en el dia actual
            this.dtpFechaDesde.Value = DateTime.Today.AddDays(-7);
            this.dtpFechaHasta.Value = DateTime.Today;

            // cargar datos a los ComboBox
            //this.CargarCombo(cboEstado, "Estados");
            //this.CargarCombo(cboCriticidad, "Criticidades");
            //this.CargarCombo(cboPrioridad, "Prioridades");
            //this.CargarCombo(cboProducto, "Productos");
            this.CargarCombo(cboAsignadoA, oUsuario.RecuperarTodo());

        }

        // metodo para cargar los combos
        private void CargarCombo(ComboBox combo, DataTable Tabla)
        {
            combo.DataSource = Tabla;
            combo.ValueMember = Tabla.Columns[0].ColumnName;//0 = "id_usuario"
            combo.DisplayMember = Tabla.Columns[2].ColumnName;//2 = "usuario"
            combo.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        

    }
}
