-- 1 - CRIAR O BANCO
CREATE DATABASE programacao_do_zero;

USE programacao_do_zero;

-- 2 - CRIAR A TABELA USUÁRIO
CREATE TABLE usuario (
    id INT NOT NULL AUTO_INCREMENT,
    nome VARCHAR(50) NOT NULL,
    sobrenome VARCHAR(150) NOT NULL,
    email VARCHAR(50) NOT NULL,
    telefone VARCHAR(14) NOT NULL,
    genero VARCHAR(20) NULL,
    senha VARCHAR(30) NOT NULL,
    usuarioGuid VARCHAR(36) NOT NULL,
    PRIMARY KEY (id)
);

-- 3 - CRIAR A TABELA ENDEREÇO
CREATE TABLE endereco (
    id INT NOT NULL AUTO_INCREMENT,
    rua VARCHAR(200) NOT NULL,
    numero VARCHAR(20) NOT NULL,
    bairro VARCHAR(200) NOT NULL,
    complemento VARCHAR(200) NULL,
    cidade VARCHAR(200) NOT NULL,
    estado VARCHAR(2) NULL,
    cep VARCHAR(9) NOT NULL,
    PRIMARY KEY (id)
);

-- 4 - RELACIONAR AS TABELAS USUÁRIO E ENDEREÇO

ALTER TABLE endereco ADD usuario_id INT NOT NULL;

ALTER TABLE endereco ADD CONSTRAINT FK_usuario FOREIGN KEY (usuario_id) REFERENCES usuario(id);

-- 5 - INSERIR USUÁRIOS

INSERT INTO usuario (nome, sobrenome, email, telefone, genero, senha, usuarioGuid) VALUES ('Renato', 'Gava', 'renatogava2@live.com', '11 99534-2343', 'Masculino', 'teste123', UUID());
INSERT INTO usuario (nome, sobrenome, email, telefone, genero, senha, usuarioGuid) VALUES ('Gustavo', 'Agusto', 'gaugusto2@live.com', '11 92531-2343', 'Masculino', 'teste342', UUID());

-- 6 - SELECIONAR USUÁRIOS

SELECT * FROM usuario;

SELECT * FROM usuario WHERE id = 1;

-- 7 - ALTERAR USUÁRIOS

UPDATE usuario SET telefone = '11 99432-3433' WHERE id = 1;

-- 8 - EXCLUIR USUÁRIO

DELETE FROM usuario WHERE id = 2;

-- ALTERAR CAMPO EXISTENTE

ALTER TABLE usuario MODIFY telefone VARCHAR(15) NOT NULL;

-- 9 - INSERIR ENDEREÇOS

INSERT INTO endereco (rua, numero, bairro, complemento, cidade, estado, cep, usuario_id) VALUES ('R. Visconde de Taunay', '382', 'Vila Arens', null,  'Jundiaí','SP', '13202-540', 1);
INSERT INTO endereco (rua, numero, bairro, complemento, cidade, estado, cep, usuario_id) VALUES ('R. das Cicas', '487', 'Corrupira', 'F37', 'Jundiaí', 'SP', '13202-540', 1);

-- 10 - SELECIONAR ENDEREÇOS DO USUÁRIO

SELECT 
    e.*
FROM
    usuario u INNER JOIN
    endereco e ON e.usuario_id = u.id
WHERE
    u.id = 1

-- 11 - ADICIONAR NOVA COLUNA
ALTER TABLE usuario ADD usuarioGuid VARCHAR(36) NOT NULL