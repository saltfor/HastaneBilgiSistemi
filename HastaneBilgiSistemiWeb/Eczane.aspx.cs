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
    public partial class Eczane : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["baglantiyolu"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from EczaneTanim where kAdi='" + TextBox1.Text + "' and sifre='" + TextBox2.Text + "'", baglanti);
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet DS = new DataSet();
            adaptor.Fill(DS);
            baglanti.Close();
            if (DS.Tables[0].Rows.Count > 0)
            {
                Response.Write("Hoşgeldiniz " + TextBox1.Text);
                TextBox2.Text = "";
                Panel1.Enabled = true;
                Session["login"] = true;
            }
            else
            {
                Response.Write("Kullanıcı adı veya şifre hatalı !");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                ListBox1.DataSource = null;
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select TC,tarih from Recete where TC=" + TextBox3.Text, baglanti);
                SqlDataAdapter adaptor = new SqlDataAdapter(komut);
                DataSet DS = new DataSet();
                adaptor.Fill(DS);
                baglanti.Close();
                ListBox1.DataSource = DS.Tables[0];
                ListBox1.DataTextField = "tarih";
                ListBox1.DataBind();
                if (ListBox1.Items.Count > 0)
                {
                    Session["HastaTC"] = TextBox3.Text;
                }
                else
                {
                    Response.Write("Girdiğiniz TC ye ait hastanın reçetesi bulunmamaktadır !");
                }
            }
            catch (Exception)
            {
                Response.Write("TC 11 haneli olmalıdır !");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["recetetarihi"] = ListBox1.SelectedItem.Text;
            Response.Redirect("Recete.aspx");
        }
    }
}