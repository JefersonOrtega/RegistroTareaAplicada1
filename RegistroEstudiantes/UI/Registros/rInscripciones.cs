using RegistroEstudiantes.BLL;
using RegistroEstudiantes.DAL;
using RegistroEstudiantes.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroEstudiantes.UI.Registros
{
    public partial class rInscripciones : Form
    {
        public rInscripciones()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            InscripcionIDnumericUpDown.Value = 0;
            FechaDateTimePicker.Value = DateTime.Now;
            EstudianteIDNumericUpDown.Value = 0;
            ComentarioRichTextBox.Text = string.Empty;
            MontoTextBox.Text = string.Empty;
            DepositoTextBox.Text = string.Empty;
            BalanceTextBox.Text = string.Empty;

        }

        private void LLenarCampo(Inscripciones inscripcion)
        {
            InscripcionIDnumericUpDown.Value = inscripcion.InscripcionID;
            FechaDateTimePicker.Value = inscripcion.Fecha;
            EstudianteIDNumericUpDown.Value = inscripcion.EstudianteID;
            ComentarioRichTextBox.Text = inscripcion.Comentarios;
            MontoTextBox.Text = Convert.ToString(inscripcion.Monto);
            DepositoTextBox.Text = Convert.ToString(inscripcion.Deposito);
            BalanceTextBox.Text = Convert.ToString(inscripcion.Balance);
        }

        private Inscripciones LlenarClase()
        {
            Inscripciones inscripcion = new Inscripciones();

            
            Contexto db = new Contexto();   //

            inscripcion.InscripcionID = Convert.ToInt32(InscripcionIDnumericUpDown.Value);
            inscripcion.Fecha = FechaDateTimePicker.Value;
            inscripcion.EstudianteID =Convert.ToInt32(EstudianteIDNumericUpDown.Value);
            inscripcion.Comentarios = ComentarioRichTextBox.Text;
            inscripcion.Monto = Convert.ToSingle(MontoTextBox.Text);
            inscripcion.Deposito = Convert.ToSingle(DepositoTextBox.Text);
            inscripcion.Balance = (Convert.ToSingle(MontoTextBox.Text)-Convert.ToSingle(DepositoTextBox.Text));

            Estudiantes estudiante = EstudiantesBLL.buscar(Convert.ToInt32(EstudianteIDNumericUpDown.Value)); //
            estudiante.Balance += inscripcion.Balance; //
            db.Entry(estudiante).State = EntityState.Modified;
            db.SaveChanges();

            return inscripcion;
        }

        
        private bool ExisteEnLaBaseDeDatos()
        {
            Inscripciones inscripcion = InscripcionesBLL.Buscar((int)InscripcionIDnumericUpDown.Value);

            return (inscripcion != null);
        }

        private bool Validar()
        {
            bool paso = true;
            MyErrorProvider.Clear();

            if (string.IsNullOrWhiteSpace(MontoTextBox.Text))
            {
                MyErrorProvider.SetError(MontoTextBox, "El campo Monto no puede estar vacío");
                MontoTextBox.Focus();
                paso = false;
            }

           

            return paso;
        }
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Inscripciones inscripcion;
            bool paso;

            if (!Validar())
                return;

            inscripcion = LlenarClase();

            //Aqui determina si es guardar o modificar
            if (InscripcionIDnumericUpDown.Value == 0)
            {
                
                paso = InscripcionesBLL.Guardar(inscripcion);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede Modificar una inscripcion que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = InscripcionesBLL.Modificar(inscripcion);
            }


            //Informa si guarda o no
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No fue posible guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            Inscripciones inscripcion = new Inscripciones();

            int.TryParse(InscripcionIDnumericUpDown.Text, out id);

            inscripcion = InscripcionesBLL.Buscar(id);

            if (inscripcion != null)
            {
                MessageBox.Show("Inscripcion Encontrada");
                LLenarCampo(inscripcion);
            }
            else
            {
                MessageBox.Show("Inscripcion no encontrada");
            }
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            MyErrorProvider.Clear();
            int id;

            int.TryParse(InscripcionIDnumericUpDown.Text, out id);

            

            if (InscripcionesBLL.Eliminar(id))
            {
                Contexto db = new Contexto();   //

                Estudiantes estudiante = EstudiantesBLL.buscar(Convert.ToInt32(EstudianteIDNumericUpDown.Value));   //
               
                estudiante.Balance -= (Convert.ToSingle(BalanceTextBox.Text)); //
                db.Entry(estudiante).State = EntityState.Modified;  //
                db.SaveChanges();   //
                

                MessageBox.Show("Eliminado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MyErrorProvider.SetError(InscripcionIDnumericUpDown, "No se puede eliminar una inscripcion que no existe");
            }
            Limpiar();
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        
    }
}
