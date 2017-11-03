using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocVien
{
    public partial class frmReport : Form
    {
        public frmReport(int idhv)
        {
            InitializeComponent();
            loadReport(idhv);
        }

        void loadReport(int idhv)
        {
            // TODO: This line of code loads data into the 'QuanLyHocVienDataSet.USP_getKetQuaHocVienByIdHV' table. You can move, or remove it, as needed.
            this.USP_getKetQuaHocVienByIdHVTableAdapter.Fill(this.QuanLyHocVienDataSet.USP_getKetQuaHocVienByIdHV,idhv);

            this.reportViewer1.RefreshReport();
        }
    }
}
