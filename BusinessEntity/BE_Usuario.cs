using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace BusinessEntity
{
    [Serializable]
    public class BE_Usuario
    {
        public BE_Usuario()
        {
        }

        public BE_Usuario(string Usuario, string Password)
        {
            f_Usuario_E = Usuario;
            f_Password_E = Password;
        }
        #region propiedades
        [Description("IDE_USUARIO")]
        public String f_Usuario_E { get; set; }

        [Description("DES_NOMBRE_USUARIO")]
        public String f_NombreUsuario_E { get; set; }

        [Description("NOMBRE_CORTO")]
        public String f_NombreUsuarioCorto_E { get; set; }

        [Description("DES_PASSWORD")]
        public String f_Password_E { get; set; }


        [Description("FLG_ESTADO")]
        public Boolean f_Bestado_E { get; set; }

        [Description("IdSistema")]
        public String f_IdSistema_E { get; set; }

        #endregion

        //public BE_Terminales oBE_Terminal { get; set; }
        public BE_Perfil oBE_Perfil { get; set; }
        public BE_TBSISTEMA oBE_Sistema { get; set; }

        [Description("UrlDefault")]
        public String f_UrlDefault_E { get; set; }
    }
}
