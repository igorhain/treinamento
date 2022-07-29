using ConsoleIgor.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleIgor.Repositorios
{
    public class RepositorioAtores
    {
        public RepositorioAtores()
        {
        }

        public DataTable BuscarAtorPorNome(string nome, bool user)
        {
            var banco = new Banco();
            string sql = "";
            sql = "select * from Atores where nome " + (user ? "like" : " = ") + " @nome";

            if (user)
                return banco.ExecuteQuery(sql, new Parametro("@nome", "%" + nome + "%"));
            else
                return banco.ExecuteQuery(sql, new Parametro("@nome", nome));
        }
        public void GravarAtor(Ator ator)
        {
            //AQUI SIM O BANCO É CHAMADO PARA FAZER A INSERÇÃO, (SQL E PARAMETROS)
            var banco = new Banco();

            string sql = "insert into atores (nome, idade) values (@nome, @idade)";
            banco.ExecuteNonQuery(sql, new Parametro("@nome", ator.Nome),
                new Parametro("@idade", ator.Idade));

        }
    }
}
