using ClsSerializacaoNoSQL.DAL;
using ClsSerializacaoNoSQL.Model;
using System.Data;

namespace ClsSerializacaoNoSQL.BLL;

public class ClsSerializacaoNoSQLBLL : ICrud<ClsFuncionarioModel, string>
{
    /// <summary>
    /// Alterar da BLL. Aplicar as regras de negócio.
    /// </summary>
    /// <param name="entidade">Estrutura MODEL de Funcionário</param>
    /// <exception cref="Exception">Erro de Sistema</exception>
    public void Alterar(ClsFuncionarioModel entidade, char BD)
    {
        //Regra de Negócio: O CPF do funcionário é obrigatório
        if (entidade.CPF is null) throw new Exception("O CPF do Funcionário é obrigatório");

        //Regra de Negócio: O nome do funcionário é obrigatório
        if (entidade.Nome is null) throw new Exception("O nome do Funcionário é obrigatório");

        //Regra de Negócio: O ID do departamento é obrigatório
        if (entidade.Id_Departamento == 0) throw new Exception("O ID do Departamento é obrigatório.");

        //Regra de Negócio: O nome do departamento é obrigatório
        if (entidade.Nome_Departamento is null) throw new Exception("O Nome do Departamento é obrigatório.");

        //Se tudo está Okay, chama a rotina de alteração.
        ClsSerializacaoNoSQLDAL obj = new(BD);

        obj.Alterar(entidade, BD);
    }

    /// <summary>
    /// Contar o número de registros dentro da tabela do banco de dados.
    /// </summary>
    /// <returns>Um número inteiro - quantidade de registros.</returns>
    public int ContaRegistros(char BD)
    {
        ClsSerializacaoNoSQLDAL obj = new(BD);

        return obj.ContaRegistros(BD);
    }

    /// <summary>
    /// Excluir Genérico da DAL. Redireciona para o BD Correto.
    /// </summary>
    /// <param name="chave">CPF ou Nome do Funcionário</param>
    /// <exception cref="Exception">Erro de Sistema</exception>
    public void Excluir(string chave, char BD)
    {
        if (chave == "") throw new Exception("Selecione um Funcionário antes de excluí-lo.");

        ClsSerializacaoNoSQLDAL obj = new(BD);

        obj.Excluir(chave, BD);
    }

    /// <summary>
    /// Incluir da BLL. Aplicar as regras de negócio.
    /// </summary>
    /// <param name="entidade"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public string Incluir(ClsFuncionarioModel entidade, char BD)
    {
        string incluir = "";

        //Regra de Negócio: O CPF do funcionário é obrigatório
        if (entidade.CPF is null) throw new Exception("O CPF do Funcionário é obrigatório");

        //Regra de Negócio: O nome do funcionário é obrigatório
        if (entidade.Nome is null) throw new Exception("O nome do Funcionário é obrigatório.");

        //Regra de Negócio: O ID do departamento é obrigatório
        if (entidade.Id_Departamento == 0) throw new Exception("O ID do Departamento é obrigatório.");

        //Regra de Negócio: O nome do departamento é obrigatório
        if (entidade.Nome_Departamento is null) throw new Exception("O Nome do Departamento é obrigatório.");

        //A Classe Data Access Layer
        ClsSerializacaoNoSQLDAL obj = new(BD);

        //Regra de Sistema: Verificar se a Chave Primaria já existe no Banco de Dados.
        bool blnExiste = obj.VerificarSeChaveExiste(entidade.CPF, BD);

        if (!blnExiste)
        {
            //Se está tudo okay, chama a rotina de inserção.
            //Passando para inclusão a estrutura do cliente (preenchida com os 
            //dados a serem incluídos e o banco que quero que inclua os dados).
            incluir = obj.Incluir(entidade, BD);
        }

        return incluir;
    }

    public string Inserir(ClsFuncionarioModel entidade, char BD)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Listagem Genérico da DAL. Redireciona para o BD Correto.
    /// </summary>
    /// <param name="chave">CPF do funcionário.</param>
    /// <returns>Uma DataTable com a lista baseada na chave recebida.</returns>
    public DataTable Listagem(string chave, char BD)
    {
        ClsSerializacaoNoSQLDAL obj = new(BD);

        return obj.Listagem(chave, BD);
    }

    public ClsFuncionarioModel SelecionarPorChave(string chave, char BD)
    {
        //Regra de Negócio: A chave é obrigatória.
        if (string.IsNullOrEmpty(chave)) return new ClsFuncionarioModel();

        ClsSerializacaoNoSQLDAL obj = new(BD);

        return obj.SelecionarPorChave(chave, BD);
    }

    public List<ClsFuncionarioModel> SelecionarPorParametro(ClsFuncionarioModel entidade, char BD)
    {
        throw new NotImplementedException();
    }

    public List<ClsFuncionarioModel> SelecionarTodos(char BD)
    {
        throw new NotImplementedException();
    }

    public bool VerificarSeChaveExiste(string chave, char BD)
    {
        //A Classe Data Access Layer
        ClsSerializacaoNoSQLDAL obj = new(BD);

        //Regra de Sistema: Verificar se a Chave Primaria já existe no Banco de Dados.
        return obj.VerificarSeChaveExiste(chave, BD);
    }
}
