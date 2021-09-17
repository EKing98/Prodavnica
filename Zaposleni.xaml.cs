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
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Zaposleni : Window
    {
        SQL sqlUtils;
        public Zaposleni()
        {
            InitializeComponent();
            sqlUtils = new SQL(ConfigurationManager.ConnectionStrings["connProdavnice"].ConnectionString);
            prikaziProdavnice();
            prikaziZaposlene();
        }

        private void prikaziProdavnice()
        {
            SqlConnection konekcija = sqlUtils.kreirajKonekciju();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [Prodavnica]", konekcija);
            DataSet ds = new DataSet();
            da.Fill(ds);

            ZaposleniComboBox.ItemsSource = ds.Tables[0].DefaultView;
            ZaposleniComboBox.SelectedValuePath = "ID";
            ZaposleniComboBox.DisplayMemberPath = "Naziv";
        }

        private void prikaziZaposlene()
        {
            SqlConnection konekcija = sqlUtils.kreirajKonekciju();
            String upit = "SELECT [Zaposleni].*, [Prodavnica].[Naziv] AS NazivProdavnice FROM [Zaposleni] INNER JOIN [Prodavnica] ON [Zaposleni].[IDProdavnice]=[Prodavnica].[ID]";
            DataTable dataTabela = sqlUtils.vratiIzBaze(konekcija, upit);
            DataGridZaposleni.ItemsSource = dataTabela.DefaultView;
        }

        private void BtnDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (txtIme.Text != "" && txtPrezime.Text != "" && txtGodRodj.Text != "" && ZaposleniComboBox.Text != "")
            {
                bool uspeh = int.TryParse(txtGodRodj.Text, out int godinaRodj);

                if (!uspeh)
                {
                    MessageBox.Show("Godina rodjenja mora biti broj");
                    return;
                }

                SqlConnection konekcija = sqlUtils.kreirajKonekciju();
                String upit = "INSERT INTO [Zaposleni] (Ime, Prezime, GodRodj, IDProdavnice) VALUES (@Ime, @Prezime, @GodRodj, @IDProdavnice)";
                SqlCommand komanda = sqlUtils.radSaUpitom(konekcija, upit);
                komanda.Parameters.AddWithValue("@Ime", txtIme.Text);
                komanda.Parameters.AddWithValue("@Prezime", txtPrezime.Text);
                komanda.Parameters.AddWithValue("@GodRodj", godinaRodj);
                komanda.Parameters.AddWithValue("@IDProdavnice", ZaposleniComboBox.SelectedValue);

                int provera = komanda.ExecuteNonQuery();
                if (provera == 1)
                {
                    MessageBox.Show("Podaci o zaposlenom su uspešno upisani");
                    prikaziProdavnice();
                    prikaziZaposlene();
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
            String upit = "UPDATE [Zaposleni] SET Ime = @Ime, Prezime = @Prezime, GodRodj = @GodRodj, IDProdavnice = @IDProdavnice WHERE ID = @ZaposleniId";
            SqlCommand komanda = sqlUtils.radSaUpitom(konekcija, upit);
            komanda.Parameters.AddWithValue("@ZaposleniId", txtZaposleniId.Text);
            komanda.Parameters.AddWithValue("@Ime", txtIme.Text);
            komanda.Parameters.AddWithValue("@Prezime", txtPrezime.Text);
            komanda.Parameters.AddWithValue("@GodRodj", int.Parse(txtGodRodj.Text));
            komanda.Parameters.AddWithValue("@IDProdavnice", ZaposleniComboBox.SelectedValue);

            if (txtIme.Text != "" && txtPrezime.Text != "" && txtGodRodj.Text != "" && ZaposleniComboBox.Text != "")
            {
                int provera = komanda.ExecuteNonQuery();
                if (provera == 1)
                {
                    MessageBox.Show("Podaci o zaposlenom su uspešno izmenjeni");
                    prikaziProdavnice();
                    prikaziZaposlene();
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
            String upit = "DELETE FROM [Zaposleni] WHERE ID = @ZaposleniId";
            SqlCommand komanda = sqlUtils.radSaUpitom(konekcija, upit);
            komanda.Parameters.AddWithValue("@ZaposleniId", txtZaposleniId.Text);

            int provera = komanda.ExecuteNonQuery();
            if (provera == 1)
            {
                MessageBox.Show("Podaci o zaposlenom su uspešno obrisani");
                prikaziProdavnice();
                prikaziZaposlene();
            }
            ponistiUnosTxt();
        }

        private void DataGridZaposleni_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                txtZaposleniId.Text = dr["ID"].ToString();
                txtIme.Text = dr["Ime"].ToString();
                txtPrezime.Text = dr["Prezime"].ToString();
                txtGodRodj.Text = dr["GodRodj"].ToString();
                ZaposleniComboBox.SelectedValue = dr["IDProdavnice"].ToString();
            }
        }

        private void ponistiUnosTxt()
        {
            txtZaposleniId.Text = "";
            txtIme.Text = "";
            txtPrezime.Text = "";
            txtGodRodj.Text = "";
        }
    }
}
