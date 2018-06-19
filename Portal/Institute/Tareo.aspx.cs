using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntity;
using BusinessLogic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Configuration;

public partial class Institute_Tareo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LOTE();
            PERSONAL();
        }
    }

    protected void LOTE()
    {
        BL_TAREO obj = new BL_TAREO();
        DataTable dtResultado = new DataTable();
        dtResultado = obj.uspSEL_LOTE();

        if (dtResultado.Rows.Count > 0)
        {
            ddllote.DataSource = dtResultado;
            ddllote.DataTextField = "DESCRIPCION_HRA";
            ddllote.DataValueField = "IDE_LOTE";
            ddllote.DataBind();
            ddllote.Items.Insert(0, new ListItem("--- Seleccionar ---", ""));
        }
    }
    protected void PERSONAL()
    {
        BL_TAREO obj = new BL_TAREO();
        DataTable dtResultado = new DataTable();
        dtResultado = obj.uspSEL_PERSONAL();

        if (dtResultado.Rows.Count > 0)
        {
            ddlPersona.DataSource = dtResultado;
            ddlPersona.DataTextField = "NOMBRES";
            ddlPersona.DataValueField = "IDE_PERSONA";
            ddlPersona.DataBind();
            ddlPersona.Items.Insert(0, new ListItem("--- Seleccionar ---", ""));
        }
    }
    //protected void ddllote_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    datosLotes();
    //}
    //protected void datosLotes()
    //{
    //    BL_TAREO xobj = new BL_TAREO();
    //    DataTable dtResul = new DataTable();
    //    dtResul = xobj.uspSEL_LOTE_POR_ID(ddllote.SelectedValue);
    //    if (dtResul.Rows.Count > 0)
    //    {

    //        HdCodigo.Value = dtResul.Rows[0]["IDE_LOTE"].ToString();
    //        txtHrs.Text = dtResul.Rows[0]["TARIFA_X_HORA"].ToString();
    //    }
    //    else
    //    {
    //        HdCodigo.Value = string.Empty;
    //        txtHrs .Text = string.Empty;
    //    }
    //}

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        string cleanMessage = string.Empty;
        
         if (ddllote.SelectedIndex ==0)
        {
            cleanMessage = "Seleccionar Lote";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "doAlert('" + cleanMessage + "');", true);
        }
         else if (txtHrs.Text == string.Empty)
        {
            cleanMessage = "Ingresar horas de trabajo";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "doAlert('" + cleanMessage + "');", true);
        }
        else if (ddlPersona.SelectedIndex == 0)
        {
            cleanMessage = "Seleccionar Personal";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "doAlert('" + cleanMessage + "');", true);
        }
        else if (txtFecha.Text == string.Empty)
        {
            cleanMessage = "Ingresar fecha de trabajo";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "doAlert('" + cleanMessage + "');", true);
        }
        else
        {

            BE_TAREO oBESol = new BE_TAREO();
            oBESol.IDE_TAREO = Convert.ToInt32(string.IsNullOrEmpty(HdCodigo.Value) ? "0" : HdCodigo.Value);
            oBESol.FECHA =  txtFecha.Text     ;
            oBESol.IDE_LOTE = Convert.ToInt32(ddllote.SelectedValue )     ;
            oBESol.HRS = Convert.ToDecimal(txtHrs.Text);
            oBESol.IDE_PERSONA = Convert.ToInt32(ddlPersona.SelectedValue);

            int rpta;
            rpta = new BL_TAREO().uspINS_TAREO(oBESol);
            if (rpta > 0)
            {
                tareos();
                txtHrs.Text = string.Empty;
                cleanMessage = "Registro exitoso";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "doAlert('" + cleanMessage + "');", true);

            }
            else
            {
                cleanMessage = "No se puede cargar más archivo";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "doAlert('" + cleanMessage + "');", true);
            }
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        string cleanMessage = string.Empty;

        if (txtFecha.Text == string.Empty )
        {
            cleanMessage = "Ingresar fecha de trabajo";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "doAlert('" + cleanMessage + "');", true);
        }
        else 
        {
            tareos();
        }
    }
    protected void tareos()
    {


        BL_TAREO obj = new BL_TAREO();
        DataTable dtResultado = new DataTable();


        dtResultado = obj.uspSEL_TAREO_POR_FECHA(txtFecha.Text);
        if (dtResultado.Rows.Count > 0)
        {
            GridView1.DataSource = dtResultado;
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = dtResultado;
            GridView1.DataBind();
        }


    }
}