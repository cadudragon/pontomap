﻿-- scripts banco

CREATE TABLE Empresa(
	IdEmpresa INT NOT NULL,
	DsCnpj VARCHAR(50) NOT NULL UNIQUE,
	DsRazaoSocial VARCHAR(50),
	NmFantasia VARCHAR(50)  NOT NULL,
	CdIsMaster BIT NOT NULL DEFAULT 0
)
go

CREATE TABLE TipoUsuario(
	IdTipoUsuario INT NOT NULL,
	DsTipoUsuario VARCHAR(30) NOT NULL
)go

CREATE TABLE Usuario(
	Idusuario INT NOT NULL,
	IdEmpresa INT NOT NULL,
	IdTipoUsuario INT NOT NULL,
	CdCpf VARCHAR(20) NOT NULL UNIQUE,
	DsEmail VARCHAR(50) NOT NULL UNIQUE,
	DsCelular VARCHAR(11) NOT NULL UNIQUE,
	CdPassword VARCHAR(11) NOT NULL,
	DtNascimento DATE NOT NULL,
	NmFuncionario VARCHAR(50),
	CdAtivo BIT NOT NULL DEFAULT 1
)go


CREATE TABLE Ponto(
	Idusuario INT NOT NULL,
	IdEmpresa INT NOT NULL,
	DtRegistro DATETIME NOT NULL,
	CdLat DECIMAL(10,6) NOT NULL,
	CdLng DECIMAL(10,6) NOT NULL,
)
go

CREATE TABLE Contato(
	IdContato INT NOT NULL,
	NmNome 	VARCHAR(50) NOT NULL,
	DsEmail VARCHAR(50) NOT NULL,
	DsAssunto VARCHAR(50) NOT NULL,
	DsMensagem VARCHAR(250) NOT NULL,
)
go

--CHAVES PRIMARIAS

ALTER TABLE Empresa
	ADD PRIMARY KEY(IdEmpresa)
go

ALTER TABLE TipoUsuario
	ADD PRIMARY KEY(IdTipoUsuario,DsTipoUsuario)
go

ALTER TABLE Usuario
	ADD PRIMARY KEY(Idusuario)
go

ALTER TABLE Ponto
	ADD PRIMARY KEY(IdFuncionario,IdEmpresa,DtRegistro)
go

ALTER TABLE Contato
	ADD PRIMARY KEY(IdContato)
go

--CHAVES ESTRANGEIRAS
ALTER TABLE Funcionario
	ADD FOREIGN KEY(IdEmpresa)
		REFERENCES Empresa
go

ALTER TABLE Ponto
	ADD FOREIGN KEY(IdFuncionario,IdEmpresa)
		REFERENCES Funcionario
go