using ClubeDaLeitura.ConsoleApp.Compartilhado;
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
        public int diasEmprestimo;


        public void AdicionarRevista()
        {

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
            throw new NotImplementedException();
        }
    }
}
