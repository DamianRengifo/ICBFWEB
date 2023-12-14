using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICBFWEB2.modelo
{
    public class NiñosDAO
    {
        ORMDataContext bd = new ORMDataContext(@"Data Source=CHECHOPC\SQLEXPRESS;Initial Catalog=ICBF;Integrated Security=True");

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
                        telefonoNiño = j.telefonoNiño,
                        direccionNiño = j.direccionNiño,
                        fk_idCiudad = j.ciudad_nacimiento.nomCiudad,
                        fk_idEps = j.eps.nomEps,
                        fk_idTipSangre = j.tipo_sangre.nomTipoSangre,
                        fk_idAcudiente = j.usuarios.nombre,
                        fk_idJardin = j.registro_jardin.nomJardin,
                        fechaNac = j.fechaNac
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
    }
}