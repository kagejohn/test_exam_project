use [master];
drop database if exists LyngbyEveningSchool;
create database LyngbyEveningSchool;

GO

use LyngbyEveningSchool;

--drop table if exists Student;

create table Student (
Id int not null IDENTITY(1,1) primary key,
Name nvarchar(255) not null,
Age int not null
);

--drop table if exists Teacher;

create table Teacher (
Id int not null IDENTITY(1,1) primary key,
Name nvarchar(255) not null,
Education nvarchar(255) not null,
Teaching bit not null
);

go

create function checkIfTeachersHaveLessThan3Courses( @field int)
returns int
as
begin
	declare @returnvalue int;
	set @returnvalue = (select count(*) from Course where TeacherId = @field group by TeacherId)
	return @returnvalue
end

go

go

create function checkIfTeachersHaveEducation( @field int)
returns nvarchar(255)
as
begin
	declare @returnvalue nvarchar(255);
	set @returnvalue = (select Education from Teacher where Id = @field and Teaching = 1)
	return @returnvalue
end

go

--drop table if exists Course;

create table Course (
Id int not null IDENTITY(1,1) primary key,
Name nvarchar(255) not null,
Participants int null,
Duration int not null,
AddedDate date not null,
TeacherId int FOREIGN KEY REFERENCES Teacher(Id) not null,
constraint CHK_Teacher check (dbo.checkIfTeachersHaveLessThan3Courses(TeacherId)  <= 3 and dbo.checkIfTeachersHaveEducation(TeacherId) = 'True')
);

--drop table if exists CourseParticipation;

create table CourseParticipation (
Id int not null IDENTITY(1,1) primary key,
StudentID int FOREIGN KEY REFERENCES Student(Id),
CourseID int FOREIGN KEY REFERENCES Course(Id),
Paid bit not null
);

CREATE INDEX CourseParticipationCourseID ON CourseParticipation(CourseID);

go

CREATE TRIGGER TRG_InsertUpdateParticipantCount 
ON CourseParticipation
AFTER INSERT AS
BEGIN
	declare @CourseID int

	select @CourseID = inserted.CourseID from inserted

	update Course set Participants =
	(select count(*) from CourseParticipation where CourseParticipation.CourseID = @CourseID) 
	where Id = @CourseID
END

go

--drop table if exists Subject;

create table Subject (
Id int not null IDENTITY(1,1) primary key,
Name nvarchar(255) not null
);

--drop table if exists CourseSubjects;

create table CourseSubjects (
Id int not null IDENTITY(1,1) primary key,
SubjectID int FOREIGN KEY REFERENCES Subject(Id),
CourseID int FOREIGN KEY REFERENCES Course(Id)
);
