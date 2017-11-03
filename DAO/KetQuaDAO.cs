using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class KetQuaDAO
    {
        private static KetQuaDAO instance;
        public static KetQuaDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new KetQuaDAO();
                return KetQuaDAO.instance;
            }
            private set { KetQuaDAO.instance = value; }
        }
        private KetQuaDAO() { }
        public DataTable getTableKetQuaByID(int idHV)
        {
            try
            {
                string query = "EXEC dbo.USP_GetTableKetQuaByID @idHV";
                return DataProvider.Instance.ExecuteQuery(query, new object[] { idHV });
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool Insert_KetQua(string tinhtrang , float ketqua , int idhv)
        {
            try
            {
                string query = string.Format("INSERT dbo.KetQuaHoc(tinhtranghocthu , ketquakiemtra , idHV ) VALUES  ( N'{0}' ,{1} ,{2})",tinhtrang,ketqua,idhv);
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool Update_KetQua(int idkq , string tinhtrang, float ketqua, int idhv)
        {
            try
            {
                string query = string.Format("UPDATE dbo.KetQuaHoc SET tinhtranghocthu=N'{1}' , ketquakiemtra={2} , idHV={3} WHERE idKQ={0}" ,idkq, tinhtrang, ketqua, idhv);
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool Delete_KetQua(int idkq)
        {
            try
            {
                string query = string.Format("DELETE dbo.KetQuaHoc WHERE idKQ={0}", idkq);
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
