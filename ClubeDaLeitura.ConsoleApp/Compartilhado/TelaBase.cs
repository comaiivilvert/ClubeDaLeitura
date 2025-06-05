using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    public abstract class TelaBase
    {
        protected string nomeEntidade;
        protected RepositorioBase repositorio;
        protected TelaBase(string nomeEntidade, RepositorioBase repositorio)
        {
            this.nomeEntidade = nomeEntidade;
            this.repositorio = repositorio;
        }

        public char ApresentarMenu()
        {
            ExibirCabecalho();

            Console.WriteLine($"1 - Cadastro de {nomeEntidade}");
            Console.WriteLine($"2 - Visualizar {nomeEntidade}");
            Console.WriteLine($"3 - Editar {nomeEntidade}");
            Console.WriteLine($"4 - Excluir {nomeEntidade}");
            Console.WriteLine($"S - Sair");

            Console.WriteLine();

            Console.Write("Digite uma opção válida: ");
            char opcaoEscolhida = Console.ReadLine().ToUpper()[0];
            return opcaoEscolhida;
        }


        protected void ExibirCabecalho()
        {
            Console.Clear();
            Console.WriteLine($"Gestão de {nomeEntidade}");
            Console.WriteLine();
        }

        public virtual void Inserir()
        {
            ExibirCabecalho();

            Console.WriteLine($"Cadastro de {nomeEntidade}");

            Console.WriteLine();

            EntidadeBase novoRegistro = ObterDados();

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

            repositorio.Inserir(novoRegistro);

            Console.WriteLine($"\n{nomeEntidade} cadastrado com sucesso!");
            Console.ReadLine();
        }

        public virtual void Editar()
        {
            ExibirCabecalho();

            Console.WriteLine($"Edição de {nomeEntidade}");

            Console.WriteLine();

            VisualizarTodos(false);

            Console.Write("Digite o id do registro que deseja selecionar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            EntidadeBase registroAtualizado = ObterDados();

            repositorio.Editar(idSelecionado, registroAtualizado);

            Console.WriteLine($"\n{nomeEntidade} editado com sucesso!");
            Console.ReadLine();
        }

        public virtual void Excluir()
        {
            ExibirCabecalho();

            Console.WriteLine($"Exclusão de {nomeEntidade}");

            Console.WriteLine();

            VisualizarTodos(false);

            Console.Write("Digite o id do registro que deseja selecionar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            repositorio.Excluir(idSelecionado);

            Console.WriteLine($"\n{nomeEntidade} excluído com sucesso!");
            Console.ReadLine();
        }

        public abstract void VisualizarTodos(bool exibirCabecalho);

        protected abstract EntidadeBase ObterDados();

    }
}
