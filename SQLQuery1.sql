create database PaginaWeb;
use PaginaWeb;

create table Libro(
Id int IDENTITY(1,1) primary key,
Isbn varchar(30) not null,
Titulo varchar(200) not null,
NoEdicion int not null,
YearPublicacion int not null,
Autores varchar(200) not null,
Pais varchar(50)not null,
Sinopsis text not null,
Carrera varchar(100)not null,
Materia varchar(100)not null
);

insert into Libro(ISBN,Titulo,Noedicion,Yearpublicacion,Autores,Pais,Sinopsis,Carrera,Materia) values
('9684972059','La inteligencia emocional',1,2011,'Daniel Goleman','México',
'La inteligencia emocional constituye un verdadero fenomeno editorial que no solamente revoluciono...','Gastronomia','Tutorias');

insert into Libro values
(@Id,@ISBN,@Titulo,@edicion,@Yearpublicacion,@Autor,@Pais,
@Sinopsis,@Carrera,@Materia);

select Titulo,Autores, Sinopsis, yearpublicacion,pais,carrera 
                            from Libro order by Titulo desc, autores;