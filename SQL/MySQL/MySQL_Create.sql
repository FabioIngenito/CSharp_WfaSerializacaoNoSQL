CREATE SCHEMA `serializacaonosql`;

USE serializacaonosql;

CREATE TABLE `tbFuncionario` (
  `CPF` varchar(11) NOT NULL,
  `JSON` json DEFAULT NULL,
  PRIMARY KEY (`CPF`)
);
