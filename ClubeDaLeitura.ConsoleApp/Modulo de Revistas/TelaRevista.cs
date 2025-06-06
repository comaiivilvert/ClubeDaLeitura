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

            VisualizarCaixas();

            Console.Write("Digite o ID da caixa desta revista: ");
            int IdCaixa = Convert.ToInt32(Console.ReadLine());

            Caixa caixaSelecionada = (Caixa)repositorioCaixa.SelecionarPorId(IdCaixa);

            Revista revista = new Revista(titulo,numeroEdicao,anoPublicacao,caixaSelecionada);

            return revista;
        }


        public override void Inserir()
        {
            ExibirCabecalho();

            Console.WriteLine($"Cadastro de {nomeEntidade}");

            Console.WriteLine();

            Revista novoRegistro = (Revista)ObterDados();

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
                Revista revistaRegistrada = (Revista)registros[i];

                if (revistaRegistrada == null)
                    continue;

                if (revistaRegistrada.titulo == novoRegistro.titulo && revistaRegistrada.numeroEdicao == novoRegistro.numeroEdicao)
                {
                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Uma revista com este titulo e numero de edição já foi cadastrado!");
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

            Revista registroAtualizado = (Revista)ObterDados();

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
                Revista revistaRegistrada = (Revista)registros[i];

                if (revistaRegistrada == null)
                    continue;

                if (
                    revistaRegistrada.id != idSelecionado &&
                    (revistaRegistrada.titulo == registroAtualizado.titulo &&
                    revistaRegistrada.numeroEdicao == registroAtualizado.numeroEdicao)
                )
                {
                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Uma revista com este Titulo ou numero de Edição já foi cadastrada!");
                    Console.ResetColor();

                    Console.Write("\nDigite ENTER para continuar...");
                    Console.ReadLine();

                    Editar();

                    return;
                }
            }
        }
        public override void Excluir()
        {
            ExibirCabecalho();

            Console.WriteLine($"Exclusão de {nomeEntidade}");

            Console.WriteLine();

            VisualizarTodos(false);

            Console.Write("Digite o id do registro que deseja selecionar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());


            EntidadeBase[] revistas = repositorioRevista.SelecionarTodos();

            for (int i = 0; i < revistas.Length; i++)
            {
                Revista r = (Revista)revistas[i];

                if (r == null)
                    continue;
                if (r.id == idSelecionado)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Não é possivel excluir a Caixa pois ele possui revistas vinculadas");
                    Console.ResetColor();
                    Console.Write("\nDigite ENTER para continuar...");
                    Console.ReadLine();

                    return;

                }
            }


            Console.WriteLine();

            repositorio.Excluir(idSelecionado);

            Console.WriteLine($"\n{nomeEntidade} excluído com sucesso!");
            Console.ReadLine();
        }



    }


}

