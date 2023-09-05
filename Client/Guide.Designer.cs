using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    partial class Guide
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Guide));
            this.label1 = new System.Windows.Forms.Label();
            this.panel_Employee = new System.Windows.Forms.Panel();
            this.but_exit = new System.Windows.Forms.Button();
            this.dataGridView_empl = new System.Windows.Forms.DataGridView();
            this.EmplFullname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmplPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_Products = new System.Windows.Forms.Panel();
            this.but_close = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView_products = new System.Windows.Forms.DataGridView();
            this.productName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitOfMeasurement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countProducts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchasePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellingPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_withButtons = new System.Windows.Forms.Panel();
            this.but_employee = new System.Windows.Forms.Button();
            this.but_products = new System.Windows.Forms.Button();
            this.but_suppliers = new System.Windows.Forms.Button();
            this.but_Back = new System.Windows.Forms.Button();
            this.panel_Employee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_empl)).BeginInit();
            this.panel_Products.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_products)).BeginInit();
            this.panel_withButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Сотрудники";
            // 
            // panel_Employee
            // 
            this.panel_Employee.Controls.Add(this.but_exit);
            this.panel_Employee.Controls.Add(this.dataGridView_empl);
            this.panel_Employee.Controls.Add(this.label1);
            this.panel_Employee.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel_Employee.Location = new System.Drawing.Point(12, 338);
            this.panel_Employee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel_Employee.Name = "panel_Employee";
            this.panel_Employee.Size = new System.Drawing.Size(445, 298);
            this.panel_Employee.TabIndex = 4;
            this.panel_Employee.Visible = false;
            // 
            // but_exit
            // 
            this.but_exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.but_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.but_exit.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.but_exit.Location = new System.Drawing.Point(323, 238);
            this.but_exit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.but_exit.Name = "but_exit";
            this.but_exit.Size = new System.Drawing.Size(106, 42);
            this.but_exit.TabIndex = 5;
            this.but_exit.Text = "Закрыть";
            this.but_exit.UseVisualStyleBackColor = true;
            this.but_exit.Click += new System.EventHandler(this.but_exit_Click);
            // 
            // dataGridView_empl
            // 
            this.dataGridView_empl.AllowUserToAddRows = false;
            this.dataGridView_empl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_empl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_empl.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmplFullname,
            this.EmplPosition});
            this.dataGridView_empl.Location = new System.Drawing.Point(18, 62);
            this.dataGridView_empl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView_empl.Name = "dataGridView_empl";
            this.dataGridView_empl.ReadOnly = true;
            this.dataGridView_empl.RowHeadersWidth = 51;
            this.dataGridView_empl.RowTemplate.Height = 25;
            this.dataGridView_empl.Size = new System.Drawing.Size(411, 168);
            this.dataGridView_empl.TabIndex = 4;
            // 
            // EmplFullname
            // 
            this.EmplFullname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EmplFullname.HeaderText = "ФИО";
            this.EmplFullname.MinimumWidth = 50;
            this.EmplFullname.Name = "EmplFullname";
            this.EmplFullname.ReadOnly = true;
            // 
            // EmplPosition
            // 
            this.EmplPosition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EmplPosition.HeaderText = "Должность";
            this.EmplPosition.MinimumWidth = 50;
            this.EmplPosition.Name = "EmplPosition";
            this.EmplPosition.ReadOnly = true;
            // 
            // panel_Products
            // 
            this.panel_Products.Controls.Add(this.but_close);
            this.panel_Products.Controls.Add(this.label2);
            this.panel_Products.Controls.Add(this.dataGridView_products);
            this.panel_Products.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel_Products.Location = new System.Drawing.Point(491, 338);
            this.panel_Products.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel_Products.Name = "panel_Products";
            this.panel_Products.Size = new System.Drawing.Size(537, 298);
            this.panel_Products.TabIndex = 5;
            this.panel_Products.Visible = false;
            // 
            // but_close
            // 
            this.but_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.but_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.but_close.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.but_close.Location = new System.Drawing.Point(411, 238);
            this.but_close.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.but_close.Name = "but_close";
            this.but_close.Size = new System.Drawing.Size(106, 42);
            this.but_close.TabIndex = 1;
            this.but_close.Text = "Закрыть";
            this.but_close.UseVisualStyleBackColor = true;
            this.but_close.Click += new System.EventHandler(this.but_close_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(13, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Номенклатура";
            // 
            // dataGridView_products
            // 
            this.dataGridView_products.AllowUserToAddRows = false;
            this.dataGridView_products.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_products.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_products.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productName,
            this.unitOfMeasurement,
            this.countProducts,
            this.purchasePrice,
            this.sellingPrice});
            this.dataGridView_products.Location = new System.Drawing.Point(18, 57);
            this.dataGridView_products.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView_products.Name = "dataGridView_products";
            this.dataGridView_products.ReadOnly = true;
            this.dataGridView_products.RowHeadersWidth = 51;
            this.dataGridView_products.RowTemplate.Height = 25;
            this.dataGridView_products.Size = new System.Drawing.Size(499, 173);
            this.dataGridView_products.TabIndex = 0;
            // 
            // productName
            // 
            this.productName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.productName.DefaultCellStyle = dataGridViewCellStyle1;
            this.productName.HeaderText = "Наименование товара";
            this.productName.MinimumWidth = 200;
            this.productName.Name = "productName";
            this.productName.ReadOnly = true;
            // 
            // unitOfMeasurement
            // 
            this.unitOfMeasurement.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.unitOfMeasurement.HeaderText = "Единицы измерения";
            this.unitOfMeasurement.MinimumWidth = 6;
            this.unitOfMeasurement.Name = "unitOfMeasurement";
            this.unitOfMeasurement.ReadOnly = true;
            // 
            // countProducts
            // 
            this.countProducts.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.countProducts.HeaderText = "Количество";
            this.countProducts.MinimumWidth = 6;
            this.countProducts.Name = "countProducts";
            this.countProducts.ReadOnly = true;
            // 
            // purchasePrice
            // 
            this.purchasePrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.purchasePrice.HeaderText = "Цена покупки";
            this.purchasePrice.MinimumWidth = 6;
            this.purchasePrice.Name = "purchasePrice";
            this.purchasePrice.ReadOnly = true;
            // 
            // sellingPrice
            // 
            this.sellingPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sellingPrice.HeaderText = "Цена продажи";
            this.sellingPrice.MinimumWidth = 6;
            this.sellingPrice.Name = "sellingPrice";
            this.sellingPrice.ReadOnly = true;
            // 
            // panel_withButtons
            // 
            this.panel_withButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_withButtons.Controls.Add(this.but_employee);
            this.panel_withButtons.Controls.Add(this.but_products);
            this.panel_withButtons.Controls.Add(this.but_suppliers);
            this.panel_withButtons.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.panel_withButtons.Location = new System.Drawing.Point(2, 11);
            this.panel_withButtons.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_withButtons.Name = "panel_withButtons";
            this.panel_withButtons.Size = new System.Drawing.Size(1038, 302);
            this.panel_withButtons.TabIndex = 9;
            // 
            // but_employee
            // 
            this.but_employee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.but_employee.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_employee.Image = ((System.Drawing.Image)(resources.GetObject("but_employee.Image")));
            this.but_employee.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.but_employee.Location = new System.Drawing.Point(428, 22);
            this.but_employee.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.but_employee.Name = "but_employee";
            this.but_employee.Size = new System.Drawing.Size(200, 230);
            this.but_employee.TabIndex = 6;
            this.but_employee.Text = "Сотрудники";
            this.but_employee.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.but_employee.UseVisualStyleBackColor = true;
            this.but_employee.Click += new System.EventHandler(this.but_employee_Click);
            // 
            // but_products
            // 
            this.but_products.Cursor = System.Windows.Forms.Cursors.Hand;
            this.but_products.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_products.Image = ((System.Drawing.Image)(resources.GetObject("but_products.Image")));
            this.but_products.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.but_products.Location = new System.Drawing.Point(37, 22);
            this.but_products.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.but_products.Name = "but_products";
            this.but_products.Size = new System.Drawing.Size(200, 230);
            this.but_products.TabIndex = 8;
            this.but_products.Text = "Товары";
            this.but_products.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.but_products.UseVisualStyleBackColor = true;
            this.but_products.Click += new System.EventHandler(this.but_products_Click);
            // 
            // but_suppliers
            // 
            this.but_suppliers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.but_suppliers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_suppliers.Image = ((System.Drawing.Image)(resources.GetObject("but_suppliers.Image")));
            this.but_suppliers.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.but_suppliers.Location = new System.Drawing.Point(795, 22);
            this.but_suppliers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.but_suppliers.Name = "but_suppliers";
            this.but_suppliers.Size = new System.Drawing.Size(200, 230);
            this.but_suppliers.TabIndex = 7;
            this.but_suppliers.Text = "Поставщики";
            this.but_suppliers.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.but_suppliers.UseVisualStyleBackColor = true;
            this.but_suppliers.Click += new System.EventHandler(this.but_suppliers_Click);
            // 
            // but_Back
            // 
            this.but_Back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.but_Back.BackgroundImage = global::Client.Properties.Resources.back;
            this.but_Back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.but_Back.Location = new System.Drawing.Point(39, 643);
            this.but_Back.Name = "but_Back";
            this.but_Back.Size = new System.Drawing.Size(100, 100);
            this.but_Back.TabIndex = 10;
            this.but_Back.UseVisualStyleBackColor = true;
            this.but_Back.Click += new System.EventHandler(this.but_Back_Click);
            // 
            // Guide
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1040, 759);
            this.Controls.Add(this.but_Back);
            this.Controls.Add(this.panel_withButtons);
            this.Controls.Add(this.panel_Products);
            this.Controls.Add(this.panel_Employee);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1056, 600);
            this.Name = "Guide";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочник";
            this.Load += new System.EventHandler(this.Guide_Load);
            this.panel_Employee.ResumeLayout(false);
            this.panel_Employee.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_empl)).EndInit();
            this.panel_Products.ResumeLayout(false);
            this.panel_Products.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_products)).EndInit();
            this.panel_withButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Label label1;
        private Panel panel_Employee;
        private DataGridView dataGridView_empl;
        private Button but_exit;
        private Panel panel_Products;
        private DataGridView dataGridView_products;
        private Button but_close;
        private DataGridViewTextBoxColumn EmplFullname;
        private DataGridViewTextBoxColumn EmplPosition;
        private Button but_employee;
        private Button but_suppliers;
        private Button but_products;
        private Panel panel_withButtons;
        private Label label2;
        private DataGridViewTextBoxColumn productName;
        private DataGridViewTextBoxColumn unitOfMeasurement;
        private DataGridViewTextBoxColumn countProducts;
        private DataGridViewTextBoxColumn purchasePrice;
        private DataGridViewTextBoxColumn sellingPrice;
        private Button but_Back;
    }
}