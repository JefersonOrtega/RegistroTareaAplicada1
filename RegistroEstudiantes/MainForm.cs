using RegistroEstudiantes.Entidades;
using RegistroEstudiantes.UI.Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RegistroEstudiantes
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void PersonaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //rEstudiantes rEstudiantes = new rEstudiantes();
            FormREstudiantes frm = new FormREstudiantes();
            //frm.MdiParent = this;
            frm.Show();
           //rEstudiantes.Show();

        }
    }
}
