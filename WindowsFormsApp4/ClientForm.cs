using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class ClientForm : Form
    {
        ClientClass client = new ClientClass();
        DBconnection connect = new DBconnection();
        OffersClass offer = new OffersClass();
        Verify ver = new Verify();
        public ClientForm()
        {
            InitializeComponent();
            showDataTable();
            showClientList();
            showDataOffer();
            showDataReg();
            showDataOffer1();
        }
        bool verify()
        {
            if ((textBox_surName.Text == "") || (textBox_firstName.Text == "") || (textBox_pat.Text == "") || (textBox_phonNum.Text == ""))
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Расширения(*.jpg;*.png;*.gif) | *.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox_Client.Image = Image.FromFile(opf.FileName);
            }
        }
        public void showDataTable()
        {
            comboBox_client.DataSource = client.getclientlist();
            comboBox_client.DisplayMember = "Sur_Name";
            comboBox_client.ValueMember = "Sur_Name";
        }
        public void showDataOffer()
        {
            comboBox_offerlist.DataSource = offer.getofferlist();
            comboBox_offerlist.DisplayMember = "name";
            comboBox_offerlist.ValueMember = "name";
        }
        public void showDataOffer1()
        {
            comboBox_offerlist1.DataSource = offer.getofferlist();
            comboBox_offerlist1.DisplayMember = "name";
            comboBox_offerlist.ValueMember = "name";
        }
        public void showDataReg()
        {
            comboBox_name.DataSource = client.getregclientlist();
            comboBox_name.DisplayMember = "Sur_Name";
            comboBox_name.ValueMember = "Sur_Name";
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            string Sur_Name = textBox_surName.Text;
            string First_Name = textBox_firstName.Text.ToString();
            string Patronymic = textBox_pat.Text;
            string Phon_Num = textBox_phonNum.Text;

            if (verify())
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    pictureBox_Client.Image.Save(ms, pictureBox_Client.Image.RawFormat);
                    byte[] Image = ms.ToArray();
                    if (client.insertclient(Sur_Name, First_Name, Patronymic,Phon_Num, Image))
                    {
                        MessageBox.Show("Новые данные успешно добавлены", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Updateclient();
        }
        public void showClientList()
        {
            dataGridView1.DataSource = client.getregclientlist();
            DataGridViewColumn Column = new DataGridViewColumn();
            Column = dataGridView1.Columns[7];

        }
        public void showOfferList()
        {
            dataGridView2.DataSource = getClientByOffer();
            DataGridViewColumn Column = new DataGridViewColumn();
            Column = dataGridView2.Columns[3];

        }

        public bool Updateclient()
        {

            MySqlCommand command = new MySqlCommand("UPDATE clients SET  Registered = 'Зарегистрирован'  WHERE Sur_Name= '" + comboBox_client.Text.ToString() + "' ", connect.getconnection);

            connect.openConnect();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Данные успешно изменены", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connect.closeConnect();
                return true;
            }
            else
            {
                connect.closeConnect();
                return false;
            }
        }

        public bool InsertOffer()
        {

            MySqlCommand command = new MySqlCommand("UPDATE clients SET  Offers = '"+comboBox_offerlist.Text.ToString()+"' WHERE Sur_Name= '" + comboBox_name.Text.ToString() + "' ", connect.getconnection);

            connect.openConnect();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Данные успешно изменены", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connect.closeConnect();
                return true;
            }
            else
            {
                connect.closeConnect();
                return false;
            }
        }
        public DataTable getClientByOffer()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `clients` WHERE  Offers = '"+comboBox_offerlist1.Text.ToString()+"'", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            InsertOffer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showOfferList();
        }

        private void textBox_surName_KeyPress(object sender, KeyPressEventArgs e)
        {
            ver.number(sender,e);
        }

        private void textBox_firstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            ver.number(sender, e);
        }

        private void textBox_pat_KeyPress(object sender, KeyPressEventArgs e)
        {
            ver.number(sender, e);
        }

        private void textBox_phonNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            ver.phonnumber(sender, e);
        }
    }
}
