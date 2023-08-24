using ClsSerializacaoNoSQL.Model;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Text.Json;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using MongoDB.Driver;
using Google.Protobuf.WellKnownTypes;
using MongoDB.Bson;
using System.Xml.Linq;
using System;

namespace ClsSerializacaoNoSQL.DAL;

public class ClsSerializacaoNoSQLDAL : IDisposable, ICrud<ClsFuncionarioModel, string>
{
    private readonly SqlConnection conexaoMSSQL = new();
    private readonly MySqlConnection conexaoMySQL = new();
    private readonly StringBuilder sbSQL = new("");
    private readonly JsonSerializerOptions options = new()
    {
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
    };
    private const string NOME_DA_BASE = "SerializacaoNoSQL";

    #region Contrutores

    public ClsSerializacaoNoSQLDAL(char BD)
    {
        ConnectionStringSettings connections1;
        IMongoClient _cliente;
        //IMongoDatabase _BaseDeDados;

        switch (BD)
        {
            case 'y':
                connections1 = ConfigurationManager.ConnectionStrings["TesteMySQL"];
                conexaoMySQL = new MySqlConnection(connections1.ConnectionString);
                break;

            case 'o':
                connections1 = ConfigurationManager.ConnectionStrings["TesteMongoDB"];

                _cliente = new MongoClient(connections1.ToString());
                //_BaseDeDados = _cliente.GetDatabase(NOME_DA_BASE);
                _ = _cliente.GetDatabase(NOME_DA_BASE);

                break;

            default:
                connections1 = ConfigurationManager.ConnectionStrings["TesteMySQL"];
                conexaoMySQL = new MySqlConnection(connections1.ConnectionString);
                //conexao.Open();
                break;
        }

        //conexao = new SqlConnection(connections1.ConnectionString);
        //conexao.Open();
    }

    #endregion

    #region IDisposable

    protected virtual void Dispose(bool disposing)
    {
        if (disposing && conexaoMySQL != null) conexaoMySQL.Dispose();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    #endregion

    /// <summary>
    /// Incluir Genérico da DAL. Redireciona para o BD Correto.
    /// 
    /// Montei 3 formas diferentes de fazer o INSERT na tabela tbfuncionario
    /// dentro do MySQL. Por favor, descomente e comente para testar cada forma 
    /// e aprecie as diferenças.
    /// </summary>
    /// <param name="entidade">Estrutura MODEL de FuncionáriosModel</param>
    /// <param name="BD">Sigla do Banco de Dados</param>
    /// <returns>Retorna string com a PK incluída dependendo se o BD suporta fazer isto.</returns>
    public string Incluir(ClsFuncionarioModel entidade, char BD)
    {
        switch (BD)
        {
            case 'm':
                return IncluirMSSQL(entidade);

            case 'y':
                //return IncluirMySQL1(entidade);
                //return IncluirMySQL2(entidade);
                return IncluirMySQL3(entidade);

            case 'o':
                return IncluirMongoDB(entidade);

            default:
                break;
        }

        return "";
    }

    /// <summary>
    /// Dados JSON no SQL Server
    /// Artigo - 02/04/2023
    /// Armazenar e indexar dados JSON no SQL Server
    /// https://learn.microsoft.com/pt-br/sql/relational-databases/json/json-data-sql-server?view=sql-server-ver16#store-and-index-json-data-in-sql-server
    /// </summary>
    /// <param name="entidade">Estrutura da ClsFuncionarioModel</param>
    /// <returns>Retorna uma String com o CPF caso tenha sucesso e VAZIO em caso de erro.</returns>
    /// <exception cref="Exception">SqlException para Banco e Exception para demais erros</exception>
    private string IncluirMSSQL(ClsFuncionarioModel entidade)
    {
        string retorno = "";
        string strSQL = "INSERT INTO tbfuncionario (CPF, JSON) VALUES (@CPF,@JSON);";

        try
        {
            //command
            SqlCommand cmd = new(strSQL)
            {
                //conexao
                Connection = conexaoMSSQL,
                CommandType = CommandType.Text,
                CommandText = strSQL
            };

            cmd.Parameters.Add("@CPF", SqlDbType.VarChar);
            cmd.Parameters.Add("@JSON", SqlDbType.NVarChar);

            cmd.Parameters["@CPF"].Value = entidade.CPF;
            cmd.Parameters["@JSON"].Value = JsonSerializer.Serialize(entidade, options);

            conexaoMSSQL.Open();
            cmd.ExecuteNonQuery();
            conexaoMSSQL.Close();

            if (cmd.Parameters["@CPF"].Value is not null)
                retorno = cmd.Parameters["@CPF"].Value.ToString() + "";
        }
        catch (SqlException ex)
        {
            throw new Exception("Servidor MSSQL Erro: " + ex.Number);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            conexaoMSSQL.Close();
        }

        return retorno;
    }

    /// <summary>
    /// * Esta é a primeira forma de demonstração para fazer INSERT no BD MySQL.
    /// 
    /// Usei:
    /// - StringBuilder + Replace;
    /// - Conexão ADO.Net dentro de um Try-Catch com tratamento de erro;
    /// </summary>
    /// <param name="entidade">Estrutura da ClsFuncionarioModel</param>
    /// <returns>Retorna uma String com o CPF caso tenha sucesso e VAZIO em caso de erro.</returns>
    /// <exception cref="Exception">MySqlException para Banco e Exception para demais erros</exception>
    //private string IncluirMySQL1(ClsFuncionarioModel entidade)
    //{
    //    string retorno;
    //    StringBuilder strBuilderSQL = new("INSERT INTO tbfuncionario (CPF, `JSON`) VALUES ('@CPF','@JSON');");

    //    try
    //    {
    //        //command
    //        MySqlCommand cmd = new();
    //        //conexao
    //        cmd.Connection = conexaoMySQL;
    //        cmd.CommandType = CommandType.Text;

    //        strBuilderSQL.Replace("@CPF", entidade.CPF);
    //        strBuilderSQL.Replace("@JSON", JsonSerializer.Serialize(entidade, options));

    //        cmd.CommandText = strBuilderSQL.ToString();

    //        conexaoMySQL.Open();
    //        cmd.ExecuteNonQuery();
    //        conexaoMySQL.Close();

    //        retorno = entidade.CPF + "";
    //    }
    //    catch (MySqlException ex)
    //    {
    //        throw new Exception("Servidor MySQL Erro: " + ex.Number);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.Message);
    //    }
    //    finally
    //    {
    //        conexaoMySQL.Close();
    //    }

    //    return retorno;
    //}

    /// <summary>
    /// * Esta é a segunda forma de demonstração para fazer INSERT no BD MySQL.
    /// 
    /// Usei:
    /// - StringBuilder + Append;
    /// - Conexão ADO.Net dentro de um USING com Try-Catch com tratamento de erro;
    /// </summary>
    /// <param name="entidade">Estrutura da ClsFuncionarioModel</param>
    /// <returns>Retorna uma String com o CPF caso tenha sucesso e VAZIO em caso de erro.</returns>
    /// <exception cref="Exception">MySqlException para Banco e Exception para demais erros</exception>
    //private string IncluirMySQL2(ClsFuncionarioModel entidade)
    //{
    //    string retorno;
    //    StringBuilder strBuilderSQL = new("INSERT INTO tbfuncionario (CPF, `JSON`) VALUES ('");

    //    strBuilderSQL.Append(entidade.CPF);
    //    strBuilderSQL.Append("','");
    //    strBuilderSQL.Append(JsonSerializer.Serialize(entidade, options));
    //    strBuilderSQL.Append("');");

    //    using (MySqlConnection conn = new(ConfigurationManager.ConnectionStrings["TesteMySQL"].ConnectionString))
    //    {
    //        try
    //        {
    //            MySqlCommand cmd = new(strBuilderSQL.ToString(), conn);
    //            conn.Open();

    //            cmd.ExecuteNonQuery();

    //            retorno = entidade.CPF + "";
    //        }
    //        catch (MySqlException ex)
    //        {
    //            throw new Exception("Servidor MySQL Erro: " + ex.Number);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception(ex.Message);
    //        }

    //        return retorno;
    //    }
    //}

    /// <summary>
    /// * Esta é a terceira forma de demonstração para fazer INSERT no BD MySQL.
    /// 
    /// Usei:
    /// - String + Parameters de ADO.Net;
    /// - Conexão ADO.Net dentro de um Try-Catch com tratamento de erro;
    /// </summary>
    /// <param name="entidade">Estrutura da ClsFuncionarioModel</param>
    /// <returns>Retorna uma String com o CPF caso tenha sucesso e VAZIO em caso de erro.</returns>
    /// <exception cref="Exception">MySqlException para Banco e Exception para demais erros</exception>
    private string IncluirMySQL3(ClsFuncionarioModel entidade)
    {
        string retorno = "";
        string strSQL = "INSERT INTO tbfuncionario (CPF, `JSON`) VALUES (@CPF,@JSON);";

        try
        {
            //command
            MySqlCommand cmd = new(strSQL)
            {
                //conexao
                Connection = conexaoMySQL,
                CommandType = CommandType.Text,
                CommandText = strSQL
            };

            cmd.Parameters.Add("@CPF", MySqlDbType.VarChar);
            cmd.Parameters.Add("@JSON", MySqlDbType.JSON);

            cmd.Parameters["@CPF"].Value = entidade.CPF;
            cmd.Parameters["@JSON"].Value = JsonSerializer.Serialize(entidade, options);

            conexaoMySQL.Open();
            cmd.ExecuteNonQuery();
            conexaoMySQL.Close();

            if (cmd.Parameters["@CPF"].Value is not null)
                retorno = cmd.Parameters["@CPF"].Value.ToString() + "";
        }
        catch (MySqlException ex)
        {
            throw new Exception("Servidor MySQL Erro: " + ex.Number);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            conexaoMySQL.Close();
        }

        return retorno;
    }

    private static string IncluirMongoDB(ClsFuncionarioModel entidade)
    {
        string retorno = entidade.CPF + "";

        try
        {
            ClsConectandoMongoDB conexaoMongoDB = new();

            conexaoMongoDB.Funcionarios.InsertOne(entidade);
        }
        catch (MongoException ex)
        {
            throw new Exception("Servidor MongoDB Erro: " + ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {

        }

        return retorno;
    }

    public void Alterar(ClsFuncionarioModel entidade, char BD)
    {
        switch (BD)
        {
            case 'm':
                AlterarMSSQL(entidade);
                break;
            case 'y':
                AlterarMySQL(entidade);
                break;
            case 'o':
                AlterarMongoDB(entidade);
                break;
            default:
                break;
        }
    }

    private void AlterarMSSQL(ClsFuncionarioModel entidade)
    {
        StringBuilder strBuilderSQL = new("UPDATE tbfuncionario SET CPF = '@CPF', `JSON` = '@JSON' WHERE CPF = '@CPF';");

        try
        {
            //command
            SqlCommand cmd = new()
            {
                //conexao
                Connection = conexaoMSSQL,
                CommandType = CommandType.Text
            };

            strBuilderSQL.Replace("@CPF", entidade.CPF);
            strBuilderSQL.Replace("@JSON", JsonSerializer.Serialize(entidade, options));

            cmd.CommandText = strBuilderSQL.ToString();

            conexaoMSSQL.Open();
            cmd.ExecuteNonQuery();
            conexaoMSSQL.Close();
        }
        catch (MySqlException ex)
        {
            throw new Exception("Servidor MSSQL Erro: " + ex.Number);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            conexaoMSSQL.Close();
        }
    }

    private void AlterarMySQL(ClsFuncionarioModel entidade)
    {
        StringBuilder strBuilderSQL = new("UPDATE tbfuncionario SET CPF = '@CPF', `JSON` = '@JSON' WHERE CPF = '@CPF';");

        try
        {
            //command
            MySqlCommand cmd = new()
            {
                //conexao
                Connection = conexaoMySQL,
                CommandType = CommandType.Text
            };

            strBuilderSQL.Replace("@CPF", entidade.CPF);
            strBuilderSQL.Replace("@JSON", JsonSerializer.Serialize(entidade, options));

            cmd.CommandText = strBuilderSQL.ToString();

            conexaoMySQL.Open();
            cmd.ExecuteNonQuery();
            conexaoMySQL.Close();
        }
        catch (MySqlException ex)
        {
            throw new Exception("Servidor MySQL Erro: " + ex.Number);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            conexaoMySQL.Close();
        }
    }

    private static void AlterarMongoDB(ClsFuncionarioModel entidade)
    {
        try
        {
            ClsConectandoMongoDB conexaoMongoDB = new();

            FilterDefinitionBuilder<ClsFuncionarioModel> construtor = Builders<ClsFuncionarioModel>.Filter;
            FilterDefinition<ClsFuncionarioModel> condicao = construtor.Eq(x => x.CPF, entidade.CPF);

            conexaoMongoDB.Funcionarios.ReplaceOne(condicao, entidade);
        }
        catch (MongoException ex)
        {
            throw new Exception("Servidor MongoDB Erro: " + ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {

        }
    }

    public int ContaRegistros(char BD)
    {
        switch (BD)
        {
            case 'm':
                return ContaRegistrosMSSQL();

            case 'y':
                return ContaRegistrosMySQL();

            case 'o':
                return ContaRegistrosMongoDB();

            default:
                break;
        }

        return 0;
    }

    private int ContaRegistrosMSSQL()
    {
        SqlDataAdapter da = new();
        DataTable dt = new();

        try
        {
            da.SelectCommand = new()
            {
                Connection = conexaoMSSQL,
                CommandType = CommandType.Text,
                //SQL
                CommandText = "SELECT COUNT(*) FROM tbfuncionario"
            };

            da.Fill(dt);

            return Convert.ToInt32(dt.Rows[0].ItemArray[0]);
        }
        catch (MySqlException ex)
        {
            throw new Exception("Servidor MSSQL Erro: " + ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {

        }
    }

    private int ContaRegistrosMySQL()
    {
        MySqlDataAdapter da = new();
        DataTable dt = new();

        try
        {
            da.SelectCommand = new()
            {
                Connection = conexaoMySQL,
                CommandType = CommandType.Text,
                //SQL
                CommandText = "SELECT COUNT(*) FROM tbfuncionario"
            };

            da.Fill(dt);

            return Convert.ToInt32(dt.Rows[0].ItemArray[0]);
        }
        catch (MySqlException ex)
        {
            throw new Exception("Servidor MySQL Erro: " + ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {

        }
    }

    private static int ContaRegistrosMongoDB()
    {
        int intReturn;

        try
        {
            ClsConectandoMongoDB conexaoMongoDB = new();

            intReturn = Convert.ToInt32(conexaoMongoDB.Funcionarios.EstimatedDocumentCount());
        }
        catch (MongoException ex)
        {
            throw new Exception("Servidor MongoDB Erro: " + ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {

        }

        return intReturn;
    }

    public void Excluir(string chave, char BD)
    {
        switch (BD)
        {
            case 'm':
                ExcluirMSSQL(chave);
                break;
            case 'y':
                //ExcluirMySQL1(chave);
                ExcluirMySQL2(chave);
                break;
            case 'o':
                ExcluirMongoDB(chave);
                break;
            default:
                break;
        }
    }

    private void ExcluirMSSQL(string Chave)
    {
        StringBuilder strBuilderSQL = new("DELETE FROM tbfuncionario WHERE CPF = '@CPF';");

        strBuilderSQL.Replace("@CPF", Chave);

        try
        {
            //command
            SqlCommand cmd = new()
            {
                //conexao
                Connection = conexaoMSSQL,
                CommandType = CommandType.Text,
                CommandText = strBuilderSQL.ToString()
            };

            conexaoMSSQL.Open();
            cmd.ExecuteNonQuery();
        }
        catch (MySqlException ex)
        {
            throw new Exception("Servidor MSSQL Erro: " + ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            conexaoMSSQL.Close();
        }
    }

    /// <summary>
    /// Excluir documento baseado em uma chave.
    /// </summary>
    /// <param name="Chave">Chave a ser excluída</param>
    /// <exception cref="Exception">Exceção lançada.</exception>
    //private static void ExcluirMySQL1(string Chave)
    //{
    //    StringBuilder strBuilderSQL = new("DELETE FROM tbfuncionario WHERE CPF = '@CPF';");

    //    strBuilderSQL.Replace("@CPF", Chave);

    //    using MySqlConnection conn = new(ConfigurationManager.ConnectionStrings["TesteMySQL"].ConnectionString);

    //    try
    //    {
    //        MySqlCommand cmd = new(strBuilderSQL.ToString(), conn);
    //        conn.Open();
    //        cmd.ExecuteNonQuery();
    //    }
    //    catch (MySqlException ex)
    //    {
    //        throw new Exception("Servidor MySQL Erro: " + ex.Message);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.Message);
    //    }
    //}

    /// <summary>
    /// Excluir documento baseado em uma chave.
    /// </summary>
    /// <param name="Chave">Chave a ser excluída</param>
    /// <exception cref="Exception">Exceção lançada.</exception>
    private void ExcluirMySQL2(string Chave)
    {
        StringBuilder strBuilderSQL = new("DELETE FROM tbfuncionario WHERE CPF = '@CPF';");

        strBuilderSQL.Replace("@CPF", Chave);

        try
        {
            //command
            MySqlCommand cmd = new()
            {
                //conexao
                Connection = conexaoMySQL,
                CommandType = CommandType.Text,
                CommandText = strBuilderSQL.ToString()
            };

            conexaoMySQL.Open();
            cmd.ExecuteNonQuery();
        }
        catch (MySqlException ex)
        {
            throw new Exception("Servidor MySQL Erro: " + ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            conexaoMySQL.Close();
        }
    }

    private static void ExcluirMongoDB(string Chave)
    {
        try
        {
            ClsConectandoMongoDB conexaoMongoDB = new();

            FilterDefinitionBuilder<ClsFuncionarioModel> construtor = Builders<ClsFuncionarioModel>.Filter;
            FilterDefinition<ClsFuncionarioModel> condicao = construtor.Eq(x => x.CPF, Chave);

            conexaoMongoDB.Funcionarios.DeleteOne(condicao);
        }
        catch (MongoException ex)
        {
            throw new Exception("Servidor MongoDB Erro: " + ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {

        }
    }

    public string Inserir(ClsFuncionarioModel entidade, char BD)
    {
        switch (BD)
        {
            case 'm':
                //return InserirMSSQL(entidade);

            case 'y':
                //return InserirMySQL(entidade);

            case 'o':
                //return InserirMongoDB(entidade);

            default:
                break;
        }

        return "";
    }

    public ClsFuncionarioModel SelecionarPorChave(string chave, char BD)
    {
        return BD switch
        {
            'm' => SelecionarPorChaveMSSQL(chave),
            'y' => SelecionarPorChaveMySQL(chave),
            'o' => SelecionarPorChaveMongoDB(chave),
            _ => new ClsFuncionarioModel(),
        };
    }

    private ClsFuncionarioModel SelecionarPorChaveMSSQL(string chave)
    {
        SqlDataAdapter da = new();
        DataTable dt = new();
        ClsFuncionarioModel? clsFuncModel = new();
        List<ClsDependenteModel>? clsDepModelList = new();

        try
        {
            SqlCommand? cmd = conexaoMSSQL.CreateCommand();

            cmd.Connection = conexaoMSSQL;
            cmd.CommandType = CommandType.Text;

            //SQL
            sbSQL.Append("SELECT ");
            sbSQL.Append("JSON_VALUE(json, '$.CPF') AS CPF, ");
            sbSQL.Append("JSON_VALUE(json, '$.Nome') AS Nome, ");
            sbSQL.Append("JSON_VALUE(json, '$.Endereco') AS Endereco, ");
            sbSQL.Append("JSON_VALUE(json, '$.Id_Departamento') AS Id_Departamento, ");
            sbSQL.Append("JSON_VALUE(json, '$.Nome_Departamento') AS Nome_Departamento, ");
            sbSQL.Append("JSON_VALUE(json, '$.Nascimento') AS Nascimento, ");
            sbSQL.Append("JSON_VALUE(json, '$.Sexo') AS Sexo, ");
            sbSQL.Append("JSON_VALUE(json, '$.Salario') AS Salario, ");
            sbSQL.Append("JSON_VALUE(json, '$.Telefone') AS Telefone, ");
            sbSQL.Append("JSON_VALUE(json, '$.CPF_Supervisor') AS CPF_Supervisor, ");
            sbSQL.Append("dep.Nome, dep.Sexo, dep.Nascimento, dep.Parentesco ");
            sbSQL.Append("FROM tbfuncionario ");
            sbSQL.Append("CROSS JOIN ");
            sbSQL.Append("JSON_TABLE(JSON_VALUE(json, '$.Dependentes'), '$[*]' ");
            sbSQL.Append("COLUMNS (Nome VARCHAR(100) PATH '$.Nome', ");
            sbSQL.Append("Sexo VARCHAR(1) PATH '$.Sexo', ");
            sbSQL.Append("Nascimento DATETIME PATH '$.Nascimento', ");
            sbSQL.Append("Parentesco VARCHAR(30) PATH '$.Parentesco')) dep ");

            if (chave != "" && long.TryParse(chave, out _))
                sbSQL.Append("WHERE CPF like '%" + chave + "%';");
            else if (chave != "")
                sbSQL.Append("WHERE Nome like '%" + chave + "%';");

            //adapter
            da.SelectCommand = new SqlCommand
            {
                Connection = conexaoMSSQL,
                CommandType = CommandType.Text,
                CommandText = sbSQL.ToString()
            };

            cmd.CommandText = sbSQL.ToString();
            da.Fill(dt);

            foreach (DataRow pRow in dt.Rows)
            {
                //Preencher o model:
                clsFuncModel.CPF = pRow[0].ToString();
                clsFuncModel.Nome = pRow[1].ToString();
                clsFuncModel.Endereco = pRow[2].ToString();
                clsFuncModel.Id_Departamento = Convert.ToByte(pRow[3]);
                clsFuncModel.Nome_Departamento = pRow[4].ToString();
                clsFuncModel.Nascimento = Convert.ToDateTime(pRow[5]);
                clsFuncModel.Sexo = Convert.ToChar(pRow[6]);
                clsFuncModel.Salario = Convert.ToDouble(pRow[7]);
                clsFuncModel.Telefone = pRow[8].ToString();
                clsFuncModel.CPF_Supervisor = pRow[9].ToString();

                if (!string.IsNullOrEmpty(pRow[10].ToString()))
                {
                    clsDepModelList.Add(new ClsDependenteModel()
                    {
                        Nome = pRow[10].ToString(),
                        Sexo = Convert.ToChar(pRow[11]),
                        Nascimento = Convert.ToDateTime(pRow[12]),
                        Parentesco = pRow[13].ToString()
                    });

                    clsFuncModel.Dependentes = clsDepModelList;
                }
            }

            return clsFuncModel;
        }
        catch (MySqlException ex)
        {
            throw new Exception("Servidor SQL Erro: " + ex.Number);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {

        }
    }

    private ClsFuncionarioModel SelecionarPorChaveMySQL(string chave)
    {
        MySqlDataAdapter da = new();
        DataTable dt = new();
        ClsFuncionarioModel? clsFuncModel = new();
        List<ClsDependenteModel>? clsDepModelList = new();

        try
        {
            MySqlCommand? cmd = conexaoMySQL.CreateCommand();

            cmd.Connection = conexaoMySQL;
            cmd.CommandType = CommandType.Text;

            //SQL
            sbSQL.Append("SELECT ");
            sbSQL.Append("JSON_UNQUOTE(JSON_EXTRACT(`JSON`, '$.CPF')) AS CPF, ");
            sbSQL.Append("JSON_UNQUOTE(JSON_EXTRACT(`JSON`, '$.Nome')) AS Nome, ");
            sbSQL.Append("JSON_UNQUOTE(JSON_EXTRACT(`JSON`, '$.Endereco')) AS Endereco, ");
            sbSQL.Append("JSON_UNQUOTE(JSON_EXTRACT(`JSON`, '$.Id_Departamento')) AS Id_Departamento, ");
            sbSQL.Append("JSON_UNQUOTE(JSON_EXTRACT(`JSON`, '$.Nome_Departamento')) AS Nome_Departamento, ");
            sbSQL.Append("JSON_UNQUOTE(JSON_EXTRACT(`JSON`, '$.Nascimento')) AS Nascimento, ");
            sbSQL.Append("JSON_UNQUOTE(JSON_EXTRACT(`JSON`, '$.Sexo')) AS Sexo, ");
            sbSQL.Append("JSON_UNQUOTE(JSON_EXTRACT(`JSON`, '$.Salario')) AS Salario, ");
            sbSQL.Append("JSON_UNQUOTE(JSON_EXTRACT(`JSON`, '$.Telefone')) AS Telefone, ");
            sbSQL.Append("JSON_UNQUOTE(JSON_EXTRACT(`JSON`, '$.CPF_Supervisor')) AS CPF_Supervisor, ");
            sbSQL.Append("dep.Nome, dep.Sexo, dep.Nascimento, dep.Parentesco ");
            sbSQL.Append("FROM tbfuncionario ");
            sbSQL.Append("CROSS JOIN ");
            sbSQL.Append("JSON_TABLE(JSON_EXTRACT(JSON, '$.Dependentes'), '$[*]' ");
            sbSQL.Append("COLUMNS (Nome VARCHAR(100) PATH '$.Nome', ");
            sbSQL.Append("Sexo VARCHAR(1) PATH '$.Sexo', ");
            sbSQL.Append("Nascimento DATETIME PATH '$.Nascimento', ");
            sbSQL.Append("Parentesco VARCHAR(30) PATH '$.Parentesco')) dep ");

            if (chave != "" && long.TryParse(chave, out _))
                sbSQL.Append("WHERE CPF like '%" + chave + "%';");
            else if (chave != "")
                sbSQL.Append("WHERE Nome like '%" + chave + "%';");

            //adapter
            da.SelectCommand = new MySqlCommand
            {
                Connection = conexaoMySQL,
                CommandType = CommandType.Text,
                CommandText = sbSQL.ToString()
            };

            cmd.CommandText = sbSQL.ToString();
            da.Fill(dt);

            foreach (DataRow pRow in dt.Rows)
            {
                //Preencher o model:
                clsFuncModel.CPF = pRow[0].ToString();
                clsFuncModel.Nome = pRow[1].ToString();
                clsFuncModel.Endereco = pRow[2].ToString();
                clsFuncModel.Id_Departamento = Convert.ToByte(pRow[3]);
                clsFuncModel.Nome_Departamento = pRow[4].ToString();
                clsFuncModel.Nascimento = Convert.ToDateTime(pRow[5]);
                clsFuncModel.Sexo = Convert.ToChar(pRow[6]);
                clsFuncModel.Salario = Convert.ToDouble(pRow[7]);
                clsFuncModel.Telefone = pRow[8].ToString();
                clsFuncModel.CPF_Supervisor = pRow[9].ToString();

                if (!string.IsNullOrEmpty(pRow[10].ToString()))
                {
                    clsDepModelList.Add(new ClsDependenteModel()
                    {
                        Nome = pRow[10].ToString(),
                        Sexo = Convert.ToChar(pRow[11]),
                        Nascimento = Convert.ToDateTime(pRow[12]),
                        Parentesco = pRow[13].ToString()
                    });

                    clsFuncModel.Dependentes = clsDepModelList;
                }
            }

            return clsFuncModel;
        }
        catch (MySqlException ex)
        {
            throw new Exception("Servidor SQL Erro: " + ex.Number);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {

        }
    }

    private static ClsFuncionarioModel SelecionarPorChaveMongoDB(string chave)
    {
        ClsFuncionarioModel clsFuncModel = new();

        try
        {
            // Conexão ao Banco de Dados MongoDB
            ClsConectandoMongoDB conexaoMongoDB = new();

            // Construtor de Filtro
            FilterDefinitionBuilder<ClsFuncionarioModel> construtor = Builders<ClsFuncionarioModel>.Filter;

            // Condição de pesquisa 
            FilterDefinition<ClsFuncionarioModel> condicao = construtor.Eq(x => x.CPF, chave);

            // Retorna somente um documento
            clsFuncModel = conexaoMongoDB.Funcionarios.Find(condicao).SingleOrDefault(); 
        }
        catch (MongoException ex)
        {
            throw new Exception("Servidor MongoDB Erro: " + ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {

        }

        return clsFuncModel;
    }

    public List<ClsFuncionarioModel> SelecionarPorParametro(ClsFuncionarioModel entidade, char BD)
    {
        throw new NotImplementedException();
    }

    public List<ClsFuncionarioModel> SelecionarTodos(char BD)
    {
        throw new NotImplementedException();
    }

    public DataTable Listagem(string chave, char BD)
    {
        switch (BD)
        {
            case 'm':
                return ListagemMSSQL(chave);
            case 'y':
                return ListagemMySQL(chave);
            case 'o':
                return ListagemMongoDB(chave);
            default:
                break;
        }

        return new DataTable();
    }

    private DataTable ListagemMSSQL(string chave)
    {
        MySqlDataAdapter da = new();
        DataTable dt = new();

        try
        {
            MySqlCommand? cmd = conexaoMySQL.CreateCommand();

            cmd.Connection = conexaoMySQL;
            cmd.CommandType = CommandType.Text;

            //SQL
            sbSQL.Append("SELECT * FROM tbfuncionario ");

            if (chave != "") sbSQL.Append("WHERE CPF = '" + chave + "'");

            ////adapter
            da.SelectCommand = new MySqlCommand
            {
                Connection = conexaoMySQL,
                CommandType = CommandType.Text,
                CommandText = sbSQL.ToString()
            };

            cmd.CommandText = sbSQL.ToString();
            da.Fill(dt);

            return dt;
        }
        catch (MySqlException ex)
        {
            throw new Exception("Servidor SQL Erro: " + ex.Number);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {

        }
    }

    private DataTable ListagemMySQL(string chave)
    {
        MySqlDataAdapter da = new();
        DataTable dt = new();

        try
        {
            MySqlCommand? cmd = conexaoMySQL.CreateCommand();

            cmd.Connection = conexaoMySQL;
            cmd.CommandType = CommandType.Text;

            //SQL
            sbSQL.Append("SELECT * FROM tbfuncionario ");

            if (chave != "") sbSQL.Append("WHERE CPF = '" + chave + "'");

            ////adapter
            da.SelectCommand = new MySqlCommand
            {
                Connection = conexaoMySQL,
                CommandType = CommandType.Text,
                CommandText = sbSQL.ToString()
            };

            cmd.CommandText = sbSQL.ToString();
            da.Fill(dt);

            return dt;
        }
        catch (MySqlException ex)
        {
            throw new Exception("Servidor SQL Erro: " + ex.Number);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {

        }
    }

    private DataTable ListagemMongoDB(string chave)
    {
        DataTable dt = new();
        DataRow dr;

        dt.Columns.Add("CPF", typeof(string));
        dt.Columns.Add("JSON", typeof(string));

        try
        {
            ClsConectandoMongoDB conexaoMongoDB = new();
            List<ClsFuncionarioModel> listaFuncionarios = new();

            listaFuncionarios = conexaoMongoDB.Funcionarios.Find(new BsonDocument()).ToList();

            if (!string.IsNullOrEmpty(chave)) listaFuncionarios = (List<ClsFuncionarioModel>)listaFuncionarios.Where(x => x.CPF == chave);
            
            for (int i = 0; i < listaFuncionarios.Count; i++)
            {
                dr = dt.NewRow();
                dr[0] = listaFuncionarios[i].CPF;
                dr[1] = JsonSerializer.Serialize(listaFuncionarios[i], options);

                dt.Rows.Add(dr);
            }

            return dt;
        }
        catch (MongoException ex)
        {
            throw new Exception("Servidor SQL Erro: " + ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {

        }
    }

    public bool VerificarSeChaveExiste(string chave, char BD)
    {
        switch (BD)
        {
            case 'm':
                return VerificarSeChaveExisteMSSQL(chave);
            case 'y':
                return VerificarSeChaveExisteMySQL(chave);
            case 'o':
                return VerificarSeChaveExisteMongoDB(chave);

            default:
                break;
        }

        return false;
    }

    private bool VerificarSeChaveExisteMSSQL(string chave)
    {
        StringBuilder strBuilderSQL = new("SELECT COUNT(1) FROM tbfuncionario WHERE CPF = '");

        try
        {
            //command
            SqlCommand cmd = new()
            {
                //conexao
                Connection = conexaoMSSQL,
                CommandType = CommandType.Text
            };

            //parâmetros da Tabela "tbfuncionario"
            // CPF  - varchar(11) - PK
            // JSON - NVARCHAR

            strBuilderSQL.Append(chave);
            strBuilderSQL.Append("';");

            cmd.CommandText = strBuilderSQL.ToString();

            conexaoMSSQL.Open();
            long result = (long)cmd.ExecuteScalar();
            conexaoMSSQL.Close();

            if ((long)result > 0) return true;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {

        }

        return false;
    }

    private bool VerificarSeChaveExisteMySQL(string chave)
    {
        StringBuilder strBuilderSQL = new("SELECT COUNT(1) FROM tbfuncionario WHERE CPF = '");

        try
        {
            //command
            MySqlCommand cmd = new()
            {
                //conexao
                Connection = conexaoMySQL,
                CommandType = CommandType.Text
            };

            //parâmetros da Tabela "tbfuncionario"
            // CPF  - varchar(11) - PK
            // JSON - json (JavaScript Object Notation)

            strBuilderSQL.Append(chave);
            strBuilderSQL.Append("';");

            cmd.CommandText = strBuilderSQL.ToString();

            conexaoMySQL.Open();
            long result = (long)cmd.ExecuteScalar();
            conexaoMySQL.Close();

            if ((long)result > 0) return true;


        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {

        }

        return false;
    }

    private static bool VerificarSeChaveExisteMongoDB(string chave)
    {
        try
        {
            ClsConectandoMongoDB conexaoMongoDB = new();

            BsonDocument filtro = new()
            {
                { "CPF", chave }
            };

            List<ClsFuncionarioModel> listaFuncionarios = conexaoMongoDB.Funcionarios.Find(filtro).ToList();

            if (listaFuncionarios.Count > 0) return true;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {

        }

        return false;
    }
}

