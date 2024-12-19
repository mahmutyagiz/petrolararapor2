using System;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
    public partial class CalisanForm : Form
    {
        public CalisanForm()
        {
            InitializeComponent();
            label1.Text = "PLAKANIZ";
            label2.Text = "YAKIT TÜRÜNÜZ";
            label3.Text = "Ödeme Yönteminiz";
            radioButton1.Text = "Nakit";
            radioButton2.Text = "Kredi Kartı";
            radioButton3.Text = "Bitcoin";
            button1.Text = "DEVAM";
            label4.Text = "İşlem Ekranı";
            label6.Text = "Alacağınız Miktar L/Watt";
        }

        // Button1: Add information to ListBox1
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear(); // Clear previous list before adding new items
            listBox1.Items.Add("PLAKANIZ: " + textBox1.Text);
            listBox1.Items.Add("Alınan Yakıt: " + comboBox1.SelectedItem.ToString());
            listBox1.Items.Add("Yüklenen Miktar: " + textBox2.Text + " Litre/Watt");

            listBox1.Items.Add("Ödeme Türü:");
            if (radioButton1.Checked)
                listBox1.Items.Add("Nakit");
            if (radioButton2.Checked)
                listBox1.Items.Add("Kredi Kartı");
            if (radioButton3.Checked)
                listBox1.Items.Add("Bitcoin");
        }

        // Button2: Display fuel prices in ListBox2
        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox2.Items.Add("Benzin: 7.25TL");
            listBox2.Items.Add("Dizel: 6.53TL");
            listBox2.Items.Add("Elektrik: 3.03TL");
            listBox2.Items.Add("Lpg: 4.36TL");
        }

        // Button3: Calculate the total cost based on fuel type and quantity
        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Lütfen tüm bilgileri girin.");
                return;
            }

            double pricePerUnit = 0;
            double quantity = Convert.ToDouble(textBox2.Text);
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Benzin":
                    pricePerUnit = 7.25;
                    break;
                case "Dizel":
                    pricePerUnit = 6.53;
                    break;
                case "Elektrik":
                    pricePerUnit = 3.03;
                    break;
                case "Lpg":
                    pricePerUnit = 4.36;
                    break;
                default:
                    MessageBox.Show("Geçersiz yakıt türü seçildi.");
                    return;
            }

            double totalCost = pricePerUnit * quantity;
            textBox3.Text = totalCost.ToString("F2");
        }

        // Button4: Close the form
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Form load event
        private void CalisanForm_Load(object sender, EventArgs e)
        {
            // Initialize ComboBox with fuel options
            comboBox1.Items.Add("Benzin");
            comboBox1.Items.Add("Dizel");
            comboBox1.Items.Add("Elektrik");
            comboBox1.Items.Add("Lpg");
        }
    }
}
