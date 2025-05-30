using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modulo_de_Amigos;
using ClubeDaLeitura.ConsoleApp.Modulo_de_Revistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Modulo_de_Empréstimos
{
    internal class Emprestimo : EntidadeBase

    {
        public Amigo amigo = new Amigo();
        public Revista revista = new Revista();
        public DateTime data;
        public string situacao; //aberto/concluido/atrasado


        public Emprestimo(Amigo amigo, Revista revista, string situacao)
        {
            this.amigo = amigo;
            this.revista = revista;
            this.data = DateTime.Now;
            this.situacao = situacao;
        }


        public override void AtualizarRegistro(EntidadeBase registroAtualizado)
        {
            return;
        }

        public override string Validar()
        {
            string erros = "";

            if (string.IsNullOrWhiteSpace(amigo.nome))
                erros += "O campo \"NOME\" é obrigatório.\n";

            return erros;
        }

        public void obterDataDevolucao()
        {
            throw new NotImplementedException();
        }

        public void registrarDevolucao()
        {
            throw new NotImplementedException();
        }
    }
}
