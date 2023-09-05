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
using Newtonsoft.Json.Linq;

namespace Client
{
    public partial class SetUser : Form
    {
        Main frm;
        public SetUser()
        {
            InitializeComponent();
            //comboBox1.Items.Add("Жека");
            //comboBox1.Items.Add("Диман");
            //comboBox1.Items.Add("Макс");
            //comboBox1.Items.Add("Тима");
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var userName = comboBox1.Text;
            
            if (userName != "")
            {
                frm.currentUser = new Main.User
                {
                    id = comboBox1.ValueMember[comboBox1.SelectedIndex],
                    name = userName
                };
                frm.setUser(userName);
                this.Close();
            }
            else
            {
                MessageBox.Show("Пользователь не выбран!");
            }
        }

        private void SetUserForm_Load(object sender, EventArgs e)
        {
            frm = (Main)this.Owner;
            string msg = frm.sendMsg("Get_ListOfEmployees").Split('|')[1];
            DataTable userData = JsonConvert.DeserializeObject<DataTable>(msg);
            comboBox1.DataSource = userData;
            comboBox1.ValueMember = "Код сотрудника";
            comboBox1.DisplayMember = "ФИО";
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
