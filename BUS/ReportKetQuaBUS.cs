using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class ReportKetQuaBUS
    {
        private static ReportKetQuaBUS instance;

        public static ReportKetQuaBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new ReportKetQuaBUS();
                return instance;
            }
            private set => instance = value;
        }
        private ReportKetQuaBUS() { }
        public DataTable getKetQuaHocVienByIdHV(int idhv)
        {
            try
            {
                return ReportKetQuaDAO.Instance.getKetQuaHocVienByIdHV(idhv);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
