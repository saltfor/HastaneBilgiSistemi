using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HastaneBilgiSistemi
{
    public partial class HastaKabul : Form
    {
        public HastaKabul()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedTab = tabPage3;
                textBox9.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                comboBox6.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                comboBox5.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                dateTimePicker2.Value = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[4].Value);
                comboBox4.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen satır seçip tekrar deneyiniz !","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            

        }

        private void button27_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HastaKabul_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool varMi = DoktorRandevuKontrol(comboBox2.Text, dateTimePicker1.Value.ToShortDateString(), comboBox3.Text);
            if (varMi==true)
            {
                MessageBox.Show("Seçtiğiniz doktor belirtilen gün ve tarihte uygun değil !","OLUMSUZ RANDEVU");
            }
            else
            {
                if (textBox3.Text.Length==11 && textBox4.Text!="" && textBox5.Text!="" && comboBox3.Text!="")
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("insert into Randevular (TC,klinik,doktor,tarih,saat,ad,soyad) values('" + textBox3.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + dateTimePicker1.Value.ToShortDateString() + "','" + comboBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", baglanti);
                    SqlCommand komut2 = new SqlCommand("insert into HastaTanim (ad,soyad,TC) values('" + textBox4.Text + "','" + textBox5.Text + "','" + textBox3.Text + "')", baglanti);
                    komut.ExecuteNonQuery();
                    komut2.ExecuteNonQuery();
                    baglanti.Close();
                    RandevuGuncelle();
                    MessageBox.Show("Ekleme işlemi başarılı");
                    tabControl1.SelectedTab = tabPage2;
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                }
                else
                {
                    MessageBox.Show("TC,Ad,Soyad,Saat bilgileri hatalı !", "Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mahmut Arslan\Documents\database.mdf;Integrated Security=True;Connect Timeout=30");

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select Kadi,sifre from SekreterlerTanim where Kadi='" + textBox1.Text + "' and sifre='" + textBox2.Text + "'", baglanti);
            DataSet DS = new DataSet();
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            adaptor.Fill(DS);
            baglanti.Close();
            if (DS.Tables[0].Rows.Count > 0)
            {
                baglanti.Open();
                SqlCommand komutklinik = new SqlCommand("select * from KliniklerTanim", baglanti);
                DataSet DSKlinik = new DataSet();
                SqlDataAdapter adaptorKlinik = new SqlDataAdapter(komutklinik);
                adaptorKlinik.Fill(DSKlinik);
                baglanti.Close();
                for (int i = 0; i < DSKlinik.Tables[0].Rows.Count; i++)
                {
                    comboBox1.DisplayMember = "klinik";
                    comboBox1.DataSource = DSKlinik.Tables[0];
                    comboBox6.DisplayMember = "klinik";
                    comboBox6.DataSource = DSKlinik.Tables[0];
                }

                tabControl1.Enabled = true;
                MessageBox.Show("Giriş Başarılı...Hoşgeldiniz " + textBox1.Text);
                RandevuGuncelle();
            }
            else
            {
                MessageBox.Show("Giriş başarısız...");
            }
        }
        public void RandevuGuncelle()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Randevular", baglanti);
            DataSet DS = new DataSet();
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            adaptor.Fill(DS);
            baglanti.Close();
            dataGridView1.DataSource = DS.Tables[0];
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox2.DataSource = null;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from DoktorTanim where klinik='"+comboBox1.Text+"'", baglanti);
            DataSet DS = new DataSet();
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            adaptor.Fill(DS);
            baglanti.Close();
            comboBox2.DisplayMember = "kAdi";
            comboBox2.DataSource = DS.Tables[0];
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Randevular where TC like '" + textBox6.Text + "'+'%'", baglanti);
            DataSet DS = new DataSet();
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            adaptor.Fill(DS);
            baglanti.Close();
            dataGridView1.DataSource = DS.Tables[0];
        }

        private void comboBox6_TextChanged(object sender, EventArgs e)
        {
            comboBox5.DataSource = null;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from DoktorTanim where klinik='" + comboBox6.Text + "'", baglanti);
            DataSet DS = new DataSet();
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            adaptor.Fill(DS);
            baglanti.Close();
            comboBox5.DisplayMember = "kAdi";
            comboBox5.DataSource = DS.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool varMi = DoktorRandevuKontrol(comboBox5.Text, dateTimePicker2.Value.ToShortDateString(), comboBox4.Text);
            if (varMi == true)
            {
                MessageBox.Show("Seçtiğiniz doktor belirtilen gün ve tarihte uygun değil !", "OLUMSUZ RANDEVU");
            }
            else
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("update Randevular set klinik='" + comboBox6.Text + "' ,doktor='" + comboBox5.Text + "' ,tarih='" + dateTimePicker2.Value.ToShortDateString() + "' ,saat='" + comboBox4.Text + "' where TC='" + textBox9.Text + "'", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                RandevuGuncelle();
                MessageBox.Show("Güncelleme işlemi başarılı");
                tabControl1.SelectedTab = tabPage2;
                textBox6.Text = "";
                textBox9.Text = "";
            }
            
        }
        public bool DoktorRandevuKontrol(string doktor, string tarih, string saat)
        {
            bool varMi = false;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Randevular where doktor='" + doktor + "' and tarih='" + tarih + "' and saat='" + saat + "'", baglanti);
            DataSet DS = new DataSet();
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            adaptor.Fill(DS);
            baglanti.Close();
            if (DS.Tables[0].Rows.Count>0)
            {
                varMi = true;
            }
            return varMi;
        }
    }
}
