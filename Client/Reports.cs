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
    public partial class Reports : Form
    {
        ClientSocket client;
        public Reports()
        {
            InitializeComponent();
        }
        private void Reports_Load(object sender, EventArgs e)
        {
            client = new ClientSocket();
        }
        private void but_getReports_Click(object sender, EventArgs e)
        {
            if (dataGridView_Reports.Rows.Count > 0)
            {
                dataGridView_Reports.Refresh();
            }
            else
            {
                //запрос на сервер для формирования отчета по всем операциям
                string request = "Get_Report";
                but_repInfo.Enabled = true;
                string jsonString = client.sendMsg(request).Split('|')[1];
                JArray reports = JArray.Parse(jsonString);
                foreach (var report in reports)
                {
                    dataGridView_Reports.Rows.Add(report["Номер операции"],
                                                  report["Дата операции"],
                                                  report["Компания"],
                                                  report["Менеджер"],
                                                  report["Тип сделки"]);
                }
            }
        }

        private void but_repInfo_Click(object sender, EventArgs e)
        {
            //отправить запрос на сервер для получения подробной инфы об выбранной операции
            string request = $"Get_InfoReport;{dataGridView_Reports[0, dataGridView_Reports.SelectedCells[0].RowIndex].Value}";
            DealInfo dealInfo = new DealInfo(request);
            dealInfo.ShowDialog();
        }

        private void but_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView_Reports_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string request = $"Get_InfoReport;{dataGridView_Reports[0, dataGridView_Reports.SelectedCells[0].RowIndex].Value}";
            DealInfo dealInfo = new DealInfo(request);
            dealInfo.ShowDialog();
        }
    }
}
