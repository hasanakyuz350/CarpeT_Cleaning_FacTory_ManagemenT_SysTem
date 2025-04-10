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
using static System.Windows.Forms.LinkLabel;

namespace Halı_Yıkama_Fabrikası
{
    public partial class customer : Form
    {
        public customer()
        {
            InitializeComponent();
        }
        private void buttonekle_Click(object sender, EventArgs e)
        {
            string filepath;
            filepath = "C:\\Users\\hasan\\source\\cusTomer.txt";
            FileStream file = new FileStream(filepath, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file);

            Customer customer = new Customer();
            customer.name = textBox1.Text;
            customer.surname = textBox2.Text;
            customer.phoneNumber = textBox3.Text;
            customer.address = textBox4.Text;

            writer.WriteLine(customer.name + "," + customer.surname + "," + customer.phoneNumber + "," + customer.address);

            writer.Flush();

            writer.Close();
            file.Close();

            int rows = Convert.ToInt32(dataGridView1.Rows.Add());

            dataGridView1.Rows[rows].Cells["name"].Value = customer.name;
            dataGridView1.Rows[rows].Cells["surname"].Value = customer.surname;
            dataGridView1.Rows[rows].Cells["phone_number"].Value = customer.phoneNumber;
            dataGridView1.Rows[rows].Cells["address"].Value = customer.address;
        }
        private void buttonsil_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.name = textBox1.Text;
            customer.surname = textBox2.Text;
            customer.phoneNumber = textBox3.Text;
            customer.address = textBox4.Text;

            string filepath;
            filepath = "C:\\Users\\hasan\\source\\cusTomer.txt";

            var lines = File.ReadAllLines(filepath).ToList();

            foreach (DataGridViewRow rows in dataGridView1.SelectedRows)
            {
                string eskiisim = dataGridView1.Rows[rows.Index].Cells["name"].Value.ToString();
                string eskisoyisim = dataGridView1.Rows[rows.Index].Cells["surname"].Value.ToString();
                string eskinumara = dataGridView1.Rows[rows.Index].Cells["phone_number"].Value.ToString();
                string eskiadres = dataGridView1.Rows[rows.Index].Cells["address"].Value.ToString();

                dataGridView1.Rows[rows.Index].Cells["name"].Value = customer.name;
                dataGridView1.Rows[rows.Index].Cells["surname"].Value = customer.surname;
                dataGridView1.Rows[rows.Index].Cells["phone_number"].Value = customer.phoneNumber;
                dataGridView1.Rows[rows.Index].Cells["address"].Value = customer.address;

                string eski = $"{eskiisim},{eskisoyisim},{eskinumara},{eskiadres}";
                string yeni = $"{customer.name},{customer.surname},{customer.phoneNumber},{customer.address}";

                for (int i = 0; i < lines.Count; i++)
                {
                    if (lines[i] == eski)
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
        private void buttonguncelle_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.name = textBox1.Text;
            customer.surname = textBox2.Text;
            customer.phoneNumber = textBox3.Text;
            customer.address = textBox4.Text;

            string filepath;
            filepath = "C:\\Users\\hasan\\source\\cusTomer.txt";

            var lines = File.ReadAllLines(filepath).ToList();

            foreach (DataGridViewRow rows in dataGridView1.SelectedRows)
            {
                string eskiisim = dataGridView1.Rows[rows.Index].Cells["name"].Value.ToString();
                string eskisoyisim = dataGridView1.Rows[rows.Index].Cells["surname"].Value.ToString();
                string eskinumara = dataGridView1.Rows[rows.Index].Cells["phone_number"].Value.ToString();
                string eskiadres = dataGridView1.Rows[rows.Index].Cells["address"].Value.ToString();

                dataGridView1.Rows[rows.Index].Cells["name"].Value = customer.name;
                dataGridView1.Rows[rows.Index].Cells["surname"].Value = customer.surname;
                dataGridView1.Rows[rows.Index].Cells["phone_number"].Value = customer.phoneNumber;
                dataGridView1.Rows[rows.Index].Cells["address"].Value = customer.address;

                string eski = $"{eskiisim},{eskisoyisim},{eskinumara},{eskiadres}";
                string yeni = $"{customer.name},{customer.surname},{customer.phoneNumber},{customer.address}";

                for (int i = 0; i < lines.Count; i++)
                {
                    if (lines[i] == eski)
                    {
                        lines[i] = yeni;
                        break;
                    }
                }
            }
            File.WriteAllLines(filepath, lines);
        }
        private void customer_Load(object sender, EventArgs e)
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
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["surname"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["phone_number"].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["address"].Value.ToString();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}
