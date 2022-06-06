create database wc_simulator;

use wc_simulator;

create table user(
	id_user int unsigned auto_increment primary key,
    login varchar(25) unique not null,
    password varchar(32) not null,
    creation_date date not null,
    last_log_date datetime not null
);
desc user;

create table tournament(
	id_tournament int unsigned auto_increment primary key,
    id_user int unsigned
);
desc tournament;

create table player(
	id_player int unsigned auto_increment primary key,
    id_team int unsigned,
    name varchar(50) not null,
    position enum("Bramkarz", "Obrońca", "Pomocnik", "Napastnik") not null
);
desc player;

create table single_group(
	id_group int unsigned auto_increment primary key,
    id_first_pl_team int unsigned,
    id_second_pl_team int unsigned,
    id_tournament int unsigned,
    letter enum("A", "B", "C", "D", "E", "F", "G", "H") not null
);
desc single_group;

create table team(
	id_team int unsigned auto_increment primary key,
    id_group int unsigned,
    name varchar(35) not null,
    coach varchar(30) not null,
    def_factor float not null,
    att_factor float not null
);
desc team;

create table schedule(
	match_code int unsigned auto_increment primary key,
    stage enum("Faza grupowa", "1/8 finału", "Ćwierćfinały", "Półfinały", "Finał", "Mecz o 3. miejsce") not null,
    time time not null,
    location enum("Al Bayt Stadium, Al-Chaur", "Lusail Stadium, Lusajl", "Stadium 974, Doha", "Al Thumama Stadium, Doha",
				"Education City Stadium, Ar-Rajjan", "Ahmed bin Ali Stadium, Ar-Rajjan", 
                "Khalifa International Stadium, Ar-Rajjan", "Al Janoub Stadium, Al-Wakra") not null,
    date date not null
);
desc schedule;

create table single_match(
	id_match int unsigned auto_increment primary key,
    id_first_team int unsigned,
    id_second_team int unsigned,
    id_tournament int unsigned,
    match_code int unsigned,
    referee enum("Abdulrahman Al-Jassim", "Chris Beath", "Alireza Faghani", "Ma Ning",
				"Szymon Marciniak", "Mohammed Abdulla Hassan Mohamed") not null,
    goals_first_team int not null,
    goals_second_team int not null
);
desc single_match;


-- player fk
alter table player add
constraint fk_player_team foreign key(id_team) references team(id_team);

-- group fk
alter table single_group add
constraint fk_group_fteam foreign key(id_first_pl_team) references team(id_team);
alter table single_group add
constraint fk_group_steam foreign key(id_second_pl_team) references team(id_team);
-- group fk dodatkowe id_tournament
alter table single_group add
constraint fk_group_tournament foreign key(id_tournament) references tournament(id_tournament);


-- team fk
alter table team add
constraint fk_team_group foreign key(id_group) references single_group(id_group);

-- match fk
alter table single_match add
constraint fk_match_fteam foreign key(id_first_team) references team(id_team);

alter table single_match add
constraint fk_match_steam foreign key(id_second_team) references team(id_team);

alter table single_match add
constraint fk_match_tournament foreign key(id_tournament) references tournament(id_tournament);

alter table single_match add
constraint fk_match_mcode foreign key(match_code) references schedule(match_code);

-- tournament fk
alter table tournament add
constraint fk_tournament_user foreign key(id_user) references user(id_user);

