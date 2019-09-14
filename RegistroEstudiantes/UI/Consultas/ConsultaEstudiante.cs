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
    public partial class cEstudiantes : Form
    {
        public cEstudiantes()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            var listado = new List<Estudiantes>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch(FiltrarComboBox.SelectedItem)
                {
                    case 0: //Todo
                        {
                            listado = EstudiantesBLL.GetList(p => true);
                            break;
                        }

                    case 1: //Id
                        {
                            int id = Convert.ToInt32(CriterioTextBox.Text);
                            listado = EstudiantesBLL.GetList(p => p.EstudianteID == id);
                            break;
                        }

                    case 3: //Matricula
                        {
                            listado = EstudiantesBLL.GetList(p => p.Matricula.Contains(CriterioTextBox.Text));
                            break;
                        }

                    case 4: //Nombre
                        {
                            listado = EstudiantesBLL.GetList(p => p.Nombres.Contains(CriterioTextBox.Text));
                            break;
                        }

                    case 5: //Cedula
                        {
                            listado = EstudiantesBLL.GetList(p => p.Cedula.Contains(CriterioTextBox.Text));
                            break;
                        }

                    case 6: //Balance
                        {
                            float balance = Convert.ToSingle(CriterioTextBox.Text);
                            listado = EstudiantesBLL.GetList(p => p.Balance == balance);
                            break;
                        }
                }
                listado = listado.Where(c => c.FechaNacimiento.Date >= DesdeDateTimePicker.Value.Date && c.FechaNacimiento.Date <= HastaDateTimePicker.Value.Date).ToList();
            }
            else
            {
                listado = EstudiantesBLL.GetList(p => true);
            }
            ConsultaDataGridView.DataSource = null;
            ConsultaDataGridView.DataSource = listado;
        }
    }
}
