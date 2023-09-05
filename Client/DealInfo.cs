using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Client
{
    public partial class DealInfo : Form
    {
        ClientSocket client;
        int summ = 0;
        public DealInfo()
        {
            InitializeComponent();
        }

        public DealInfo(string req)
        {
            InitializeComponent();
            client = new ClientSocket();
            string jsonString = client.sendMsg(req).Split('|')[1];
            JArray reportsDetails = JArray.Parse(jsonString);
            foreach (var reportsDetail in reportsDetails)
            {
                dataGridView_dopInfo.Rows.Add(reportsDetail["Наименование"],
                                              reportsDetail["Кол-во"],
                                              reportsDetail["Название единицы измерения"],
                                              reportsDetail["Цена"],
                                              reportsDetail["Cумма"]);
                summ += Int32.Parse(dataGridView_dopInfo[4, dataGridView_dopInfo.RowCount - 1].Value.ToString());
            }
            textBox1.Text = summ.ToString();
        }


        private void but_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void but_print_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog(this);
        }
    }
}
