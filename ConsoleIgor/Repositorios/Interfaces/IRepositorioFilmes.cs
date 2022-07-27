using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleIgor.Repositorios.Interfaces
{
    public interface IRepositorioFilmes
    {
        DataTable BuscarFilmePorNome(string nome, bool usarLike);
        void GravarFilme(Filme filme);
    }
}
