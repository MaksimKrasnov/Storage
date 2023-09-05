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
using System.Text.RegularExpressions;


namespace Client
{
    public partial class Suppliers : Form
    {
        ClientSocket client;
        string request = "";
        int ed = 0;
        int indx = 0;
        public Suppliers()
        {
            InitializeComponent();            
        }

        private void Suppliers_Load(object sender, EventArgs e)
        {
            client = new ClientSocket();
            //отправка запроса на сервер для получения списка поставщиков
            request = "Get_ListOfOrg";
            string jsonString = client.sendMsg(request).Split('|')[1];
            JArray suppliers = JArray.Parse(jsonString);
            foreach (var supplier in suppliers)
            {
                dataGridView1.Rows.Add(supplier["Код организации"],
                                       supplier["Название организации"],
                                       supplier["Адрес"],
                                       supplier["Телефон"]);
            }
            isEmptyList();
        }

        //проверяем есть ли элементы в списке поставщиков
        private bool isEmptyList()
        {
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("Список поставщиков пуст");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void enabledOff()
        {
            but_AddNewSuppl.Enabled =
            but_DeleteSuppl.Enabled =
            but_EditSuppl.Enabled = false;
        }

        //добавление нового поставщика
        private void but_AddNewSuppl_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
            enabledOff();
            but_Save.Enabled = true;
            dataGridView1[1, dataGridView1.RowCount - 1].ReadOnly = false;
            dataGridView1[2, dataGridView1.RowCount - 1].ReadOnly = false;
            dataGridView1[3, dataGridView1.RowCount - 1].ReadOnly = false;
            request = "ADD_org;";
        }

        private void but_Exit_Click(object sender, EventArgs e)
        {
            if(but_Save.Enabled == true)
            {
                DialogResult dialogResult = MessageBox.Show("Выйти без сохранения?", "Изменения не были сохранены", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }                  
            }
            Close();
        }

        //удаление поставщика
        private void but_DeleteSuppl_Click(object sender, EventArgs e)
        {
            //отправляем запрос на сервер для удаления компании целиком
            // в запросе отправляем название компании (orgName)и (ID_Delete)  
            if (!isEmptyList())
            {                
                enabledOff();
                request = $"DELETE_org;{dataGridView1[0, dataGridView1.SelectedCells[0].RowIndex].Value}";
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                but_Save.Enabled = true;
            }
        }

        //сохранить изменения
        private void but_Save_Click(object sender, EventArgs e)
        {
            // подается запрос на сервер со строкой "res"
            if (dataGridView1[1, dataGridView1.SelectedCells[0].RowIndex].Value == null ||
                dataGridView1[2, dataGridView1.SelectedCells[0].RowIndex].Value == null ||
                dataGridView1[3, dataGridView1.SelectedCells[0].RowIndex].Value == null)
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                but_choice(request);
                client.sendMsg(request);
                MessageBox.Show("Изменения сохранены.");
                dataGridView1.Refresh();
                Suppliers.ActiveForm.Close();
            }
        }

        //редактировать данные поставщика
        private void but_EditSuppl_Click(object sender, EventArgs e)
        {
            if (!isEmptyList())
            {
                enabledOff();
                if(ed == 0)
                {
                    MessageBox.Show("Выберите компанию для редктиррования и нажмите " + "\"Изменить\".");
                    but_EditSuppl.Text = "Изменить";
                    but_EditSuppl.Enabled = true;
                    ed = 1;
                }
                else
                {
                    MessageBox.Show("Отредактируйте выбранную строку");
                    indx = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1[1, indx].ReadOnly = false;
                    dataGridView1[2, indx].ReadOnly = false;
                    dataGridView1[3, indx].ReadOnly = false;
                    but_Save.Enabled = true;
                    request = $"EDIT_org;";
                }
            }
        }

        private void DataGridView1_ReadOnlyChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        //формирование строки запроса
        private void but_choice(string newString)
        {
            if (newString == "ADD_org;")
            {

                request += $"{dataGridView1[1, dataGridView1.RowCount - 1].Value};" +
                           $"{dataGridView1[2, dataGridView1.RowCount - 1].Value};" +
                           $"{dataGridView1[3, dataGridView1.RowCount - 1].Value}";
            }
            else if (newString == "EDIT_org;")
            {
                request += $"{dataGridView1[0, indx].Value};"+
                           $"{dataGridView1[1, indx].Value};"+
                           $"{dataGridView1[2, indx].Value};"+
                           $"{dataGridView1[3, indx].Value}";
            }
        }

        //метод для проверки строки на корректность
        private void checkString(string phoneNumber)
        {
            const string numbers = @"[^0-9\s:]";
            if (phoneNumber != null)
            {
                if (Regex.IsMatch(phoneNumber, numbers, RegexOptions.IgnoreCase))
                {
                    MessageBox.Show("Некорректный ввод телефона");
                    dataGridView1[3, dataGridView1.SelectedCells[0].RowIndex].Value = null;                                      
                }
            }           
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            //если выбранная ячейка из третьей колонки(номер телефона)
            if(dataGridView1.CurrentCell == dataGridView1[3, dataGridView1.SelectedCells[0].RowIndex])
            {
                if (dataGridView1[3, dataGridView1.SelectedCells[0].RowIndex].Value != null)
                {
                    //проверяем на правильность ввода номера телефона
                    checkString(dataGridView1[3, dataGridView1.SelectedCells[0].RowIndex].Value.ToString());
                }
            }

        }
    }
}
