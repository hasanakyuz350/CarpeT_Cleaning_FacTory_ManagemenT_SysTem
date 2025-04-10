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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Halı_Yıkama_Fabrikası
{
    public partial class state : Form
    {
        public state()
        {
            InitializeComponent();
        }
        private void state_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("name", "Ad");
            dataGridView1.Columns.Add("surname", "Soyad");
            dataGridView1.Columns.Add("phone_number", "Telefon Numarasi");
            dataGridView1.Columns.Add("address", "Adres");
            dataGridView1.Columns.Add("square", "Halının m²");
            dataGridView1.Columns.Add("received", "Alınan Tarihi");
            dataGridView1.Columns.Add("delivery", "Tahmini Teslim Tarihi");
            dataGridView1.Columns.Add("price", "ÜcreT(TL Cinsinden)");
            dataGridView1.Columns.Add("status", "Durum");

            string filepath_1;
            filepath_1 = "C:\\Users\\hasan\\source\\carpeT.txt";
            FileStream file_1 = new FileStream(filepath_1, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader_1 = new StreamReader(file_1);

            string line_1 = reader_1.ReadLine();
            while (line_1 != null)
            {
                string[] parts = line_1.Split(',');
                if (parts.Length >= 9)
                {
                    dataGridView1.Rows.Add(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], parts[6], parts[7], parts[8]);
                }
                line_1 = reader_1.ReadLine();
            }

            reader_1.Close();
            file_1.Close();
        }
        private void buttonguncelle_Click(object sender, EventArgs e)
        {
            Carpet carpet = new Carpet();
            carpet.status = comboBox1.Text;

            string filepath;
            filepath = "C:\\Users\\hasan\\source\\carpeT.txt";

            var lines = File.ReadAllLines(filepath).ToList();

            foreach (DataGridViewRow rows in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows[rows.Index].Cells["name"].Value = textBox4.Text;
                dataGridView1.Rows[rows.Index].Cells["surname"].Value = textBox5.Text;
                dataGridView1.Rows[rows.Index].Cells["phone_number"].Value = textBox6.Text;
                dataGridView1.Rows[rows.Index].Cells["address"].Value = textBox7.Text;
                dataGridView1.Rows[rows.Index].Cells["square"].Value = textBox1.Text;
                dataGridView1.Rows[rows.Index].Cells["received"].Value = textBox2.Text;
                dataGridView1.Rows[rows.Index].Cells["delivery"].Value = textBox3.Text;
                dataGridView1.Rows[rows.Index].Cells["price"].Value = textBox8.Text;
                dataGridView1.Rows[rows.Index].Cells["status"].Value = carpet.status;

                string yeni = $"{textBox4.Text},{textBox5.Text},{textBox6.Text},{textBox7.Text},{textBox1.Text},{textBox2.Text},{textBox3.Text},{textBox8.Text},{carpet.status}";

                lines[rows.Index] = yeni;
            }
            File.WriteAllLines(filepath, lines);
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["surname"].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["phone_number"].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["address"].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["square"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["received"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["delivery"].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells["price"].Value.ToString();
        }
    }
}
