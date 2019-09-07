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

namespace RegistroEstudiantes.UI.Registros
{
    public partial class FormREstudiantes : Form
    {
        public FormREstudiantes()
        {
            InitializeComponent();
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void FormREstudiantes_Load(object sender, EventArgs e)
        {

        }

        //Metodo para limpiar los componentes del registro


        private void Limpiar()
        {
            IDnumericUpDown.Value = 0;
            MatriculaTextBox.Text = string.Empty;
            NombresTextBox.Text = string.Empty;
            ApellidosTextBox.Text = string.Empty;
            CedulaMaskedTextBox.Text = string.Empty;
            TelefonoMaskedTextBox.Text = string.Empty;
            CelularMaskedTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            SexoComboBox.Text = string.Empty;
            BalanceTextBox.Text = string.Empty;
            FechaNacimientoDateTimePicker.Value = DateTime.Now;
            MyErrorProvider.Clear();
        }

        //Evento del boton nuevo
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private Estudiantes LlenarClase() //del form a la base de datos
        {
            Estudiantes estudiante = new Estudiantes();
            estudiante.EstudianteID = Convert.ToInt32(IDnumericUpDown.Value);
            estudiante.Matricula = NombresTextBox.Text;
            estudiante.Nombres = MatriculaTextBox.Text;
            estudiante.Apellidos = ApellidosTextBox.Text;
            estudiante.Cedula = CedulaMaskedTextBox.Text;
            estudiante.Telefono = TelefonoMaskedTextBox.Text;
            estudiante.Celular = CelularMaskedTextBox.Text;
            estudiante.Email = EmailTextBox.Text;
            estudiante.Sexo = Convert.ToInt32(SexoComboBox.SelectedIndex);
            estudiante.Balance = Convert.ToInt32(BalanceTextBox.Text);
            estudiante.FechaNacimiento = FechaNacimientoDateTimePicker.Value;

            return estudiante;
        }

        private void LLenarCampo(Estudiantes estudiante)
        {
            IDnumericUpDown.Value = estudiante.EstudianteID;
            MatriculaTextBox.Text = estudiante.Matricula;
            NombresTextBox.Text = estudiante.Nombres;
            ApellidosTextBox.Text = estudiante.Apellidos;
            CedulaMaskedTextBox.Text = estudiante.Cedula;
            TelefonoMaskedTextBox.Text = estudiante.Telefono;
            CelularMaskedTextBox.Text = estudiante.Celular;
            EmailTextBox.Text = estudiante.Email;
            SexoComboBox.Text = Convert.ToString(estudiante.Sexo);
            BalanceTextBox.Text = Convert.ToString(estudiante.Balance);
            FechaNacimientoDateTimePicker.Value = estudiante.FechaNacimiento;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Estudiantes estudiante = EstudiantesBLL.buscar((int)IDnumericUpDown.Value);
            return (estudiante != null);
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Estudiantes estudiante;
            bool paso = false;

            if (!Validar())
               return;

            estudiante = LlenarClase();

            //Determinar si es guargar o modificar
            if (IDnumericUpDown.Value == 0)
                paso = EstudiantesBLL.guardar(estudiante);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una persona que no existe");
                    return;
                }
                paso = EstudiantesBLL.modificar(estudiante);

            }

            //Informar el resultado
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private bool Validar()
        {
            bool paso = true;
            MyErrorProvider.Clear();

            if(NombresTextBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(NombresTextBox, "El campo nombre no puede estar vacio");
                NombresTextBox.Focus();
                paso = false;
            }
            
            if (string.IsNullOrWhiteSpace(MatriculaTextBox.Text))
            {
                MyErrorProvider.SetError(MatriculaTextBox, "El campo matricula no pude estar vacio");
                MatriculaTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CedulaMaskedTextBox.Text))
            {
                MyErrorProvider.SetError(CedulaMaskedTextBox, "El campo Cedula no puede estar vacio");
                CedulaMaskedTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(BalanceTextBox.Text))
            {
                MyErrorProvider.SetError(BalanceTextBox, "El campo Balance no puede estar vacio");
                BalanceTextBox.Focus();
                paso = false;
            }
            return paso;
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            Estudiantes estudiante = new Estudiantes();
            int.TryParse(IDnumericUpDown.Text, out id);

            Limpiar();

            estudiante = EstudiantesBLL.buscar(id);

            if (estudiante != null)
            {
                MessageBox.Show("Estudiante Encontrado");
                LLenarCampo(estudiante);
            }
            else
            {
                MessageBox.Show("Estudiante No encontrado");
            }
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            MyErrorProvider.Clear();

            int id;
            int.TryParse(IDnumericUpDown.Text, out id);

            Limpiar();

            if (EstudiantesBLL.eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MyErrorProvider.SetError(IDnumericUpDown, "No se puede eliminar un estudiante que no existe");

        }
    }
}
