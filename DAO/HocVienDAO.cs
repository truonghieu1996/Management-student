using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class HocVienDAO
    {
        private static HocVienDAO instance;

        public static HocVienDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new HocVienDAO();
                return HocVienDAO.instance;
            }
            private set
            {
                HocVienDAO.instance = value;
            } 
        }
        private HocVienDAO() { }
        public DataTable GetTableHocVien()
        {
            try
            {
                string query = "SELECT * FROM dbo.HocVien";
                return DataProvider.Instance.ExecuteQuery(query);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<HocVienDTO> timKiemTen(string ten)
        {
            List<HocVienDTO> list = new List<HocVienDTO>();

            string query = string.Format("SELECT * FROM dbo.HocVien WHERE dbo.fuConvertToUnsign1(ten) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", ten);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                HocVienDTO hocvien = new HocVienDTO(item);
                list.Add(hocvien);
            }
            return list;
        }
        public bool Insert_HocVien(string holot , string ten , DateTime ngaysinh , string sdt, string diachi, string gioitinh, string ghichu, DateTime ngaynhap, DateTime ngayhocthu)
        {
            try
            {

                string query = string.Format("INSERT dbo.HocVien (holot , ten , ngaysinh , sdt , diachi , gioitinh , ghichu , ngaynhap , ngayhocthu )VALUES  (N'{0}' ,N'{1}' ,'{2}' ,'{3}' , N'{4}' , N'{5}' , N'{6}' , '{7}' ,  '{8}')", holot, ten, ngaysinh, sdt, diachi, gioitinh, ghichu, ngaynhap, ngayhocthu);
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool Update_HocVien(int idHV ,string holot, string ten, DateTime ngaysinh, string sdt, string diachi, string gioitinh, string ghichu, DateTime ngaynhap, DateTime ngayhocthu)
        {
            try
            {

                string query = string.Format("UPDATE dbo.HocVien SET holot=N'{1}' , ten=N'{2}' , ngaysinh='{3}' , sdt='{4}' , diachi=N'{5}' , gioitinh=N'{6}' , ghichu=N'{7}' , ngaynhap='{8}' , ngayhocthu='{9}' WHERE idHV={0}", idHV,holot, ten, ngaysinh, sdt, diachi, gioitinh, ghichu, ngaynhap, ngayhocthu);
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return result > 0;
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
                string query = "EXEC dbo.USP_DeleteHocVienByID @idHV";
                int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] {idHV});
                return result > 0;
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }
    }
}
