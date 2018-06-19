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
   public class DA_TAREO
    {
        Util oUtilitarios = new Util();
        public DataTable uspSEL_LOTE()
        {
            return oUtilitarios.EjecutaDatatable("uspSEL_LOTE");
        }
        public DataTable uspSEL_LOTE_POR_ID(string IDE_LOTE)
        {
            return oUtilitarios.EjecutaDatatable("uspSEL_LOTE_POR_ID", IDE_LOTE);
        }
        public int uspINS_TAREO(BE_TAREO oBESOl)
        {
            object[] Parametros = new[] {
                            (object)UC_FormWeb.mSQLFieldOrNull(oBESOl.IDE_TAREO  ,tgSQLFieldType.TEXT),
                            (object)UC_FormWeb.mSQLFieldOrNull(oBESOl.FECHA  ,tgSQLFieldType.TEXT),
                            (object)UC_FormWeb.mSQLFieldOrNull(oBESOl.IDE_LOTE  ,tgSQLFieldType.TEXT),
                            (object)UC_FormWeb.mSQLFieldOrNull(oBESOl.HRS  ,tgSQLFieldType.TEXT),
                            (object)UC_FormWeb.mSQLFieldOrNull(oBESOl.IDE_PERSONA  ,tgSQLFieldType.TEXT),

            };


            return Convert.ToInt32(new Util().ExecuteScalar("uspINS_TAREO", Parametros));
        }
        public DataTable uspSEL_PERSONAL_POR_ID(string IDE_PERSONA)
        {
            return oUtilitarios.EjecutaDatatable("uspSEL_PERSONAL_POR_ID", IDE_PERSONA);
        }
        public DataTable uspSEL_PERSONAL()
        {
            return oUtilitarios.EjecutaDatatable("uspSEL_PERSONAL");
        }
        public DataTable uspSEL_TAREO_POR_FECHA(string FECHA)
        {
            return oUtilitarios.EjecutaDatatable("uspSEL_TAREO_POR_FECHA", FECHA);
        }

    }
}
