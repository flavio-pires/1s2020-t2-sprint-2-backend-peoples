--CRIA O BANCO DE DADOS
CREATE DATABASE M_Peoples;
GO

--DEFINE QUAL BANCO DE DADOS SER� USADO
USE M_Peoples;
GO

--CRIA AS TABELAS DO BANCO DE DADOS
CREATE TABLE Funcionarios (
	IdFuncionario  INT PRIMARY KEY IDENTITY,
	Nome		   VARCHAR (255) NOT NULL,
	Sobrenome	   VARCHAR (255) NOT NULL,
	DataNascimento DATE
);
GO
