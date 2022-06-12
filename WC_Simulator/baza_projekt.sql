create database wc_simulator;
-- drop database wc_simulator;

use wc_simulator;

create table user(
	id_user int unsigned auto_increment primary key,
    login varchar(25) unique not null,
    password binary(32) not null,
    creation_date date not null,
    last_log_date datetime not null,
    security_question varchar(25) not null,
    security_answer varchar(25) not null
);
desc user;

create table tournament(
	id_tournament int unsigned auto_increment primary key,
    id_user int unsigned  not null
);
desc tournament;

create table player(
	id_player int unsigned auto_increment primary key,
    id_team int unsigned not null,
    name varchar(50) not null,
    position enum("Bramkarz", "Obrońca", "Pomocnik", "Napastnik") not null
);
desc player;

create table single_group(
	id_group int unsigned auto_increment primary key,
    id_first_pl_team int unsigned,
    id_second_pl_team int unsigned,
    id_tournament int unsigned not null,
    letter enum("A", "B", "C", "D", "E", "F", "G", "H") not null
);
desc single_group;

create table team(
	id_team int unsigned auto_increment primary key,
    id_group int unsigned not null,
    name varchar(35) not null,
    short_name varchar(3) not null,
    coach varchar(30) not null,
    def_factor float not null,
    att_factor float not null
);
desc team;

create table single_match(
	id_match int unsigned auto_increment primary key,
    id_first_team int unsigned,
    id_second_team int unsigned,
    id_tournament int unsigned not null,
    match_code int unsigned not null,
    goals_first_team int,
    goals_second_team int
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

-- chyba do wywalenia
-- alter table single_match add
-- constraint fk_match_mcode foreign key(match_code) references schedule(match_code);

-- tournament fk
alter table tournament add
constraint fk_tournament_user foreign key(id_user) references user(id_user);



-- dodawanie rekordow do tabeli 'user'
insert into user (id_user, login, password, creation_date, last_log_date, security_question, security_answer) values
(1, "Qsalvic", 0101, now(), now(), "Co robisz?", "No to ciszej k");

-- dodawanie rekordow do tabeli 'tournament'
insert into tournament values
(1,1);

-- dodawanie rekordow do tabeli 'single_group'
insert into single_group (id_group, id_tournament, letter) values
(1, 1,"A"), (2, 1,"B"), (3, 1,"C"), (4, 1,"D"), (5, 1,"E"),
(6, 1,"F"), (7, 1,"G"), (8, 1,"H");

-- dodawanie rekordow do tabeli 'team'
insert into team (id_group, name, short_name, coach, def_factor, att_factor) values
(1, "Katar", "QAT", "Félix Sánchez Bas", 0.5, 0.5),
(1, "Ekwador", "ECU", "Gustavo Alfaro", 0.5, 0.5),
(1, "Senegal", "SEN", "Aliou Cissé", 0.5, 0.5),
(1, "Holandia", "NED", "Louis van Gaal", 0.5, 0.5),

(2, "Anglia", "ENG", "Gareth Southgate", 0.5, 0.5),
(2, "Iran", "IRN", "Dragan Skočić", 0.5, 0.5),
(2, "Stany Zjednoczone", "USA", "Gregg Berhalter", 0.5, 0.5),
(2, "Walia", "WAL", "Robert Page", 0.5, 0.5),

(3, "Argentyna", "ARG", "Lionel Scaloni", 0.5, 0.5),
(3, "Arabia Saudyjska", "KSA", "Hervé Renard", 0.5, 0.5),
(3, "Meksyk", "MEX", "Gerardo Martino", 0.5, 0.5),
(3, "Polska", "POL", "Czesław Michniewicz", 0.5, 0.5),

(4, "Francja", "FRA", "Didier Deschamps", 0.5, 0.5),
(4, "X", "xxx", "Félix", 0.5, 0.5),
(4, "Dania", "DEN", "Kasper Hjulmand", 0.5, 0.5),
(4, "Tunezja", "TUN", "Mondher Kebaier", 0.5, 0.5),

(5, "Hiszpania", "ESP", "Luis Enrique", 0.5, 0.5),
(5, "Y", "yyy", "Félix", 0.5, 0.5),
(5, "Niemcy", "GER", "Hans-Dieter Flick", 0.5, 0.5),
(5, "Japonia", "JPN", "Hajime Moriyasu", 0.5, 0.5),

(6, "Belgia", "BEL", "Roberto Martínez", 0.5, 0.5),
(6, "Kanada", "CAN", "John Herdman", 0.5, 0.5),
(6, "Maroko", "MAR", "Vahid Halilhodžić", 0.5, 0.5),
(6, "Chorwacja", "CRO", "Zlatko Dalić", 0.5, 0.5),

(7, "Brazylia", "BRA", "Tite", 0.5, 0.5),
(7, "Serbia", "SRB", "Dragan Stojković", 0.5, 0.5),
(7, "Szwajcaria", "SUI", "Murat Yakın", 0.5, 0.5),
(7, "Kamerun", "CMR", "Rigobert Song", 0.5, 0.5),

(8, "Portugalia", "POR", "Fernando Santos", 0.5, 0.5),
(8, "Ghana", "GHA", "Otto Addo", 0.5, 0.5),
(8, "Urugwaj", "URU", "Diego Alonso", 0.5, 0.5),
(8, "Korea Południowa", "KOR", "Paulo Bento", 0.5, 0.5);
select * from team;

