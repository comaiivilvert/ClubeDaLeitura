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
        public RepositorioAmigo repositorioAmigo;
        public RepositorioEmprestimo repositorioEmprestimo;


        public TelaRevista(RepositorioRevista repositorioRevista
            ) : base("Revista", repositorioRevista)
        {
            this.repositorioRevista = repositorioRevista;
        }

        public override void VisualizarTodos(bool exibirCabecalho)
        {
            if (exibirCabecalho == true)
                ExibirCabecalho();

            Console.WriteLine("Visualização de Revistas");

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
            Console.Write("Digite o nome do amigo: ");
            string nome = Console.ReadLine();

            Console.Write("Digite e responsável do amigo: ");
            string responsavel = Console.ReadLine();

            Console.Write("Digite o telefone do amigo: ");
            string telefone = Console.ReadLine();

            Amigo amigo = new Amigo();
            amigo.nome = nome;
            amigo.responsavel = responsavel;
            amigo.telefone = telefone;

            return amigo;
        }

        private void VisualizarEmprestimos()
        {
            Console.WriteLine();

            Console.WriteLine("Visualização de Empréstimos");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -20}",
                "Id", "Amigo", "Revista", "Data", "Situação"
            );

            EntidadeBase[] emprestimos = repositorioEmprestimo.SelecionarTodos();

            for (int i = 0; i < emprestimos.Length; i++)
            {
                Emprestimo e = (Emprestimo)emprestimos[i];

                if (e == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -20} | {5, -15}"
                //e.id, e.nome, e.precoAquisicao.ToString("C2"), e.numeroSerie, e.fabricante.nome, e.dataFabricacao.ToShortDateString()
                );
            }

            Console.ReadLine();
        }
    }


}

