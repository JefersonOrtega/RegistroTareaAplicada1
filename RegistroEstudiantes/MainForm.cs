using RegistroEstudiantes.Entidades;
using RegistroEstudiantes.UI.Registros;
using RegistroEstudiantes.UI.Consultas;
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
            
            FormREstudiantes rEstudiantes = new FormREstudiantes();
            rEstudiantes.MdiParent = this;
            rEstudiantes.Show();

        }

        private void EstudianteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cEstudiantes cEstudiantes = new cEstudiantes();
            cEstudiantes.MdiParent = this;
            cEstudiantes.Show();
        }

        private void InscripcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rInscripciones rInscripciones = new rInscripciones();
            rInscripciones.MdiParent = this;
            rInscripciones.Show();
        }

        private void InscripcionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cInscripcion cInscripcion = new cInscripcion();
            cInscripcion.MdiParent = this;
            cInscripcion.Show();
        }
    }
}
