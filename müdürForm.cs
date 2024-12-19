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

namespace petrol
{
    public partial class müdürForm : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-CN4K9TK;Initial Catalog=Petrol;Integrated Security=True");
        public müdürForm()
        {
            InitializeComponent();
        }

        private void müdürForm_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'petrolDataSet4.Rezerv' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.rezervTableAdapter.Fill(this.petrolDataSet4.Rezerv);
            // TODO: Bu kod satırı 'petrolDataSet3.çalışanlar' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.çalışanlarTableAdapter2.Fill(this.petrolDataSet3.çalışanlar);


        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void şubelerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO çalışanlar (CalışanAD, CalışanSoyad, Pozisyon, Saatler) VALUES (@p1, @p2, @p3, @p4)", baglanti);
                cmd.Parameters.AddWithValue("@p1", textBox1.Text);
                cmd.Parameters.AddWithValue("@p2", textBox2.Text);
                cmd.Parameters.AddWithValue("@p3", textBox3.Text);
                cmd.Parameters.AddWithValue("@p4", textBox4.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Eklendi");
                this.çalışanlarTableAdapter2.Fill(this.petrolDataSet3.çalışanlar);
                baglanti.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Eklenmedi");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM çalışanlar WHERE CalışanAD = @p1 AND CalışanSoyad = @p2", baglanti);
                cmd.Parameters.AddWithValue("@p1", textBox1.Text);
                cmd.Parameters.AddWithValue("@p2", textBox2.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Silindi");
                this.çalışanlarTableAdapter2.Fill(this.petrolDataSet3.çalışanlar);
                baglanti.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Silinemedi");
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("UPDATE çalışanlar SET CalışanSoyad = @p2, Pozisyon = @p3, Saatler = @p4 WHERE CalışanAD = @p1", baglanti);
                cmd.Parameters.AddWithValue("@p1", textBox1.Text); // CalışanAD
                cmd.Parameters.AddWithValue("@p2", textBox2.Text); // CalışanSoyad
                cmd.Parameters.AddWithValue("@p3", textBox3.Text); // Pozisyon
                cmd.Parameters.AddWithValue("@p4", textBox4.Text); // Saatler
                cmd.ExecuteNonQuery();
                MessageBox.Show("Güncellendi");
                this.çalışanlarTableAdapter2.Fill(this.petrolDataSet3.çalışanlar);
                baglanti.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Güncellenemedi");
            }
        }

        private void istanbulŞubesiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
    
}
