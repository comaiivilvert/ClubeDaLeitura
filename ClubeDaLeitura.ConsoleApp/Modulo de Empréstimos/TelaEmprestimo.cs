using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modulo_de_Amigos;
using ClubeDaLeitura.ConsoleApp.Modulo_de_Caixas;
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


        public TelaEmprestimo(RepositorioEmprestimo repositorioEmprestimo,
            RepositorioAmigo repositorioAmigo,
            RepositorioRevista repositorioRevista
            ) : base("Emprestimo", repositorioEmprestimo)
        {
            this.repositorioEmprestimo = repositorioEmprestimo;
            this.repositorioAmigo = repositorioAmigo;
            this.repositorioRevista = repositorioRevista;
        }

        public override void VisualizarTodos(bool exibirCabecalho)
        {
            if (exibirCabecalho == true)
                ExibirCabecalho();

            Console.WriteLine("Visualização de Emprestimos");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {3, -20}",
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
                    e.id, e.amigo.nome, e.revista.titulo, e.data, e.situacao
                );
            }

            Console.ReadLine();
        }

        protected override EntidadeBase ObterDados()
        {
            VisualizarAmigos();
            Console.Write("Digite o id do amigo: ");
            int idAmigo = Convert.ToInt32(Console.ReadLine());
            Amigo amigoSelecionado = (Amigo)repositorioAmigo.SelecionarPorId(idAmigo);

            VisualizarRevistas();
            Console.Write("Digite o ID da revista: ");
            int idRevista= Convert.ToInt32(Console.ReadLine());
            Revista revistaSelecionada = (Revista)repositorioRevista.SelecionarPorId(idRevista);

            string situacao = "Aberto";
            revistaSelecionada.statusEmprestimo = situacao;

            Emprestimo emprestimo = new Emprestimo(amigoSelecionado, revistaSelecionada, situacao);
            
            return emprestimo;
        
        }

        public void VisualizarAmigos()
        {

            Console.WriteLine("Visualização de Amigos");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -15} | {3, -15}",
                "Id", "Nome", "Responsável", "Telefone"
            );

            EntidadeBase[] amigo = repositorioAmigo.SelecionarTodos();

            for (int i = 0; i < amigo.Length; i++)
            {
                Amigo a = (Amigo)amigo[i];

                if (a == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -15} | {3, -15}",
                    a.id, a.nome, a.responsavel, a.telefone
                );
            }

            Console.ReadLine();
        }

        public void VisualizarRevistas()
        {
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

        public char ApresentarMenuEmprestimo()
        {
            ExibirCabecalho();

            Console.WriteLine($"1 - Cadastro de novo empréstimo");
            Console.WriteLine($"2 - Visualizar empréstimos Abertos/Concluídos");
            Console.WriteLine($"3 - Registrar devolução");
            Console.WriteLine($"S - Sair");

            Console.WriteLine();

            Console.Write("Digite uma opção válida: ");
            char opcaoEscolhida = Console.ReadLine().ToUpper()[0];
            return opcaoEscolhida;
        }

        public void RegistrarDevolucao()
        {
            VisualizarTodos(false);
            Console.Write("Digite o id do empréstimo que deseja devolver: ");
            int idEmprestimo = Convert.ToInt32(Console.ReadLine());
            Emprestimo emprestimoSelecionado = (Emprestimo)repositorioEmprestimo.SelecionarPorId(idEmprestimo);

            if (emprestimoSelecionado.situacao == "Aberto" || emprestimoSelecionado.situacao == "Atrasado")
                emprestimoSelecionado.situacao = "Concluído";

            Revista revistaDevolvida = emprestimoSelecionado.revista;
            revistaDevolvida.statusEmprestimo = "Em Estoque";


        }

        internal void VisualizarAtrasados()
        {
            throw new NotImplementedException();
        }
    }
}
