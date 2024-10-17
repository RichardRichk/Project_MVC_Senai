create database dev_db
use dev_db

create table Professores(
ProfessorId int primary key identity,
Nome varchar (255),
Email varchar (255),
Senha varchar (255)
)

create table Turmas(
TurmaId int primary key identity,
Nome varchar (255),
ProfessorId int Foreign key(ProfessorId) references Professores(ProfessorId)
)

create table Atividades(
AtividadeId int primary key identity,
Descricao varchar (255),
TurmaId int Foreign key(TurmaId) references Turmas(TurmaId)
)

insert into Professores(Nome, Email, Senha) values 
('Richk', 'richk@gmail.com','admin1234'),
('Carlos', 'carlos@gmail.com','admin1234'),
('Luck', 'luck@gmail.com','admin1234')

insert into Turmas(Nome, ProfessorId) values
('Desenvolvimento',1),
('Multimidia',2),
('Cyber',3)

insert into Atividades(Descricao, TurmaId) values
('Simulado com MVC',1),
('Identidade Visual',2),
('CTF',3)

