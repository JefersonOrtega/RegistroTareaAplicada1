using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;

namespace RegistroEstudiantes.Entidades
{
    public class Inscripciones
    {

        [Key]
        public int InscripcionID { get; set; }
        public DateTime Fecha { get; set; }
        public int EstudianteID { get; set; }
        public string Comentarios { get; set; }
        public float Monto { get; set; }
        public float Deposito { get; set; }
        public float Balance { get; set; }

        public Inscripciones()
        {
            InscripcionID = 0;
            Fecha = DateTime.Now;
            EstudianteID = 0;
            Comentarios = string.Empty;
            Monto = 0.00f;
            Deposito = 0.00f;
            Balance = 0.00f;
        }
    }
}
