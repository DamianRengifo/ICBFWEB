using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICBFWEB2.modelo
{
    public class EstadosDAO
    {
        ORMDataContext bd = new ORMDataContext();
        public Object consultarTodos()
        {
            return from e in bd.estados where e.fk_idTiposEstados == 1 select e;
        }

        public Object consultarEstadosNiños()
        {
            return from e in bd.estados where e.fk_idTiposEstados == 2 select e;
        }

        public String consultarEstados(String nomEstado) {
            return (from j in bd.estados where j.nomEstado == nomEstado select j.idEstado).FirstOrDefault().ToString(); 
        }
    }
}