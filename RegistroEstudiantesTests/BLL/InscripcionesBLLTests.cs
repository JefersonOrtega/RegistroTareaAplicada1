using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroEstudiantes.BLL;
using RegistroEstudiantes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEstudiantes.BLL.Tests
{
    [TestClass()]
    public class InscripcionesBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Inscripciones inscripcion = new Inscripciones();

            inscripcion.InscripcionID = 0;
            inscripcion.EstudianteID = 0;
            inscripcion.Monto = 2000000000.00f;
            inscripcion.Deposito = 2222222.00f;
            inscripcion.Comentarios = "Hecho por el administrador";
            inscripcion.Balance = 50000000000000.00f;

            paso = InscripcionesBLL.Guardar(inscripcion);

            Assert.AreEqual(paso,true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Inscripciones inscripcion = new Inscripciones();

            inscripcion.InscripcionID = 9;
            inscripcion.EstudianteID = 1;
            inscripcion.Monto = 50000.00f;
            inscripcion.Deposito = 25000.00f;
            inscripcion.Comentarios = "Hecho por el administrador";
            inscripcion.Balance = 25000.00f;

            paso = InscripcionesBLL.Modificar(inscripcion);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            paso = InscripcionesBLL.Eliminar(12);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Inscripciones inscripcion = new Inscripciones();
            inscripcion = InscripcionesBLL.Buscar(11);
            Assert.AreNotEqual(inscripcion, null);
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }
    }
}