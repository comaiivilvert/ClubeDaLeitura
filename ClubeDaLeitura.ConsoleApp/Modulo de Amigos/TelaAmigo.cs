using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modulo_de_Empréstimos;

namespace ClubeDaLeitura.ConsoleApp.Modulo_de_Amigos
{
    internal class TelaAmigo : TelaBase
    {
        public RepositorioAmigo repositorioAmigo;
        public RepositorioEmprestimo repositorioEmprestimo;
        

        public TelaAmigo(RepositorioAmigo repositorioAmigo           
            ) : base("Amigo", repositorioAmigo)
        {
            this.repositorioAmigo = repositorioAmigo;
        }

        public override void VisualizarTodos(bool exibirCabecalho)
        {
            if (exibirCabecalho == true)
                ExibirCabecalho();

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
                    "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -20}",
                    a.id, a.nome, a.responsavel, a.telefone
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

            //VisualizarEmprestimos();

            //Console.Write("Digite o ID do empréstimo que deseja selecionar: ");
            //int idEmprestimo = Convert.ToInt32(Console.ReadLine());

            //Emprestimo emprestimoSelecionado = (Emprestimo)repositorioEmprestimo.SelecionarPorId(idEmprestimo);

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

            EntidadeBase[] emprestimos = RepositorioEmprestimo.SelecionarTodos();

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
