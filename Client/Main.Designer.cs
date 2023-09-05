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
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.buyButton = new System.Windows.Forms.Button();
            this.sellButton = new System.Windows.Forms.Button();
            this.but_Guide = new System.Windows.Forms.Button();
            this.but_Reports = new System.Windows.Forms.Button();
            this.testBtn = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buyButton
            // 
            this.buyButton.AutoSize = true;
            this.buyButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buyButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buyButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buyButton.Image = global::Client.Properties.Resources.buy3;
            this.buyButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buyButton.Location = new System.Drawing.Point(193, 12);
            this.buyButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buyButton.Name = "buyButton";
            this.buyButton.Size = new System.Drawing.Size(210, 230);
            this.buyButton.TabIndex = 0;
            this.buyButton.Text = "Покупка";
            this.buyButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buyButton.UseVisualStyleBackColor = false;
            this.buyButton.Click += new System.EventHandler(this.buyButton_Click);
            // 
            // sellButton
            // 
            this.sellButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sellButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sellButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sellButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.sellButton.Image = ((System.Drawing.Image)(resources.GetObject("sellButton.Image")));
            this.sellButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.sellButton.Location = new System.Drawing.Point(193, 290);
            this.sellButton.Name = "sellButton";
            this.sellButton.Size = new System.Drawing.Size(210, 230);
            this.sellButton.TabIndex = 1;
            this.sellButton.Text = "Продажа";
            this.sellButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.sellButton.UseVisualStyleBackColor = false;
            this.sellButton.Click += new System.EventHandler(this.sellButton_Click);
            // 
            // but_Guide
            // 
            this.but_Guide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.but_Guide.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.but_Guide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.but_Guide.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_Guide.Image = ((System.Drawing.Image)(resources.GetObject("but_Guide.Image")));
            this.but_Guide.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.but_Guide.Location = new System.Drawing.Point(466, 13);
            this.but_Guide.Name = "but_Guide";
            this.but_Guide.Size = new System.Drawing.Size(210, 230);
            this.but_Guide.TabIndex = 2;
            this.but_Guide.Text = "Справочник";
            this.but_Guide.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.but_Guide.UseVisualStyleBackColor = false;
            this.but_Guide.Click += new System.EventHandler(this.but_Guide_Click_1);
            // 
            // but_Reports
            // 
            this.but_Reports.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.but_Reports.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.but_Reports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.but_Reports.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_Reports.Image = ((System.Drawing.Image)(resources.GetObject("but_Reports.Image")));
            this.but_Reports.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.but_Reports.Location = new System.Drawing.Point(466, 290);
            this.but_Reports.Name = "but_Reports";
            this.but_Reports.Size = new System.Drawing.Size(210, 230);
            this.but_Reports.TabIndex = 3;
            this.but_Reports.Text = "Отчеты";
            this.but_Reports.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.but_Reports.UseVisualStyleBackColor = false;
            this.but_Reports.Click += new System.EventHandler(this.but_Reports_Click_1);
            // 
            // testBtn
            // 
            this.testBtn.Location = new System.Drawing.Point(0, 26);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(187, 98);
            this.testBtn.TabIndex = 4;
            this.testBtn.Text = "Тестовая кнопка";
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Visible = false;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripDropDownButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 536);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(859, 26);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(90, 21);
            this.toolStripStatusLabel1.Text = "Пользователь: ";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.ShowDropDownArrow = false;
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(24, 24);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.ToolTipText = "Сменить пользователя\r\n";
            this.toolStripDropDownButton1.Click += new System.EventHandler(this.toolStripDropDownButton1_Click_1);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 562);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.testBtn);
            this.Controls.Add(this.but_Reports);
            this.Controls.Add(this.but_Guide);
            this.Controls.Add(this.sellButton);
            this.Controls.Add(this.buyButton);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(875, 600);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Склад";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buyButton;
        private System.Windows.Forms.Button sellButton;
        private System.Windows.Forms.Button but_Guide;
        private System.Windows.Forms.Button but_Reports;
        private System.Windows.Forms.Button testBtn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
    }
}

