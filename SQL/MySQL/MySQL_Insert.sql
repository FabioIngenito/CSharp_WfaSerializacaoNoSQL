USE serializacaonosql;

-- INSERT DE UM REGISTRO
INSERT INTO tbfuncionario (CPF, `JSON`)
VALUES 
("44222555587", '{"CPF":"44222555587",
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
								 {"Nome":"Marcia Aparecida de Souza", "Sexo":"F", "Nascimento":"1970-07-16T00:12:00", "Parentesco":"Esposa"}]}');

-- delete from tbfuncionario;

-- INSERT DE VÁRIOS REGISTROS
INSERT INTO tbfuncionario (CPF, `JSON`)
VALUES 
("44222555588", '{
				  "CPF": "44222555588",
				  "Nome": "Teste teste",
				  "Endereco": "Rua Teste, 111",
				  "Id_Departamento": 1,
				  "Nome_Departamento": "Administrativo",
				  "Nascimento": "1972-07-09T00:12:00",
				  "Sexo": "M",
				  "Salario": 5000,
				  "Telefone": "3333333333",
				  "CPF_Supervisor": "111.111.111-11",
				  "Dependentes": null
				}'
),
("44222555589", '{
				  "CPF": "44222555589",
				  "Nome": "Teste 89",
				  "Endereco": "Rua Teste, 189",
				  "Id_Departamento": 1,
				  "Nome_Departamento": "Administrativo",
				  "Nascimento": "1971-01-01T00:00:00",
				  "Sexo": "F",
				  "Salario": 6000,
				  "Telefone": "1234567890",
				  "CPF_Supervisor": "112.112.111-89",
				  "Dependentes": null
				}'
),
("44222555587", '{"CPF":"44222555587",
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
								 {"Nome":"Marcia Aparecida de Souza", "Sexo":"F", "Nascimento":"1970-07-16T00:12:00", "Parentesco":"Esposa"}]}');
                                 
         

