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
    public class EstudiantesBLLTests
    {
        [TestMethod()]
        public void guardarTest()
        {
            bool paso;
            Estudiantes estudiante = new Estudiantes();
            estudiante.EstudianteID = 0;
            estudiante.Matricula = "2017 - 0595";
            estudiante.Nombres = "Jeferson Raul";
            estudiante.Apellidos = "Ortega Brito";
            estudiante.Cedula = "402-0000000-0";
            estudiante.Telefono = "809-587-0000";
            estudiante.Celular = "829-754-0000";
            estudiante.Email = "aaasddd@gmail.com";
            estudiante.FechaNacimiento = DateTime.Now;
            estudiante.Sexo = 1;
            estudiante.Balance = 21000;

            paso = EstudiantesBLL.guardar(estudiante);
            Assert.AreEqual(paso,true);
        }

        [TestMethod()]
        public void modificarTest()
        {
            bool paso;
            Estudiantes estudiante = new Estudiantes();
            estudiante.EstudianteID = 1;
            estudiante.Matricula = "2016 - 0595";
            estudiante.Nombres = "Juan";
            estudiante.Apellidos = "Perez";
            estudiante.Cedula = "402-0005000-0";
            estudiante.Telefono = "809-588-0000";
            estudiante.Celular = "829-504-0000";
            estudiante.Email = "juanperez@gmail.com";
            estudiante.FechaNacimiento = DateTime.Now;
            estudiante.Sexo = 1;
            estudiante.Balance = 15000;

            paso = EstudiantesBLL.guardar(estudiante);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void eliminarTest()
        {
            bool paso;
            paso = EstudiantesBLL.eliminar(4);
            Assert.AreEqual(paso,true);
        }

        [TestMethod()]
        public void buscarTest()
        {
            Estudiantes estudiante = new Estudiantes();
            estudiante = EstudiantesBLL.buscar(2);
            Assert.AreNotEqual(estudiante, null);
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }
    }
}