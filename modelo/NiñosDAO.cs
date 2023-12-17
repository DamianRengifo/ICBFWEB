using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICBFWEB2.modelo
{
    public class NiñosDAO
    {
        ORMDataContext bd = new ORMDataContext(@"Data Source=DESKTOP-DVTF0L7\SQLEXPRESS;Initial Catalog=ICBF;Integrated Security=True");

        public Object consultarNiños()
        {
            return (from j in bd.niños select j).ToList();
        }

        public Object consultarDatos()
        {
            return (from j in bd.niños
                    select new
                    {
                        idNiño = j.idNiño,
                        nombre = j.nombre,
                        numIdentificacion = j.numIdentificacion,
                        telefono = j.telefonoNiño,
                        direccion = j.direccionNiño,
                        Ciudad = j.ciudad_nacimiento.nomCiudad,
                        Eps = j.eps.nomEps,
                        TipoSangre = j.tipo_sangre.nomTipoSangre,
                        Acudiente = j.usuarios.nombre,
                        Jardin = j.registro_jardin.nomJardin,
                        FechaNacimiento = j.fechaNac
                    }).ToList();
        }

        public void registrarNiños(niños niño)
        {
            bd.niños.InsertOnSubmit(niño);
            bd.SubmitChanges();
        }

        public void editarNiño(niños niño)
        {
            niños niñoEdit = (from j in bd.niños where j.idNiño == niño.idNiño select j).FirstOrDefault();
            niñoEdit.nombre = niño.nombre;
            niñoEdit.numIdentificacion = niño.numIdentificacion;
            niñoEdit.telefonoNiño = niño.telefonoNiño;
            niñoEdit.direccionNiño = niño.direccionNiño;
            niñoEdit.fk_idCiudad = niño.fk_idCiudad;
            niñoEdit.fk_idEps = niño.fk_idEps;
            niñoEdit.fk_idTipSangre = niño.fk_idTipSangre;
            niñoEdit.fk_idAcudiente = niño.fk_idAcudiente;
            niñoEdit.fk_idJardin = niño.fk_idJardin;
            niñoEdit.fechaNac = niño.fechaNac;
            bd.SubmitChanges();
        }

        public void eliminarNiño(int idNiño)
        {
            niños niñoEliminar = (from j in bd.niños where j.idNiño == idNiño select j).FirstOrDefault();
            bd.niños.DeleteOnSubmit(niñoEliminar);
            bd.SubmitChanges();
        }

        public String consultarId(String nomNiño) {
            String idNiño = (from j in bd.niños where j.nombre == nomNiño select j.idNiño).FirstOrDefault().ToString();
            return idNiño;
        }

        public Object reporteNiñoJardin(int idJardin) {
            return (from j in bd.niños where j.fk_idJardin == idJardin orderby j.idNiño descending 
                    select new {

                        idNiño = j.idNiño,
                        nombre = j.nombre,
                        numIdentificacion = j.numIdentificacion,
                        telefono = j.telefonoNiño,
                        direccion = j.direccionNiño,
                        Ciudad = j.ciudad_nacimiento.nomCiudad,
                        Eps = j.eps.nomEps,
                        TipoSangre = j.tipo_sangre.nomTipoSangre,
                        Acudiente = j.usuarios.nombre,
                        Jardin = j.registro_jardin.nomJardin,
                        FechaNacimiento = j.fechaNac
                    }).ToList();
        }

        public Boolean validarExistenciaNiño(niños niñoView) {
            var niño = (from j in bd.niños where niñoView.Equals(j) select j);

            if (niño.ToList().Count>0) {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Boolean validarNombreNiño(String nombre, String identificacion) {
            var niño = (from j in bd.niños where j.nombre == nombre || j.numIdentificacion == identificacion select j);

            if (niño.ToList().Count > 0) {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Boolean validarAños(DateTime fechaNacimiento) {
            DateTime fechaActual = DateTime.Today;
            int edad = fechaActual.Year - fechaNacimiento.Year;
            if (fechaNacimiento.Date > fechaActual.AddYears(-edad))
            {
                edad--; 
            }


            if (edad > 6) {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}