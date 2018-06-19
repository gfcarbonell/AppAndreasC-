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

public partial class Login_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) BL_Session.ClearSession();
    }
    private BE_TBUSUARIO f_CapturarDatos()
    {

        BE_TBUSUARIO Usuario = new BE_TBUSUARIO();
        Usuario.IDE_USUARIO = Email.Text.Trim();
        Usuario.DES_PASSWORD = Password.Text.Trim();
        return Usuario;
    }

    //protected void Seleccionar(object sender, ImageClickEventArgs e)
    //{
    //    string pMesajeResp = string.Empty;
    //    ImageButton btnAdd = ((ImageButton)sender);
    //    int item = Convert.ToInt32(btnAdd.CommandArgument);



    //    BL_Session.Usuario = lstRol.DataKeys[item -1].Values["IDE_USUARIO"].ToString();
    //    BL_Session.IdSistema = (int)lstRol.DataKeys[item - 1].Values["IdSistema"];
    //    BL_Session.Perfil = (int)lstRol.DataKeys[item - 1].Values["IdPerfil"];
    //    BL_Session.PerfilNombre = lstRol.DataKeys[item - 1].Values["Descripcion"].ToString();
    //    BL_Session.UsuarioNombre = lstRol.DataKeys[item - 1].Values["DES_NOMBRE_USUARIO"].ToString();


    //    Response.Redirect(lstRol.DataKeys[item - 1].Values["UrlDefault"].ToString());


    //}

    protected void LogIn(object sender, EventArgs e)
    {
        string pMesajeResp = string.Empty;
        DataTable dtResultado = new DataTable();
        BE_Usuario oBE_Usuario = new BE_Usuario(Email.Text.Trim(), Password.Text.Trim());
        BE_Usuario oBE_Usuario_R = new BE_Usuario();
        oBE_Usuario_R = new BL_Seguridad().f_LogeoDatos_B(oBE_Usuario, ref pMesajeResp);
        if (string.IsNullOrEmpty(oBE_Usuario_R.f_Usuario_E))
        {
            UC_MessageBox.Show(Page, this.GetType(), pMesajeResp);
        }

        else
        {
            BL_Seguridad objSeg = new BL_Seguridad();
            dtResultado = objSeg.ListarSistemas(Email.Text.Trim());
            if (dtResultado.Rows.Count == 1)
            {

                BE_Usuario oBE_user = new BE_Usuario();
                BE_Usuario oBE_Acceso = new BE_Usuario();
                oBE_user.f_Usuario_E = Email.Text.Trim();
                oBE_user.f_Password_E = Password.Text.Trim();
                oBE_user.f_IdSistema_E = dtResultado.Rows[0]["IdSistema"].ToString();
                oBE_Acceso = new BL_Seguridad().f_LogeoUsuario_B(oBE_user, ref pMesajeResp);

                if (string.IsNullOrEmpty(oBE_Acceso.f_Usuario_E))
                {

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "doAlert('" + pMesajeResp + "');", true);
                }

                else
                {
                    string url = oBE_Acceso.f_UrlDefault_E;
                    Response.Redirect(url);

                }
            }
            else
            {
                Response.Redirect("~/Login/Main.aspx");
                //lstRol.DataSource = dtResultado;
                //lstRol.DataBind();
                //ModalRegistro.Show();



            }
            //string url = oBE_Usuario_R.f_UrlDefault_E;
            //Response.Redirect(url);

        }

    }
}