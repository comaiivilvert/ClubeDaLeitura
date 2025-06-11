using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modulo_de_Amigos;
using ClubeDaLeitura.ConsoleApp.Modulo_de_Caixas;
using ClubeDaLeitura.ConsoleApp.Modulo_de_Revistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClubeDaLeitura.ConsoleApp.Modulo_de_Empréstimos
{
    internal class Emprestimo : EntidadeBase

    {


        public Amigo amigo;
        public Revista revista;
        public DateTime data;
        public string situacao; //aberto/concluido/atrasado
        public DateTime dataDevolucao;


        public Emprestimo(Amigo amigo, Revista revista, string situacao, DateTime data)
        {
            this.amigo = amigo;
            this.revista = revista;
            this.data = data;//DateTime.Now; //ajustar aqui antes de enviar para professores 
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
            dataDevolucao = data.AddDays(7);
            
            if (DateTime.Now > dataDevolucao)
            {
                situacao = "Atrasado";

            }
            return;
        }

        public void registrarDevolucao()
        {
            throw new NotImplementedException();
        }

       

    }
}
