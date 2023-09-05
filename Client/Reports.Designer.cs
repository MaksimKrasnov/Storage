using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    partial class Reports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reports));
            this.dataGridView_Reports = new System.Windows.Forms.DataGridView();
            this.dealid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTrans = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seller = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Buyer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeOfTrans = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.but_getReports = new System.Windows.Forms.Button();
            this.but_repInfo = new System.Windows.Forms.Button();
            this.but_exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Reports)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Reports
            // 
            this.dataGridView_Reports.AllowUserToAddRows = false;
            this.dataGridView_Reports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Reports.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dealid,
            this.DateTrans,
            this.Seller,
            this.Buyer,
            this.TypeOfTrans});
            this.dataGridView_Reports.Location = new System.Drawing.Point(30, 22);
            this.dataGridView_Reports.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_Reports.Name = "dataGridView_Reports";
            this.dataGridView_Reports.ReadOnly = true;
            this.dataGridView_Reports.RowHeadersWidth = 51;
            this.dataGridView_Reports.RowTemplate.Height = 29;
            this.dataGridView_Reports.Size = new System.Drawing.Size(883, 355);
            this.dataGridView_Reports.TabIndex = 0;
            this.dataGridView_Reports.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Reports_CellDoubleClick);
            // 
            // dealid
            // 
            this.dealid.HeaderText = "Номер операции";
            this.dealid.MinimumWidth = 6;
            this.dealid.Name = "dealid";
            this.dealid.ReadOnly = true;
            this.dealid.Width = 125;
            // 
            // DateTrans
            // 
            this.DateTrans.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DateTrans.HeaderText = "Дата операции";
            this.DateTrans.MinimumWidth = 6;
            this.DateTrans.Name = "DateTrans";
            this.DateTrans.ReadOnly = true;
            // 
            // Seller
            // 
            this.Seller.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Seller.HeaderText = "Компания";
            this.Seller.MinimumWidth = 6;
            this.Seller.Name = "Seller";
            this.Seller.ReadOnly = true;
            // 
            // Buyer
            // 
            this.Buyer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Buyer.HeaderText = "Менеджер";
            this.Buyer.MinimumWidth = 6;
            this.Buyer.Name = "Buyer";
            this.Buyer.ReadOnly = true;
            // 
            // TypeOfTrans
            // 
            this.TypeOfTrans.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TypeOfTrans.HeaderText = "Тип операции";
            this.TypeOfTrans.MinimumWidth = 6;
            this.TypeOfTrans.Name = "TypeOfTrans";
            this.TypeOfTrans.ReadOnly = true;
            // 
            // but_getReports
            // 
            this.but_getReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.but_getReports.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.but_getReports.Location = new System.Drawing.Point(30, 392);
            this.but_getReports.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.but_getReports.Name = "but_getReports";
            this.but_getReports.Size = new System.Drawing.Size(199, 45);
            this.but_getReports.TabIndex = 1;
            this.but_getReports.Text = "Сформировать отчет";
            this.but_getReports.UseVisualStyleBackColor = true;
            this.but_getReports.Click += new System.EventHandler(this.but_getReports_Click);
            // 
            // but_repInfo
            // 
            this.but_repInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.but_repInfo.Enabled = false;
            this.but_repInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.but_repInfo.Location = new System.Drawing.Point(256, 392);
            this.but_repInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.but_repInfo.Name = "but_repInfo";
            this.but_repInfo.Size = new System.Drawing.Size(154, 45);
            this.but_repInfo.TabIndex = 2;
            this.but_repInfo.Text = "Подробно";
            this.but_repInfo.UseVisualStyleBackColor = true;
            this.but_repInfo.Click += new System.EventHandler(this.but_repInfo_Click);
            // 
            // but_exit
            // 
            this.but_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.but_exit.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.but_exit.Location = new System.Drawing.Point(785, 392);
            this.but_exit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.but_exit.Name = "but_exit";
            this.but_exit.Size = new System.Drawing.Size(128, 45);
            this.but_exit.TabIndex = 3;
            this.but_exit.Text = "Закрыть";
            this.but_exit.UseVisualStyleBackColor = true;
            this.but_exit.Click += new System.EventHandler(this.but_exit_Click);
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 450);
            this.Controls.Add(this.but_exit);
            this.Controls.Add(this.but_repInfo);
            this.Controls.Add(this.but_getReports);
            this.Controls.Add(this.dataGridView_Reports);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Reports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчеты";
            this.Load += new System.EventHandler(this.Reports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Reports)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView_Reports;
        private Button but_getReports;
        private Button but_repInfo;
        private Button but_exit;
        private DataGridViewTextBoxColumn dealid;
        private DataGridViewTextBoxColumn DateTrans;
        private DataGridViewTextBoxColumn Seller;
        private DataGridViewTextBoxColumn Buyer;
        private DataGridViewTextBoxColumn TypeOfTrans;
    }
}