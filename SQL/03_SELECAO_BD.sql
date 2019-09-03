use T_InLock

select * from Usuarios 
select * from Estudios
select * from Jogos
select * from UsuarioEstudio

Select Jogos.NomeJogo , Estudios.NomeEstudio
from Jogos
inner join Estudios
on Jogos.EstudioId = Estudios.EstudioId

Select Estudios.NomeEstudio ,Jogos.NomeJogo 
from Estudios
left join Jogos
on Jogos.EstudioId = Estudios.EstudioId

--GO
--CREATE PROCEDURE BuscarPorEmailESenha @Email Varchar(255) , @Senha Varchar(255)
--AS BEGIN
--SELECT @Email = Email , @Senha =Senha  FROM Usuarios WHERE Usuarios.Email = @Email and Usuarios.Senha = @Senha;
--End


--Buscar um usuário por email e senha
go 
create procedure BuscarUsuario @Email VARCHAR(255), @Senha VARCHAR(255)
as begin 
select UsuarioId, Email, Senha
from Usuarios WHERE Email = @Email and Senha = @Senha
end

Exec BuscarUsuario'admin@admin.com','admin'


--Buscar um jogo por JogoId;
go
create procedure BuscarJogoId @IdJogo int
as begin
Select JogoId , NomeJogo , Descricao, DataLancamento, Valor, Estudios.NomeEstudio
from Jogos join Estudios on Jogos.EstudioId = Estudios.EstudioId Where  JogoId = @IdJogo
end

exec BuscarJogoId  1

--	Buscar um estúdio por EstudioId
go
create procedure BuscarEstudioId @EstudioId int
as begin
Select EstudioId , NomeEstudio , PaisOrigem, DataCriacao
from Estudios Where  EstudioId = @EstudioId
end

exec BuscarEstudioId  1


go --Top(5) para inserir uma quantidade
create procedure JogosCaros
as begin
Select Top(5) * from Jogos order by Valor desc
end

drop procedure JogosCaros

exec JogosCaros

SELECT * from Estudios

select * from Estudios where PaisOrigem = @Nome
