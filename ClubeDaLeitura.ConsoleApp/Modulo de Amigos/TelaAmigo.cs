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
                    "{0, -10} | {1, -20} | {2, -15} | {3, -15}",
                
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

            Amigo amigo = new Amigo();
            amigo.nome = nome;
            amigo.responsavel = responsavel;
            amigo.telefone = telefone;

            return amigo;
        }

        public override void Inserir()
        {
            ExibirCabecalho();

            Console.WriteLine($"Cadastro de {nomeEntidade}");

            Console.WriteLine();

            Amigo novoRegistro = (Amigo)ObterDados();

            string erros = novoRegistro.Validar();

            if (erros.Length > 0)
            {
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(erros);
                Console.ResetColor();

                Console.Write("\nDigite ENTER para continuar...");
                Console.ReadLine();

                Inserir();

                return;
            }

            EntidadeBase[] registros = repositorio.SelecionarTodos();

            for (int i = 0; i < registros.Length; i++)
            {
                Amigo amigoRegistrado = (Amigo)registros[i];

                if (amigoRegistrado == null)
                    continue;

                if (amigoRegistrado.nome == novoRegistro.nome || amigoRegistrado.telefone == novoRegistro.telefone)
                {
                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Um amigo com este nome ou telefone já foi cadastrado!");
                    Console.ResetColor();

                    Console.Write("\nDigite ENTER para continuar...");
                    Console.ReadLine();

                    Inserir();
                    return;
                }
            }

            repositorio.Inserir(novoRegistro);

            Console.WriteLine($"\n{nomeEntidade} cadastrado com sucesso!");
            Console.ReadLine();
        }

        public override void Editar()
        {
            ExibirCabecalho();

            Console.WriteLine($"Edição de {nomeEntidade}");

            Console.WriteLine();

            VisualizarTodos(false);

            Console.Write("Digite o id do registro que deseja selecionar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Amigo registroAtualizado = (Amigo)ObterDados();

            string erros = registroAtualizado.Validar();

            if (erros.Length > 0)
            {
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(erros);
                Console.ResetColor();

                Console.Write("\nDigite ENTER para continuar...");
                Console.ReadLine();

                Editar();

                return;
            }

            EntidadeBase[] registros = repositorio.SelecionarTodos();

            for (int i = 0; i < registros.Length; i++)
            {
                Amigo amigoRegistrado = (Amigo)registros[i];

                if (amigoRegistrado == null)
                    continue;

                if (
                    amigoRegistrado.id != idSelecionado &&
                    (amigoRegistrado.nome == registroAtualizado.nome ||
                    amigoRegistrado.telefone == registroAtualizado.telefone)
                )
                {
                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Um amigo com este nome ou telefone já foi cadastrado!");
                    Console.ResetColor();

                    Console.Write("\nDigite ENTER para continuar...");
                    Console.ReadLine();

                    Editar();

                    return;
                }
            }

            repositorio.Editar(idSelecionado, registroAtualizado);

            Console.WriteLine($"\n{nomeEntidade} editado com sucesso!");
            Console.ReadLine();
        }


    }
}
