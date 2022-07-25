using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleIgor
{
    public class Banco
    {
        //CLASSE BANCO
        private MySqlConnection sqlConnection; //VARIAVEL GLOBAL

        public Banco()
        {
            ConectarBanco();
        }

        public bool BuscarFilmePorNome(string nome)
        {
            var dt = new DataTable();

            string sql = "select * from Filmes where nome = @nome";
            MySqlCommand command = new MySqlCommand(sql, sqlConnection);
            command.Parameters.AddWithValue("@nome", nome);

            using (var dr = command.ExecuteReader())
            {
                dt.Load(dr);
                dr.Close();
            }

            if (dt.Rows.Count > 0)
                return true;
            else
                return false;

        }

        public void GravarObjetoNoBanco(Filme filme)
        {
            if(BuscarFilmePorNome(filme.Titulo) == false)
            {
                string sql = "insert into filmes values(@nome, @data, @estudio)";
                MySqlCommand command = new MySqlCommand(sql, sqlConnection);
                command.Parameters.AddWithValue("@nome", filme.Titulo);
                command.Parameters.AddWithValue("@data", filme.DataLancamento);
                command.Parameters.AddWithValue("@estudio", filme.Estudio);

                command.ExecuteNonQuery();
            }
        }

        public void ConectarBanco()
        {
            //string connectionString = "Server=localhost;Database=banco;User Id=root;Password=Kreator132;"
            string connectionString = "server=localhost;user id=root;password=Kreator132;database=filmes";
            sqlConnection = new MySqlConnection(connectionString);

            sqlConnection.Open();
        }

        public void FecharConexaoBanco()
        {
            sqlConnection.Close();
        }
    }
}