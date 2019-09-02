Create database T_InLock

use T_InLock

create table Usuarios 
(
	UsuarioId		int primary key identity
	,Email			varchar(255) not null unique
	,Senha			varchar(255) not null 
	,Permissao		varchar(255) not null
)

create table Estudios
(
	EstudioId			int primary key identity
	,NomeEstudio		varchar(255) not null unique
	,PaisOrigem			varchar(255) not null
	,DataCriacao		Date not null
	,UsuarioId			int foreign key References Usuarios(UsuarioId)
)

create table Jogos 
(
	JogoId				int primary key identity
	,NomeJogo			varchar(255) not null 
	,Descricao			text not null
	,DataLancamento		Date not null
	,Valor				float not null
	,EstudioId			int foreign key References Estudios(EstudioId)
)