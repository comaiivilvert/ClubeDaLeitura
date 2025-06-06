using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modulo_de_Amigos;
using ClubeDaLeitura.ConsoleApp.Modulo_de_Caixas;
using ClubeDaLeitura.ConsoleApp.Modulo_de_Empréstimos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Modulo_de_Revistas
{
    internal class TelaRevista : TelaBase
    {
        public RepositorioRevista repositorioRevista;
        public RepositorioCaixa repositorioCaixa;
        
        public TelaRevista(RepositorioRevista repositorioRevista,
            RepositorioCaixa repositorioCaixa
            ) : base("Revista", repositorioRevista)
        {
            this.repositorioRevista = repositorioRevista;
            this.repositorioCaixa = repositorioCaixa;
        }

        public override void VisualizarTodos(bool exibirCabecalho)
        {
            if (exibirCabecalho == true)
                ExibirCabecalho();

            Console.WriteLine("Visualização de Revistas");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -10} | {3, -15} | {4, -25} | {5, -20}",
                "Id", "Título", "Nº Edição", "Ano Publicação", "Status de Empréstimo", "Caixa"
            );

            EntidadeBase[] revista = repositorioRevista.SelecionarTodos();

            for (int i = 0; i < revista.Length; i++)
            {
                Revista r = (Revista)revista[i];

                if (r == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -10} | {3, -15} | {4, -25} | {5, -20}",
                    r.id, r.titulo, r.numeroEdicao, r.anoPublicacao, r.statusEmprestimo, r.caixa.etiqueta
                );
            }

            Console.ReadLine();
        }

        public void VisualizarCaixas()
        {
            Console.WriteLine();

            Console.WriteLine("Visualização de Caixas");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -15} | {3, -15}",
                "Id", "Etiqueta", "Cor", "Dias de Emprestimo"
            );

            
            EntidadeBase[] caixa = repositorioCaixa.SelecionarTodos();

            for (int i = 0; i < caixa.Length; i++)
            {
                Caixa c = (Caixa)caixa[i];

                if (c == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -15} | {3, -15}",
                    c.id, c.etiqueta, c.cor, c.diasEmprestimo
                );
            }

            Console.ReadLine();
        }

        protected override EntidadeBase ObterDados()
        {
            Console.Write("Digite o Título da revista: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite o numero da edição da revista: ");
            int numeroEdicao = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o ano de publicação da revista: ");
            int anoPublicacao = Convert.ToInt32(Console.ReadLine());

            //Console.Write("Digite o status do emprestimo desta revista: ");
            //string statusEmprestimo = Console.ReadLine();

            VisualizarCaixas();

            Console.Write("Digite o ID da caixa desta revista: ");
            int IdCaixa = Convert.ToInt32(Console.ReadLine());

            Caixa caixaSelecionada = (Caixa)repositorioCaixa.SelecionarPorId(IdCaixa);

            Revista revista = new Revista(titulo,numeroEdicao,anoPublicacao,caixaSelecionada);

            return revista;
        }

    }


}

