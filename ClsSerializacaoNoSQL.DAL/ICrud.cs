using System.Data;

namespace ClsSerializacaoNoSQL.DAL;

public interface ICrud<T, tipoChave>
{
    string Incluir(T entidade, char BD);
    void Alterar(T entidade, char BD);
    void Excluir(tipoChave chave, char BD);
    tipoChave Inserir(T entidade, char BD);
    DataTable Listagem(tipoChave chave, char BD);
    T SelecionarPorChave(tipoChave chave, char BD);
    List<T> SelecionarTodos(char BD);
    List<T> SelecionarPorParametro(T entidade, char BD);
    int ContaRegistros(char BD);
    bool VerificarSeChaveExiste(tipoChave chave, char BD);
}
