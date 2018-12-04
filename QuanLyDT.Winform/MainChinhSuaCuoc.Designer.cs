namespace QuanLyDT.Winform
{
    partial class MainChinhSuaCuoc
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtgiacuoc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txttgbatdau = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txttgketthuc = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddEdit = new System.Windows.Forms.Button();
            this.txttrangthai = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Giá cước";
            // 
            // txtgiacuoc
            // 
            this.txtgiacuoc.Location = new System.Drawing.Point(111, 81);
            this.txtgiacuoc.Margin = new System.Windows.Forms.Padding(4);
            this.txtgiacuoc.Name = "txtgiacuoc";
            this.txtgiacuoc.Size = new System.Drawing.Size(231, 20);
            this.txtgiacuoc.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Thời gian kết thúc";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 15);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Thời gian bắt đầu";
            // 
            // txttgbatdau
            // 
            this.txttgbatdau.Location = new System.Drawing.Point(111, 11);
            this.txttgbatdau.Margin = new System.Windows.Forms.Padding(4);
            this.txttgbatdau.Name = "txttgbatdau";
            this.txttgbatdau.Size = new System.Drawing.Size(231, 20);
            this.txttgbatdau.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 123);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Trạng thái";
            // 
            // txttgketthuc
            // 
            this.txttgketthuc.Location = new System.Drawing.Point(111, 43);
            this.txttgketthuc.Margin = new System.Windows.Forms.Padding(4);
            this.txttgketthuc.Name = "txttgketthuc";
            this.txttgketthuc.Size = new System.Drawing.Size(231, 20);
            this.txttgketthuc.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnAddEdit);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtgiacuoc);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txttrangthai);
            this.panel1.Controls.Add(this.txttgbatdau);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txttgketthuc);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(363, 248);
            this.panel1.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(95, 196);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 28);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddEdit
            // 
            this.btnAddEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddEdit.Location = new System.Drawing.Point(233, 195);
            this.btnAddEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddEdit.Name = "btnAddEdit";
            this.btnAddEdit.Size = new System.Drawing.Size(117, 28);
            this.btnAddEdit.TabIndex = 9;
            this.btnAddEdit.Text = "Xác nhận";
            this.btnAddEdit.UseVisualStyleBackColor = true;
            this.btnAddEdit.Click += new System.EventHandler(this.btnAddEdit_Click);
            // 
            // txttrangthai
            // 
            this.txttrangthai.Location = new System.Drawing.Point(111, 120);
            this.txttrangthai.Margin = new System.Windows.Forms.Padding(4);
            this.txttrangthai.Name = "txttrangthai";
            this.txttrangthai.Size = new System.Drawing.Size(231, 20);
            this.txttrangthai.TabIndex = 7;
            // 
            // MainChinhSuaCuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 269);
            this.Controls.Add(this.panel1);
            this.Name = "MainChinhSuaCuoc";
            this.Text = "MainChinhSuaCuoc";
            this.Load += new System.EventHandler(this.MainChinhSuaCuoc_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtgiacuoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txttgbatdau;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txttgketthuc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddEdit;
        private System.Windows.Forms.TextBox txttrangthai;
    }
}