namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

public abstract class RepositorioBase
{
    
    private EntidadeBase[] registros = new EntidadeBase[100];
    private int contadorRegistros = 0;

    public void Inserir(EntidadeBase novoRegistro)
    {
        registros[contadorRegistros] = novoRegistro;

        contadorRegistros++;
    }

    public bool Editar(int idSelecionado, EntidadeBase registroAtualizado)
    {
        EntidadeBase registroSelecionado = SelecionarPorId(idSelecionado);

        if (registroSelecionado == null)
            return false;

        registroSelecionado.AtualizarRegistro(registroAtualizado);

        return true;
    }

    public bool Excluir(int idSelecionado)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            if (registros[i] == null)
                continue;

            else if (registros[i].id == idSelecionado)
            {
                registros[i] = null;

                return true;
            }
        }

        return false;
    }

    public EntidadeBase[] SelecionarTodos()
    {
        return registros;
    }

    public EntidadeBase SelecionarPorId(int idSelecionado)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            EntidadeBase registro = registros[i];

            if (registro == null)
                continue;

            if (registro.id == idSelecionado)
                return registro;
        }

        return null;
    }
}
