use T_InLock

insert into Usuarios values ('admin@admin.com','admin','ADMINISTRADOR')
insert into Usuarios values ('cliente@cliente.com','cliente','CLIENTE')

insert into Estudios values ('Blizzard','EUA','08/02/1991')
insert into Estudios values ('Rockstar Studios ','EUA','01/12/1998'),('Square Enix','Jap�o','01/04/2003')

delete  from Estudios where EstudioId = 3

Insert into Jogos Values ('Diablo 3','� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�.','15/05/2012', 99.00 , 1)
Insert into Jogos Values ('Red Dead Redemption II','jogo eletr�nico de a��o-aventura western','26/10/2018',120,2)

Insert into UsuarioEstudio values (1,1),(1,2),(1,4)


select * from Usuarios 
select * from Estudios
select * from Jogos
select * from UsuarioEstudio