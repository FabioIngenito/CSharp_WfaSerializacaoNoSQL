USE [SerializacaoMSSQL];

CREATE TABLE tbFuncionario (
  CPF varchar(11) NOT NULL,
  JSON nvarchar(MAX) DEFAULT NULL,
  PRIMARY KEY (CPF)
);