using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mesadepartes
{
    public partial class FormGestion : Form
    {
        public FormGestion()
        {
            InitializeComponent();
        }

        private void FormGestion_Load(object sender, EventArgs e)
        {
            dgvExpedientes.Columns.Add("colCodigo", "Código");
            dgvExpedientes.Columns.Add("colDni", "DNI");
            dgvExpedientes.Columns.Add("colNombres", "Nombres");
            dgvExpedientes.Columns.Add("colApellidos", "Apellidos");
            dgvExpedientes.Columns.Add("colTipo", "Tipo");
            dgvExpedientes.Columns.Add("colAsunto", "Asunto");
            dgvExpedientes.Columns.Add("colFecha", "Fecha");

            dgvExpedientes.ReadOnly = true;
            dgvExpedientes.AllowUserToAddRows = false;
            dgvExpedientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            MostrarTodos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string codigo = txtBuscarCodigo.Text.Trim();
            if (codigo == "")
            {
                MessageBox.Show("Ingrese un código para buscar");
                return;
            }

            int pos = GestorExpedientes.BuscarPorCodigo(codigo);
            if (pos == -1)
            {
                MessageBox.Show("No se encontró el expediente");
                return;
            }

            dgvExpedientes.Rows.Clear();
            dgvExpedientes.Rows.Add(
                GestorExpedientes.codigos[pos], GestorExpedientes.dnis[pos],
                GestorExpedientes.nombres[pos], GestorExpedientes.apellidos[pos],
                GestorExpedientes.tipos[pos], GestorExpedientes.asuntos[pos],
                GestorExpedientes.fechas[pos]);
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            GestorExpedientes.OrdenarBurbuja();
            MostrarTodos();
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            txtBuscarCodigo.Clear();
            MostrarTodos();
        }

        private void MostrarTodos()
        {
            dgvExpedientes.Rows.Clear();
            for (int i = 0; i < GestorExpedientes.cont; i++)
            {
                dgvExpedientes.Rows.Add(
                    GestorExpedientes.codigos[i], GestorExpedientes.dnis[i],
                    GestorExpedientes.nombres[i], GestorExpedientes.apellidos[i],
                    GestorExpedientes.tipos[i], GestorExpedientes.asuntos[i],
                    GestorExpedientes.fechas[i]);
            }
        }
    }
}
