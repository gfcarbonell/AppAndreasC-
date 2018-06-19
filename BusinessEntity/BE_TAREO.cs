using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
   public class BE_TAREO
    {
        private int m_IDE_TAREO;
        public int IDE_TAREO
        {
            get { return m_IDE_TAREO; }
            set { m_IDE_TAREO = value; }
        }
        private string m_FECHA;
        public string FECHA
        {
            get { return m_FECHA; }
            set { m_FECHA = value; }
        }
        private int m_IDE_LOTE;
        public int IDE_LOTE
        {
            get { return m_IDE_LOTE; }
            set { m_IDE_LOTE = value; }
        }
        private Decimal m_HRS;
        public Decimal HRS
        {
            get { return m_HRS; }
            set { m_HRS = value; }
        }
        private int m_IDE_PERSONA;
        public int IDE_PERSONA
        {
            get { return m_IDE_PERSONA; }
            set { m_IDE_PERSONA = value; }
        }

    }
}
