using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;


namespace Client
{
    public partial class Guide : Form
    {
        ClientSocket client;
               
        public Guide()
        {
            InitializeComponent();
        }
        private void Guide_Load(object sender, EventArgs e)
        {
            Size = new Size(1110, 700);
            panel_withButtons.Location = new Point(0, 100);
            client = new ClientSocket();
        }

        //������ "����������"
        private void Employee_Click(object sender, EventArgs e)
        {
            panel_Employee.Dock = DockStyle.Fill;
            panel_Products.Visible = false;
            //����������� ������� �� ������ ��� ����������� ������ �����������
            panel_Employee.Visible = true;
        }

        private void but_exit_Click(object sender, EventArgs e)
        {
            ActiveForm.Text = "����������";
            panel_withButtons.Visible = true;
            panel_Employee.Visible = false;
            panel_Products.Visible = false;
            but_Back.Visible = true;
        }

        private void but_close_Click(object sender, EventArgs e)
        {
            ActiveForm.Text = "����������";
            panel_withButtons.Visible = true;
            panel_Products.Visible = false;
            panel_Employee.Visible = false;
            but_Back.Visible = true;
        }

        private void but_employee_Click(object sender, EventArgs e)
        {
            ActiveForm.Text = "����������/����������";
            but_Back.Visible = false;
            panel_withButtons.Visible = false;
            panel_Products.Visible = false;
            panel_Employee.Visible = true;
            panel_Employee.Dock = DockStyle.Fill;

            if (dataGridView_empl.RowCount == 0)
            {
                string request = "Get_ListOfEmployees";
                //����������� ������� �� ������ ��� ����������� ������ �����������
                string jsonString = client.sendMsg(request).Split('|')[1];
                JArray users = JArray.Parse(jsonString);
                foreach (var user in users)
                {
                    dataGridView_empl.Rows.Add(user["���"], user["���������"]);
                }
            }
        }

        private void but_suppliers_Click(object sender, EventArgs e)
        {
            //������ �� ������ ��� ������������ ������ ����������� (��������, �����, �������)
            Suppliers supl = new Suppliers();
            supl.ShowDialog();
        }


        private void but_products_Click(object sender, EventArgs e)
        {
            ActiveForm.Text = "����������/������";
            but_Back.Visible = false;
            panel_withButtons.Visible = false;
            panel_Products.Dock = DockStyle.Fill;
            // ������ �� ��������� ������� �������
            panel_Products.Visible = true;
            panel_Products.Location = new Point(25, 52);
            if (dataGridView_products.RowCount == 0)
            {
                string request = "Get_ListOfProducts";
                string jsonString = client.sendMsg(request).Split('|')[1];
                JArray products = JArray.Parse(jsonString);
                foreach (var product in products)
                {
                    dataGridView_products.Rows.Add(product["�������� ������"],
                                                   product["������� ���������"],
                                                   product["���-��"],
                                                   product["���� �������"],
                                                   product["���� �������"]);
                    if (Int32.Parse(product["���-��"].ToString()) < 0)
                    {
                        dataGridView_products[2, dataGridView_products.RowCount - 1].Style.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void but_Back_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}