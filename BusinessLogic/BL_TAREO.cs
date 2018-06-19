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
   public class BL_TAREO
    {
        public DataTable uspSEL_LOTE()
        {
            return new DA_TAREO().uspSEL_LOTE();
        }
        public DataTable uspSEL_LOTE_POR_ID(string IDE_LOTE)
        {
            return new DA_TAREO().uspSEL_LOTE_POR_ID(IDE_LOTE);
        }
        public int uspINS_TAREO(BE_TAREO oBESOl)
        {
            try
            {
                return new DA_TAREO().uspINS_TAREO(oBESOl);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public DataTable uspSEL_PERSONAL_POR_ID(string IDE_PERSONA)
        {
            return new DA_TAREO().uspSEL_PERSONAL_POR_ID(IDE_PERSONA);
        }
        public DataTable uspSEL_PERSONAL()
        {
            return new DA_TAREO().uspSEL_PERSONAL();
        }
        public DataTable uspSEL_TAREO_POR_FECHA(string FECHA)
        {
            return new DA_TAREO().uspSEL_TAREO_POR_FECHA(FECHA);
        }

    }
}
