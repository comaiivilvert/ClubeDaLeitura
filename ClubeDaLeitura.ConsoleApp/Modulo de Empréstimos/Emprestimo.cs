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
        Amigo amigo = new Amigo();
        Revista revista = new Revista();
        DateTime data;
        string situacao;


        public static explicit operator Emprestimo(EntidadeBase v)
        {
            throw new NotImplementedException();
        }

        public override void AtualizarRegistro(EntidadeBase registroAtualizado)
        {
            Emprestimo emprestimoAtualizado = (Emprestimo)registroAtualizado;

            this.amigo = emprestimoAtualizado.amigo;
            this.revista = emprestimoAtualizado.revista;
            this.data = emprestimoAtualizado.data;
            this.situacao = emprestimoAtualizado.situacao;
        }

    }
}
