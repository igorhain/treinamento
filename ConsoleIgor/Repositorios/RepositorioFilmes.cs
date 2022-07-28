﻿using ConsoleIgor.Entidades;
using ConsoleIgor.Repositorios.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleIgor.Repositorios
{
    public class RepositorioFilmes : IRepositorioFilmes
    {

        public RepositorioFilmes()
        {
        }

        public DataTable BuscarFilmePorNome(string nome, bool usarLike)
        {
            var banco = new Banco();
            string sql = "";
            sql = "select * from Filmes where nome " + (usarLike ? "like" : " = ") + " @nome";

            if(usarLike)
                return banco.ExecuteQuery(sql, new Parametro("@nome", "%" + nome + "%"));
            else
                return banco.ExecuteQuery(sql, new Parametro("@nome" , nome));
        }

        public void GravarFilme(Filme filme)
        {
            var banco = new Banco();
            if (BuscarFilmePorNome(filme.Titulo, false).Rows.Count == 0)
            {
                string sql = "insert into filmes (nome, data, estudio) values (@nome, @data, @estudio)";
                banco.ExecuteNonQuery(sql, new Parametro("@nome", filme.Titulo),
                    new Parametro("@data", filme.DataLancamento),
                    new Parametro("@estudio", filme.Estudio));
            }
        }

        public void ListarFilmesPorEstudio(string nomeEstudio)
        {
            //EXECUTAR O EXERCICIO 1 AQUI
            throw new NotImplementedException();
        }
    }
}
