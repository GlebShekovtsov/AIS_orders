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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Form activeForm = null;
        private void OpenAddClient(Form ClientForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = ClientForm;
            ClientForm.TopLevel = false;
            ClientForm.FormBorderStyle = FormBorderStyle.None;
            ClientForm.Dock = DockStyle.Fill;
            panel1.Controls.Add(ClientForm);
            panel1.Tag = ClientForm;
            ClientForm.BringToFront();
            ClientForm.Show();
        }
        private void OpenAddOffer(Form OffersForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = OffersForm;
            OffersForm.TopLevel = false;
            OffersForm.FormBorderStyle = FormBorderStyle.None;
            OffersForm.Dock = DockStyle.Fill;
            panel1.Controls.Add(OffersForm);
            panel1.Tag = OffersForm;
            OffersForm.BringToFront();
            OffersForm.Show();
        }
        private void пользовательToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenAddClient(new ClientForm());
        }

        private void услугиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenAddOffer(new OffersForm());
        }
    }
}
