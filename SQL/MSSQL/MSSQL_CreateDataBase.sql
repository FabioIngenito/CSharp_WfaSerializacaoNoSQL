USE master;
GO

CREATE DATABASE SerializacaoMSSQL ON
(NAME = SerializacaoMSSQL,
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SerializacaoMSSQL.mdf',
    SIZE = 8 MB,
    MAXSIZE = UNLIMITED,
    FILEGROWTH = 64 MB)
LOG ON
(NAME = SerializacaoMSSQL_log,
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SerializacaoMSSQL.ldf',
    SIZE = 8 MB,
    MAXSIZE = UNLIMITED,
    FILEGROWTH = 64 MB);
GO
