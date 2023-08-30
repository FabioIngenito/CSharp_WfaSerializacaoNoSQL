// Site para conversão de JSON -> C#
// https://json2csharp.com/
//
// RETIRE: "ObjectId{ ... } (MAS DEIXE O VALOR)

namespace ClsSerializacaoNoSQL.Model;

public class ClsDependenteModel
{
    #region Construtores

    //public ClsDependenteModel()
    //{

    //}

    #endregion

    #region Atributos

    private string? _nome;
    private char _sexo;
    private DateTime _nascimento;
    private string? _parentesco;

    #endregion

    #region Propriedades

    public string? Nome
    {
        get { return _nome; }
        set { _nome = value; }
    }

    public char Sexo
    {
        get { return _sexo; }
        set { _sexo = value; }
    }

    public DateTime Nascimento
    {
        get { return _nascimento; }
        set { _nascimento = value; }
    }

    public string? Parentesco
    {
        get { return _parentesco; }
        set { _parentesco = value; }
    }

    #endregion
}
