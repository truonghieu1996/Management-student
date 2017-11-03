using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HocVienDTO
    {
        private int idhv;
        private string holot;
        private string ten;
        private DateTime ngaysinh;
        private string sdt;
        private string diachi;
        private string gioitinh;
        private string ghichu;
        private DateTime ngaynhap;
        private DateTime ngayhocthu;

        public int idHV { get => idhv; set => idhv = value; }
        public string Holot { get => holot; set => holot = value; }
        public string Ten { get => ten; set => ten = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
        public string Ghichu { get => ghichu; set => ghichu = value; }
        public DateTime Ngaynhap { get => ngaynhap; set => ngaynhap = value; }
        public DateTime Ngayhocthu { get => ngayhocthu; set => ngayhocthu = value; }

        public HocVienDTO(int idhv, string holot , string ten , DateTime ngaysinh, string sdt, string diachi, string gioitinh, string ghichu, DateTime ngaynhap, DateTime ngayhocthu)
        {
            this.idhv = idhv;
            this.holot = holot;
            this.ten = ten;
            this.ngaysinh = ngaysinh;
            this.sdt = sdt;
            this.diachi = diachi;
            this.gioitinh = gioitinh;
            this.ghichu = ghichu;
            this.ngaynhap = ngaynhap;
            this.ngayhocthu = ngayhocthu;
        }
        public HocVienDTO(DataRow row)
        {
            this.idhv = (int)row["idHV"];
            this.holot = row["holot"].ToString();
            this.ten = row["ten"].ToString();
            this.ngaysinh = (DateTime)row["ngaysinh"];
            this.sdt = row["sdt"].ToString();
            this.diachi = row["diachi"].ToString();
            this.gioitinh = row["gioitinh"].ToString();
            this.ghichu = row["ghichu"].ToString();
            this.ngaynhap = (DateTime)row["ngaynhap"];
            this.ngayhocthu = (DateTime)row["ngayhocthu"];
        }
    }
}
