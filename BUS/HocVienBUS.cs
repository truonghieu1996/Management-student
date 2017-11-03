using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class HocVienBUS
    {
        private static HocVienBUS instance;
        public static HocVienBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new HocVienBUS();
                return instance;
            }
            private set { instance = value; }
        }
        private HocVienBUS() { }

        public DataTable GetTableHocVien()
        {
            try
            {
                return HocVienDAO.Instance.GetTableHocVien();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HocVienDTO> timKiemTen(string ten)
        {
            try
            {
                return HocVienDAO.Instance.timKiemTen(ten);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool Insert_HocVien(string holot, string ten, DateTime ngaysinh, string sdt, string diachi, string gioitinh, string ghichu, DateTime ngaynhap, DateTime ngayhocthu)
        {
            try
            {
                return HocVienDAO.Instance.Insert_HocVien(holot, ten, ngaysinh, sdt, diachi, gioitinh, ghichu, ngaynhap, ngayhocthu);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool Update_HocVien(int idHV, string holot, string ten, DateTime ngaysinh, string sdt, string diachi, string gioitinh, string ghichu, DateTime ngaynhap, DateTime ngayhocthu)
        {
            try
            {
                return HocVienDAO.Instance.Update_HocVien(idHV,holot, ten, ngaysinh, sdt, diachi, gioitinh, ghichu, ngaynhap, ngayhocthu);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool Delete_HocVien(int idHV)
        {
            try
            {
                return HocVienDAO.Instance.Delete_HocVien(idHV);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
