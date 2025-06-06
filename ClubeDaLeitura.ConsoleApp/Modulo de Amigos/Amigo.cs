using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modulo_de_Empréstimos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Modulo_de_Amigos
{
    public class Amigo : EntidadeBase
    {
        
        public string nome;
        public string responsavel;
        public string telefone;

        public Amigo(string nome, string responsavel, string telefone)
        {
            this.nome = nome;
            this.responsavel = responsavel;
            this.telefone = telefone;
        }

        public override string Validar()
        {
            string erros = "";

            if (responsavel.Length < 3 || responsavel.Length > 100)
                erros += "O campo \"RESPONSÁVEL\" precisa conter entre 3 e 100 caracteres.\n";

            else if (nome.Length < 3 || nome.Length > 100)
                erros += "O campo \"NOME\" precisa conter entre 3 e 100 caracteres.\n";

            if (telefone.Length < 11 || telefone.Length > 12 )
                erros += "O campo \"TELEFONE\" está invalido: (XX XXXXXXXX) ou (XX XXXXXXXXX).\n";
            
            return erros;
        }

        public void ObterEmprestimos() //mostrar todos os emprestimos
        {
            throw new NotImplementedException();
        }

        public override void AtualizarRegistro(EntidadeBase registroAtualizado)
        {
            Amigo amigoAtualizado = (Amigo)registroAtualizado;

            this.nome = amigoAtualizado.nome;
            this.responsavel = amigoAtualizado.responsavel;
            this.telefone = amigoAtualizado.telefone;
        }
    }
}
