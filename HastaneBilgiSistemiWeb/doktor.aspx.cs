using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace HastaneBilgiSistemiWeb
{
    public partial class doktor : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["baglantiyolu"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        

        protected void Button1_Click(object sender, EventArgs e)
        {
            //BURAYA POSTBACK KONTROLU GEREKİYOR !!!!!!!!!
            ListBox1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from DoktorTanim where kAdi='" + TextBox1.Text + "' and sifre='" + TextBox2.Text + "'", baglanti);
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet DS = new DataSet();
            adaptor.Fill(DS);
            baglanti.Close();
            if (DS.Tables[0].Rows.Count > 0)
            {
                Session["Doktor"] = TextBox1.Text;
                Response.Write("Hoşgeldiniz " + Session["Doktor"]);
                TextBox2.Text = "";
                RandevulariCek();
                TahlilleriCek();
                HastaliklariCek();
                if (ListBox1.Items.Count>0)
                {
                    Panel1.Enabled = true;
                }
                else
                {
                    Response.Write(".Bugun için hastanız bulunmamaktadır !");
                }
            }
            else
            {
                Response.Write("Kullanıcı adı veya şifre hatalı !");
            }
        }
        public void RandevulariCek()
        {
            string bugun = DateTime.Now.ToShortDateString();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select tarih,saat,TC,ad,soyad from Randevular where doktor='" + Session["Doktor"] + "' and tarih='" + bugun + "'", baglanti);
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet DS = new DataSet();
            adaptor.Fill(DS);
            baglanti.Close();
            GridView1.DataSource = DS.Tables[0];
            GridView1.DataBind();
            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
            {
                ListBox1.Items.Add(GridView1.Rows[i].Cells[3].Text + " " + GridView1.Rows[i].Cells[4].Text);
            }
        }
        public void TahlilleriCek()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select tahlil from TahlilTanim", baglanti);
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet DS = new DataSet();
            adaptor.Fill(DS);
            baglanti.Close();
            CheckBoxList1.DataSource = DS.Tables[0];
            CheckBoxList1.DataTextField = "tahlil";
            CheckBoxList1.DataBind();
        }
        public void HastaliklariCek()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select hastalik from HastalikTanim", baglanti);
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet DS = new DataSet();
            adaptor.Fill(DS);
            baglanti.Close();
            CheckBoxList2.DataSource = DS.Tables[0];
            CheckBoxList2.DataTextField = "hastalik";
            CheckBoxList2.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                int tahlilsayisi = CheckBoxList1.Items.Count;
                string tahliller = "";
                for (int i = 0; i < tahlilsayisi; i++)
                {
                    if (CheckBoxList1.Items[i].Selected == true)
                    {
                        tahliller = tahliller + CheckBoxList1.Items[i].Text + ",";
                    }
                }
                baglanti.Open();
                string TC = GridView1.Rows[ListBox1.SelectedIndex].Cells[2].Text;
                SqlCommand komut = new SqlCommand("insert into HastaTahlil (TC,tahliller) values('" + TC + "','" + tahliller + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
            }
            catch (Exception)
            {
                Response.Write("Lütfen hasta seçip tekrar deneyiniz !");
            }
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                ListBox2.Items.Clear();
                int hastaliksayisi = CheckBoxList2.Items.Count;
                string hastaliklar = "";
                for (int i = 0; i < hastaliksayisi; i++)
                {
                    if (CheckBoxList2.Items[i].Selected == true)
                    {
                        hastaliklar = hastaliklar + CheckBoxList2.Items[i].Text + ",";
                        ListBox2.Items.Add(CheckBoxList2.Items[i].Text);
                    }
                }
                baglanti.Open();
                string TC = GridView1.Rows[ListBox1.SelectedIndex].Cells[2].Text;
                SqlCommand komut = new SqlCommand("insert into Muayene (TC,hastalik,doktor,tarih) values('" + TC + "','" + hastaliklar + "','" + Session["Doktor"] + "','" + DateTime.Now.ToShortDateString() + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
            }
            catch (Exception)
            {
                Response.Write("Lütfen hasta seçip tekrar deneyiniz !");
            }
            
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (ListBox3.Items.Count>0)
            {
                string ilaclar = "";
                string dozlar = "";
                for (int i = 0; i < ListBox3.Items.Count; i++)
                {
                    ilaclar = ilaclar + ListBox3.Items[i].Text + ",";
                    dozlar = dozlar + ListBox4.Items[i].Text + ",";
                }
                baglanti.Open();
                string TC = GridView1.Rows[ListBox1.SelectedIndex].Cells[2].Text;
                string tarih = DateTime.Now.ToShortDateString();
                SqlCommand komut = new SqlCommand("insert into Recete (TC,ilac,doz,tarih) values('" + TC + "','" + ilaclar + "','" + dozlar + "','" + tarih + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                ListBox2.Items.Clear();
                ListBox2.DataSource = null;
                DropDownList1.DataSource = null;
                TextBox3.Text = "";
                ListBox3.Items.Clear();
                ListBox4.Items.Clear();
                Response.Write("Reçete başarılı bir şekilde yazıldı...");
            }
            else
            {
                Response.Write("Reçete edilecek ilaç bulunmamaktadır !");
            }
            
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select ilacadi from IlacTanim where hastalik='" + ListBox2.SelectedItem.Text + "'", baglanti);
                DataSet DS = new DataSet();
                SqlDataAdapter adaptor = new SqlDataAdapter(komut);
                adaptor.Fill(DS);
                baglanti.Close();
                DropDownList1.DataSource = DS.Tables[0];
                DropDownList1.DataTextField = "ilacadi";
                DropDownList1.DataBind();
            }
            catch (Exception)
            {
                Response.Write("Hastalık seçip tekar deneyiniz !");
            }
            
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            if (TextBox3.Text!="")
            {
                ListBox3.Items.Add(DropDownList1.Text);
                ListBox4.Items.Add(TextBox3.Text);
            }
            else
            {
                Response.Write("Doz sayısını girmediniz !");
            }
        }
    }
}