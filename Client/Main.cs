using Client;
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
    public partial class Main : Form
    {
        public struct User
        {
            public int id;
            public string name;
        }
        public User currentUser;

        ClientSocket client;
        public Main()
        {
            InitializeComponent();
        }
        private void loadForm(Form form) //метод для открытия новых форм 
        {
            form.ShowDialog();
        }
        public void setUser(string user)
        {
            toolStripStatusLabel1.Text = $"Пользователь: {user}";
        }
        public string sendMsg(string msg)
        { //отправляем сообщение на сервер и получаем ответ в виде строки
            return client.sendMsg(msg);
        }
        private void sellButton_Click(object sender, EventArgs e)
        {
            //loadForm(new SellForm { Owner = this });
            string deal = "sell";
            loadForm(new Trade(deal) { Owner = this });
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            client = new ClientSocket();
            loadForm(new SetUser { Owner = this }); //выбираем пользователя
        }
        private void toolStripDropDownButton1_Click_1(object sender, EventArgs e)
        {
            loadForm(new SetUser { Owner = this });
        }
        private void but_Guide_Click_1(object sender, EventArgs e)
        {
            loadForm(new Guide { Owner = this });
        }
        private void but_Reports_Click_1(object sender, EventArgs e)
        {
            loadForm(new Reports { Owner = this });
        }
        private void buyButton_Click(object sender, EventArgs e)
        {
            //loadForm(new BuyForm { Owner = this });
            string deal = "buy";
            loadForm(new Trade(deal) { Owner = this });
        }

        private void testBtn_Click(object sender, EventArgs e)
        {
            //testBtn.Text = sendMsg("EDIT_countProducts;3;55");
            //string deal = "buy";
            //loadForm(new SellForm(deal) { Owner = this });
        }
    }
}
