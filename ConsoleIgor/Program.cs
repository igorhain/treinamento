using ConsoleIgor.Entidades;
using ConsoleIgor.Repositorios;
using System;
using System.Xml;

namespace ConsoleIgor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Selecione a opção abaixo:");
            Console.WriteLine("1 - Digite um número para multiplicar por 2");
            Console.WriteLine("2 - Digite um número para multiplicar por 10");
            Console.WriteLine("3 - Digite um número para multiplicar por 4");
            Console.WriteLine("4 - Leitura de arquivo XML");
            int opcao = lerInputDevolverConvertido<int>();
            int retorno = 0;
            switch (opcao)
            {
                case 1:
                    retorno = MultiplicarPorDois(); 
                    break;
                case 2:
                    retorno = MultiplicarPorDez(); 
                    break;
                case 3:
                    retorno = MultiplicarPorQuatro();
                    break;
                case 4:
                    LerArquivoXML();
                    break;
                case 5:
                    TesteAtor();
                    break;
                default:
                    Console.WriteLine("Você digitou um número inválido");
                    break;
            }

            if(retorno > 0)
                Console.WriteLine(retorno);

            Console.WriteLine("digite qualquer tecla para sair");
            Console.ReadLine();
        }

        private static void TesteAtor()
        {
            var ator = new Ator();
            ator.Nome = "Igor Hain";
            ator.Idade = 23;
        }

        private static void LerArquivoXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("C:/Curso/xml arquivo/filmes/filmes.xml");

            var banco = new Banco();

            XmlNode node = doc.SelectSingleNode("Filmes");
            foreach (XmlNode filme in node)
            {
                var objetoFilme = new Filme();

                objetoFilme.Titulo = filme.SelectSingleNode("Titulo").InnerText;
                objetoFilme.DataLancamento = Convert.ToDateTime(filme.SelectSingleNode("DataLancamento").InnerText);
                objetoFilme.Estudio = filme.SelectSingleNode("Estudio").InnerText;

                var repositorioFilmes = new RepositorioFilmes();
                repositorioFilmes.GravarFilme(objetoFilme);

                Console.WriteLine("Titulo: " + objetoFilme.Titulo + " Data de Lançamento: " + objetoFilme.DataLancamento + " Estudio: " + objetoFilme.Estudio);
            }
        }

        private static int MultiplicarPorDois()
        {
            var numero = DigiteUmNumero();
            return numero * 2;
        }

        private static int MultiplicarPorDez()
        {
            var numero = DigiteUmNumero();
            return numero * 10;
        }

        private static int MultiplicarPorQuatro()
        {
            var numero = DigiteUmNumero();
            return numero * 4;
        }

        private static int DigiteUmNumero()
        {
            Console.WriteLine("Digite um número maior que zero");
            string numero = Console.ReadLine();

            int num = 0;
            if (Int32.TryParse(numero, out num))
            {
                return num;
            }
            else
            {
                Console.WriteLine("Número inválido");
                return 0;
            }
        }

        static T lerInputDevolverConvertido<T>()
        {
            var opt = Console.ReadLine();
            try
            {
                return (T)Convert.ChangeType(opt, typeof(T));
            }
            catch
            {
                return default(T);
            }
        }
    }
}
