USE serializacaonosql;

SELECT *
FROM tbfuncionario;

SELECT COUNT(1) 
FROM tbfuncionario 
WHERE CPF = '44222555588';

SELECT * 
FROM tbfuncionario 
WHERE CPF = '44222555588';

SELECT
	JSON_UNQUOTE(JSON_EXTRACT(`JSON`,"$.CPF")) as CPF,
	JSON_UNQUOTE(JSON_EXTRACT(`JSON`,"$.Nome")) as Nome,
	JSON_UNQUOTE(JSON_EXTRACT(`JSON`,"$.Endereco")) as Endereco,
	JSON_UNQUOTE(JSON_EXTRACT(`JSON`,"$.Id_Departamento")) as Id_Departamento,
	JSON_UNQUOTE(JSON_EXTRACT(`JSON`,"$.Nome_Departamento")) as Nome_Departamento,
	JSON_UNQUOTE(JSON_EXTRACT(`JSON`,"$.Nascimento")) as Nascimento,
	JSON_UNQUOTE(JSON_EXTRACT(`JSON`,"$.Sexo")) as Sexo,
	JSON_UNQUOTE(JSON_EXTRACT(`JSON`,"$.Salario")) as Salario,
	JSON_UNQUOTE(JSON_EXTRACT(`JSON`,"$.CPF_Supervisor")) as CPF_Supervisor,
	JSON_UNQUOTE(JSON_EXTRACT(`JSON`,"$.Dependentes")) as Dependentes
from tbfuncionario;

SELECT
	JSON_UNQUOTE(JSON_EXTRACT(`JSON`, "$.CPF")) AS CPF,
	JSON_UNQUOTE(JSON_EXTRACT(`JSON`, "$.Dependentes[*].Nome")) AS `Nome Dependentes`,
	JSON_UNQUOTE(JSON_EXTRACT(`JSON`, "$.Dependentes[*].Sexo")) AS `Sexo Dependentes`,
	JSON_UNQUOTE(JSON_EXTRACT(`JSON`, "$.Dependentes[*].Nascimento")) AS `Nascimento Dependentes`,
	JSON_UNQUOTE(JSON_EXTRACT(`JSON`, "$.Dependentes[*].Parentesco")) AS `Parentesco Dependentes`
FROM tbfuncionario;

SELECT 
JSON_UNQUOTE(JSON_EXTRACT('{"CPF":"44222555587",
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
				 {"Nome":"Marcia Aparecida de Souza", "Sexo":"F", "Nascimento":"1970-07-16T00:12:00", "Parentesco":"Esposa"}]}',"$.Nome[0]")) as Nome;
         
         
SELECT 
    JSON_UNQUOTE(JSON_EXTRACT(`JSON`, '$.CPF')) AS CPF,
    JSON_UNQUOTE(JSON_EXTRACT(`JSON`, '$.Nome')) AS Nome,
    JSON_UNQUOTE(JSON_EXTRACT(`JSON`, '$.Endereco')) AS Endereço,
    JSON_UNQUOTE(JSON_EXTRACT(`JSON`, '$.Id_Departamento')) as "ID departamento",
    JSON_UNQUOTE(JSON_EXTRACT(`JSON`, '$.Nome_Departamento')) as "Nome Departamento",
    JSON_UNQUOTE(JSON_EXTRACT(`JSON`, '$.Nascimento')) as "Nascimento",
    JSON_UNQUOTE(JSON_EXTRACT(`JSON`, '$.Sexo')) as Sexo,
    JSON_UNQUOTE(JSON_EXTRACT(`JSON`, '$.Salario')) as Salário,
    JSON_UNQUOTE(JSON_EXTRACT(`JSON`, '$.CPF_Supervisor')) as "CPF Supervisor",
    dep.Nome, dep.Sexo, dep.Nascimento, dep.Parentesco
FROM tbfuncionario
CROSS JOIN
JSON_TABLE (JSON_EXTRACT (JSON, "$.Dependentes"), "$[*]"
COLUMNS (Nome VARCHAR(100) PATH "$.Nome",
Sexo CHAR(1) PATH "$.Sexo",
Nascimento DATETIME PATH "$.Nascimento",
Parentesco VARCHAR(19) PATH "$.Parentesco")) dep;


SELECT 
JSON_UNQUOTE(JSON_EXTRACT(`JSON`, '$.CPF')) AS CPF, 
JSON_UNQUOTE(JSON_EXTRACT(`JSON`, '$.Nome')) AS Nome, 
JSON_UNQUOTE(JSON_EXTRACT(`JSON`, '$.Endereco')) AS Endereco, 
JSON_UNQUOTE(JSON_EXTRACT(`JSON`, '$.Id_Departamento')) AS Id_Departamento, 
JSON_UNQUOTE(JSON_EXTRACT(`JSON`, '$.Nome_Departamento')) AS Nome_Departamento, 
JSON_UNQUOTE(JSON_EXTRACT(`JSON`, '$.Nascimento')) AS Nascimento, 
JSON_UNQUOTE(JSON_EXTRACT(`JSON`, '$.Sexo')) AS Sexo, 
JSON_UNQUOTE(JSON_EXTRACT(`JSON`, '$.Salario')) AS Salario, 
JSON_UNQUOTE(JSON_EXTRACT(`JSON`, '$.Telefone')) AS Telefeone, 
JSON_UNQUOTE(JSON_EXTRACT(`JSON`, '$.CPF_Supervisor')) AS CPF_Supervisor, 
dep.Nome, dep.Sexo, dep.Nascimento, dep.Parentesco 
FROM tbfuncionario 
CROSS JOIN 
JSON_TABLE(JSON_EXTRACT(JSON, '$.Dependentes'), '$[*]' 
COLUMNS (Nome VARCHAR(100) PATH '$.Nome', 
Sexo VARCHAR(1) PATH '$.Sexo', 
Nascimento DATETIME PATH '$.Nascimento', 
Parentesco VARCHAR(30) PATH '$.Parentesco')
) dep 
WHERE CPF like '%22222222223%';