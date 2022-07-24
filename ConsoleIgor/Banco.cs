using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleIgor
{
    public class Banco
    {
        //private SqlConnection sqlConnection; //VARIAVEL GLOBAL
        private MySqlConnection sqlConnection;

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

        /// <summary>
        /// Esse método é utilizado para gravar um filme no banco SQL Server
        /// </summary>
        /// <param name="filme"></param>
        public void GravarObjetoNoBanco(Filme filme)
        {
            //aqui está buscando se o filme existe ou não
            if(BuscarFilmePorNome(filme.Titulo) == false)
            {
                string sql = "insert into filmes (nome, data, estudio, origem) values(@nome, @data, @estudio, @origem)";
                MySqlCommand command = new MySqlCommand(sql, sqlConnection);
                command.Parameters.AddWithValue("@nome", filme.Titulo);
                command.Parameters.AddWithValue("@data", filme.DataLancamento);
                command.Parameters.AddWithValue("@estudio", filme.Estudio);
                command.Parameters.AddWithValue("@origem", "");

                command.ExecuteNonQuery();
            }
        }

        public void ConectarBanco()
        {
            string connectionString = "Server=192.168.50.27;Database=filmes;User Id=root;Password=u*yLk@Bh]-Oahw1;";
            sqlConnection = new MySqlConnection(connectionString);

            sqlConnection.Open();
        }

        public void FecharConexaoBanco()
        {
            sqlConnection.Close();
        }
    }
}
