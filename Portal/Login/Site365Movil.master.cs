using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntity;
using BusinessLogic;

public partial class Login_Site365Movil : System.Web.UI.MasterPage
{
    public int intPerfil;
    public int intSistema;
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CO");

        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = ".";
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ",";
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ",";
        if (Session["IDE_USUARIO"] == null)
        {
            Response.Redirect("~/default.aspx");
        }
        if (!Page.IsPostBack)
        {

            try
            {
                //this.lblNombreUsuario.Text = BL_Session.UsuarioNombre_Corto;
                intPerfil = BL_Session.Perfil;
                intSistema = BL_Session.IdSistema;

                DataTable dtMenu = new DataTable();
                BL_Seguridad ObjSeguridad = new BL_Seguridad();

                dtMenu = ObjSeguridad.ListarMenu(intPerfil);
                foreach (DataRow drMenuItem in dtMenu.Rows)
                {
                    //esta condicion indica q son elementos padre.
                    //If drMenuItem("IdPagina").Equals(drMenuItem("IdPadre")) Then
                    if (drMenuItem["IdPadre"].Equals(0))
                    {
                        MenuItem mnuMenuItem = new MenuItem();
                        mnuMenuItem.Value = drMenuItem["IdOpcion"].ToString();
                        mnuMenuItem.Text = drMenuItem["NombreOpcion"].ToString();
                        mnuMenuItem.ImageUrl = drMenuItem["Icono"].ToString();
                        mnuMenuItem.NavigateUrl = drMenuItem["Url"].ToString();
                        //agregamos el Item al menu
                        Menu1.Items.Add(mnuMenuItem);
                        //hacemos un llamado al metodo recursivo encargado de generar el arbol del menu.
                        AddMenuItem(mnuMenuItem, dtMenu);
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    private void AddMenuItem(MenuItem mnuMenuItem, DataTable dtMenuItems)
    {

        foreach (DataRow drMenuItem in dtMenuItems.Rows)
        {
            if (drMenuItem["IdPadre"].ToString().Equals(mnuMenuItem.Value) && !drMenuItem["IdOpcion"].Equals(drMenuItem["IdPadre"]))
            {
                MenuItem mnuNewMenuItem = new MenuItem();

                mnuNewMenuItem.Value = drMenuItem["IdOpcion"].ToString();
                mnuNewMenuItem.Text = drMenuItem["NombreOpcion"].ToString();
                mnuNewMenuItem.ImageUrl = drMenuItem["Icono"].ToString();
                mnuNewMenuItem.NavigateUrl = drMenuItem["Url"].ToString();
                //Agregamos el Nuevo MenuItem al MenuItem que viene de un nivel superior.
                mnuMenuItem.ChildItems.Add(mnuNewMenuItem);
                //llamada recursiva para ver si el nuevo menu item aun tiene elementos hijos.
                AddMenuItem(mnuNewMenuItem, dtMenuItems);
            }
        }
    }

}
