using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.UI;
using Portal;
using BusinessEntity;
using BusinessLogic;
using UserCode;
using System.Data;
using System.Web.UI.WebControls;
public partial class Login_Main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dtResultado = new DataTable();
            BL_Seguridad objSeg = new BL_Seguridad();
            dtResultado = objSeg.ListarSistemas(BL_Session.Usuario);

            //this.GridView1.Columns[0]. = true;
            GridView1.DataSource = dtResultado;
            GridView1.DataBind();
        }
    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Request.Browser.IsMobileDevice)
            MasterPageFile = "~/Login/MasterPageMovil.master";
    }
    protected void Seleccionar(object sender, ImageClickEventArgs e)
    {
        string pMesajeResp = string.Empty;
        ImageButton btnAdd = ((ImageButton)sender);
        int item = Convert.ToInt32(btnAdd.CommandArgument);



        BL_Session.Usuario = GridView1.DataKeys[item - 1].Values["IDE_USUARIO"].ToString();
        BL_Session.IdSistema = (int)GridView1.DataKeys[item - 1].Values["IdSistema"];
        BL_Session.Perfil = (int)GridView1.DataKeys[item - 1].Values["IdPerfil"];
        BL_Session.PerfilNombre = GridView1.DataKeys[item - 1].Values["Descripcion"].ToString();
        BL_Session.UsuarioNombre = GridView1.DataKeys[item - 1].Values["DES_NOMBRE_USUARIO"].ToString();
        BL_Session.UsuarioNombre_Corto = GridView1.DataKeys[item - 1].Values["NOMBRE_CORTO"].ToString();
        BL_Session.PerfilNombreName = GridView1.DataKeys[item - 1].Values["PERFIL_NAME"].ToString();
        Response.Redirect(GridView1.DataKeys[item - 1].Values["UrlDefault"].ToString());


    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //e.Row.Cells[0].CssClass = "GridviewScrollHeader";
        //e.Row.Cells[1].CssClass = "GridviewScrollHeader";
    }
}