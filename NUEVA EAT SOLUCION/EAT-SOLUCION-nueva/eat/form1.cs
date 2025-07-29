using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eat
{
    public partial class formPrincipal : Form
    {

        private static formPrincipal _instancia;
        
        
        
        public formPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formMozos nuevoForm = new formMozos();
            nuevoForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
             FormEvento nuevoForm = new FormEvento();
            nuevoForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormCliente nuevoForm = new FormCliente();
            nuevoForm.ShowDialog();
        }
    }
}
