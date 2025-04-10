using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Halı_Yıkama_Fabrikası
{
    public partial class carpet : Form
    {
        public carpet()
        {
            InitializeComponent();
        }
        private void buttonekle_Click(object sender, EventArgs e)
        {
            string filepath;
            filepath = "C:\\Users\\hasan\\source\\carpeT.txt";
            FileStream file = new FileStream(filepath, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file);

            Carpet carpet = new Carpet();
            carpet.carpetsquaremeter = Convert.ToInt32(textBox1.Text);
            carpet.received = textBox2.Text;
            carpet.delivery = textBox3.Text;
            int ucreT = Convert.ToInt32(textBox1.Text) * 20;
            carpet.status = "Alındı";

            writer.WriteLine(textBox4.Text + "," + textBox5.Text + "," + textBox6.Text + "," + textBox7.Text + "," + carpet.carpetsquaremeter + "," + carpet.received + "," + carpet.delivery + "," + ucreT + "," + carpet.status);

            writer.Flush();

            writer.Close();
            file.Close();

            int rows = Convert.ToInt32(dataGridView2.Rows.Add());

            dataGridView2.Rows[rows].Cells["name"].Value = textBox4.Text;
            dataGridView2.Rows[rows].Cells["surname"].Value = textBox5.Text;
            dataGridView2.Rows[rows].Cells["phone_number"].Value = textBox6.Text;
            dataGridView2.Rows[rows].Cells["address"].Value = textBox7.Text;
            dataGridView2.Rows[rows].Cells["square"].Value = carpet.carpetsquaremeter;
            dataGridView2.Rows[rows].Cells["received"].Value = carpet.received;
            dataGridView2.Rows[rows].Cells["delivery"].Value = carpet.delivery;
            dataGridView2.Rows[rows].Cells["price"].Value = ucreT;
            dataGridView2.Rows[rows].Cells["status"].Value = carpet.status;
        }
        private void buttonsil_Click(object sender, EventArgs e)
        {
            Carpet carpet = new Carpet();
            int deger;
            if (int.TryParse(textBox1.Text, out deger))
            {
                carpet.carpetsquaremeter = deger;
            }
            carpet.received = textBox2.Text;
            carpet.delivery = textBox3.Text;
            string ucreT = " ";

            string filepath;
            filepath = "C:\\Users\\hasan\\source\\carpeT.txt";

            var lines = File.ReadAllLines(filepath).ToList();

            foreach (DataGridViewRow rows in dataGridView2.SelectedRows)
            {
                string eskiisim = dataGridView2.Rows[rows.Index].Cells["name"].Value.ToString();
                string eskisoyisim = dataGridView2.Rows[rows.Index].Cells["surname"].Value.ToString();
                string eskinumara = dataGridView2.Rows[rows.Index].Cells["phone_number"].Value.ToString();
                string eskiadres = dataGridView2.Rows[rows.Index].Cells["address"].Value.ToString();
                string eskikare = dataGridView2.Rows[rows.Index].Cells["square"].Value.ToString();
                string eskialım = dataGridView2.Rows[rows.Index].Cells["received"].Value.ToString();
                string eskiteslim = dataGridView2.Rows[rows.Index].Cells["delivery"].Value.ToString();
                string eskiucreT = dataGridView2.Rows[rows.Index].Cells["price"].Value.ToString();
                string eskidurum = dataGridView2.Rows[rows.Index].Cells["status"].Value.ToString();

                dataGridView2.Rows[rows.Index].Cells["name"].Value = textBox4.Text;
                dataGridView2.Rows[rows.Index].Cells["surname"].Value = textBox5.Text;
                dataGridView2.Rows[rows.Index].Cells["phone_number"].Value = textBox6.Text;
                dataGridView2.Rows[rows.Index].Cells["address"].Value = textBox7.Text;
                dataGridView2.Rows[rows.Index].Cells["square"].Value = carpet.carpetsquaremeter;
                dataGridView2.Rows[rows.Index].Cells["received"].Value = carpet.received;
                dataGridView2.Rows[rows.Index].Cells["delivery"].Value = carpet.delivery;
                dataGridView2.Rows[rows.Index].Cells["price"].Value = ucreT;
                dataGridView2.Rows[rows.Index].Cells["status"].Value = carpet.status;

                string eski = $"{eskiisim},{eskisoyisim},{eskinumara},{eskiadres},{eskikare},{eskialım},{eskiteslim},{eskiucreT},{eskidurum}";
                string yeni = $"{textBox4.Text},{textBox5.Text},{textBox6.Text},{textBox7.Text},{carpet.carpetsquaremeter},{carpet.received},{carpet.delivery},{ucreT},{carpet.status}";

                for (int i = 0; i < lines.Count; i++)
                {
                    if (lines[i].Trim() == eski.Trim())
                    {
                        lines[i] = yeni;
                        break;
                    }
                }
            }

            foreach (DataGridViewRow rows in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(rows);
            }

            File.WriteAllLines(filepath, lines);
        }
        private void carpet_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("name", "Ad");
            dataGridView1.Columns.Add("surname", "Soyad");
            dataGridView1.Columns.Add("phone_number", "Telefon Numarası");
            dataGridView1.Columns.Add("address", "Adres");

            string filepath;
            filepath = "C:\\Users\\hasan\\source\\cusTomer.txt";
            FileStream file = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            string line = reader.ReadLine();
            while (line != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length >= 4)
                {
                    dataGridView1.Rows.Add(parts[0], parts[1], parts[2], parts[3]);
                }
                line = reader.ReadLine();
            }

            reader.Close();
            file.Close();

            dataGridView2.Columns.Add("name", "Ad");
            dataGridView2.Columns.Add("surname", "Soyad");
            dataGridView2.Columns.Add("phone_number", "Telefon Numarasi");
            dataGridView2.Columns.Add("address", "Adres");
            dataGridView2.Columns.Add("square", "Halının m²");
            dataGridView2.Columns.Add("received", "Alınan Tarihi");
            dataGridView2.Columns.Add("delivery", "Tahmini Teslim Tarihi");
            dataGridView2.Columns.Add("price", "ÜcreT(TL Cinsinden)");
            dataGridView2.Columns.Add("status", "Durum");

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
                    dataGridView2.Rows.Add(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], parts[6], parts[7], parts[8]);
                }
                line_1 = reader_1.ReadLine();
            }

            reader_1.Close();
            file_1.Close();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["surname"].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["phone_number"].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["address"].Value.ToString();
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView2.Rows[e.RowIndex].Cells["name"].Value.ToString();
            textBox5.Text = dataGridView2.Rows[e.RowIndex].Cells["surname"].Value.ToString();
            textBox6.Text = dataGridView2.Rows[e.RowIndex].Cells["phone_number"].Value.ToString();
            textBox7.Text = dataGridView2.Rows[e.RowIndex].Cells["address"].Value.ToString();
            textBox1.Text = dataGridView2.Rows[e.RowIndex].Cells["square"].Value.ToString();
            textBox2.Text = dataGridView2.Rows[e.RowIndex].Cells["received"].Value.ToString();
            textBox3.Text = dataGridView2.Rows[e.RowIndex].Cells["delivery"].Value.ToString();
        }
        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }
    }
}
