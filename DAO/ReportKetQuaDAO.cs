using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ReportKetQuaDAO
    {
        private static ReportKetQuaDAO instance;

        public static ReportKetQuaDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ReportKetQuaDAO();
                return instance;
            }
            private set => instance = value;
        }
        private ReportKetQuaDAO() { }
        public DataTable getKetQuaHocVienByIdHV(int idhv)
        {
            string query = "EXEC dbo.USP_getKetQuaHocVienByIdHV @idhv ";
            try
            {
                return DataProvider.Instance.ExecuteQuery(query, new object[] {idhv});
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
