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
        

        public TelaCaixa(RepositorioCaixa repositorioCaixa
            ) : base("Caixa", repositorioCaixa)
        {
            this.repositorioCaixa = repositorioCaixa;
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

            Caixa caixa = new Caixa();
            caixa.etiqueta = etiqueta;
            caixa.cor = cor;
            caixa.diasEmprestimo = diasEmprestimo;

            return caixa;
        }

    }


}

