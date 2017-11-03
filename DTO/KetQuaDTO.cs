using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KetQuaDTO
    {
        private int idkq;
        private string tinhtranghocthu;
        private float ketquakt;
        private int idhv;

        public int Idkq { get => idkq; set => idkq = value; }
        public string Tinhtranghocthu { get => tinhtranghocthu; set => tinhtranghocthu = value; }
        public float Ketquakt { get => ketquakt; set => ketquakt = value; }
        public int Idhv { get => idhv; set => idhv = value; }

        public KetQuaDTO(int idkq , string tinhtranghocthu , float ketquakt , int idhv)
        {
            this.idkq = idkq;
            this.tinhtranghocthu = tinhtranghocthu;
            this.ketquakt = ketquakt;
            this.idhv = idhv;
        }
        public KetQuaDTO(DataRow row)
        {
            this.idkq = (int)row["idKQ"];
            this.tinhtranghocthu = row["tinhtranghocthu"].ToString();
            this.ketquakt = (float)Convert.ToDouble(row["ketquakiemtra"].ToString());
            this.idhv = (int)row["idHV"];
        }
    }
}
