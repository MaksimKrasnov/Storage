using System.Drawing;
using System.Windows.Forms;
namespace Client
{
    partial class DealInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DealInfo));
            this.dataGridView_dopInfo = new System.Windows.Forms.DataGridView();
            this.NameProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitsOfMeasurement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.but_print = new System.Windows.Forms.Button();
            this.but_exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dopInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_dopInfo
            // 
            this.dataGridView_dopInfo.AllowUserToAddRows = false;
            this.dataGridView_dopInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_dopInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameProduct,
            this.CountProduct,
            this.UnitsOfMeasurement,
            this.PriceProduct,
            this.totalPrice});
            this.dataGridView_dopInfo.Location = new System.Drawing.Point(32, 32);
            this.dataGridView_dopInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_dopInfo.Name = "dataGridView_dopInfo";
            this.dataGridView_dopInfo.ReadOnly = true;
            this.dataGridView_dopInfo.RowHeadersWidth = 51;
            this.dataGridView_dopInfo.RowTemplate.Height = 29;
            this.dataGridView_dopInfo.Size = new System.Drawing.Size(735, 380);
            this.dataGridView_dopInfo.TabIndex = 0;
            // 
            // NameProduct
            // 
            this.NameProduct.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NameProduct.HeaderText = "Наименование";
            this.NameProduct.MinimumWidth = 6;
            this.NameProduct.Name = "NameProduct";
            this.NameProduct.ReadOnly = true;
            // 
            // CountProduct
            // 
            this.CountProduct.HeaderText = "Количество";
            this.CountProduct.MinimumWidth = 6;
            this.CountProduct.Name = "CountProduct";
            this.CountProduct.ReadOnly = true;
            this.CountProduct.Width = 125;
            // 
            // UnitsOfMeasurement
            // 
            this.UnitsOfMeasurement.HeaderText = "Единицы измерения";
            this.UnitsOfMeasurement.MinimumWidth = 6;
            this.UnitsOfMeasurement.Name = "UnitsOfMeasurement";
            this.UnitsOfMeasurement.ReadOnly = true;
            this.UnitsOfMeasurement.Width = 125;
            // 
            // PriceProduct
            // 
            this.PriceProduct.HeaderText = "Цена за единицу";
            this.PriceProduct.MinimumWidth = 6;
            this.PriceProduct.Name = "PriceProduct";
            this.PriceProduct.ReadOnly = true;
            this.PriceProduct.Width = 125;
            // 
            // totalPrice
            // 
            this.totalPrice.HeaderText = "Итоговая сумма";
            this.totalPrice.MinimumWidth = 6;
            this.totalPrice.Name = "totalPrice";
            this.totalPrice.ReadOnly = true;
            this.totalPrice.Width = 125;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // but_print
            // 
            this.but_print.Cursor = System.Windows.Forms.Cursors.Hand;
            this.but_print.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.but_print.Location = new System.Drawing.Point(32, 439);
            this.but_print.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.but_print.Name = "but_print";
            this.but_print.Size = new System.Drawing.Size(111, 40);
            this.but_print.TabIndex = 1;
            this.but_print.Text = "Печать";
            this.but_print.UseVisualStyleBackColor = true;
            this.but_print.Click += new System.EventHandler(this.but_print_Click);
            // 
            // but_exit
            // 
            this.but_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.but_exit.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.but_exit.Location = new System.Drawing.Point(166, 439);
            this.but_exit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.but_exit.Name = "but_exit";
            this.but_exit.Size = new System.Drawing.Size(99, 41);
            this.but_exit.TabIndex = 2;
            this.but_exit.Text = "Закрыть";
            this.but_exit.UseVisualStyleBackColor = true;
            this.but_exit.Click += new System.EventHandler(this.but_exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(528, 446);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Итоговая сумма:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(667, 443);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 4;
            // 
            // DealInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 490);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.but_exit);
            this.Controls.Add(this.but_print);
            this.Controls.Add(this.dataGridView_dopInfo);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DealInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Информация об операции";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dopInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView_dopInfo;
        private DataGridViewTextBoxColumn NameProduct;
        private DataGridViewTextBoxColumn CountProduct;
        private DataGridViewTextBoxColumn UnitsOfMeasurement;
        private DataGridViewTextBoxColumn PriceProduct;
        private DataGridViewTextBoxColumn totalPrice;
        private PrintDialog printDialog1;
        private Button but_print;
        private Button but_exit;
        private Label label1;
        private TextBox textBox1;
    }
}