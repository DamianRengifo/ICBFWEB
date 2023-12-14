﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICBFWEB2.modelo
{
    public class EstadosDAO
    {
        ORMDataContext bd = new ORMDataContext(@"Data Source=CHECHOPC\SQLEXPRESS;Initial Catalog=ICBF;Integrated Security=True");
        public Object consultarTodos()
        {
            return from e in bd.estados where e.fk_idTiposEstados == 1 select e;
        }

        public Object consultarEstadosNiños()
        {
            return from e in bd.estados where e.fk_idTiposEstados == 2 select e;
        }
    }
}