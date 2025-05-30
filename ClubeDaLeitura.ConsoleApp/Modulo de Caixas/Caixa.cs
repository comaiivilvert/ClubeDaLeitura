using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Modulo_de_Revistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Modulo_de_Caixas
{
    internal class Caixa : EntidadeBase
    {
        public string etiqueta;
        public string cor;
        public int diasEmprestimo = 7;
        Revista revista = new Revista();



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
            throw new NotImplementedException();
        }



        public override string Validar()
        {
            string erros = "";

            if (etiqueta.Length > 50)
                erros += "O campo \"ETIQUETA\" deve conter no máximo 50 caracteres.\n";

            else if (cor != "verde" && cor != "preto" && cor != "branco")
                erros += "O campo \"COR\" Precisa ser Verde/Preto/Branco.\n";

            if (diasEmprestimo <= 0)
                erros += "O campo \"DIAS DE EMPRESTIMO\" deve ser um numero positivo.\n";

            return erros;
        }
    }
}
