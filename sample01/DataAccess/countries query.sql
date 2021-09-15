create database world2021;
use world2021;

create table countries (
	id int primary key identity not null,
	id_country varchar(10) not null,
	name varchar(50) not null
);

create table states (
	id int primary key identity not null,
	id_state varchar(10) not null,
	name varchar(50) not null,
	fk_country int foreign key(fk_country) references countries(id) 
);

create table cities (
	id int primary key identity not null,
	id_city varchar(10) not null,
	name varchar(50) not null,
	fk_state int foreign key(fk_state) references states(id)
);

insert into countries (id_country, name) values 
('MX', 'Mexico'),
('US', 'United States'),
('CAN', 'Canada');

insert into states (id_state, name, fk_country) values 
('BC', 'Baja California', 1),
('JAL', 'Jalisco', 1),
('SIN', 'Sinaloa', 1),
('CA', 'California', 2),
('TX', 'Texas', 2),
('NV', 'Nevada', 2),
('ONT', 'Ontario', 3),
('NVT', 'Nunavut', 3),
('SIN', 'Quebec', 3);

insert into cities (id_city, name, fk_state) values 
('TJ', 'Tijuana', 1),
('ROS', 'Rosarito', 1),
('ENS', 'Ensenada', 1),
('GDL', 'Guadalajara', 2),
('VLL', 'Puerto Vallarta', 2),
('ZAP', 'Zapopan', 2),
('CLN', 'Culiacan', 3),
('MZ', 'Mazatlan', 3),
('LMM', 'Los Mochis', 3),
('LA', 'Los Angeles', 4),
('LB', 'Long Beach', 4),
('SA', 'Santa Ana', 4),
('HOU', 'Houston', 5),
('AU', 'Austin', 5),
('DL', 'Dallas', 5),
('LV', 'Las Vegas', 6),
('RE', 'Reno', 6),
('SP', 'Sparks', 6),
('ONT', 'Ontario', 7),
('OTW', 'Ottawa', 7),
('HAM', 'Hamilton', 7),
('CB', 'Cambridge Bay', 8),
('CD', 'Cape Dorset', 8),
('BL', 'Baker Lake', 8),
('FA', 'Faro', 9),
('WL', 'Watson Lake', 9),
('DAW', 'Dawon', 9);


--Get countries, states and cities
select c.id, c.id_country, c.name, s.id_state, s.name, ci.id_city, ci.name
from countries c 
inner join states s on c.id = s.fk_country
inner join cities ci on s.id = ci.fk_state;

select c.id, c.id_country, c.name, s.id_state, s.name, ci.id_city, ci.name
from countries c 
inner join states s on c.id = s.fk_country
inner join cities ci on s.id = ci.fk_state 
where c.id = 1;


-- Get cities and states
select s.id, s.id_state, s.name, ci.id_city, ci.name
from states s 
inner join cities ci on s.id = ci.fk_state;

select s.id, s.id_state, s.name, ci.id_city, ci.name
from states s 
inner join cities ci on s.id = ci.fk_state
where s.id = 1
