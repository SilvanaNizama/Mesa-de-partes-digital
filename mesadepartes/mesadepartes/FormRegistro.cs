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
    public partial class FormRegistro : Form
    {
        public FormRegistro()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormRegistro_Load(object sender, EventArgs e)
        {
            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipo.Items.Add("Solicitud");
            cboTipo.Items.Add("Oficio");
            cboTipo.Items.Add("Informe");
            cboTipo.Items.Add("Carta");
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text.Trim();
            string dni = txtDni.Text.Trim();
            string nombre = txtNombres.Text.Trim();
            string apellido = txtApellidos.Text.Trim();
            string tipo = cboTipo.Text;
            string asunto = txtAsunto.Text.Trim();
            string fecha = dtpFecha.Value.ToString("dd/MM/yyyy");

            if (!GestorExpedientes.CamposCompletos(codigo, dni, nombre, apellido, tipo, asunto))
            {
                MessageBox.Show("Complete todos los campos");
                return;
            }
            if (!GestorExpedientes.DniValido(dni))
            {
                MessageBox.Show("El DNI debe tener 8 dígitos numéricos");
                return;
            }
            if (GestorExpedientes.BuscarPorCodigo(codigo) != -1)
            {
                MessageBox.Show("Ya existe un expediente con ese código");
                return;
            }

            if (GestorExpedientes.Registrar(codigo, dni, nombre, apellido, tipo, asunto, fecha))
            {
                MessageBox.Show("Expediente registrado correctamente");
                GestorExpedientes.GuardarEnArchivo();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No hay espacio para más expedientes");
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtDni.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtAsunto.Clear();
            cboTipo.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Today;
            txtCodigo.Focus();
        }
    }
}