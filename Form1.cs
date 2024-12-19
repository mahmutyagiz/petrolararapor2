using petrol;

using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Petrol
{
    public partial class Form1 : Form
    {
        public static string genel_bilgi = "";

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-CN4K9TK;Initial Catalog=Petrol;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Lütfen Kullanıcı Adını giriniz");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Şifre Giriniz");
                return;
            }

            string kul = textBox1.Text;
            string sifre = textBox2.Text;

            try
            {
                baglanti.Open();
                string sorgu = "SELECT * FROM giriş WHERE Kullanıcıad=@kul AND Sifre=@sifre";
                SqlCommand command = new SqlCommand(sorgu, baglanti);
                command.Parameters.AddWithValue("@kul", kul);
                command.Parameters.AddWithValue("@sifre", sifre);

                SqlDataReader oku = command.ExecuteReader();

                if (oku.Read())
                {
                    string rol = oku["Rol"].ToString(); // Kullanıcının rolü

                    genel_bilgi = "Hoşgeldin " + oku["Kullanıcıad"].ToString();

                    // Switch-case ile rol kontrolü
                    switch (rol)
                    {
                        case "çalışan":
                            MessageBox.Show(genel_bilgi + " (Çalışan olarak giriş yapıldı)");
                            this.Hide(); // Mevcut formu gizle
                            CalisanForm CalisanForm = new CalisanForm(); // Doğru sınıf adı
                            CalisanForm.Show(); // Çalışan formunu göster
                           break;

                        case "müdür":
                            MessageBox.Show(genel_bilgi + " (Müdür olarak giriş yapıldı)");
                            this.Hide(); // Mevcut formu gizle
                            müdürForm mudurForm = new müdürForm();
                            mudurForm.Show(); // Müdür formunu göster
                            break;

                        default:
                            MessageBox.Show("Tanımlanmamış rol!");
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox2_Click(sender, e); // Aynı giriş kontrolü için pictureBox2_Click metodunu kullan
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}