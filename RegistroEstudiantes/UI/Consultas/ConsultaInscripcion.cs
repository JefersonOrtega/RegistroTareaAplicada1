using RegistroEstudiantes.BLL;
using RegistroEstudiantes.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroEstudiantes.UI.Consultas
{
    public partial class cInscripcion : Form
    {
        public cInscripcion()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            var listado = new List<Inscripciones>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltrarComboBox.SelectedItem)
                {
                    case 0: //Todo
                        {
                            listado = InscripcionesBLL.GetList(p=>true);
                            break;
                        }

                    case 1: //ID
                        {
                            int id = Convert.ToInt32(CriterioTextBox.Text);
                            listado = InscripcionesBLL.GetList(p => p.InscripcionID == id);
                            break;
                        }

                    case 2: //Id del estudiante
                        {
                            int id = Convert.ToInt32(CriterioTextBox.Text);
                            listado = InscripcionesBLL.GetList(p => p.EstudianteID == id);
                            break;
                        }

                    case 3: //Monto
                        {
                            float monto = Convert.ToSingle(CriterioTextBox.Text);
                            listado = InscripcionesBLL.GetList(p => p.Monto == monto);
                            break;
                        }

                    case 4: //Deposito
                        {
                            float deposito = Convert.ToSingle(CriterioTextBox.Text);
                            listado = InscripcionesBLL.GetList(p => p.Deposito == deposito);
                            break;
                        }

                    case 5: //Balance
                        {
                            float balance = Convert.ToSingle(CriterioTextBox.Text);
                            listado = InscripcionesBLL.GetList(p => p.Balance == balance);
                            break;
                        }
                }
                listado = listado.Where(c => c.Fecha.Date >= DesdeDateTimePicker.Value.Date && c.Fecha.Date <= HastaDateTimePicker.Value.Date).ToList();
            }
            else
            {
                listado = InscripcionesBLL.GetList(p => true);
            }
            ConsultaDataGridView.DataSource = null;
            ConsultaDataGridView.DataSource = listado;
        }
    }
}
