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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "admin" && txtContrasena.Text == "1234")
            {
                this.Hide();
                FormPrincipal principal = new FormPrincipal();
                principal.ShowDialog();
                txtContrasena.Clear();
                this.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
                txtContrasena.Clear();
                txtContrasena.Focus();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
