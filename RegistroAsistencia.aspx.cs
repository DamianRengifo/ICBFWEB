using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICBFWEB2
{
    public partial class RegistroAsistencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (Session["idUsuario"] != null && Session["fk_idRol"].Equals(2))
            {
                if (!IsPostBack)
                {
                    lblUser.Text = Session["nombre"].ToString();
                    lblMensaje.Text = "";

                    modelo.NiñosDAO niñosDAO = new modelo.NiñosDAO();
                    ddlNino.DataSource = niñosDAO.consultarDatos();
                    ddlNino.DataValueField = "idNiño";
                    ddlNino.DataTextField = "nombre";
                    ddlNino.DataBind();

                    modelo.EstadosDAO estDAO = new modelo.EstadosDAO();
                    ddlEstado.DataSource = estDAO.consultarEstadosNiños();
                    ddlEstado.DataValueField = "idEstado";
                    ddlEstado.DataTextField = "nomEstado";
                    ddlEstado.DataBind();
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnRegistrarAsis_Click(object sender, EventArgs e)
        {
            int hora = DateTime.Now.Hour;
            if (hora >= 8 && hora < 10)
            {
                modelo.RegistroAsistenciaDAO asistenciaDAO = new modelo.RegistroAsistenciaDAO();
                modelo.registro_asistencia reg_asis = new modelo.registro_asistencia();

                reg_asis.fechaAsistencia = DateTime.Now.Date;
                reg_asis.fk_idNiño = int.Parse(ddlNino.SelectedValue);
                reg_asis.fk_idEstado = int.Parse(ddlEstado.SelectedValue);
                reg_asis.fk_idMadCom = int.Parse(Session["idUsuario"].ToString());

                asistenciaDAO.registrar(reg_asis);
                lblMensaje.Text = "Registro de asistencia exitoso";
            } else
            {
                lblMensaje.Text = "Horario incorrecto para registrar asistencia";
            }
            
        }

        protected void btnIrAReportes_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportesAsistencia.aspx");
        }
    }
}