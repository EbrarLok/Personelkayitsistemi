using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PersonelKayit
{
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-8EU3443\\SQLSERVER;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            //Grafik 1
            baglanti.Open();
            SqlCommand komutg1 = new SqlCommand("Select PerSehir,Count(*) From Tbl_Personel Group by PerSehir",baglanti);
            SqlDataReader dr1 = komutg1.ExecuteReader();
            while(dr1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]); // 0 olan şehir adı, 1 olan sayısı.
            }
            baglanti.Close();

            //Grafik 2
            baglanti.Open();
            SqlCommand komutg2= new SqlCommand("Select PerMeslek Avg(Permaas) Personel Group by PerSehir", baglanti);
            SqlDataReader dr2=komutg2.ExecuteReader();
            while (dr2.Read()) 
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr2[0], dr2[1]); // 0 olan şehir adı, 1 olan sayısı.
            }
            baglanti.Close();
        }
    }
}
