using BL.Ventas;
using System;
using System.Windows.Forms;

namespace Win.Delivery
{
    public partial class FormLogin : Form
    {
        SeguridadBL _seguridad;

        public FormLogin()
        {
            InitializeComponent();
            _seguridad = new SeguridadBL();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string usuario;
            string contrasena;

            usuario = textBox1.Text;
            contrasena = textBox2.Text;

            button1.Enabled = false;
            button1.Text = "Verificando...";
            Application.DoEvents();

            var usuarioDB = _seguridad.Autorizar(usuario, contrasena);

            if (usuarioDB != null)
            {
                Utilidades.NombreUsuario = usuarioDB.Nombre;
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecta");
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
       
            if (textBox1.Text != "")
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    textBox2.Focus();
                }
            }

        }

        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (textBox2.Text != "")
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    button1.PerformClick();
                }
            }
        }
    }
    
}
