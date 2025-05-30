using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modulo_de_Amigos;
using ClubeDaLeitura.ConsoleApp.Modulo_de_Revistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Modulo_de_Empréstimos
{
    internal class TelaEmprestimo : TelaBase
    {
        public RepositorioEmprestimo repositorioEmprestimo;
        public RepositorioAmigo repositorioAmigo;
        public RepositorioRevista repositorioRevista;


        public TelaEmprestimo(RepositorioEmprestimo repositorioEmprestimo
            ) : base("Emprestimo", repositorioEmprestimo)
        {
            this.repositorioEmprestimo = repositorioEmprestimo;
        }

        public override void VisualizarTodos(bool exibirCabecalho)
        {
            if (exibirCabecalho == true)
                ExibirCabecalho();

            Console.WriteLine("Visualização de Emprestimos");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {3, -15}",
                "Id", "Amigo", "Revista", "Data", "Situação"
            );

            EntidadeBase[] emprestimo = repositorioEmprestimo.SelecionarTodos();

            for (int i = 0; i < emprestimo.Length; i++)
            {
                Emprestimo e = (Emprestimo)emprestimo[i];

                if (e == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -20}",
                    e.id, e.amigo, e.revista, e.data, e.situacao
                );
            }

            Console.ReadLine();
        }

        protected override EntidadeBase ObterDados()
        {
            Console.Write("Digite o id do amigo: ");
            string IdAmigo = Console.ReadLine();

            Console.Write("Digite o nome da revista: ");
            string revista = Console.ReadLine();

            Console.Write("Digite a situação do emprestimo: (Aberto/Concluído/Atrasado) ");
            string situacao = Console.ReadLine();

            VisualizarTodos(true);

            Console.Write("Digite o ID do empréstimo que deseja selecionar: ");
            int idEmprestimo = Convert.ToInt32(Console.ReadLine());

            Emprestimo emprestimoSelecionado = (Emprestimo)repositorioEmprestimo.SelecionarPorId(idEmprestimo);

            Emprestimo emprestimo = new Emprestimo
                (emprestimoSelecionado.amigo, emprestimoSelecionado.revista, emprestimoSelecionado.situacao);

            return emprestimo;
        }

        public void VisualizarRevistas()
        {

        }

        public void VisualizarAmigos()
        {

        }

        public void RegistrarDevolulcao()
        {

        }


    }
}
