using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocVien
{
    public partial class frmQuanLyHocVien : Form
    {
        BindingSource bdTableHocVien = new BindingSource();
        public frmQuanLyHocVien()
        {
            InitializeComponent();
            dgvHocVien.DataSource = bdTableHocVien;
            LoadTableHocVien();
            addBindingHocVien();
        }
        # region Method
        void LoadTableHocVien()
        {
            rdbNam.Checked = true;
            try
            {
                bdTableHocVien.DataSource = HocVienBUS.Instance.GetTableHocVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }

            dgvHocVien.Columns["idHV"].Visible = false;
            dgvHocVien.Columns["holot"].HeaderText = "HỌ LÓT";
            dgvHocVien.Columns["ten"].HeaderText = "TÊN";
            dgvHocVien.Columns["ngaysinh"].HeaderText = "NGÀY SINH";
            dgvHocVien.Columns["sdt"].HeaderText = "SỐ ĐIỆN THOẠI";
            dgvHocVien.Columns["diachi"].HeaderText = "ĐỊA CHỈ";
            dgvHocVien.Columns["gioitinh"].HeaderText = "GIỚI TÍNH";
            dgvHocVien.Columns["ghichu"].HeaderText = "GHI CHÚ";
            dgvHocVien.Columns["ngaynhap"].HeaderText = "NGÀY NHẬP";
            dgvHocVien.Columns["ngayhocthu"].HeaderText = "NGÀY HỌC THỬ";
        }

        void addBindingHocVien()
        {
            txtMaHocVien.DataBindings.Add(new Binding("Text",dgvHocVien.DataSource,"idHV",true,DataSourceUpdateMode.Never));
            txtHolot.DataBindings.Add(new Binding("Text", dgvHocVien.DataSource, "holot", true, DataSourceUpdateMode.Never));
            txtTen.DataBindings.Add(new Binding("Text", dgvHocVien.DataSource, "ten", true, DataSourceUpdateMode.Never));
            dtpNgaysinh.DataBindings.Add(new Binding("Value", dgvHocVien.DataSource, "ngaysinh", true, DataSourceUpdateMode.Never));
            txtsdt.DataBindings.Add(new Binding("Text", dgvHocVien.DataSource, "sdt", true, DataSourceUpdateMode.Never));
            txtghichu.DataBindings.Add(new Binding("Text", dgvHocVien.DataSource, "ghichu", true, DataSourceUpdateMode.Never));
            dtpNgayNhapHoc.DataBindings.Add(new Binding("Value", dgvHocVien.DataSource, "ngaynhap", true, DataSourceUpdateMode.Never));
            dtpNgayHocThu.DataBindings.Add(new Binding("Value", dgvHocVien.DataSource, "ngayhocthu", true, DataSourceUpdateMode.Never));
            txtDiaChi.DataBindings.Add(new Binding("Text", dgvHocVien.DataSource, "diachi", true, DataSourceUpdateMode.Never));
        }

        List<HocVienDTO> timKiemTen(string ten)
        {
            List<HocVienDTO> danhsachTen = HocVienBUS.Instance.timKiemTen(ten);

            return danhsachTen;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text != "")
            {
                bdTableHocVien.DataSource = timKiemTen(txtTimKiem.Text);
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập dữ liệu cho ô tìm kiếm!.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTimKiem.Focus();
            }
        }

        private void btnSaoLuu_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "BAK Files (.bak)|*.bak|All Files (*.*)|*.*";
            save.InitialDirectory = Directory.GetCurrentDirectory();

            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    SecurityBUS.Instance.BackupData(save.FileName);
                    MessageBox.Show("Sao lưu thành công!", "Thông báo");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Sao lưu thất bại!\nError: " + ex.ToString(), "Lỗi");
                }
            }
        }

        private void btnPhucHoi_Click(object sender, EventArgs e)
        {
            openFileDialogRestore.Filter = "bak File |*.bak";
            openFileDialogRestore.InitialDirectory = Directory.GetCurrentDirectory();

            if (openFileDialogRestore.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SecurityBUS.Instance.RestoreData(openFileDialogRestore.FileName);
                    MessageBox.Show("Phục hồi thành công!", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Phục hồi thất bại!\nError: " + ex.ToString(), "Lỗi");
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtHolot.Text == "" || txtTen.Text == "" || txtsdt.Text == "" || txtDiaChi.Text == "")
            {
                MessageBox.Show("Các trường không được bỏ trống!\n Ngoại trừ trường GHI CHÚ.", "Thông báo");
                return;
            }
            else
            {
                try
                {
                    string holot = txtHolot.Text;
                    string ten = txtTen.Text;
                    DateTime ngaysinh = dtpNgaysinh.Value;
                    string sdt = txtsdt.Text;
                    string diachi = txtDiaChi.Text;
                    string gioitinh = "";
                    if (rdbNam.Checked == true)
                        gioitinh = "Nam";
                    if (rdbNu.Checked == true)
                        gioitinh = "Nữ";
                    string ghichu = txtghichu.Text;
                    DateTime ngaynhap = dtpNgayNhapHoc.Value;
                    DateTime ngayhocthu = dtpNgayHocThu.Value;
                    if (HocVienBUS.Instance.Insert_HocVien(holot, ten, ngaysinh, sdt, diachi, gioitinh, ghichu, ngaynhap, ngayhocthu))
                    {
                        MessageBox.Show("Thêm học viên mới thành công!", "Thông báo");
                        LoadTableHocVien();
                    }
                    else
                    {
                        MessageBox.Show("Thêm học viên mới không thành công!", "Thông báo");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Lỗi");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int idHV = int.Parse(txtMaHocVien.Text);
                string holot = txtHolot.Text;
                string ten = txtTen.Text;
                DateTime ngaysinh = dtpNgaysinh.Value;
                string sdt = txtsdt.Text;
                string diachi = txtDiaChi.Text;
                string gioitinh = "";
                if (rdbNam.Checked == true)
                    gioitinh = "Nam";
                if (rdbNu.Checked == true)
                    gioitinh = "Nữ";
                string ghichu = txtghichu.Text;
                DateTime ngaynhap = dtpNgayNhapHoc.Value;
                DateTime ngayhocthu = dtpNgayHocThu.Value;
                if (HocVienBUS.Instance.Update_HocVien(idHV,holot, ten, ngaysinh, sdt, diachi, gioitinh, ghichu, ngaynhap, ngayhocthu))
                {
                    MessageBox.Show("Cập nhật học viên thành công!", "Thông báo");
                    LoadTableHocVien();
                }
                else
                {
                    MessageBox.Show("Cập nhật học viên không thành công!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi");
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string holot = txtHolot.Text;
                string ten = txtTen.Text;
                int idHV = int.Parse(txtMaHocVien.Text);
                DialogResult tl = MessageBox.Show("Bạn có chắc muốn xóa học viên "+ holot +" "+ ten,"Thông báo", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (tl == DialogResult.Yes)
                {
                    if (HocVienBUS.Instance.Delete_HocVien(idHV))
                    {
                        MessageBox.Show("Xóa học viên thành công!", "Thông báo");
                        LoadTableHocVien();
                    }
                    else
                    {
                        MessageBox.Show("Xóa học viên không thành công!", "Thông báo");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi");
            }
        }
        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            int idhv = int.Parse(txtMaHocVien.Text);
            string holot = txtHolot.Text;
            string ten = txtTen.Text;
            frmReportViewer report = new frmReportViewer(idhv, holot, ten);
            report.ShowDialog();
        }
        private void btnXemLai_Click(object sender, EventArgs e)
        {
            LoadTableHocVien();
        }
        #endregion
        #region Event
        private void dgvHocVien_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //xu ly su kien click them thong tin ket qua cho hoc vien.
            int idhv = int.Parse(dgvHocVien.CurrentRow.Cells["idHV"].Value.ToString());
            frmKetQuaKiemTra frmKQ = new frmKetQuaKiemTra(idhv);
            frmKQ.ShowDialog();
            
        }

        private void dgvHocVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string gioitinh = dgvHocVien.CurrentRow.Cells["gioitinh"].Value.ToString().ToLower();
            if (gioitinh.CompareTo("nam") == 0)
                rdbNam.Checked = true;
            else
                rdbNu.Checked = true;
        }

        #endregion

        
    }
}
