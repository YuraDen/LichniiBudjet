using MySql.Data.MySqlClient;
using Mysqlx.Prepare;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LichniiBudjet
{
    public partial class Form3 : Form
    {
        static string Adr = "server=localhost;user=root;database=Scheta;port=3306;password=DB_My2025";
        MySqlConnection con = new MySqlConnection(Adr);
        int ID = 0, B = 0, ib = 0;
        public Form3()
        {
            InitializeComponent();
            VTB();
            D();
            M();
        }

        private void VTB()
        {
            con.Open();
            MySqlDataAdapter v = new MySqlDataAdapter("select * from prvtb", con);
            DataTable vtb = new DataTable();
            v.Fill(vtb);
            dataGridView1.DataSource = vtb;
            MySqlCommand cb = new MySqlCommand("SELECT Balans FROM vtb ORDER BY ID DESC LIMIT 1", con);
            B = Convert.ToInt32(cb.ExecuteScalar());
            con.Close();
            label2.Text = B.ToString();
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 70;
            dataGridView1.Columns[1].HeaderText = "Сумма";
            dataGridView1.Columns[2].Width = 50;
            dataGridView1.Columns[2].HeaderText = "+/-";
            dataGridView1.Columns[3].Width = 70;
            dataGridView1.Columns[3].HeaderText = "Баланс";
            dataGridView1.Columns[4].Width = 50;
            dataGridView1.Columns[4].HeaderText = "День";
            dataGridView1.Columns[5].Width = 50;
            dataGridView1.Columns[5].HeaderText = "Месяц";
            dataGridView1.Columns[6].Width = 50;
            dataGridView1.Columns[6].HeaderText = "Год";
            dataGridView1.Columns[7].Width = 130;
            dataGridView1.Columns[7].HeaderText = "Примечание";
        }

        private void D()
        {
            comboBox1.Items.Clear();
            con.Open();
            MySqlCommand cD = new MySqlCommand("SELECT * FROM doh", con);
            MySqlDataReader rD = cD.ExecuteReader();
            while (rD.Read())
            {
                comboBox1.Items.Add(rD["Oper"]);
            }
            comboBox1.SelectedIndex = -1;
            con.Close();
        }

        private void M()
        {
            comboBox3.Items.Clear();
            con.Open();
            MySqlCommand cM = new MySqlCommand("SELECT * FROM mesac", con);
            MySqlDataReader rM = cM.ExecuteReader();
            while (rM.Read())
            {
                comboBox3.Items.Add(rM["Nazv"]);
            }
            comboBox3.SelectedIndex = -1;
            con.Close();
        }

        private void OPV()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OPV();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int s = 0;
            s = Convert.ToInt32(textBox1.Text);
            B += s;            
            con.Open();
            MySqlCommand ciD = new MySqlCommand("SELECT ID FROM doh where Oper=@Oper", con);
            ciD.Parameters.AddWithValue("@Oper", comboBox1.Text);
            int indD = Convert.ToInt32(ciD.ExecuteScalar());
            MySqlCommand ciM = new MySqlCommand("SELECT ID FROM mesac where Nazv=@Nazv", con);
            ciM.Parameters.AddWithValue("@Nazv", comboBox3.Text);
            int indM = Convert.ToInt32(ciM.ExecuteScalar());
            MySqlCommand cp = new MySqlCommand("insert into vtb (Summa, DohRash, Balans, Den, Mes, God, Primechanie) value (@Summa, @DohRash, @Balans, @Den, @Mes, @God, @Primechanie)", con);
            cp.Parameters.AddWithValue("@Summa", s);
            cp.Parameters.AddWithValue("@DohRash", indD);
            cp.Parameters.AddWithValue("@Balans", B);
            cp.Parameters.AddWithValue("@Den", Convert.ToInt32(comboBox2.Text));
            cp.Parameters.AddWithValue("@Mes", indM);
            cp.Parameters.AddWithValue("@God", Convert.ToInt32(comboBox4.Text));
            cp.Parameters.AddWithValue("@Primechanie", textBox2.Text);
            cp.ExecuteNonQuery();
            con.Close();
            VTB();
            OPV();
            MessageBox.Show("Проводка выполнена");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            B -= ib;
            int s = 0;
            s = Convert.ToInt32(textBox1.Text);
            B += s;
            con.Open();
            MySqlCommand ciD = new MySqlCommand("SELECT ID FROM doh where Oper=@Oper", con);
            ciD.Parameters.AddWithValue("@Oper", comboBox1.Text);
            int indD = Convert.ToInt32(ciD.ExecuteScalar());
            MySqlCommand ciM = new MySqlCommand("SELECT ID FROM mesac where Nazv=@Nazv", con);
            ciM.Parameters.AddWithValue("@Nazv", comboBox3.Text);
            int indM = Convert.ToInt32(ciM.ExecuteScalar());
            MySqlCommand cip = new MySqlCommand("update vtb set Summa=@Summa, DohRash=@DohRash, Balans=@Balans, Den=@Den, Mes=@Mes, God=@God, Primechanie=@Primechanie where ID=@ID", con);
            cip.Parameters.AddWithValue("@ID", ID);
            cip.Parameters.AddWithValue("@Summa", s);
            cip.Parameters.AddWithValue("@DohRash", indD);
            cip.Parameters.AddWithValue("@Balans", B);
            cip.Parameters.AddWithValue("@Den", Convert.ToInt32(comboBox2.Text));
            cip.Parameters.AddWithValue("@Mes", indM);
            cip.Parameters.AddWithValue("@God", Convert.ToInt32(comboBox4.Text));
            cip.Parameters.AddWithValue("@Primechanie", textBox2.Text);
            cip.ExecuteNonQuery();
            con.Close();
            VTB();
            OPV();
            checkBox1.Checked = false;
            MessageBox.Show("Проводка изменена");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            B -= ib;
            con.Open();
            MySqlCommand cup = new MySqlCommand("delete from vtb where ID=@ID", con);
            cup.Parameters.AddWithValue("@ID", ID);
            cup.ExecuteNonQuery();
            con.Close();
            VTB();
            OPV();
            checkBox1.Checked = false;
            MessageBox.Show("Проводка удалена");
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1) textBox1.Text = "-";
            else textBox1.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            ib = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);            
            string doh = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
            string D = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
            string M = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);
            string G = Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value);
            string P = Convert.ToString(dataGridView1.CurrentRow.Cells[7].Value);
            textBox1.Text = "";
            comboBox1.Text = doh;
            textBox1.Text = textBox1.Text+Math.Abs(ib).ToString();
            comboBox2.Text = D;
            comboBox3.Text = M;
            comboBox4.Text = G;
            textBox2.Text = P;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) {
                button2.Visible = true;
                button3.Visible = true;
            }
            else
            {
                button2.Visible = false;
                button3.Visible = false;
            }
        }
    }
}
