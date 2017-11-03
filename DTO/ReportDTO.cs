using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ReportDTO
    {
        private string holot;
        private string ten;
        private DateTime ngaysinh;
        private string sdt;
        private string diachi;
        private string gioitinh;
        private string tinhtranghoc;
        private float ketquakiemtra;
        public ReportDTO(string holot, string ten, DateTime ngaysinh, string sdt, string diachi, string gioitinh, string tinhtranghoc, float ketquakiemtra)
        {
            this.holot = holot;
            this.ten = ten;
            this.ngaysinh = ngaysinh;
            this.sdt = sdt;
            this.diachi = diachi;
            this.gioitinh = gioitinh;
            this.tinhtranghoc = tinhtranghoc;
            this.ketquakiemtra = ketquakiemtra;
        }
        public ReportDTO(DataRow row)
        {
            this.holot = row["holot"].ToString();
            this.ten = row["ten"].ToString();
            this.ngaysinh = (DateTime)row["ngaysinh"];
            this.sdt = row["sdt"].ToString();
            this.diachi = row["diachi"].ToString();
            this.gioitinh = row["gioitinh"].ToString();
            this.tinhtranghoc = row["tinhtranghoc"].ToString();
            this.ketquakiemtra = (float)Convert.ToDouble(row["ketquakiemtra"].ToString());
        }
    }
}
