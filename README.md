-----------------------
ATENÇÃO! NÃO esqueça!
-----------------------

Para funcionar, NÃO esqueça de configurar no código o SEU acesso ao Banco de Dados MySQL dentro do arquivo "App.config", caso você tenha usuário e senha, por exemplo. O Banco MongoDB está no caminho default.

Na pasta SQL tem arquivos de script para ajudar a montar a estrutura da tabela MySQL. Não se preocupe com o MongoDB, ele mesmo monta sua estrutura automaticamente parecido com o "Entity Framework".

-----------------------
Como funciona estes exemplo...
-----------------------

A ideia fazer um CRUD (Create, Read, Update and Delete) de uma "lista de contato do trabalho" (benchmark - referência) para gravar em formato "documento" usando dois bancos de dados: MySQL e MongoDB.

Montei algumas funções extras experimentais. Exemplos: IncluirMySQL1, IncluirMySQL2, IncluirMySQL3 -> são 3 formas diferentes de fazer uma inclusão na base de dados MySQL, mas fazem exatamente o mesmo serviço. São somente "variantes".

Eu usei um arquivo tipo interface chamado "ICrud.cs" para orientar o CRUD, você pode alterá-lo caso falte algou ou esteja com algo sobrando.

Coloquei tudo como "síncrono", mas você pode usar todos os métodos como "assíncrono" se quiser.

Montei mais dois botões experimentais:

- Serialização &JSON
Gera a serialização e joga na área de transferência (Ctrl+C), depois basta colar no site: https://jsoneditoronline.org/ para ver o resultado.

- Pesquisar QTD Dependentes no Banco de Dados (NÃO GRID)
Esse botão gera um busca DENTRO da base de dados escolhida através do que está no campo "txtPesquisar.Text".

-----------------------
O que será usado?
-----------------------

Vou gravar em dois Bancos de Dados a saber:
- MySQL   - RDBMS (Banco de Dados Relacional) - Porém será usado como se fosse um BD de Documentos, pois vou usar o TIPO de campo "JSON".
- MongoDB - Banco de Dados de Documentos.

Também será usado:
- C# - Microsoft
- JSON - JavaScript Object Notation - Notação de Objeto JavaScript
- 3 Camadas:
  = UI - User Interface - Interface do usuário;
  = BLL - Business Logic Layer - Camada Lógica das Regras de Negócios;
  = DAL - Data Access Object - Objeto de Acesso aos Dados;
  = Model - Dada Base Model - Modelo do Banco de Dados;

-----------------------
Estrutura da tabela "tbfuncionario" - Parâmetros:
-----------------------

- CPF  - varchar(11) - PK
- JSON - json (JavaScript Object Notation)

-----------------------
Pastas
-----------------------

- SQL - Estão prontos os scripts SQL para montar os Banco de Dados e as Tabelas.
- ICONES - Alguns ícones para ilustrar o formulario.

-----------------------
NOSQL - Não apenas SQL - (Not Only SQL)
-----------------------

- Para sistemas que precisam ampliar as necessidades de gerenciamento de dados.

- São banco de dados DISTRIBUÍDOS;
- Foco no armazenamento de dados SEMI-ESTRUTURADOS;
- Alta disponibilidade;
- Replicação de dados;
- Escalabildiade;

Excelente para REDES SOCIAIS, MAPAS, POSTAGENS, etc.

-----------------------
SQL ou SEQUEL - Structured (ENGLISH) Query Language
-----------------------

- Ênfase na consistência de dados;
- Linguage de consultas poderosa;
- Armazenamento de dados estruturados;

https://pt.wikipedia.org/wiki/SQL

Excelente para SISTEMAS TRANSACIONAIS (Exemplos: Folhas de Pagamento, Contabilidade, Sistemas de RH, Logística, etc.).

Os bancos de dados SQL serão ainda utilizados por muito tempo porque, para controlar os processos estruturados das empresas, estes tipos de bancos (SQL) ainda são a melhor alternativa.

-----------------------
JSON - JavaScript Object Notation
-----------------------

Os caracteres estruturais são: o abre e fecha chaves, o abre e fecha colchetes, a vírgula e os dois pontos.

6 caracteres estruturais:
- { } - Abre e fecha chaves - limita o JSON;
- [ ] - Abre e fecha colchetes - limita o array;
- : - O dois pontos - separar o nome da propriedade e seu valor;
- , - A vírgula - separar o conjunto propriedade + valor;

Outros tipos de dados:

- Strings (TEXTO);
- Números - ponto como separador de decimal;
- 3 tipos literais: False, True e Null;

Propriedades e textos limitados por aspas simples ou aspas duplas.

PROPRIEDADE : VALOR

* PROPRIEDADE é um NOME único.
* VALOR: 
  - String, Número ou Valor Lógico;
  - Outro JSON;
  - Array;

-----------------------
*** Dicas de Links ***
-----------------------

O que é o MongoDB?

MongoDB é um banco de dados de documentos com a escalabilidade e flexibilidade que você deseja junto com a consulta e indexação que você precisa

https://www.mongodb.com/pt-br/what-is-mongodb

-----------------------

JSON Editor Online

https://jsoneditoronline.org/

-----------------------

Convert Json to C# Classes Online
Convert any JSON object to a C# class online. Check out the help panel below to view details on how to use this converter.

https://json2csharp.com/

-----------------------

Robo 3T is now Studio 3T Free

https://robomongo.org/

C:\Program Files\3T Software Labs\Studio 3T\

-----------------------

MongoDB C#/.NET Driver

https://www.mongodb.com/docs/drivers/csharp/

-----------------------

Connection String URI Format

https://www.mongodb.com/docs/manual/reference/connection-string/

-----------------------

The Connection Strings Reference
MySQL connection strings

https://www.connectionstrings.com/mysql/

-----------------------

How to serialize and deserialize (marshal and unmarshal) JSON in .NET
Article
09/23/2022
16 minutes to read

https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/how-to?pivots=dotnet-6-0

-----------------------
Resolve nullable warnings
Article
10/04/2022
13 minutes to read

https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/nullable-warnings?f1url=%3FappId%3Droslyn%26k%3Dk(CS8602)

-----------------------
Uso da classe StringBuilder no .NET

https://learn.microsoft.com/pt-br/dotnet/standard/base-types/stringbuilder

-----------------------
Classe de intervalos Unicode

public static System.Text.Unicode.UnicodeRange LatinExtendedA { get; }

https://learn.microsoft.com/en-us/dotnet/api/system.text.unicode.unicoderanges?view=net-6.0

-----------------------
Encontrando documentos no MongoDB usando C#
2020, 28 DE FEVEREIRO    
KEVIN SMITH

https://kevsoft.net/2020/02/28/finding-documents-in-mongodb-using-csharp.html

-----------------------