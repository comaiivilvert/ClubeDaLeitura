using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modulo_de_Amigos;
using ClubeDaLeitura.ConsoleApp.Modulo_de_Empréstimos;
using ClubeDaLeitura.ConsoleApp.Modulo_de_Revistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Modulo_de_Caixas
{
    internal class TelaCaixa : TelaBase
    {
        public RepositorioCaixa repositorioCaixa;
        public RepositorioAmigo repositorioAmigo;
        public RepositorioEmprestimo repositorioEmprestimo;
        public RepositorioRevista repositorioRevista;
        

        public TelaCaixa(RepositorioCaixa repositorioCaixa,
            RepositorioAmigo repositorioAmigo,
            RepositorioEmprestimo repositorioEmprestimo,
            RepositorioRevista repositorioRevista
            ) : base("Caixa", repositorioCaixa)
        {
            this.repositorioCaixa = repositorioCaixa;
            this.repositorioAmigo = repositorioAmigo;
            this.repositorioEmprestimo = repositorioEmprestimo;
            this.repositorioRevista = repositorioRevista;
        }

        public override void VisualizarTodos(bool exibirCabecalho)
        {
            if (exibirCabecalho == true)
                ExibirCabecalho();

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
            Console.Write("Digite o nome da etiqueta: ");
            string etiqueta = Console.ReadLine();

            Console.Write("Digite a cor da caixa: ");
            string cor = Console.ReadLine();

            Console.Write("Digite quantos dias de emprestimo: ");
            int diasEmprestimo = Convert.ToInt32(Console.ReadLine());

            Caixa caixa = new Caixa(etiqueta,cor);

            return caixa;
        }


        public override void Inserir()
        {
            ExibirCabecalho();

            Console.WriteLine($"Cadastro de {nomeEntidade}");

            Console.WriteLine();

            Caixa novoRegistro = (Caixa)ObterDados();

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
                Caixa caixaRegistrada = (Caixa)registros[i];

                if (caixaRegistrada == null)
                    continue;

                if (caixaRegistrada.etiqueta == novoRegistro.etiqueta)
                {
                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Uma caixa com esta etiqueta já foi cadastrado!");
                    Console.ResetColor();

                    Console.Write("\nDigite ENTER para continuar...");
                    Console.ReadLine();

                    Inserir();
                    return;
                }
            }


            repositorio.Inserir(novoRegistro);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{nomeEntidade} cadastrado com sucesso!");
            Console.ResetColor();
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

            Caixa registroAtualizado = (Caixa)ObterDados();

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
                Caixa caixaRegistrada = (Caixa)registros[i];

                if (caixaRegistrada == null)
                    continue;

                if (
                    caixaRegistrada.id != idSelecionado &&
                    (caixaRegistrada.etiqueta == registroAtualizado.etiqueta)
                )
                {
                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Uma caixa com esta etiqueta já foi cadastrado!");
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{nomeEntidade} excluído com sucesso!");
            Console.ResetColor();
            Console.ReadLine();
        }

    }


}

