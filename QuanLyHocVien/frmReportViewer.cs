using BUS;
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
    public partial class frmReportViewer : Form
    {
        public frmReportViewer(int idhv, string holot, string ten)
        {
            InitializeComponent();
            load(idhv, holot, ten);
        }
        void load(int idhv, string holot, string ten)
        {
            label1.Text = string.Format("Thông tin học viên: {0} {1}",holot,ten);
            getKetQuaHocVienByIdHV(idhv);
        }
        void getKetQuaHocVienByIdHV(int idhv)
        {
            try
            {
                dgvKetQuaHocVien.DataSource = ReportKetQuaBUS.Instance.getKetQuaHocVienByIdHV(idhv);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
            dgvKetQuaHocVien.Columns["holot"].HeaderText = "HỌ LÓT";
            dgvKetQuaHocVien.Columns["ten"].HeaderText = "TÊN";
            dgvKetQuaHocVien.Columns["ngaysinh"].HeaderText = "NGÀY SINH";
            dgvKetQuaHocVien.Columns["sdt"].HeaderText = "SĐT";
            dgvKetQuaHocVien.Columns["diachi"].HeaderText = "ĐỊA CHỈ";
            dgvKetQuaHocVien.Columns["gioitinh"].HeaderText = "GIỚI TÍNH";
            dgvKetQuaHocVien.Columns["tinhtranghocthu"].HeaderText = "TÌNH TRẠNG HỌC";
            dgvKetQuaHocVien.Columns["ketquakiemtra"].HeaderText = "KẾT QUẢ HỌC";
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            // Lấy về nguồn dữ liệu cần Export là 1 DataTable
            // DataTable này mỗi bạn lấy mỗi khác. 
            // Ở đây tôi dùng BindingSouce có tên bs nên tôi ép kiểu như sau:
            // Bạn nào gán trực tiếp vào DataGridView thì ép kiểu DataSource của
            // DataGridView nhé 
            DataTable dt = (DataTable)dgvKetQuaHocVien.DataSource;
            ExportToExcel.Instance.Export(dt, "KetQuaKiemTra", "THÔNG TIN KẾT QUẢ KIỂM TRA");
        }
    }
}
