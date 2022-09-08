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
    public partial class frmConsultaBugs : Form
    {
        Bug oBug = new Bug();
        Estado oEstado = new Estado();
        Prioridad oPrioridad = new Prioridad();
        Producto oProducto = new Producto();
        UsuarioService oUsuario = new UsuarioService();
        Criticidad oCriticidad = new Criticidad();

        public frmConsultaBugs()
        {
            InitializeComponent();
        }

        private void frmConsultaBugs_Load(object sender, EventArgs e)
        {
            this.limpiar();

            this.CargarCombo(cboEstado, oEstado.RecuperarTodos());
            this.CargarCombo(cboPrioridad, oPrioridad.RecuperarTodos());
            this.CargarCombo(cboProducto, oProducto.RecuperarTodos());
            this.CargarCombo(cboAsignadoA, oUsuario.traerTodos(), "usuario", "id_usuario");
            this.CargarCombo(cboCriticidad, oCriticidad.RecuperarTodos());

            //this.dgvBugs.DataSource = oBug.RecuperarTodos();
            this.CargarGrilla(dgvBugs, oBug.RecuperarTodos());

            this.btnConsultar.Enabled = true;
            this.btnNuevo.Enabled = true;
            this.btnAsignar.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnDetalle.Enabled = false;
            this.btnSalir.Enabled = true;
        }

        private void CargarGrilla(DataGridView grilla, DataTable tabla)
        {
            grilla.Rows.Clear();
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                grilla.Rows.Add(tabla.Rows[i]["id_bug"],
                                tabla.Rows[i]["titulo"],
                                tabla.Rows[i]["producto"],
                                tabla.Rows[i]["fecha_alta"],
                                tabla.Rows[i]["estado"],
                                tabla.Rows[i]["asignado"],
                                tabla.Rows[i]["criticidad"],
                                tabla.Rows[i]["prioridad"]);
            }
        }

        private void CargarCombo(ComboBox combo, DataTable tabla)
        {
            combo.DataSource = tabla;
            combo.DisplayMember = tabla.Columns[1].ColumnName;
            combo.ValueMember = tabla.Columns[0].ColumnName;
            combo.SelectedIndex = -1;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void CargarCombo(ComboBox combo, DataTable tabla,string campoMostrar,string campoValor)
        {
            combo.DataSource = tabla;
            combo.DisplayMember = campoMostrar;
            combo.ValueMember = campoValor;
            combo.SelectedIndex = -1;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string _estado, _asignado, _prioridad, _criticidad, _producto;
            _estado = _asignado = _prioridad = _criticidad = _producto = string.Empty;

            if (dtpFechaDesde.Value>dtpFechaHasta.Value)
            {
                MessageBox.Show("Fechas erroneas!!!");
                dtpFechaDesde.Focus();
                return;
            }
            if (cboEstado.SelectedIndex != -1)
                _estado = cboEstado.SelectedValue.ToString(); 
            if (cboAsignadoA.SelectedIndex != -1)
                _asignado = cboAsignadoA.SelectedValue.ToString();
            if (cboPrioridad.SelectedIndex != -1)
                _prioridad = cboPrioridad.SelectedValue.ToString();
            if (cboCriticidad.SelectedIndex != -1)
                _criticidad = cboCriticidad.SelectedValue.ToString();
            if (cboProducto.SelectedIndex != -1)
                _producto = cboProducto.SelectedValue.ToString();

            this.CargarGrilla(dgvBugs, oBug.RecuperarFiltrados(dtpFechaDesde.Value.ToString("yyyy/MM/dd"),
                                                               dtpFechaHasta.Value.ToString("yyyy/MM/dd"),
                                                               _estado,
                                                               _asignado,
                                                               _prioridad,
                                                               _criticidad,
                                                               _producto));
            this.limpiar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void limpiar()
        {
            this.dtpFechaDesde.Value = DateTime.Today.AddDays(-7);
            this.dtpFechaHasta.Value = DateTime.Today;
            this.cboAsignadoA.SelectedIndex = -1;
            this.cboCriticidad.SelectedIndex = -1;
            this.cboEstado.SelectedIndex = -1;
            this.cboPrioridad.SelectedIndex = -1;
            this.cboProducto.SelectedIndex = -1;
        }

        private void dgvBugs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnDetalle.Enabled = true;
            this.btnEditar.Enabled = true;
            this.btnAsignar.Enabled = true;
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            frmDetalleBug fdb = new frmDetalleBug((int)dgvBugs.CurrentRow.Cells[0].Value);
            //fdb.IdBug = (int)dgvBugs.CurrentRow.Cells[0].Value;
            fdb.ShowDialog();
        }
    }
}
