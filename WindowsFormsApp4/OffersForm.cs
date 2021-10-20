using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class OffersForm : Form
    {
        OffersClass offer = new OffersClass();
        Verify ver = new Verify();
        public OffersForm()
        {
            InitializeComponent();
            showDataTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox_offName.Text;
            string disc = textBox_offDisc.Text;
            string price = textBox_offPrice.Text;


            if (verify())
            {
                try
                {

                    if (offer.insertoffer(name,disc,price))
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

        public void showDataTable()
        {
            comboBox_offer.DataSource = offer.getofferlist();
            comboBox_offer.DisplayMember = "name";
            comboBox_offer.ValueMember = "name";
        }
        public void showClientList()
        {
            dataGridView1.DataSource = offer.getofferlist();
            DataGridViewColumn Column = new DataGridViewColumn();
            Column = dataGridView1.Columns[3];

        }
        bool verify()
        {
            if ((textBox_offName.Text == "") || (textBox_offDisc.Text == "") || (textBox_offPrice.Text == ""))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            showClientList();
        }

        private void textBox_offName_KeyPress(object sender, KeyPressEventArgs e)
        {
            ver.number(sender,e);
        }

        private void textBox_offDisc_KeyPress(object sender, KeyPressEventArgs e)
        {
            ver.number(sender, e);

        }

        private void textBox_offPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            ver.word(sender, e);

        }
    }
}
