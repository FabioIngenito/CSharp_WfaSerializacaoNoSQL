using ClsSerializacaoNoSQL.Model;
using MongoDB.Driver;
using System.Configuration;

namespace ClsSerializacaoNoSQL.DAL;

public class ClsConectandoMongoDB
{
    public const string NOME_DA_BASE = "SerializacaoNoSQL";
    public const string NOME_DA_COLECAO = "tbFuncionario";

    private static readonly IMongoClient _cliente;
    private static readonly IMongoDatabase _BaseDeDados;

    static ClsConectandoMongoDB()
    {
        _cliente = new MongoClient(ConfigurationManager.ConnectionStrings["TesteMongoDB"].ToString());
        _BaseDeDados = _cliente.GetDatabase(NOME_DA_BASE);
    }

    public IMongoClient Cliente
    {
        get { return _cliente; }
    }

    public IMongoCollection<ClsFuncionarioModel> Funcionarios
    {
        get { return _BaseDeDados.GetCollection<ClsFuncionarioModel>(NOME_DA_COLECAO); }
    }
}
