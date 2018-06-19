using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;
using BusinessEntity;
using UserCode;
using System.Data.SqlClient;
using DataAccess.Conexion;


namespace DataAccess
{
   public  class DA_Seguridad
    {
            
        Util  oUtilitarios = new Util();
        public BE_Usuario f_LogeoDatos_D(BE_Usuario oBE_Usuario)
        {
            try
            {
                BE_Usuario oBE_Usuario_R = new BE_Usuario();
                using (IDataReader dr = oUtilitarios.EjecutaDataReader("dbo.USP_USUARIO_ACCESO", oBE_Usuario.f_Usuario_E, oBE_Usuario.f_Password_E))
                {
                    BE_Perfil oBE_Perfil_R = new BE_Perfil();
                    while (dr.Read())
                    {
                        new UC_Mapeador().ReaderToObject(dr, oBE_Usuario_R);
                    }
                    dr.Close();
                }
                return oBE_Usuario_R;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public BE_Usuario f_LogeoUsuario_D(BE_Usuario oBE_Usuario)
        {
            try
            {
                BE_Usuario oBE_Usuario_R = new BE_Usuario();
                using (IDataReader dr = oUtilitarios.EjecutaDataReader("dbo.USP_USUARIO_LOGIN", oBE_Usuario.f_Usuario_E, oBE_Usuario.f_Password_E, oBE_Usuario.f_IdSistema_E))
                {
                    BE_Perfil oBE_Perfil_R = new BE_Perfil();
                    BE_TBSISTEMA  oBE_sistema_R = new BE_TBSISTEMA();
                    //BE_EMPRESA oBE_Empresa_R = new BE_EMPRESA();
                    while (dr.Read())
                    {
                        new UC_Mapeador().ReaderToObject(dr, oBE_Usuario_R);
                        new UC_Mapeador().ReaderToObject(dr, oBE_sistema_R);
                        new UC_Mapeador().ReaderToObject(dr, oBE_Perfil_R);

                    }
                    dr.Close();

                    oBE_Usuario_R.oBE_Sistema = oBE_sistema_R;
                    oBE_Usuario_R.oBE_Perfil = oBE_Perfil_R;
          
                    GC.SuppressFinalize(oBE_Perfil_R);
                    GC.SuppressFinalize(oBE_sistema_R);
                }

                return oBE_Usuario_R;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListarMenu_DA(int idPerfil)
        {
            return oUtilitarios.EjecutaDatatable("dbo.usp_SeleccionarMenuPrincipal", idPerfil);
        }

        

        public DataTable ListarSistemas_d(string usuario)
        {
            return oUtilitarios.EjecutaDatatable("dbo.USP_USUARIO_SISTEMAS", usuario);
        }
      
    }
}
