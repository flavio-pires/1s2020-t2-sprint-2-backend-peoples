--DEFINE QUAL BANCO DE DADOS SERÁ USADO
USE M_Peoples;
GO

--INSERIR DADOS NAS TABELAS
INSERT INTO Funcionarios (Nome, Sobrenome)
VALUES ('Catarina','Strada'),
	   ('Tadeu', 'Vitelli');
GO

-- Atualiza o valor da coluna DataNascimento
UPDATE Funcionarios SET DataNascimento = '1993-11-06'
WHERE IdFuncionario = 2;

-- INSERIR DADOS NA TABELA TIPOUSUARIO
INSERT INTO TipoUsuario (Titulo)
VALUES ('Administrador'),
	   ('Comum');
GO

-- INSERIR DADOS NA TABELA USUARIO
INSERT INTO Usuario (Email, Senha, IdTipoUsuario)
VALUES ('catarina@email.com', 123, 1),
	   ('tadeu@email.com', 123, 2);
GO

-- ATUALIZA O ID USUARIO DO FUNCIONARIO
UPDATE Funcionarios SET IdUsuario = 4
WHERE IdFuncionario = 2;



