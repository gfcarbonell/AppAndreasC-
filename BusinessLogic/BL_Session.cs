using System;

using System.Data;
using System.Web;
using System.Web.Security;
using System.Configuration;
using System.Web.SessionState;
using System.Collections.Generic;
using BusinessEntity;

namespace BusinessLogic
{
    public  class BL_Session
    {
        static public void ClearSession()
        {
            HttpContext.Current.Session.RemoveAll();
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            FormsAuthentication.SignOut();
        }
        static public string Usuario
        {
            get
            {
                return HttpContext.Current.Session["IDE_USUARIO"] != null ? HttpContext.Current.Session["IDE_USUARIO"].ToString() : string.Empty;
            }
            set
            {
                if (value == null) return;
                HttpContext.Current.Session["IDE_USUARIO"] = value.Trim();
            }
        }

        static public string NombreCargo
        {
            get
            {
                return HttpContext.Current.Session["DES_USUARIO"] != null ? HttpContext.Current.Session["DES_USUARIO"].ToString() : string.Empty;
            }
            set
            {
                if (value == null) return;
                HttpContext.Current.Session["DES_USUARIO"] = value.Trim();
            }
        }
        static public int Perfil
        {
            get
            {
                return int.Parse(HttpContext.Current.Session["IdPerfil"] == null ? "0" : (HttpContext.Current.Session["IdPerfil"].ToString()));
            }
            set
            {
                HttpContext.Current.Session["IdPerfil"] = value;
            }
        }
        static public string PerfilNombre
        {
            get
            {
                return HttpContext.Current.Session["Descripcion"] != null ? HttpContext.Current.Session["Descripcion"].ToString() : string.Empty;
            }
            set
            {
                if (value == null) return;
                HttpContext.Current.Session["Descripcion"] = value.Trim();
            }
        }
        static public string PerfilNombreName
        {
            get
            {
                return HttpContext.Current.Session["PERFIL_NAME"] != null ? HttpContext.Current.Session["PERFIL_NAME"].ToString() : string.Empty;
            }
            set
            {
                if (value == null) return;
                HttpContext.Current.Session["PERFIL_NAME"] = value.Trim();
            }
        }
        static public string UsuarioNombre
        {
            get
            {
                return HttpContext.Current.Session["NOMBRE_USUARIO"] != null ? HttpContext.Current.Session["NOMBRE_USUARIO"].ToString() : string.Empty;
            }
            set
            {
                if (value == null) return;
                HttpContext.Current.Session["NOMBRE_USUARIO"] = value.Trim();
            }
        }
        static public string UsuarioNombre_Corto
        {
            get
            {
                return HttpContext.Current.Session["NOMBRE_CORTO"] != null ? HttpContext.Current.Session["NOMBRE_CORTO"].ToString() : string.Empty;
            }
            set
            {
                if (value == null) return;
                HttpContext.Current.Session["NOMBRE_CORTO"] = value.Trim();
            }
        }
        static public string Controles
        {
            get
            {
                return HttpContext.Current.Session["CONTROL"] != null ? HttpContext.Current.Session["CONTROL"].ToString() : string.Empty;
            }
            set
            {
                if (value == null) return;
                HttpContext.Current.Session["CONTROL"] = value.Trim();
            }
        }
        static public int IdPersonal
        {
            get
            {
                return int.Parse(HttpContext.Current.Session["ID_PERSONAL"] == null ? "0" : (HttpContext.Current.Session["ID_PERSONAL"].ToString()));
            }
            set
            {
                HttpContext.Current.Session["ID_PERSONAL"] = value;
            }
        }
        static public int IdSistema
        {
            get
            {
                return int.Parse(HttpContext.Current.Session["IdSistema"] == null ? "1" : (HttpContext.Current.Session["IdSistema"].ToString()));
            }
            set
            {
                HttpContext.Current.Session["IdSistema"] = value;
            }
        }
    }
}
