using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace BusinessEntity
{
    [Serializable]
    public  class BE_TBSISTEMA
    {
        public BE_TBSISTEMA()
        {

        }
        [Description("IdSistema")]
        public Int32 f_IdSistema_E { get; set; }
        [Description("Descripcion")]
        public String f_DescripcionSistema_E { get; set; }
        [Description("Estado")]
        public Boolean f_Bestado_E { get; set; }
        [Description("url")]
        public String f_url_E { get; set; }
    }
}
