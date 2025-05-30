using ClubeDaLeitura.ConsoleApp.Modulo_de_Amigos;
using ClubeDaLeitura.ConsoleApp.Modulo_de_Caixas;
using ClubeDaLeitura.ConsoleApp.Modulo_de_Empréstimos;
using ClubeDaLeitura.ConsoleApp.Modulo_de_Revistas;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
            RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
            RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();
            RepositorioRevista repositorioRevista = new RepositorioRevista();


            TelaAmigo telaAmigo = new TelaAmigo
            (
                repositorioAmigo
            );

            TelaCaixa telaCaixa = new TelaCaixa
           (
               repositorioCaixa
           );

            TelaEmprestimo telaEmprestimo = new TelaEmprestimo
           (
                repositorioEmprestimo
           );

            TelaRevista telaRevista = new TelaRevista
       (
            repositorioRevista
       );

            while (true)
            {
                char telaEscolhida = ApresentarMenuPrincipal();

                if (telaEscolhida == 'S' || telaEscolhida == 's')
                    break;

                if (telaEscolhida == '1')
                {
                    char opcaoEscolhida = telaAmigo.ApresentarMenu();

                    if (opcaoEscolhida == 'S')
                        break;

                    switch (opcaoEscolhida)
                    {
                        case '1':
                            telaAmigo.Inserir();
                            break;

                        case '2':
                            telaAmigo.VisualizarTodos(true);
                            break;

                        case '3':
                            telaAmigo.Editar();
                            break;

                        case '4':
                            telaAmigo.Excluir();
                            break;
                    }
                }

                else if (telaEscolhida == '2')
                {
                    char opcaoEscolhida = telaCaixa.ApresentarMenu();

                    if (opcaoEscolhida == 'S')
                        break;

                    switch (opcaoEscolhida)
                    {
                        case '1':
                            telaCaixa.Inserir();
                            break;

                        case '2':
                            telaCaixa.VisualizarTodos(true);
                            break;

                        case '3':
                            telaCaixa.Editar();
                            break;

                        case '4':
                            telaCaixa.Excluir();
                            break;
                    }
                }

                else if (telaEscolhida == '3')
                {
                    char opcaoEscolhida = telaEmprestimo.ApresentarMenu();

                    if (opcaoEscolhida == 'S')
                        break;

                    switch (opcaoEscolhida)
                    {
                        case '1':
                            telaEmprestimo.Inserir();
                            break;

                        case '2':
                            telaEmprestimo.VisualizarTodos(true);
                            break;

                        case '3':
                            telaEmprestimo.Editar();
                            break;

                        case '4':
                            telaEmprestimo.Excluir();
                            break;
                    }
                }

                else if (telaEscolhida == '4')
                {
                    char opcaoEscolhida = telaRevista.ApresentarMenu();

                    if (opcaoEscolhida == 'S')
                        break;

                    switch (opcaoEscolhida)
                    {
                        case '1':
                            telaRevista.Inserir();
                            break;

                        case '2':
                            telaRevista.VisualizarTodos(true);
                            break;

                        case '3':
                            telaRevista.Editar();
                            break;

                        case '4':
                            telaRevista.Excluir();
                            break;
                    }
                }

            }
        }

        public static char ApresentarMenuPrincipal()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|          Clube da Leitura             |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("1 - Módulo de Amigos");
            Console.WriteLine("2 - Módulo de Caixas");
            Console.WriteLine("3 - Módulo de Empréstimos");
            Console.WriteLine("4 - Módulo de Revistas");
            Console.WriteLine("S - Sair");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char opcaoEscolhida = Console.ReadLine()[0];

            return opcaoEscolhida;
        }
    }
    }

