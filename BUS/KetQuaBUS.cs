using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class KetQuaBUS
    {
        private static KetQuaBUS instance;
        public static KetQuaBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new KetQuaBUS();
                return KetQuaBUS.instance;
            }
            private set { KetQuaBUS.instance = value; }
        }
        private KetQuaBUS() { }
        public DataTable getTableKetQuaByID(int idHV)
        {
            try
            {
                return KetQuaDAO.Instance.getTableKetQuaByID(idHV);
            }
            catch (Exception ex)
            {
                throw (ex);
            }          
        }
        public bool Insert_KetQua(string tinhtrang, float ketqua, int idhv)
        {
            try
            {
                return KetQuaDAO.Instance.Insert_KetQua(tinhtrang, ketqua, idhv);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool Update_KetQua(int idkq, string tinhtrang, float ketqua, int idhv)
        {
            try
            {
                return KetQuaDAO.Instance.Update_KetQua(idkq, tinhtrang, ketqua, idhv);
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
                return KetQuaDAO.Instance.Delete_KetQua(idkq);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
