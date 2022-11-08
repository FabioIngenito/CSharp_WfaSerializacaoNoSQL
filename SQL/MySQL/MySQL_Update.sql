USE serializacaonosql;

-- UPDATE DE UM REGISTRO
UPDATE tbfuncionario SET CPF = '11111111111', `JSON` = 
'{"CPF":"11111111111",
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
				 {"Nome":"Marcia Aparecida de Souza", "Sexo":"F", "Nascimento":"1970-07-16T00:12:00", "Parentesco":"Esposa"}]}'
WHERE CPF = '22222222222';
