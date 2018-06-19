using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntity;
using DataAccess;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using UserCode;
using System.Web;
namespace BusinessLogic
{
   public  class BL_Seguridad
    {
        public BE_Usuario f_LogeoDatos_B(BE_Usuario oBE_Usuario, ref string pMesajeResp, string ShowAplicacion = "WEB")
        {
            BE_Usuario oBE_Usuario_New = new BE_Usuario();
            try
            {

                if (string.IsNullOrEmpty(oBE_Usuario.f_Password_E) || string.IsNullOrEmpty(oBE_Usuario.f_Usuario_E))
                {
                    pMesajeResp = "El Usuario o Contrase\x00f1a no debe ser vacio";
                    return oBE_Usuario_New;
                }
                oBE_Usuario_New = new DA_Seguridad().f_LogeoDatos_D(oBE_Usuario);
                if (!string.IsNullOrEmpty(oBE_Usuario_New.f_Usuario_E))
                {
                    if (ShowAplicacion.Equals(UserCode.UC_Constante.Web))
                    {
                        BL_Session.Usuario = oBE_Usuario_New.f_Usuario_E;
                    }
                    return oBE_Usuario_New;
                }
                pMesajeResp = "Error en Usuario o Contrase\x00f1a.";
                if (ShowAplicacion.Equals(UserCode.UC_Constante.Web))
                {
                    BL_Session.ClearSession();
                }
            }
            catch (Exception ex)
            {
                if (ShowAplicacion.Equals(UserCode.UC_Constante.Web))
                {
                    Logger.Write(ex);
                }
                pMesajeResp = "Error al realizar la consulta con la BD";
            }
            return oBE_Usuario_New;
        }

        public BE_Usuario f_LogeoUsuario_B(BE_Usuario oBE_Usuario, ref string pMesajeResp, string ShowAplicacion = "WEB")
        {
            BE_Usuario oBE_Usuario_New = new BE_Usuario();
            try
            {

                if (string.IsNullOrEmpty(oBE_Usuario.f_Password_E) || string.IsNullOrEmpty(oBE_Usuario.f_Usuario_E))
                {
                    pMesajeResp = "El Usuario o Contrase\x00f1a no debe ser vacio";
                    return oBE_Usuario_New;
                }
                oBE_Usuario_New = new DA_Seguridad().f_LogeoUsuario_D(oBE_Usuario);
                if (!string.IsNullOrEmpty(oBE_Usuario_New.f_Usuario_E))
                {
                    if (ShowAplicacion.Equals(UserCode.UC_Constante.Web))
                    {
                        BL_Session.Usuario = oBE_Usuario_New.f_Usuario_E;
                        BL_Session.IdSistema = oBE_Usuario_New.oBE_Sistema.f_IdSistema_E;
                        //BL_Session.NombreTerminal = oBE_Usuario_New.oBE_Terminal.f_NOMBRE_TERMINAL_E;
                        BL_Session.Perfil = oBE_Usuario_New.oBE_Perfil.f_Perfil_E;
                        BL_Session.PerfilNombre = oBE_Usuario_New.oBE_Perfil.f_Vnomperfil_E;
                        BL_Session.UsuarioNombre = oBE_Usuario_New.f_NombreUsuario_E;
                        BL_Session.UsuarioNombre_Corto = oBE_Usuario_New.f_NombreUsuarioCorto_E;
                        BL_Session.PerfilNombreName = oBE_Usuario_New.oBE_Perfil.f_PerfilName_E;

                        //BL_Session.IDE_EMPRESA = oBE_Usuario_New.oBE_Empresa.I_EMPRESA_E;
                    }
                    return oBE_Usuario_New;
                }
                pMesajeResp = "Error en Usuario o Contrase\x00f1a.";
                if (ShowAplicacion.Equals(UserCode.UC_Constante.Web))
                {
                    BL_Session.ClearSession();
                }
            }
            catch (Exception ex)
            {
                if (ShowAplicacion.Equals(UserCode.UC_Constante.Web))
                {
                    Logger.Write(ex);
                }
                pMesajeResp = "Error al realizar la consulta con la BD";
            }
            return oBE_Usuario_New;
        }

        public DataTable ListarMenu(int idPerfil)
        {
            return new DA_Seguridad().ListarMenu_DA(idPerfil);
        }

        

        public DataTable ListarSistemas(string  usuario)
        {
            return new DA_Seguridad().ListarSistemas_d(usuario);
        }
     
    }
}
