using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LichniiBudjet
{
    public partial class Form2 : Form
    {
        static string Adr = "server=localhost;user=root;database=Scheta;port=3306;password=DB_My2025";
        MySqlConnection con = new MySqlConnection(Adr);
        public Form2()
        {
            InitializeComponent();
            B();
        }

        private void B()
        {
            con.Open();
            MySqlCommand cbV = new MySqlCommand("SELECT Balans FROM vtb ORDER BY ID DESC LIMIT 1", con);
            int BV = Convert.ToInt32(cbV.ExecuteScalar());
            MySqlCommand cbS = new MySqlCommand("SELECT Balans FROM sber ORDER BY ID DESC LIMIT 1", con);
            int BS = Convert.ToInt32(cbS.ExecuteScalar());
            MySqlCommand cbC = new MySqlCommand("SELECT Balans FROM ci ORDER BY ID DESC LIMIT 1", con);
            int BC = Convert.ToInt32(cbC.ExecuteScalar());
            con.Close();
            int OB = BV + BS + BC;
            label2.Text = OB.ToString() + " рублей";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            B();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.ShowDialog();
        }
    }
}
