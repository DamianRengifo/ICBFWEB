using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICBFWEB2.modelo
{
    public class RegistroAvanceAcademico
    {
        ORMDataContext bd = new ORMDataContext(@"Data Source=CHECHOPC\SQLEXPRESS;Initial Catalog=ICBF;Integrated Security=True");

        public Object consultarDatos()
        {
            return (from j in bd.registro_avance_academico
                    select new
                    {
                        Codigo = j.idRegAvAcademico,
                        Niño = j.niños.nombre,
                        fechaEntregaNotas = j.fecEntregaNotas,
                        año = j.añoEscolar,
                        descripcion = j.descripcion,
                        Notas = j.notas.nomNotas,
                        Nivel = j.nivel.nomNivel,
                    }).ToList();
        }

        public void registrar(registro_avance_academico registroAvanceAcademico)
        {
            bd.registro_avance_academico.InsertOnSubmit(registroAvanceAcademico);
            bd.SubmitChanges();
        }

        public void editarAvance(registro_avance_academico registroAvanceAcademico)
        {
            registro_avance_academico regEdit = (from j in bd.registro_avance_academico
                                                 where j.idRegAvAcademico == registroAvanceAcademico.idRegAvAcademico
                                                 select j).FirstOrDefault();

            regEdit.fk_idNiño = registroAvanceAcademico.fk_idNiño;
            regEdit.fecEntregaNotas = registroAvanceAcademico.fecEntregaNotas;
            regEdit.añoEscolar = registroAvanceAcademico.añoEscolar;
            regEdit.descripcion = registroAvanceAcademico.descripcion;
            regEdit.fk_idNotas = registroAvanceAcademico.fk_idNotas;
            regEdit.fk_idNivel = registroAvanceAcademico.fk_idNivel;

            bd.SubmitChanges();
        }
    }
}