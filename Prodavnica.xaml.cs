using Prodavnica;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using KlasePodataka;

namespace Prodavnice

{
   
    public partial class Prodavnica : Window
    {
        SQL sqlUtils;
        public Prodavnica()
        {
            InitializeComponent();
            sqlUtils= new SQL(ConfigurationManager.ConnectionStrings["connProdavnice"].ConnectionString);
            prikaziKudove();
        }

        private void prikaziKudove()
        {
            SqlConnection konekcija = sqlUtils.kreirajKonekciju();
            String upit = "SELECT * FROM [Prodavnica]";
            DataTable dataTabela = sqlUtils.vratiIzBaze(konekcija, upit);
            DataGridKud.ItemsSource = dataTabela.DefaultView;
        }

        private void DataGridKud_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                txtKudId.Text = dr["ID"].ToString();
                txtAdresa.Text = dr["Adresa"].ToString();
                txtMesto.Text = dr["Mesto"].ToString();
                txtNaziv.Text = dr["Naziv"].ToString();
                txtSifra.Text = dr["Sifra"].ToString();
            }
        }

        private void BtnDodaj_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection konekcija = sqlUtils.kreirajKonekciju();
            String upit = "INSERT INTO [Prodavnica] (Adresa, Mesto, Naziv, Sifra) VALUES (@Adresa, @Mesto, @Naziv, @Sifra)";
            SqlCommand komanda = sqlUtils.radSaUpitom(konekcija, upit);
            komanda.Parameters.AddWithValue("@Adresa", txtAdresa.Text);
            komanda.Parameters.AddWithValue("@Mesto", txtMesto.Text);
            komanda.Parameters.AddWithValue("@Naziv", txtNaziv.Text);
            komanda.Parameters.AddWithValue("@Sifra", txtSifra.Text);

            if (txtAdresa.Text != "" && txtMesto.Text != "" && txtSifra.Text != "" && txtNaziv.Text != "")
            {
                int provera = komanda.ExecuteNonQuery();
                if (provera == 1)
                {
                    MessageBox.Show("Podaci o prodavnici su uspešno upisani");
                    prikaziKudove();
                }
                ponistiUnosTxt();
            }
            else
            {
                MessageBox.Show("Greska: Polja moraju biti popunjena.");
            }
        }

        private void BtnIzmeni_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection konekcija = sqlUtils.kreirajKonekciju();
            String upit = "UPDATE [Prodavnica] SET Adresa = @Adresa, Mesto = @Mesto, Naziv = @Naziv, Sifra = @Sifra WHERE ID = @ProdavnicaId";
            SqlCommand komanda = sqlUtils.radSaUpitom(konekcija, upit);
            komanda.Parameters.AddWithValue("@ProdavnicaId", txtKudId.Text);
            komanda.Parameters.AddWithValue("@Adresa", txtAdresa.Text);
            komanda.Parameters.AddWithValue("@Mesto", txtMesto.Text);
            komanda.Parameters.AddWithValue("@Naziv", txtNaziv.Text);
            komanda.Parameters.AddWithValue("@Sifra", txtSifra.Text);

            if (txtAdresa.Text != "" && txtMesto.Text != "" && txtSifra.Text != "" && txtNaziv.Text != "")
            {
                int provera = komanda.ExecuteNonQuery();
                if (provera == 1)
                {
                    MessageBox.Show("Podaci o prodavnici su uspešno izmenjeni");
                    prikaziKudove();
                }
                ponistiUnosTxt();
            }
            else
            {
                MessageBox.Show("Greska: Polja moraju biti popunjena.");
            }
        }

        private void BtnObrisi_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection konekcija = sqlUtils.kreirajKonekciju();
            String upit = "DELETE FROM [Prodavnica] WHERE ID = @ProdavnicaId";
            SqlCommand komanda = sqlUtils.radSaUpitom(konekcija, upit);
            komanda.Parameters.AddWithValue("@ProdavnicaId", txtKudId.Text);
            
            int provera = komanda.ExecuteNonQuery();
            if (provera == 1)
            {
                MessageBox.Show("Podaci o prodavnici su uspešno obrisani");
                prikaziKudove();
            }
            ponistiUnosTxt();
        }
       
        private void ponistiUnosTxt()
        {
            txtKudId.Text = "";
            txtAdresa.Text = "";
            txtMesto.Text = "";
            txtSifra.Text = "";
            txtNaziv.Text = "";
        }
    }
}
