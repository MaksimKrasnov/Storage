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
    partial class Suppliers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Suppliers));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.but_AddNewSuppl = new System.Windows.Forms.Button();
            this.but_Exit = new System.Windows.Forms.Button();
            this.but_DeleteSuppl = new System.Windows.Forms.Button();
            this.but_Save = new System.Windows.Forms.Button();
            this.but_EditSuppl = new System.Windows.Forms.Button();
            this.idSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orgAdress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orgPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idSupplier,
            this.orgName,
            this.orgAdress,
            this.orgPhone});
            this.dataGridView1.Location = new System.Drawing.Point(12, 54);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1031, 384);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridView1_CurrentCellDirtyStateChanged);
            // 
            // but_AddNewSuppl
            // 
            this.but_AddNewSuppl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.but_AddNewSuppl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.but_AddNewSuppl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.but_AddNewSuppl.Location = new System.Drawing.Point(14, 445);
            this.but_AddNewSuppl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.but_AddNewSuppl.Name = "but_AddNewSuppl";
            this.but_AddNewSuppl.Size = new System.Drawing.Size(253, 62);
            this.but_AddNewSuppl.TabIndex = 4;
            this.but_AddNewSuppl.Text = "Добавить поставщика";
            this.but_AddNewSuppl.UseVisualStyleBackColor = true;
            this.but_AddNewSuppl.Click += new System.EventHandler(this.but_AddNewSuppl_Click);
            // 
            // but_Exit
            // 
            this.but_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.but_Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.but_Exit.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.but_Exit.Location = new System.Drawing.Point(922, 445);
            this.but_Exit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.but_Exit.Name = "but_Exit";
            this.but_Exit.Size = new System.Drawing.Size(121, 134);
            this.but_Exit.TabIndex = 5;
            this.but_Exit.Text = "Выход";
            this.but_Exit.UseVisualStyleBackColor = true;
            this.but_Exit.Click += new System.EventHandler(this.but_Exit_Click);
            // 
            // but_DeleteSuppl
            // 
            this.but_DeleteSuppl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.but_DeleteSuppl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.but_DeleteSuppl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.but_DeleteSuppl.Location = new System.Drawing.Point(360, 445);
            this.but_DeleteSuppl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.but_DeleteSuppl.Name = "but_DeleteSuppl";
            this.but_DeleteSuppl.Size = new System.Drawing.Size(253, 62);
            this.but_DeleteSuppl.TabIndex = 6;
            this.but_DeleteSuppl.Text = "Удалить поставщика";
            this.but_DeleteSuppl.UseVisualStyleBackColor = true;
            this.but_DeleteSuppl.Click += new System.EventHandler(this.but_DeleteSuppl_Click);
            // 
            // but_Save
            // 
            this.but_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.but_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.but_Save.Enabled = false;
            this.but_Save.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.but_Save.Location = new System.Drawing.Point(360, 516);
            this.but_Save.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.but_Save.Name = "but_Save";
            this.but_Save.Size = new System.Drawing.Size(253, 62);
            this.but_Save.TabIndex = 8;
            this.but_Save.Text = "Сохранить изменения";
            this.but_Save.UseVisualStyleBackColor = true;
            this.but_Save.Click += new System.EventHandler(this.but_Save_Click);
            // 
            // but_EditSuppl
            // 
            this.but_EditSuppl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.but_EditSuppl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.but_EditSuppl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.but_EditSuppl.Location = new System.Drawing.Point(14, 516);
            this.but_EditSuppl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.but_EditSuppl.Name = "but_EditSuppl";
            this.but_EditSuppl.Size = new System.Drawing.Size(253, 62);
            this.but_EditSuppl.TabIndex = 9;
            this.but_EditSuppl.Text = "Редактировать данные поставщика";
            this.but_EditSuppl.UseVisualStyleBackColor = true;
            this.but_EditSuppl.Click += new System.EventHandler(this.but_EditSuppl_Click);
            // 
            // idSupplier
            // 
            this.idSupplier.FillWeight = 47.27327F;
            this.idSupplier.HeaderText = "Код организации";
            this.idSupplier.MinimumWidth = 20;
            this.idSupplier.Name = "idSupplier";
            this.idSupplier.ReadOnly = true;
            this.idSupplier.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // orgName
            // 
            this.orgName.FillWeight = 96.39618F;
            this.orgName.HeaderText = "Название организации";
            this.orgName.MinimumWidth = 50;
            this.orgName.Name = "orgName";
            this.orgName.ReadOnly = true;
            this.orgName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.orgName.ToolTipText = "Название организации";
            // 
            // orgAdress
            // 
            this.orgAdress.FillWeight = 96.39618F;
            this.orgAdress.HeaderText = "Адрес";
            this.orgAdress.MinimumWidth = 50;
            this.orgAdress.Name = "orgAdress";
            this.orgAdress.ReadOnly = true;
            this.orgAdress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.orgAdress.ToolTipText = "Адрес организации";
            // 
            // orgPhone
            // 
            dataGridViewCellStyle1.Format = "N0";
            this.orgPhone.DefaultCellStyle = dataGridViewCellStyle1;
            this.orgPhone.FillWeight = 70.36219F;
            this.orgPhone.HeaderText = "Телефон";
            this.orgPhone.MinimumWidth = 10;
            this.orgPhone.Name = "orgPhone";
            this.orgPhone.ReadOnly = true;
            this.orgPhone.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.orgPhone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.orgPhone.ToolTipText = "Телефон организации";
            // 
            // Suppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 595);
            this.Controls.Add(this.but_EditSuppl);
            this.Controls.Add(this.but_Save);
            this.Controls.Add(this.but_DeleteSuppl);
            this.Controls.Add(this.but_Exit);
            this.Controls.Add(this.but_AddNewSuppl);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Suppliers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поставщики";
            this.Load += new System.EventHandler(this.Suppliers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView1;
        private Button but_AddNewSuppl;
        private Button but_Exit;
        private Button but_DeleteSuppl;
        private Button but_Save;
        private Button but_EditSuppl;
        private DataGridViewTextBoxColumn idSupplier;
        private DataGridViewTextBoxColumn orgName;
        private DataGridViewTextBoxColumn orgAdress;
        private DataGridViewTextBoxColumn orgPhone;
    }
}