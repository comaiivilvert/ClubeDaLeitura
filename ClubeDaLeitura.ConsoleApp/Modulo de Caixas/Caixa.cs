using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modulo_de_Revistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Modulo_de_Caixas
{
    internal class Caixa : EntidadeBase
    {
        public string etiqueta;
        public string cor;
        public int diasEmprestimo;

        public Caixa(string etiqueta, string cor)
        {
            this.etiqueta = etiqueta;
            this.cor = cor;
            diasEmprestimo = 7;
        }

        public Caixa(string etiqueta, string cor, int diasEmprestimo)
        {
            this.etiqueta = etiqueta;
            this.cor = cor;
            this.diasEmprestimo = diasEmprestimo;
        }

        public void AdicionarRevista()
        {
            //exibir revistas
            //ler id da revista que deseja inserir na caixa
            //gravar dentro da caixa
        }
        public void RemoverRevista()
        {

        }
        public override void AtualizarRegistro(EntidadeBase registroAtualizado)
        {
            Caixa caixaAtualizada = (Caixa)registroAtualizado;

            this.etiqueta = caixaAtualizada.etiqueta;
            this.cor = caixaAtualizada.cor;
            this.diasEmprestimo = caixaAtualizada.diasEmprestimo;
        }



        public override string Validar()
        {
            string erros = "";

            if(string.IsNullOrWhiteSpace(etiqueta) || etiqueta.Length > 50)
            erros += "O campo \"Etiqueta\" é obrigatório e recebe no máximo 50 caracteres.";

            if (string.IsNullOrWhiteSpace(cor))
                erros += "O campo \"Cor\" é obrigatório.";

            if (diasEmprestimo < 1)
                erros += "O campo \"Dias de Empréstimo\" deve conter um valor maior que 0.";

            return erros;
        }
    }
}
