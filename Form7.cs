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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LichniiBudjet
{
    public partial class Form7 : Form
    {
        static string Adr = "server=localhost;user=root;database=Scheta;port=3306;password=DB_My2025";
        MySqlConnection con = new MySqlConnection(Adr);
        int bv = 0, bs = 0, bc = 0, sp = 0;
        public Form7()
        {
            InitializeComponent();
            M();
            Balans();
        }

        private void Balans()
        {
            con.Open();
            MySqlCommand cbv = new MySqlCommand("SELECT Balans FROM vtb ORDER BY ID DESC LIMIT 1", con);
            bv = Convert.ToInt32(cbv.ExecuteScalar());
            MySqlCommand cbs = new MySqlCommand("SELECT Balans FROM sber ORDER BY ID DESC LIMIT 1", con);
            bs = Convert.ToInt32(cbs.ExecuteScalar());
            MySqlCommand cbc = new MySqlCommand("SELECT Balans FROM ci ORDER BY ID DESC LIMIT 1", con);
            bc = Convert.ToInt32(cbc.ExecuteScalar());
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sp = Convert.ToInt32(textBox1.Text);
            // Списание со счета
            if (comboBox1.Text == "ВТБ")
            {
                if (sp > bv) { 
                   MessageBox.Show("На счёте не достаточно средств для перевода");
                    return;
                } 
                else
                {
                    con.Open();
                    MySqlCommand ciM = new MySqlCommand("SELECT ID FROM mesac where Nazv=@Nazv", con);
                    ciM.Parameters.AddWithValue("@Nazv", comboBox3.Text);
                    int indM = Convert.ToInt32(ciM.ExecuteScalar());
                    MySqlCommand cp = new MySqlCommand("insert into vtb (Summa, DohRash, Balans, Den, Mes, God, Primechanie) value (@Summa, @DohRash, @Balans, @Den, @Mes, @God, @Primechanie)", con);
                    cp.Parameters.AddWithValue("@Summa", -sp);
                    cp.Parameters.AddWithValue("@DohRash", 2);
                    cp.Parameters.AddWithValue("@Balans", bv - sp);
                    cp.Parameters.AddWithValue("@Den", Convert.ToInt32(comboBox5.Text));
                    cp.Parameters.AddWithValue("@Mes", indM);
                    cp.Parameters.AddWithValue("@God", Convert.ToInt32(comboBox4.Text));
                    cp.Parameters.AddWithValue("@Primechanie", "Перевод на счёт в " + comboBox2.Text);
                    cp.ExecuteNonQuery();
                    con.Close();
                }
            }
            else if (comboBox1.Text == "Сбер")
            {
                if (sp > bs)
                {
                    MessageBox.Show("На счёте не достаточно средств для перевода");
                    return;
                }
                else
                {
                    con.Open();
                    MySqlCommand ciM = new MySqlCommand("SELECT ID FROM mesac where Nazv=@Nazv", con);
                    ciM.Parameters.AddWithValue("@Nazv", comboBox3.Text);
                    int indM = Convert.ToInt32(ciM.ExecuteScalar());
                    MySqlCommand cp = new MySqlCommand("insert into sber (Summa, DohRash, Balans, Den, Mes, God, Primechanie) value (@Summa, @DohRash, @Balans, @Den, @Mes, @God, @Primechanie)", con);
                    cp.Parameters.AddWithValue("@Summa", -sp);
                    cp.Parameters.AddWithValue("@DohRash", 2);
                    cp.Parameters.AddWithValue("@Balans", bs - sp);
                    cp.Parameters.AddWithValue("@Den", Convert.ToInt32(comboBox5.Text));
                    cp.Parameters.AddWithValue("@Mes", indM);
                    cp.Parameters.AddWithValue("@God", Convert.ToInt32(comboBox4.Text));
                    cp.Parameters.AddWithValue("@Primechanie", "Перевод на счёт в " + comboBox2.Text);
                    cp.ExecuteNonQuery();
                    con.Close();
                }
            }
            else if (comboBox1.Text == "Центр - Инвест")
            {
                if (sp > bc)
                {
                    MessageBox.Show("На счёте не достаточно средств для перевода");
                    return;
                }
                else
                {
                    con.Open();
                    MySqlCommand ciM = new MySqlCommand("SELECT ID FROM mesac where Nazv=@Nazv", con);
                    ciM.Parameters.AddWithValue("@Nazv", comboBox3.Text);
                    int indM = Convert.ToInt32(ciM.ExecuteScalar());
                    MySqlCommand cp = new MySqlCommand("insert into ci (Summa, DohRash, Balans, Den, Mes, God, Primechanie) value (@Summa, @DohRash, @Balans, @Den, @Mes, @God, @Primechanie)", con);
                    cp.Parameters.AddWithValue("@Summa", -sp);
                    cp.Parameters.AddWithValue("@DohRash", 2);
                    cp.Parameters.AddWithValue("@Balans", bc - sp);
                    cp.Parameters.AddWithValue("@Den", Convert.ToInt32(comboBox5.Text));
                    cp.Parameters.AddWithValue("@Mes", indM);
                    cp.Parameters.AddWithValue("@God", Convert.ToInt32(comboBox4.Text));
                    cp.Parameters.AddWithValue("@Primechanie", "Перевод на счёт в " + comboBox2.Text);
                    cp.ExecuteNonQuery();
                    con.Close();
                }
            }
            // Поступление на счёт
            if (comboBox2.Text == "ВТБ")
            {
                con.Open();
                MySqlCommand ciM = new MySqlCommand("SELECT ID FROM mesac where Nazv=@Nazv", con);
                ciM.Parameters.AddWithValue("@Nazv", comboBox3.Text);
                int indM = Convert.ToInt32(ciM.ExecuteScalar());
                MySqlCommand cp = new MySqlCommand("insert into vtb (Summa, DohRash, Balans, Den, Mes, God, Primechanie) value (@Summa, @DohRash, @Balans, @Den, @Mes, @God, @Primechanie)", con);
                cp.Parameters.AddWithValue("@Summa", sp);
                cp.Parameters.AddWithValue("@DohRash", 1);
                cp.Parameters.AddWithValue("@Balans", bv + sp);
                cp.Parameters.AddWithValue("@Den", Convert.ToInt32(comboBox5.Text));
                cp.Parameters.AddWithValue("@Mes", indM);
                cp.Parameters.AddWithValue("@God", Convert.ToInt32(comboBox4.Text));
                cp.Parameters.AddWithValue("@Primechanie", "Перевод со счёта " + comboBox1.Text);
                cp.ExecuteNonQuery();
                con.Close();
            }
            else if (comboBox2.Text == "Сбер")
            {
                con.Open();
                MySqlCommand ciM = new MySqlCommand("SELECT ID FROM mesac where Nazv=@Nazv", con);
                ciM.Parameters.AddWithValue("@Nazv", comboBox3.Text);
                int indM = Convert.ToInt32(ciM.ExecuteScalar());
                MySqlCommand cp = new MySqlCommand("insert into sber (Summa, DohRash, Balans, Den, Mes, God, Primechanie) value (@Summa, @DohRash, @Balans, @Den, @Mes, @God, @Primechanie)", con);
                cp.Parameters.AddWithValue("@Summa", sp);
                cp.Parameters.AddWithValue("@DohRash", 1);
                cp.Parameters.AddWithValue("@Balans", bs + sp);
                cp.Parameters.AddWithValue("@Den", Convert.ToInt32(comboBox5.Text));
                cp.Parameters.AddWithValue("@Mes", indM);
                cp.Parameters.AddWithValue("@God", Convert.ToInt32(comboBox4.Text));
                cp.Parameters.AddWithValue("@Primechanie", "Перевод со счёта " + comboBox1.Text);
                cp.ExecuteNonQuery();
                con.Close();
            }
            else if (comboBox2.Text == "Центр - Инвест")
            {
                con.Open();
                MySqlCommand ciM = new MySqlCommand("SELECT ID FROM mesac where Nazv=@Nazv", con);
                ciM.Parameters.AddWithValue("@Nazv", comboBox3.Text);
                int indM = Convert.ToInt32(ciM.ExecuteScalar());
                MySqlCommand cp = new MySqlCommand("insert into ci (Summa, DohRash, Balans, Den, Mes, God, Primechanie) value (@Summa, @DohRash, @Balans, @Den, @Mes, @God, @Primechanie)", con);
                cp.Parameters.AddWithValue("@Summa", sp);
                cp.Parameters.AddWithValue("@DohRash", 1);
                cp.Parameters.AddWithValue("@Balans", bc + sp);
                cp.Parameters.AddWithValue("@Den", Convert.ToInt32(comboBox5.Text));
                cp.Parameters.AddWithValue("@Mes", indM);
                cp.Parameters.AddWithValue("@God", Convert.ToInt32(comboBox4.Text));
                cp.Parameters.AddWithValue("@Primechanie", "Перевод со счёта " + comboBox1.Text);
                cp.ExecuteNonQuery();
                con.Close();
            }
            MessageBox.Show("Перевод выполнен");
            OPV();
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
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OPV();
        }
    }
}
