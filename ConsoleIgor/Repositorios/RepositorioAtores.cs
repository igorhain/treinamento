using ConsoleIgor.Entidades;
using System;
using System.Collections.Generic;
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
