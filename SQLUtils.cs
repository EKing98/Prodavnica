using System.Data.SqlClient;
using System.Data;

namespace KlasePodataka
{
    public class SQL
    {
        private string _connectionString;

        public SQL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection kreirajKonekciju()
        {
            SqlConnection konekcija = new SqlConnection(_connectionString);
            konekcija.Open();
            return konekcija;
        }

        public DataTable vratiIzBaze(SqlConnection konekcija, string upit)
        {
            using (var komanda = radSaUpitom(konekcija, upit)) {
                SqlDataReader reader = komanda.ExecuteReader();
                DataTable datatable = new DataTable();
                datatable.Load(reader);
                return datatable;
            }
        }

        public SqlCommand radSaUpitom(SqlConnection konekcija, string upit)
        {
            return new SqlCommand(upit, konekcija);
        }
    }
}
