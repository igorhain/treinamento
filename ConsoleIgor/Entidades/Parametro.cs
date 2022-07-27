using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleIgor.Entidades
{
    public class Parametro
    {
        public string Nome { get; set; }
        public object Valor { get; set; }

        public Parametro(string nome, object valor)
        {
            this.Nome = nome;
            this.Valor = valor;
        }
    }
}
