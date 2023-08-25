/*
Dados JSON no SQL Server
Artigo - 02/04/2023
https://learn.microsoft.com/pt-br/sql/relational-databases/json/json-data-sql-server?view=sql-server-ver16#store-and-index-json-data-in-sql-server

Extrair um valor de texto JSON por meio da função JSON_VALUE
https://learn.microsoft.com/pt-br/sql/relational-databases/json/validate-query-and-change-json-data-with-built-in-functions-sql-server?view=sql-server-ver16#QUERY
*/

USE [SerializacaoMSSQL];

SELECT *
FROM tbfuncionario;

SELECT COUNT(1) 
FROM tbfuncionario 
WHERE CPF = '44222555587';

SELECT * 
FROM tbfuncionario 
WHERE CPF = '44222555587'
--FOR JSON AUTO;
FOR JSON PATH;

SELECT
	JSON_VALUE(json,'$.CPF') as CPF,
	JSON_VALUE(json,'$.Nome') as Nome,
	JSON_VALUE(json,'$.Endereco') as Endereco,
	JSON_VALUE(json,'$.Id_Departamento') as Id_Departamento,
	JSON_VALUE(json,'$.Nome_Departamento') as Nome_Departamento,
	JSON_VALUE(json,'$.Nascimento') as Nascimento,
	JSON_VALUE(json,'$.Sexo') as Sexo,
	JSON_VALUE(json,'$.Salario') as Salario,
	JSON_VALUE(json,'$.CPF_Supervisor') as CPF_Supervisor,
	JSON_VALUE(json,'$.Dependentes[0].Nome') as Nome0,
	JSON_VALUE(json,'$.Dependentes[0].Sexo') as Sexo0,
	JSON_VALUE(json,'$.Dependentes[0].Nascimento') as Nascimento0,
	JSON_VALUE(json,'$.Dependentes[0].Parentesco') as Parentesco0,
	JSON_VALUE(json,'$.Dependentes[1].Nome') as Nome1,
	JSON_VALUE(json,'$.Dependentes[1].Sexo') as Sexo1,
	JSON_VALUE(json,'$.Dependentes[1].Nascimento') as Nascimento1,
	JSON_VALUE(json,'$.Dependentes[1].Parentesco') as Parentesco1
from tbfuncionario;
--FOR JSON AUTO;

-- [{"CPF":"44222555587",
--"Nome":"Getúlio Vargas","Endereco":"Rua 9 de Julho, 1932 - São Paulo \/ SP","Id_Departamento":"1","Nome_Departamento":"Administrativo",
--"Nascimento":"1972-07-09T00:12:00","Sexo":"M","Salario":"5000.00","CPF_Supervisor":"73682332235"},
--{"CPF":"44222555588","Nome":"Teste teste","Endereco":"Rua Teste, 111","Id_Departamento":"1","Nome_Departamento":"Administrativo",
--"Nascimento":"1972-07-09T00:12:00","Sexo":"M","Salario":"5000","CPF_Supervisor":"111.111.111-11"},
--{"CPF":"44222555589","Nome":"Teste 89","Endereco":"Rua Teste, 189","Id_Departamento":"1","Nome_Departamento":"Administrativo",
--"Nascimento":"1971-01-01T00:00:00","Sexo":"F","Salario":"6000","CPF_Supervisor":"112.112.111-89"}]

SELECT
	JSON_VALUE(json, '$.CPF') AS CPF,
	JSON_VALUE(json, '$.Dependentes.Nome') AS 'Nome',
	JSON_VALUE(json, '$.Dependentes.Sexo') AS 'Sexo Dependentes',
	JSON_VALUE(json, '$.Dependentes.Nascimento') AS 'Nascimento Dependentes',
	JSON_VALUE(json, '$.Dependentes.Parentesco') AS 'Parentesco Dependentes'
FROM tbfuncionario
FOR JSON PATH, ROOT('Dependentes');

----------------------------------------------------------
DECLARE @Dependentes NVARCHAR(MAX)

SET @Dependentes=N'{"Dependentes":[
								 {"Nome":"Rodrigo de Souza Coutinho", "Sexo":"M", "Nascimento":"1997-11-15T00:12:00", "Parentesco":"Filho"}, 
								 {"Nome":"Marcia Aparecida de Souza", "Sexo":"F", "Nascimento":"1970-07-16T00:12:00", "Parentesco":"Esposa"}
								 ]}';

SELECT JSON_PATH_EXISTS(@Dependentes,'$.Dependentes'); 

----------------------------------------------------------

DECLARE @Regitro NVARCHAR(MAX)

Set @Regitro = N'{"CPF":"44222555587",
  "Nome":"Getúlio Vargas", 
  "Endereco":"Rua 9 de Julho, 1932 - São Paulo / SP", 
  "Id_Departamento":1,
  "Nome_Departamento":"Administrativo", 
  "Nascimento":"1972-07-09T00:12:00", 
  "Sexo":"M", 
  "Salario": 5000.00, 
  "Telefone":"(11) 9999-9999",
  "CPF_Supervisor":"73682332235",  
  "Dependentes":[{"Nome":"Rodrigo de Souza Coutinho", "Sexo":"M", "Nascimento":"1997-11-15T00:12:00", "Parentesco":"Filho"}, 
				 {"Nome":"Marcia Aparecida de Souza", "Sexo":"F", "Nascimento":"1970-07-16T00:12:00", "Parentesco":"Esposa"}]}';

SELECT JSON_PATH_EXISTS(@Regitro,'$.Dependentes'); 

----------------------------------------------------------

SELECT 
    JSON_VALUE(json, '$.CPF') AS CPF,
    JSON_VALUE(json, '$.Nome') AS Nome,
    JSON_VALUE(json, '$.Endereco') AS Endereço,
    JSON_VALUE(json, '$.Id_Departamento') as "ID departamento",
    JSON_VALUE(json, '$.Nome_Departamento') as "Nome Departamento",
    JSON_VALUE(json, '$.Nascimento') as "Nascimento",
    JSON_VALUE(json, '$.Sexo') as Sexo,
    JSON_VALUE(json, '$.Salario') as Salário,
    JSON_VALUE(json, '$.CPF_Supervisor') as "CPF Supervisor",
    dep.Nome, dep.Sexo, dep.Nascimento, dep.Parentesco
FROM tbfuncionario f 
	CROSS APPLY OPENJSON(f.json, '$.Dependentes')
		WITH(Nome nvarchar(MAX), Sexo char(1), Nascimento datetime, Parentesco nvarchar(100)) dep

-----------------------------------------------
