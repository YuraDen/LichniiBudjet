using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LichniiBudjet
{
    public partial class Form6 : Form
    {
        static string Adr = "server=localhost;user=root;database=Scheta;port=3306;password=DB_My2025";
        MySqlConnection con = new MySqlConnection(Adr);
        public Form6()
        {
            InitializeComponent();
            D();
            M();
            VTB();
        }

        private void VTB()
        {
            con.Open();
            MySqlDataAdapter v = new MySqlDataAdapter("select * from prvtb", con);
            DataTable vtb = new DataTable();
            v.Fill(vtb);
            dataGridView1.DataSource = vtb;
            MySqlCommand cb = new MySqlCommand("SELECT Balans FROM vtb ORDER BY ID DESC LIMIT 1", con);
            int B = Convert.ToInt32(cb.ExecuteScalar());
            con.Close();
            label2.Text = B.ToString();
            DGVn();
        }

        private void SBER()
        {
            con.Open();
            MySqlDataAdapter s = new MySqlDataAdapter("select * from prsber", con);
            DataTable sber = new DataTable();
            s.Fill(sber);
            dataGridView1.DataSource = sber;
            MySqlCommand cb = new MySqlCommand("SELECT Balans FROM sber ORDER BY ID DESC LIMIT 1", con);
            int B = Convert.ToInt32(cb.ExecuteScalar());
            con.Close();
            label2.Text = B.ToString();
            DGVn();
        }

        private void CI()
        {
            con.Open();
            MySqlDataAdapter c = new MySqlDataAdapter("select * from prci", con);
            DataTable ci = new DataTable();
            c.Fill(ci);
            dataGridView1.DataSource = ci;
            MySqlCommand cb = new MySqlCommand("SELECT Balans FROM ci ORDER BY ID DESC LIMIT 1", con);
            int B = Convert.ToInt32(cb.ExecuteScalar());
            con.Close();
            label2.Text = B.ToString();
            DGVn();
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
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
        }

        private void DGVn()
        {
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

        private void Form6_Load(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OPV();
            radioButton1.Checked = true;
            VTB();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked) VTB();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked) SBER();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked) CI();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            // Замена шрифта на times.ttf (это Times New Roman) чтобы сохранялся русский текст, ещё можно arial.ttf и другие шрифты, которые поддерживают русский
            string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf"); 
            BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL);
            // Вызов saveFileDialog и создание документа
            saveFileDialog1.ShowDialog();
            FileStream stream = new FileStream(saveFileDialog1.FileName, FileMode.Create);
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 20f, 20f);
            PdfWriter.GetInstance(pdfDoc, stream);
            pdfDoc.Open();
            PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count);
            pdfTable.WidthPercentage = 100;
            // Заголовки
            foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    PdfPCell headerCell = new PdfPCell(new Phrase(column.HeaderText, font));
                    //headerCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    pdfTable.AddCell(headerCell);
                }
            // Данные строк
            foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            pdfTable.AddCell(new Phrase(cell.Value?.ToString() ?? string.Empty, font));
                        }
                    }
                }
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                con.Open();
                MySqlDataAdapter vdr = new MySqlDataAdapter("select * from prvtb where Oper = @Oper", con);
                vdr.SelectCommand.Parameters.AddWithValue("@Oper", comboBox1.Text);
                DataTable tdr = new DataTable();
                vdr.Fill(tdr);
                dataGridView1.DataSource = tdr;
                con.Close();
            }
            if (radioButton2.Checked)
            {
                con.Open();
                MySqlDataAdapter vdr = new MySqlDataAdapter("select * from prsber where Oper = @Oper", con);
                vdr.SelectCommand.Parameters.AddWithValue("@Oper", comboBox1.Text);
                DataTable tdr = new DataTable();
                vdr.Fill(tdr);
                dataGridView1.DataSource = tdr;
                con.Close();
            }
            if (radioButton3.Checked)
            {
                con.Open();
                MySqlDataAdapter vdr = new MySqlDataAdapter("select * from prci where Oper = @Oper", con);
                vdr.SelectCommand.Parameters.AddWithValue("@Oper", comboBox1.Text);
                DataTable tdr = new DataTable();
                vdr.Fill(tdr);
                dataGridView1.DataSource = tdr;
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                con.Open();
                MySqlDataAdapter vdat = new MySqlDataAdapter("select * from prvtb where Den = @Den and Nazv=@Nazv and God=@God", con);
                vdat.SelectCommand.Parameters.AddWithValue("@Den", comboBox2.Text);
                vdat.SelectCommand.Parameters.AddWithValue("@Nazv", comboBox3.Text);
                vdat.SelectCommand.Parameters.AddWithValue("@God", comboBox4.Text);
                DataTable tdr = new DataTable();
                vdat.Fill(tdr);
                dataGridView1.DataSource = tdr;
                con.Close();
            }
            if (radioButton2.Checked)
            {
                con.Open();
                MySqlDataAdapter vdat = new MySqlDataAdapter("select * from prsber where Den = @Den and Nazv=@Nazv and God=@God", con);
                vdat.SelectCommand.Parameters.AddWithValue("@Den", comboBox2.Text);
                vdat.SelectCommand.Parameters.AddWithValue("@Nazv", comboBox3.Text);
                vdat.SelectCommand.Parameters.AddWithValue("@God", comboBox4.Text);
                DataTable tdat = new DataTable();
                vdat.Fill(tdat);
                dataGridView1.DataSource = tdat;
                con.Close();
            }
            if (radioButton3.Checked)
            {
                con.Open();
                MySqlDataAdapter vdat = new MySqlDataAdapter("select * from prci where Den = @Den and Nazv=@Nazv and God=@God", con);
                vdat.SelectCommand.Parameters.AddWithValue("@Den", comboBox2.Text);
                vdat.SelectCommand.Parameters.AddWithValue("@Nazv", comboBox3.Text);
                vdat.SelectCommand.Parameters.AddWithValue("@God", comboBox4.Text);
                DataTable tdat = new DataTable();
                vdat.Fill(tdat);
                dataGridView1.DataSource = tdat;
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                con.Open();
                MySqlDataAdapter vm = new MySqlDataAdapter("select * from prvtb where Nazv=@Nazv", con);
                vm.SelectCommand.Parameters.AddWithValue("@Nazv", comboBox3.Text);
                DataTable tm = new DataTable();
                vm.Fill(tm);
                dataGridView1.DataSource = tm;
                con.Close();
            }
            if (radioButton2.Checked)
            {
                con.Open();
                MySqlDataAdapter vm = new MySqlDataAdapter("select * from prsber where Nazv=@Nazv", con);
                vm.SelectCommand.Parameters.AddWithValue("@Nazv", comboBox3.Text);
                DataTable tm = new DataTable();
                vm.Fill(tm);
                dataGridView1.DataSource = tm;
                con.Close();
            }
            if (radioButton3.Checked)
            {
                con.Open();
                MySqlDataAdapter vm = new MySqlDataAdapter("select * from prci where Nazv=@Nazv", con);
                vm.SelectCommand.Parameters.AddWithValue("@Nazv", comboBox3.Text);
                DataTable tm = new DataTable();
                vm.Fill(tm);
                dataGridView1.DataSource = tm;
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                con.Open();
                MySqlDataAdapter vg = new MySqlDataAdapter("select * from prvtb where God=@God", con);
                vg.SelectCommand.Parameters.AddWithValue("@God", comboBox4.Text);
                DataTable tg = new DataTable();
                vg.Fill(tg);
                dataGridView1.DataSource = tg;
                con.Close();
            }
            if (radioButton2.Checked)
            {
                con.Open();
                MySqlDataAdapter vg = new MySqlDataAdapter("select * from prsber where God=@God", con);
                vg.SelectCommand.Parameters.AddWithValue("@God", comboBox4.Text);
                DataTable tg = new DataTable();
                vg.Fill(tg);
                dataGridView1.DataSource = tg;
                con.Close();
            }
            if (radioButton3.Checked)
            {
                con.Open();
                MySqlDataAdapter vg = new MySqlDataAdapter("select * from prci where God=@God", con);
                vg.SelectCommand.Parameters.AddWithValue("@God", comboBox4.Text);
                DataTable tg = new DataTable();
                vg.Fill(tg);
                dataGridView1.DataSource = tg;
                con.Close();
            }
        }
    }
}
