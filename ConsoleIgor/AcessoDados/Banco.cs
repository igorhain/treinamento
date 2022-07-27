using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleIgor.Entidades;
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

        public void ConectarBanco()
        {
            //string connectionString = "Server=localhost;Database=banco;User Id=root;Password=Kreator132;"
            string connectionString = "server=localhost;user id=root;password=Kreator132;database=filmes";
            //string connectionString = "Server=192.168.50.27;Database=filmes;User Id=root;Password=u*yLk@Bh]-Oahw1;";
            //string connectionString = "Server=34.95.193.80;Database=igoryuri;User Id=Igoryuri;Password=kreator132;";
            sqlConnection = new MySqlConnection(connectionString);

            sqlConnection.Open();
        }

        public DataTable ExecuteQuery(string sql, params Parametro[] parametros)
        {
            var dt = new DataTable();
            MySqlCommand command = new MySqlCommand(sql, sqlConnection);

            foreach (var parametro in parametros)
            {
                var param = command.Parameters.AddWithValue(parametro.Nome, parametro.Valor);
                param.IsNullable = true;

                if (parametro.Valor == null)
                {
                    param.Value = DBNull.Value;
                }

                if (parametro.Valor is DateTime)
                {
                    if ((DateTime)parametro.Valor < new DateTime(1900, 1, 1))
                    {
                        param.Value = DBNull.Value;
                    }
                }
            }

            using (var dr = command.ExecuteReader())
            {
                dt.Load(dr);
                dr.Close();
            }

            return dt;
        }

        public void ExecuteNonQuery(string sql, params Parametro[] parametros)
        {
            MySqlCommand command = new MySqlCommand(sql, sqlConnection);

            foreach (var parametro in parametros)
            {
                var param = command.Parameters.AddWithValue(parametro.Nome, parametro.Valor);
                param.IsNullable = true;

                if (parametro.Valor == null)
                {
                    param.Value = DBNull.Value;
                }

                if (parametro.Valor is DateTime)
                {
                    if ((DateTime)parametro.Valor < new DateTime(1900, 1, 1))
                    {
                        param.Value = DBNull.Value;
                    }
                }
            }

            command.ExecuteNonQuery();
        }

        public void FecharConexaoBanco()
        {
            sqlConnection.Close();
        }
    }
}