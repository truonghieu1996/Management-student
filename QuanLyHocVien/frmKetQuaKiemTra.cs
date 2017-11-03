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
    public partial class frmKetQuaKiemTra : Form
    {
        BindingSource bdTableKetQua = new BindingSource();
        public frmKetQuaKiemTra(int idHV)
        {
            InitializeComponent();
            Load(idHV);
        }
        #region Method
        void Load(int idHV)
        {
            dgvKetQua.DataSource = bdTableKetQua;
            LoadTableKetQua(idHV);
            addBindingKetQua();
            if (dgvKetQua.Rows[0].Cells[0].Value == null)
                btnThem.Enabled = true;
            else
                btnThem.Enabled = false;
        }
        void LoadTableKetQua(int idHV)
        {
                bdTableKetQua.DataSource = KetQuaBUS.Instance.getTableKetQuaByID(idHV);
                dgvKetQua.Columns["idKQ"].Visible = false;
                dgvKetQua.Columns["tinhtranghocthu"].HeaderText = "TÌNH TRẠNG HỌC THỬ";
                dgvKetQua.Columns["ketquakiemtra"].HeaderText = "KẾT QUẢ KIỂM TRA";
                dgvKetQua.Columns["idHV"].Visible = false;
                txtMaHV.Text = idHV.ToString();
        }
        void addBindingKetQua()
        {
            txtMaKetQua.DataBindings.Add(new Binding("Text", dgvKetQua.DataSource, "idKQ", true, DataSourceUpdateMode.Never));
            txtTinhTrangHocThu.DataBindings.Add(new Binding("Text", dgvKetQua.DataSource, "tinhtranghocthu", true, DataSourceUpdateMode.Never));
            txtKQKT.DataBindings.Add(new Binding("Text", dgvKetQua.DataSource, "ketquakiemtra", true, DataSourceUpdateMode.Never));
        }
        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        #endregion
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTinhTrangHocThu.Text == "" || txtKQKT.Text == "")
            {
                MessageBox.Show("Các trường không được bỏ trống");
                return;
            }
            else
            {
                if (IsNumber(txtKQKT.Text))
                {
                    if (int.Parse(txtKQKT.Text) < 0 || int.Parse(txtKQKT.Text) > 10)
                    {
                        MessageBox.Show("Bạn phải nhập giá trị từ 0 -> 10", "Lỗi");
                        txtKQKT.Clear();
                        txtKQKT.Focus();
                    }
                    else
                    {
                        try
                        {
                            string tinhtrang = txtTinhTrangHocThu.Text;
                            float ketquahoc = (float)Convert.ToDouble(txtKQKT.Text);
                            int idhv = int.Parse(txtMaHV.Text);
                            if (KetQuaBUS.Instance.Insert_KetQua(tinhtrang, ketquahoc, idhv))
                            {
                                MessageBox.Show("Thêm kết quả thành công!", "Thông báo");
                                LoadTableKetQua(idhv);
                                btnThem.Enabled = false;
                            }
                            else
                            {
                                MessageBox.Show("Thêm kết quả không thành công!", "Thông báo");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Lỗi");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Bạn phải nhập là số!", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    txtKQKT.Clear();
                    txtKQKT.Focus();
                }
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int idkq = int.Parse(txtMaKetQua.Text);
                string tinhtrang = txtTinhTrangHocThu.Text;
                float ketquahoc = (float)Convert.ToDouble(txtKQKT.Text);
                int idhv = int.Parse(txtMaHV.Text);
                if (KetQuaBUS.Instance.Update_KetQua(idkq,tinhtrang, ketquahoc, idhv))
                {
                    MessageBox.Show("Cập nhật kết quả thành công!", "Thông báo");
                    LoadTableKetQua(idhv);
                }
                else
                {
                    MessageBox.Show("Cập nhật quả không thành công!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),"Lỗi");
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int idkq = int.Parse(txtMaKetQua.Text);
                int idhv = int.Parse(txtMaHV.Text);
                if (KetQuaBUS.Instance.Delete_KetQua(idkq))
                {
                    MessageBox.Show("Xóa kết quả thành công!", "Thông báo");
                    LoadTableKetQua(idhv);
                    btnThem.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Xóa kết quả không thành công!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi");
            }
        }
    }
}
