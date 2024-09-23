create database project_management_application

create table Project(
 id int not null Primary Key,
 ProjectName  varchar(30) not null,
 Descriptions text, 
 Starting_date  date not null,
 Status_condition varchar(50) check(status_condition in('started','dev','build','test','deployed')) not null
);

create table Employee(
 id int not null primary key identity,
  Full_name varchar(30) not null,
  Designation varchar(30) not null,
  Gender varchar(10) not null,
  Salary decimal not null,
  project_id int not null , foreign key (project_id) references project(id)
);

create table task(
 task_id int not null Primary Key identity, 
 task_name varchar(30) not null,
 project_id int not null, foreign key (project_id) references project (id),
 employee_id int not null foreign key (employee_id) references employee(id),
 Status_condition varchar(50) check(status_condition in('Assigned', 'started', 'completed')) not null
)

