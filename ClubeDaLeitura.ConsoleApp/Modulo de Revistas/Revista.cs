using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modulo_de_Amigos;
using ClubeDaLeitura.ConsoleApp.Modulo_de_Caixas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Modulo_de_Revistas
{
    internal class Revista : EntidadeBase
    {
        public string titulo;
        public int numeroEdicao;
        public int anoPublicacao;
        public Caixa caixa;
        public string statusEmprestimo;

        public Revista(string titulo, int numeroEdicao, int anoPublicacao, Caixa caixa)
        {
            this.titulo = titulo;
            this.numeroEdicao = numeroEdicao;
            this.anoPublicacao = anoPublicacao;
            statusEmprestimo = "Disponível";
            this.caixa = caixa;
        }

        public override void AtualizarRegistro(EntidadeBase registroAtualizado)
        {
            Revista revistaAtualizada = (Revista)registroAtualizado;

            this.titulo = revistaAtualizada.titulo;
            this.numeroEdicao = revistaAtualizada.numeroEdicao;
            this.anoPublicacao= revistaAtualizada.anoPublicacao;
        }

        public override string Validar()
        {
            string erros = "";

            if (titulo.Length < 2 || titulo.Length > 100)
                erros += "O campo \"TÍTULO\" precisa conter entre 2 e 100 caracteres.\n";

            else if (numeroEdicao <= 0)
                erros += "O campo \"NUMERO EDIÇÃO\" precisa ser positivo.\n";

            if (anoPublicacao < 1900 || anoPublicacao > DateTime.Now.Year)
                erros += "O campo \"ANO DE PUBLICAÇÃO\" está invalido: (1900-2025).\n";

            return erros;
        }
        public void Emprestar()
        {

        }

        public void Devolver()
        {

        }

        public void Reservar()
        {

        }
    }
}
