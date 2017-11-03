namespace QuanLyHocVien
{
    partial class frmReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.QuanLyHocVienDataSet = new QuanLyHocVien.QuanLyHocVienDataSet();
            this.USP_getKetQuaHocVienByIdHVBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.USP_getKetQuaHocVienByIdHVTableAdapter = new QuanLyHocVien.QuanLyHocVienDataSetTableAdapters.USP_getKetQuaHocVienByIdHVTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyHocVienDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_getKetQuaHocVienByIdHVBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.USP_getKetQuaHocVienByIdHVBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyHocVien.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, -1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(572, 434);
            this.reportViewer1.TabIndex = 0;
            // 
            // QuanLyHocVienDataSet
            // 
            this.QuanLyHocVienDataSet.DataSetName = "QuanLyHocVienDataSet";
            this.QuanLyHocVienDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // USP_getKetQuaHocVienByIdHVBindingSource
            // 
            this.USP_getKetQuaHocVienByIdHVBindingSource.DataMember = "USP_getKetQuaHocVienByIdHV";
            this.USP_getKetQuaHocVienByIdHVBindingSource.DataSource = this.QuanLyHocVienDataSet;
            // 
            // USP_getKetQuaHocVienByIdHVTableAdapter
            // 
            this.USP_getKetQuaHocVienByIdHVTableAdapter.ClearBeforeFill = true;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 434);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyHocVienDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_getKetQuaHocVienByIdHVBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource USP_getKetQuaHocVienByIdHVBindingSource;
        private QuanLyHocVienDataSet QuanLyHocVienDataSet;
        private QuanLyHocVienDataSetTableAdapters.USP_getKetQuaHocVienByIdHVTableAdapter USP_getKetQuaHocVienByIdHVTableAdapter;
    }
}