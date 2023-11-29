using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICBFWEB2.modelo
{
    public class RegistroAsistenciaDAO
    {
        ORMDataContext bd = new ORMDataContext();
        public DateTime fechaActualSoloFecha = DateTime.Today;
        public Object consultarDatos()
        {

            modelo.registro_asistencia registro_Asistencia = new modelo.registro_asistencia();
            return (from j in bd.registro_asistencia
                    select new
                    {
                        Codigo = j.idRegAsistencia,
                        fecha = j.fechaAsistencia,
                        Niño = j.niños.nombre,
                        Estado = j.estados.nomEstado,
                        madreComunitaria = j.usuarios.nombre,
                    }).ToList();

        }
        public void registrar(registro_asistencia registroAsistencia)
        {
            registroAsistencia.fk_idMadCom = ClsVariablesGlobales.idUser;
            bd.registro_asistencia.InsertOnSubmit(registroAsistencia);
            bd.SubmitChanges();
        }

        public void actualizar(registro_asistencia registroAsistencia)
        {
            registro_asistencia registro = (from j in bd.registro_asistencia where j.idRegAsistencia == registroAsistencia.idRegAsistencia select j).FirstOrDefault();
            registro.fechaAsistencia = registroAsistencia.fechaAsistencia;
            registro.fk_idNiño = registroAsistencia.fk_idNiño;
            registro.fk_idEstado = registroAsistencia.fk_idEstado;
            bd.SubmitChanges();
        }
    }
}