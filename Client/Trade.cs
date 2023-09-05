using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Client
{
    public partial class Trade : Form
    {
        Main frm;
        //public SellForm()
        //{
        //    InitializeComponent();
        //}
        string deal = null;
        string price = "Цена продажи";
        string dealType = "Продажа";

        public Trade(string typeOfDeal)
        {
            InitializeComponent();
            deal = typeOfDeal;
            if (deal == "buy")
            {
                Text = "Покупка";
                Icon = Icon.ExtractAssociatedIcon("buy48.ico");
                label2.Text = "Продавец";
                dealType = "Покупка";
                price = "Цена покупки";
                sellBtn.Text = "Купить";
            }
        }
        private void SellForm_Load(object sender, EventArgs e)
        {
            frm = (Main)this.Owner;
            //get Companies;
            string msg = frm.sendMsg("Get_ListOfOrg").Split('|')[1];
            DataTable orgData = JsonConvert.DeserializeObject<DataTable>(msg);
            comboBox1.DataSource = orgData;
            comboBox1.ValueMember = "Код организации";
            comboBox1.DisplayMember= "Название организации";
            comboBox1.SelectedIndex = 0;

            //get Supplies
            msg = frm.sendMsg("Get_Product").Split('|')[1];
            DataTable suppData = JsonConvert.DeserializeObject<DataTable>(msg);
            DataGridViewComboBoxColumn col1 = new DataGridViewComboBoxColumn();
            col1.HeaderText = "Наименование";
            col1.DataSource = suppData;
            col1.DisplayMember = "Наименование продукта";
            col1.ValueMember = "Код продукта";
            dataGridView1.Columns.Add(col1);

            //add Number of supplies
            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "Количество";
            col2.ValueType = typeof(int);
            dataGridView1.Columns.Add(col2);

            //add dimension
            string msg2 = frm.sendMsg("Get_UnitOfMeasurements").Split('|')[1];
            DataTable suppData2 = JsonConvert.DeserializeObject<DataTable>(msg2);
            DataGridViewComboBoxColumn col3 = new DataGridViewComboBoxColumn();
            col3.HeaderText = "Ед. измерения";
            col3.DataSource = suppData2;
            col3.DisplayMember = "Название единицы измерения";
            col3.ValueMember = "Код единицы измерения";
            dataGridView1.Columns.Add(col3);

            //add sellPrice
            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            col4.HeaderText = "Цена за ед.";
            col4.ReadOnly = true;
            dataGridView1.Columns.Add(col4);

            //add totalPrice
            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
            col5.HeaderText = "Сумма";
            col5.ReadOnly = true;
            dataGridView1.Columns.Add(col5);
            timer1.Start();
            if (dataGridView1.RowCount == 0)
            {
                sellBtn.Enabled = false;
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            int idx = dataGridView1.SelectedCells[0].RowIndex;
            dataGridView1.Rows.RemoveAt(idx);
            if (dataGridView1.RowCount == 0)
            {
                sellBtn.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string req = frm.sendMsg("Get_ListOfProducts").Split('|')[1];
            var c1 = dataGridView1[0, dataGridView1.SelectedCells[0].RowIndex].Value;
            var c2 = dataGridView1[2, dataGridView1.SelectedCells[0].RowIndex].Value;
            var c3 = dataGridView1[3, dataGridView1.SelectedCells[0].RowIndex].Value;

            JArray products = JArray.Parse(req);
            foreach (var product in products)
            {
                if(c1 != null && c2 != null)
                {
                    if (product["Код товара"].ToString() == c1.ToString() &&
                        product["Код единицы измерения"].ToString() == c2.ToString())
                    {
                        dataGridView1[3, dataGridView1.SelectedCells[0].RowIndex].Value = product[price];                     
                    }
                }
            }
            if (dataGridView1[1, dataGridView1.SelectedCells[0].RowIndex].Value != null &&
                dataGridView1[3, dataGridView1.SelectedCells[0].RowIndex].Value != null)
            {
                dataGridView1[4, dataGridView1.SelectedCells[0].RowIndex].Value =
                    Int32.Parse(dataGridView1[1, dataGridView1.SelectedCells[0].RowIndex].Value.ToString()) *
                    Int32.Parse(dataGridView1[3, dataGridView1.SelectedCells[0].RowIndex].Value.ToString());
            }
            if(c1 !=null && c2 != null && c3 != null)
            {
                sellBtn.Enabled = true;
            }
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private int findUserIndx(string currentUser)
        {
            int indx;
            string req = frm.sendMsg("Get_ListOfEmployees").Split('|')[1];     
            JArray users = JArray.Parse(req);
            foreach (var user in users)
            {
                if (user["ФИО"].ToString() == currentUser)
                {
                    indx = Int32.Parse(user["Код сотрудника"].ToString());
                    return indx;
                }
            }
            return -1;
        }

        private int findUnitOfMeasurementsID(string str)
        {
            int id = 0;
            string request = "Get_UnitOfMeasurements";
            string jsonString = frm.sendMsg(request).Split('|')[1];
            JArray result = JArray.Parse(jsonString);
            foreach(var res in result)
            {
                if (str == res["Код единицы измерения"].ToString())
                {
                    id = Int32.Parse(res["Код единицы измерения"].ToString());
                }
            }            
            return id;
        }

        private void sellBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount < 1)
            {
                MessageBox.Show("Заполните все поля.", "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            for (int i = 1; i < dataGridView1.RowCount + 1; i++)
            {
                if (dataGridView1[0, dataGridView1.RowCount - i].Value == null ||
                    dataGridView1[1, dataGridView1.RowCount - i].Value == null ||
                    dataGridView1[2, dataGridView1.RowCount - i].Value == null)
                {
                    MessageBox.Show("Заполните все поля.", "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
            }

            //заполняем шапку и сохранем в отчеты
            int idx = findUserIndx(frm.currentUser.name);    
            string msg = $"Fill_DealHat;" +
                         $"{textBox1.Text};" +                  //dealDate
                         $"{dealType};" +                       //dealType
                         $"{comboBox1.SelectedValue};" +        //clientId
                         $"{idx}";                              //employeeId            
            string req = frm.sendMsg(msg).Split('|')[1];

            int dealHatID;  
            dealHatID = Int32.Parse(req);                       //получаем dealHatID            

            //заполняем подробную информацию о сделке (Fill_Deal)
            int idOfMeasurements;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                idOfMeasurements = findUnitOfMeasurementsID(dataGridView1[2, i].Value.ToString());
                string request = $"Fill_Deal;" +
                                 $"{Int32.Parse(dataGridView1[1, i].Value.ToString())};" +       //countProducts
                                 $"{Int32.Parse(dataGridView1[3, i].Value.ToString())};" +       //price
                                 $"{Int32.Parse(dataGridView1[0, i].Value.ToString())};" +       //productID
                                 $"{dealHatID};" +                                               //dealHatID
                                 $"{idOfMeasurements}";                                          //unitOfMeasurementsID
                frm.sendMsg(request);
            }//конец заполнения

            string request2 = "Get_ListOfProducts";
            string jsonString = frm.sendMsg(request2).Split('|')[1];
            JArray products = JArray.Parse(jsonString);
            foreach (var product in products)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    idOfMeasurements = findUnitOfMeasurementsID(dataGridView1[2, i].Value.ToString());
                    if (product["Код товара"].ToString() == dataGridView1[0, i].Value.ToString())
                    {
                        if (product["Код единицы измерения"].ToString() == idOfMeasurements.ToString())
                        {
                            int res;
                            if (deal == "buy")
                            {
                                res = Int32.Parse(product["Кол-во"].ToString()) +
                                      Int32.Parse(dataGridView1[1, i].Value.ToString());
                            }
                            else
                            {
                                res = Int32.Parse(product["Кол-во"].ToString()) -
                                      Int32.Parse(dataGridView1[1, i].Value.ToString());
                            }

                            if (idOfMeasurements == 2)
                            {
                                //если код ед.измерения = 2 (упак.) то ID продукта берется из второй половины списка, там где упаковки
                                //т.к. у нас id продукта повторяются, а ед.измерения у них разные
                                frm.sendMsg($"EDIT_countProducts;" +
                                            $"{Int32.Parse(product["Код товара"].ToString()) + products.Count / 2};" +  //productID
                                            $"{res}");                                                                 //countProducts                               
                            }
                            else
                            {
                                frm.sendMsg($"EDIT_countProducts;" +
                                        $"{product["Код товара"]};" +           //productID
                                        $"{res}");                              //countProducts
                            }
                        }
                    }
                }
            }
            MessageBox.Show("Успешно.");
            while (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(0);
            }
            sellBtn.Enabled = false;
        }

        private void but_close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
