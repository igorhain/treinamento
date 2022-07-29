using ConsoleIgor.Entidades;
using ConsoleIgor.Repositorios;
using System;
using System.Data;
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
            Console.WriteLine("5 - Cadastrar Ator");
            Console.WriteLine("6 - Listar Filmes por Nome");
            Console.WriteLine("7 - Listar Filmes por Estúdio");
            Console.WriteLine("8 - Listar Filmes por Ator");

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
                    CadastrarAtor();
                    break;
                case 6:
                    ListarFilmesPorNome();
                    break;
                case 7:
                    ListarFilmesPorEstudio();
                    break;
                case 8:
                    ListarFilmesPorAtores();
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

        private static void ListarFilmesPorNome()
        {
            Console.WriteLine("Digite o nome do filmes para listar os filmes");
            string nomeFilme = Console.ReadLine();

            var repositorioFilmes = new RepositorioFilmes();
            var dtFilmes = repositorioFilmes.BuscarFilmePorNome(nomeFilme, true);

            if (dtFilmes.Rows.Count > 0)
                Console.WriteLine("Filmes encontrados:");
            foreach (DataRow dr in dtFilmes.Rows)
            {
                Console.WriteLine(dr["nome"]);
            }
        }

        private static void ListarFilmesPorEstudio()
        {
            //Exercicio 1
            //CRIAR SELECT PARA LISTAR FILMES PELO ESTÚDIO
            Console.WriteLine("Digite o nome do estúdio para listar os filmes");
            string estudio = Console.ReadLine();

            var repositorioFilmes = new RepositorioFilmes();
            var dtFilmes = repositorioFilmes.ListarFilmesPorEstudio(estudio);

            if (dtFilmes.Rows.Count > 0)
                Console.WriteLine("Filmes encontrados pelo estúdio começando com: " + estudio);

            int c = 1;
            foreach (DataRow dr in dtFilmes.Rows)
            {
                Console.WriteLine(c + " - " + dr["nome"]);
                c++;
            }

            Console.WriteLine("");
        }


        private static void ListarFilmesPorAtores()
        {
            Console.WriteLine("Digite o nome do Ator");
            string estudio = Console.ReadLine();

            var repositorioFilmes = new RepositorioFilmes();
            var dtAtor = repositorioFilmes.ListarFilmesPorAtores(estudio);

            if (dtAtor.Rows.Count > 0)
                Console.WriteLine("Filmes encontrados pelo Ator começando com:" + estudio);

            var c = 1;
            foreach (DataRow dr in dtAtor.Rows)
            {
                Console.WriteLine(c + " - " + dr["nome"]);
                c++;
            }
            Console.WriteLine("");
        }

        private static void CadastrarAtor()
        {
            var ator = new Ator();
            Console.WriteLine("Digite o nome do ator");
            ator.Nome = Console.ReadLine();

            Console.WriteLine("Digite a idade do ator");
            ator.Idade = lerInputDevolverConvertido<int>();

            var repositorioAtores = new RepositorioAtores();
            repositorioAtores.GravarAtor(ator);

            Console.WriteLine("Inserido");

            //Exercicio 2
            //Criar RepositorioAtores e depois utilizar para gravar o Ator
            //também CRIAR a TABELA DE ATORES NO BANCO COM COLUNA DE NOME E IDADE
            //repositorioAtor = new repositorioAtores();
            //repositorioAtor.GravarAtor(ator);
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
