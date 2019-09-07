using RegistroEstudiantes.DAL;
using RegistroEstudiantes.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace RegistroEstudiantes.BLL
{
    public class EstudiantesBLL
    {
        

        ///<Summary>
        ///Permite guardar una entidad en la base de datos
        ///</Summary>

        public static bool guardar(Estudiantes estudiante)
        {
            bool paso = false; //Si termina como false algo fallo, sino todo paso bien
            Contexto db = new Contexto();
            try
            {
                if (db.Estudiante.Add(estudiante) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose(); //Para cerrar la conexion, siempre hay que hacerlo
            }
            return paso;
        }

        ///<summary>
        ///Permite modificar una persona en la base de datos
        ///</summary>
        public static bool modificar(Estudiantes estudiante)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(estudiante).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        ///<summary>
        ///Perminte eliminar entidades de una base de datos
        /// </summary>
        public static bool eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.Estudiante.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;

                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
         }

        public static Estudiantes buscar(int id)
        {
            Contexto db = new Contexto();
            Estudiantes estudiante = new Estudiantes();
            try
            {
                estudiante = db.Estudiante.Find(id);

            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return estudiante;
        }

        ///<summary>
        ///permite extraer una lista de personas de la base de datos
        /// </summary>
        public static List<Estudiantes> GetList(Expression<Func<Estudiantes, bool>> estudiante)
        {
            List<Estudiantes> Lista = new List<Estudiantes>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.Estudiante.Where(estudiante).ToList();
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;
        }


    }
}
