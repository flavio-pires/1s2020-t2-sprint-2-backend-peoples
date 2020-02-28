--DEFINE QUAL BANCO DE DADOS SERÁ USADO
USE M_Peoples;
GO

--SELECIONA TODOS OS REGISTROS DA TABELA
SELECT * FROM Funcionarios INNER JOIN Usuario ON Funcionarios.IdUsuario = Usuario.IdUsuario;

-- Exibe todos os funcionários
SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios;

-- Exibe o funcionário com ID = 1
SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios WHERE IdFuncionario = 1;

-- Exibe o funcionário que tenha o nome Catarina
SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios WHERE Nome = 'Catarina';

-- Exibe o nome completo dos funcionários
SELECT IdFuncionario, CONCAT (Nome,' ',Sobrenome) AS [Nome Completo], DataNascimento FROM Funcionarios;

-- Exibe todos os funcionários de forma ordenada
SELECT IdFuncionario, Nome, Sobrenome, DataNascimento FROM Funcionarios ORDER BY Nome DESC;

-- Exibe todos os tipos de usuario
SELECT * FROM TipoUsuario;

-- Exibe todos os usuarios
SELECT * FROM Usuario INNER JOIN Funcionarios ON Usuario.IdUsuario = Funcionarios.IdUsuario;

