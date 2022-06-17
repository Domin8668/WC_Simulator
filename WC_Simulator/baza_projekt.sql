create database wc_simulator;
-- drop database wc_simulator;

use wc_simulator;

create table user(
	id_user int unsigned auto_increment primary key,
    login varchar(25) unique not null,
    password binary(32) not null,
    creation_date datetime not null,
    last_log_date datetime not null,
    security_question varchar(25) not null,
    security_answer binary(32) not null
);
desc user;

create table tournament(
	id_tournament int unsigned auto_increment primary key,
    id_user int unsigned not null,
    t_name varchar(30) default "tournament_1"
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
    id_first_pl_team int unsigned default 1,
    id_second_pl_team int unsigned default 2,
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


-- dodawanie rekordow do tabeli 'tournament'
insert into tournament (id_tournament, id_user) values
(1,1);

-- dodawanie rekordow do tabeli 'single_group'
insert into single_group (id_group, id_tournament, letter) values
(1, 1, "A"), (2, 1,"B"), (3, 1,"C"), (4, 1,"D"), (5, 1,"E"),
(6, 1,"F"), (7, 1,"G"), (8, 1,"H");

-- dodawanie rekordow do tabeli 'team'
insert into team (id_group, name, short_name, coach, def_factor, att_factor) values
new Team(1, "Katar", "QAT", "Félix Sánchez Bas", (float)0.5, (float)0.5),
new Team(1, "Ekwador", "ECU", "Gustavo Alfaro", (float)0.5, (float)0.5),
new Team(1, "Senegal", "SEN", "Aliou Cissé", (float)0.5, (float)0.5),
new Team(1, "Holandia", "NED", "Louis van Gaal", (float)0.5, (float)0.5),

new Team(2, "Anglia", "ENG", "Gareth Southgate", (float)0.5, (float)0.5),
new Team(2, "Iran", "IRN", "Dragan Skočić", (float)0.5, (float)0.5),
new Team(2, "Stany Zjednoczone", "USA", "Gregg Berhalter", (float)0.5, (float)0.5),
new Team(2, "Walia", "WAL", "Robert Page", (float)0.5, (float)0.5),

new Team(3, "Argentyna", "ARG", "Lionel Scaloni", (float)0.5, (float)0.5),
new Team(3, "Arabia Saudyjska", "KSA", "Hervé Renard", (float)0.5, (float)0.5),
new Team(3, "Meksyk", "MEX", "Gerardo Martino", (float)0.5, (float)0.5),
new Team(3, "Polska", "POL", "Czesław Michniewicz", (float)0.5, (float)0.5),

new Team(4, "Francja", "FRA", "Didier Deschamps", (float)0.5, (float)0.5),
new Team(4, "Australia", "AUS", "Graham Arnold", (float)0.5, (float)0.5),
new Team(4, "Dania", "DEN", "Kasper Hjulmand", (float)0.5, (float)0.5),
new Team(4, "Tunezja", "TUN", "Mondher Kebaier", (float)0.5, (float)0.5),

new Team(5, "Hiszpania", "ESP", "Luis Enrique", (float)0.5, (float)0.5),
new Team(5, "Kostaryka", "CRC", "Luis Fernando Suárez", (float)0.5, (float)0.5),
new Team(5, "Niemcy", "GER", "Hans-Dieter Flick", (float)0.5, (float)0.5),
new Team(5, "Japonia", "JPN", "Hajime Moriyasu", (float)0.5, (float)0.5),

new Team(6, "Belgia", "BEL", "Roberto Martínez", (float)0.5, (float)0.5),
new Team(6, "Kanada", "CAN", "John Herdman", (float)0.5, (float)0.5),
new Team(6, "Maroko", "MAR", "Vahid Halilhodžić", (float)0.5, (float)0.5),
new Team(6, "Chorwacja", "CRO", "Zlatko Dalić", (float)0.5, (float)0.5),

new Team(7, "Brazylia", "BRA", "Tite", (float)0.5, (float)0.5),
new Team(7, "Serbia", "SRB", "Dragan Stojković", (float)0.5, (float)0.5),
new Team(7, "Szwajcaria", "SUI", "Murat Yakın", (float)0.5, (float)0.5),
new Team(7, "Kamerun", "CMR", "Rigobert Song", (float)0.5, (float)0.5),

new Team(8, "Portugalia", "POR", "Fernando Santos", (float)0.5, (float)0.5),
new Team(8, "Ghana", "GHA", "Otto Addo", (float)0.5, (float)0.5),
new Team(8, "Urugwaj", "URU", "Diego Alonso", (float)0.5, (float)0.5),
new Team(8, "Korea Południowa", "KOR", "Paulo Bento", (float)0.5, (float)0.5),
select * from team;

-- group fk
alter table single_group add
constraint fk_group_fteam foreign key(id_first_pl_team) references team(id_team);
alter table single_group add
constraint fk_group_steam foreign key(id_second_pl_team) references team(id_team);
-- group fk dodatkowe id_tournament
alter table single_group add
constraint fk_group_tournament foreign key(id_tournament) references tournament(id_tournament);


select team.id_team, team.name, count(player.id_player) from team, player where team.id_team=player.id_team group by team.id_team;  
select * from player;
-- dodawanie pilkarzy do tabeli 'Player'
insert into player (id_team, name, position) values
(20, "Gonda Shuichi", "Bramkarz"),
(20, "Kawashima Eiji", "Bramkarz"),
(20, "Osako Keisuke", "Bramkarz"),
(20, "Endo Wataru", "Obrońca"),
(20, "Itakura Ko", "Obrońca"),
(20, "Nagatomo Yuto", "Obrońca"),
(20, "Nakatani Shinnosuke", "Obrońca"),
(20, "Nakayama Yuta", "Obrońca"),
(20, "Sakai Hiroki", "Obrońca"),
(20, "Sasaki Sho", "Obrońca"),
(20, "Tomiyasu Takehiro", "Obrońca"),
(20, "Doan Ritsu", "Pomocnik"),
(20, "Haraguchi Genki", "Pomocnik"),
(20, "Hatate Reo", "Pomocnik"),
(20, "Ito Hiroki", "Pomocnik"),
(20, "Kamada Daichi", "Pomocnik"),
(20, "Mitoma Kaoru", "Pomocnik"),
(20, "Morita Hidemasa", "Pomocnik"),
(20, "Shibasaki Gaku", "Pomocnik"),
(20, "Asano Takuma", "Napastnik"),
(20, "Furuhashi Kyogo", "Napastnik"),
(20, "Hayashi Daichi", "Napastnik"),
(20, "Ito Junya", "Napastnik"),
(20, "Kubo Takefusa", "Napastnik"),
(20, "Maeda Daizen", "Napastnik"),
(20, "Minamino Takumi", "Napastnik"),

(23, "Bono", "Bramkarz"),
(23, "Munir", "Bramkarz"),
(23, "Tagnaouti Ahmed Reda", "Bramkarz"),
(23, "Aguerd Nayef", "Obrońca"),
(23, "Alakouch Sofiane", "Obrońca"),
(23, "Attiat-Allal Yahya", "Obrońca"),
(23, "Chakla Soufiane", "Obrońca"),
(23, "Chibi Mohamed", "Obrońca"),
(23, "El Yamiq Jawad", "Obrońca"),
(23, "Hakimi Achraf", "Obrońca"),
(23, "Masina Adam", "Obrońca"),
(23, "Amallah Selim", "Pomocnik"),
(23, "Amrabat Sofyan", "Pomocnik"),
(23, "Barkok Aymen", "Pomocnik"),
(23, "Boufal Sofiane", "Pomocnik"),
(23, "Chair Ilias", "Pomocnik"),
(23, "El Karouani Souffian", "Pomocnik"),
(23, "Fajr Faycal", "Pomocnik"),
(23, "Harit Amine", "Pomocnik"),
(23, "Jabrane Yahya", "Pomocnik"),
(23, "Louza Imran", "Pomocnik"),
(23, "Aboukhlal Zakaria", "Napastnik"),
(23, "El Haddadi Munir", "Napastnik"),
(23, "El Kaabi Ayoub", "Napastnik"),
(23, "En Nesyri Youssef", "Napastnik"),
(23, "Mmaee Ryan", "Napastnik"),

(28, "Onana Andre", "Bramkarz"),
(28, "Epassy Devis", "Bramkarz"),
(28, "Omossola Simon Loti", "Bramkarz"),
(28, "Castelletto Jean-Charles", "Obrońca"),
(28, "Ebosse Enzo", "Obrońca"),
(28, "Fai Collins", "Obrońca"),
(28, "Mbaizo Olivier", "Obrońca"),
(28, "Moukoudi Harold", "Obrońca"),
(28, "Ngadeu Michael", "Obrońca"),
(28, "Onguene Jerome", "Obrońca"),
(28, "Oyongo Ambroise", "Obrońca"),
(28, "Anguissa Andre Zambo", "Pomocnik"),
(28, "Hongla Martin", "Pomocnik"),
(28, "Kunde Pierre", "Pomocnik"),
(28, "Lea Siliki James", "Pomocnik"),
(28, "Moumi Ngamaleu Nicolas", "Pomocnik"),
(28, "Neyou Yvan", "Pomocnik"),
(28, "Onana Jean", "Pomocnik"),
(28, "Ondoua Gael", "Pomocnik"),
(28, "Aboubakar Vincent", "Napastnik"),
(28, "Bahoken Stephane", "Napastnik"),
(28, "Bassogog Christian", "Napastnik"),
(28, "Choupo-Moting Eric Maxim", "Napastnik"),
(28, "Ganago Ignatius", "Napastnik"),
(28, "N'Jie Clinton", "Napastnik"),
(28, "Toko Ekambi Karl", "Napastnik"),

(22, "Borjan Milan", "Bramkarz"),
(22, "Crepeau Maxime", "Bramkarz"),
(22, "Dayne St. Clair", "Bramkarz"),
(22, "Adekugbe Sam", "Obrońca"),
(22, "Brault-Guillard Zachary", "Obrońca"),
(22, "Cornelius Derek", "Obrońca"),
(22, "Davies Alphonso", "Obrońca"),
(22, "Gutierrez Cristian", "Obrońca"),
(22, "Henry Doneil", "Obrońca"),
(22, "Kennedy Scott", "Obrońca"),
(22, "Laryea Richie", "Obrońca"),
(22, "Miller Kamal", "Obrońca"),
(22, "Antunes Eustaquio Stephen", "Pomocnik"),
(22, "Buchanan Tajon", "Pomocnik"),
(22, "Edwards Raheem", "Pomocnik"),
(22, "Fraser Liam", "Pomocnik"),
(22, "Hutchinson Atiba", "Pomocnik"),
(22, "Johnston Alistair", "Pomocnik"),
(22, "Kaye Mark", "Pomocnik"),
(22, "Kone Ismael", "Pomocnik"),
(22, "Millar Liam", "Pomocnik"),
(22, "Brym Charles-Andreas", "Napastnik"),
(22, "Cavallini Lucas", "Napastnik"),
(22, "David Jonathan", "Napastnik"),
(22, "Hoilett Junior", "Napastnik"),
(22, "Larin Cyle", "Napastnik"),

(11, "Acevedo Carlos", "Bramkarz"),
(11, "Cota Rodolfo", "Bramkarz"),
(11, "Ochoa David", "Bramkarz"),
(11, "Aguirre Erick", "Obrońca"),
(11, "Alvarez Campos Kevin Nahin", "Obrońca"),
(11, "Alvarez Edson", "Obrońca"),
(11, "Angulo Jesus", "Obrońca"),
(11, "Araujo Julian", "Obrońca"),
(11, "Araujo Nestor", "Obrońca"),
(11, "Arteaga Gerardo", "Obrońca"),
(11, "Dominguez Julio", "Obrońca"),
(11, "Aguirre Erick", "Pomocnik"),
(11, "Alvarado Roberto", "Pomocnik"),
(11, "Antuna Uriel", "Pomocnik"),
(11, "Beltran Fernando", "Pomocnik"),
(11, "Carrillo Jordan", "Pomocnik"),
(11, "Chavez Luis", "Pomocnik"),
(11, "Cordova Sebastian", "Pomocnik"),
(11, "Corona Jesus", "Pomocnik"),
(11, "Flores Marcelo", "Pomocnik"),
(11, "Aguirre Eduardo", "Napastnik"),
(11, "Funes Mori Rogelio", "Napastnik"),
(11, "Gimenez Santiago Tomas", "Napastnik"),
(11, "Jimenez Raul", "Napastnik"),
(11, "Lainez Diego", "Napastnik"),
(11, "Lozano Hirving", "Napastnik"),

(19, "ter Stegen Marc-Andre", "Bramkarz"),
(19, "Neuer Manuel", "Bramkarz"),
(19, "Trapp Kevin", "Bramkarz"),
(19, "Ginter Matthias", "Obrońca"),
(19, "Gunter Christian", "Obrońca"),
(19, "Kehrer Thilo", "Obrońca"),
(19, "Klostermann Lukas", "Obrońca"),
(19, "Rudiger Antonio", "Obrońca"),
(19, "Schlotterbeck Nico", "Obrońca"),
(19, "Sule Niklas", "Obrońca"),
(19, "Tah Jonathan", "Obrońca"),
(19, "Draxler Julian", "Pomocnik"),
(19, "Goretzka Leon", "Pomocnik"),
(19, "Gundogan Ilkay", "Pomocnik"),
(19, "Havertz Kai", "Pomocnik"),
(19, "Henrichs Benjamin", "Pomocnik"),
(19, "Hofmann Jonas", "Pomocnik"),
(19, "Kimmich Joshua", "Pomocnik"),
(19, "Musiala Jamal", "Pomocnik"),
(19, "Weigl Julian", "Pomocnik"),
(19, "Adeyemi Karim", "Napastnik"),
(19, "Brandt Julian", "Napastnik"),
(19, "Gnabry Serge", "Napastnik"),
(19, "Muller Thomas", "Napastnik"),
(19, "Werner Timo", "Napastnik"),
(19, "Sane Leroy", "Napastnik"),

(1, "Al Sheeb Saad", "Bramkarz"),
(1, "Barsham Meshaal", "Bramkarz"),
(1, "Mohamed Ali Yousef Hassan", "Bramkarz"),
(1, "Ahmed Homam", "Obrońca"),
(1, "Al-Rawi Bassam Hisham", "Obrońca"),
(1, "Al Hajri Salem", "Obrońca"),
(1, "Assadalla Ali", "Obrońca"),
(1, "Hassan Abdelkarim", "Obrońca"),
(1, "Khoder Musab", "Obrońca"),
(1, "Khoukhi Boualem", "Obrońca"),
(1, "Madibo Assim Omer", "Obrońca"),
(1, "Mohamed Khidir Musaab", "Obrońca"),
(1, "Abdelrahman Fahmi", "Pomocnik"),
(1, "Al Bayati Mohammed", "Pomocnik"),
(1, "Al Hadhrami Naif", "Pomocnik"),
(1, "Al Haydos Hasan", "Pomocnik"),
(1, "Alahrak Abdullah", "Pomocnik"),
(1, "Boudiaf Karim", "Pomocnik"),
(1, "Hatim Abdulaziz", "Pomocnik"),
(1, "Muntari Mohammed", "Pomocnik"),
(1, "Afif Akram", "Napastnik"),
(1, "Ahmed Alaaeldin", "Napastnik"),
(1, "Almoez Ali", "Napastnik"),
(1, "Mazeed Khalid Muneer", "Napastnik"),
(1, "Mohammad Ismaeel", "Napastnik"),
(1, "Shehata Hazem", "Napastnik"),

(12, "Szczęsny Wojciech", "Bramkarz"),
(12, "Grabara Kamil", "Bramkarz"),
(12, "Skorupski Lukasz", "Bramkarz"),
(12, "Bednarek Jan", "Obrońca"),
(12, "Bereszynski Bartosz", "Obrońca"),
(12, "Bielik Krystian", "Obrońca"),
(12, "Cash Matty", "Obrońca"),
(12, "Glik Kamil", "Obrońca"),
(12, "Puchacz Tymoteusz", "Obrońca"),
(12, "Helik Michal", "Obrońca"),
(12, "Kamiński Marcin", "Obrońca"),
(12, "Kiwior Jakub", "Obrońca"),
(12, "Frankowski Przemyslaw", "Pomocnik"),
(12, "Góralski Jacek", "Pomocnik"),
(12, "Żurkowski Szymon", "Pomocnik"),
(12, "Kamiński Jakub", "Pomocnik"),
(12, "Klich Mateusz", "Pomocnik"),
(12, "Krychowiak Grzegorz", "Pomocnik"),
(12, "Zieliński Piotr", "Pomocnik"),
(12, "Szymaśski Sebastian", "Pomocnik"),
(12, "Moder Jakub", "Pomocnik"),
(12, "Zalewski Nicola", "Pomocnik"),
(12, "Lewandowski Robert", "Napastnik"),
(12, "Milik Arkadiusz", "Napastnik"),
(12, "Piątek Krzysztof", "Napastnik"),
(12, "Świderski Karol", "Napastnik"),

(32, "Gu Sung-Yun", "Bramkarz"),
(32, "Jo Hyeon-Woo", "Bramkarz"),
(32, "Kim Dong-Jun", "Bramkarz"),
(32, "Cho Yu-Min", "Obrońca"),
(32, "Choi Ji-Mook", "Obrońca"),
(32, "Hong Chul", "Obrońca"),
(32, "Jung Seung-Hyun", "Obrońca"),
(32, "Kang Sang-Woo", "Obrońca"),
(32, "Kim Jin-Su", "Obrońca"),
(32, "Kim Min-Jae", "Obrońca"),
(32, "Kim Moon-Hwan", "Obrońca"),
(32, "Hwang In-Beom", "Pomocnik"),
(32, "Jeong Woo-Yeong", "Pomocnik"),
(32, "Jung Woo-Young", "Pomocnik"),
(32, "Kim Dong-Hyun", "Pomocnik"),
(32, "Kim Jin-Kyu", "Pomocnik"),
(32, "Kim Tae-Hwan", "Pomocnik"),
(32, "Ko Seung-Beom", "Pomocnik"),
(32, "Kwon Chang-Hoon", "Pomocnik"),
(32, "Son Heung-Min", "Napastnik"),
(32, "Cho Young-Wook", "Napastnik"),
(32, "Eom Ji-Seong", "Napastnik"),
(32, "Hwang Hee-Chan", "Napastnik"),
(32, "Hwang Ui-Jo", "Napastnik"),
(32, "Kim Dae-Won", "Napastnik"),
(32, "Kim Gun-Hee", "Napastnik"),

(18, "Alvarado Esteban", "Bramkarz"),
(18, "Cruz Aaron", "Bramkarz"),
(18, "Moreira Leonel", "Bramkarz"),
(18, "Blanco Ricardo", "Obrońca"),
(18, "Calvo Francisco", "Obrońca"),
(18, "Duarte Oscar", "Obrońca"),
(18, "Fuller Spence Keysher", "Obrońca"),
(18, "Galo Orlando", "Obrońca"),
(18, "Lopez Douglas", "Obrońca"),
(18, "Martinez Carlos", "Obrońca"),
(18, "Mora Carlos", "Obrońca"),
(18, "Aguilera Brandon", "Pomocnik"),
(18, "Bennette Jewison", "Pomocnik"),
(18, "Borges Celso", "Pomocnik"),
(18, "Chacon Salas Daniel", "Pomocnik"),
(18, "Matarrita Ronald", "Pomocnik"),
(18, "Salas Youstin", "Pomocnik"),
(18, "Tejeda Yeltsin", "Pomocnik"),
(18, "Torres Gerson", "Pomocnik"),
(18, "Campbell Joel", "Napastnik"),
(18, "Contreras Anthony", "Napastnik"),
(18, "Martinez Alonso", "Napastnik"),
(18, "Ortiz Jose Guilermo", "Napastnik"),
(18, "Ruiz Bryan", "Napastnik"),
(18, "Suarez Aaron", "Napastnik"),
(18, "Venegas Johan", "Napastnik"),

(29, "Diogo Costa", "Bramkarz"),
(29, "Jose Sa", "Bramkarz"),
(29, "Patricio Rui", "Bramkarz"),
(29, "Cancelo Joao", "Obrońca"),
(29, "Dalot Diogo", "Obrońca"),
(29, "Djalo Tiago", "Obrońca"),
(29, "Duarte Domingos", "Obrońca"),
(29, "Fonte Jose", "Obrońca"),
(29, "Guerreiro Raphael", "Obrońca"),
(29, "Mendes Nuno", "Obrońca"),
(29, "Pepe", "Obrońca"),
(29, "Carvalho William", "Pomocnik"),
(29, "Danilo", "Pomocnik"),
(29, "Fernandes Bruno", "Pomocnik"),
(29, "Moutinho Joao", "Pomocnik"),
(29, "Neves Ruben", "Pomocnik"),
(29, "Nunes Matheus", "Pomocnik"),
(29, "Otavio", "Pomocnik"),
(29, "Palhinha Joao", "Pomocnik"),
(29, "Silva Bernardo", "Pomocnik"),
(29, "Diogo Jota", "Napastnik"),
(29, "Guedes Goncalo", "Napastnik"),
(29, "Horta Ricardo", "Napastnik"),
(29, "Joao Felix", "Napastnik"),
(29, "Leao Rafael", "Napastnik"),
(29, "Ronaldo Cristiano", "Napastnik"),

(3, "Dieng Seny", "Bramkarz"),
(3, "Faty Alioune Badara", "Bramkarz"),
(3, "Gomis Alfred", "Bramkarz"),
(3, "Ballo-Toure Fode", "Obrońca"),
(3, "Ciss Saliou", "Obrońca"),
(3, "Cisse Pape Abou", "Obrońca"),
(3, "Diallo Abdou", "Obrońca"),
(3, "Koulibaly Kalidou", "Obrońca"),
(3, "Mbaye Ibrahima", "Obrońca"),
(3, "Sarr Bouna", "Obrońca"),
(3, "Seck Abdoulaye", "Obrońca"),
(3, "Gueye Idrissa", "Pomocnik"),
(3, "Gueye Pape", "Pomocnik"),
(3, "Kouyate Cheikhou", "Pomocnik"),
(3, "Lopy Joseph", "Pomocnik"),
(3, "Loum Mamadou", "Pomocnik"),
(3, "Mendy Nampalys", "Pomocnik"),
(3, "Name Moustapha", "Pomocnik"),
(3, "Sarr Pape", "Pomocnik"),
(3, "Balde Keita", "Napastnik"),
(3, "Dia Boulaye", "Napastnik"),
(3, "Diallo Habib", "Napastnik"),
(3, "Diedhiou Famara", "Napastnik"),
(3, "Dieng Bamba", "Napastnik"),
(3, "Mane Sadio", "Napastnik"),
(3, "Sarr Ismaila", "Napastnik"),

(26, "Dmitrovic Marko", "Bramkarz"),
(26, "Ilic Marko", "Bramkarz"),
(26, "Milinkovic-Savic Vanja", "Bramkarz"),
(26, "Milenkovic Nikola", "Obrońca"),
(26, "Mitrovic Stefan", "Obrońca"),
(26, "Mladenovic Filip", "Obrońca"),
(26, "Nastasic Matija", "Obrońca"),
(26, "Pavlovic Strahinja", "Obrońca"),
(26, "Ristic Mihailo", "Obrońca"),
(26, "Terzic Aleksa", "Obrońca"),
(26, "Veljkovic Milos", "Obrońca"),
(26, "Djuricic Filip", "Pomocnik"),
(26, "Grujic Marko", "Pomocnik"),
(26, "Gudelj Nemanja", "Pomocnik"),
(26, "Ilic Ivan", "Pomocnik"),
(26, "Lazovic Darko", "Pomocnik"),
(26, "Lukic Sasa", "Pomocnik"),
(26, "Maksimovic Nemanja", "Pomocnik"),
(26, "Milinkovic-Savic Sergej", "Pomocnik"),
(26, "Racic Uros", "Pomocnik"),
(26, "Radonjic Nemanja", "Pomocnik"),
(26, "Zivkovic Andrija", "Pomocnik"),
(26, "Jovic Luka", "Napastnik"),
(26, "Kostic Filip", "Napastnik"),
(26, "Mitrovic Aleksandar", "Napastnik"),
(26, "Tadic Dusan", "Napastnik"),

(7, "Horvath Ethan", "Bramkarz"),
(7, "Johnson Sean", "Bramkarz"),
(7, "Slonina Gabriel", "Bramkarz"),
(7, "Adams Tyler", "Obrońca"),
(7, "Bello George", "Obrońca"),
(7, "Booth Taylor", "Obrońca"),
(7, "Cannon Reggie", "Obrońca"),
(7, "Carter-Vickers Cameron", "Obrońca"),
(7, "Che Justin", "Obrońca"),
(7, "Dest Sergino", "Obrońca"),
(7, "Gomez Jonathan", "Obrońca"),
(7, "Aaronson Brenden", "Pomocnik"),
(7, "Acosta Kellyn", "Pomocnik"),
(7, "Pulisic Christian", "Pomocnik"),
(7, "Reyna Giovanni", "Pomocnik"),
(7, "Clark Caden", "Pomocnik"),
(7, "Johnny", "Pomocnik"),
(7, "Lennon Brooks", "Pomocnik"),
(7, "Lletget Sebastian", "Pomocnik"),
(7, "Arriola Paul", "Napastnik"),
(7, "Cowell Cade", "Napastnik"),
(7, "Weah Timothy", "Napastnik"),
(7, "Morris Jordan", "Napastnik"),
(7, "Zardes Gyasi", "Napastnik"),
(7, "Siebatcheu Jordan", "Napastnik"),
(7, "Tillman Malik", "Napastnik"),

(27, "Kobel Gregor", "Bramkarz"),
(27, "Mvogo Yvon", "Bramkarz"),
(27, "Omlin Jonas", "Bramkarz"),
(27, "Akanji Manuel", "Obrońca"),
(27, "Comert Eray", "Obrońca"),
(27, "Elvedi Nico", "Obrońca"),
(27, "Lotomba Jordan", "Obrońca"),
(27, "Mbabu Kevin", "Obrońca"),
(27, "Rodriguez Ricardo", "Obrońca"),
(27, "Schar Fabian", "Obrońca"),
(27, "Stergiou Leonidas", "Obrońca"),
(27, "Widmer Silvan", "Obrońca"),
(27, "Aebischer Michel", "Pomocnik"),
(27, "Bottani Mattia", "Pomocnik"),
(27, "Frei Fabian", "Pomocnik"),
(27, "Freuler Remo", "Pomocnik"),
(27, "Shaqiri Xherdan", "Pomocnik"),
(27, "Sow Djibril", "Pomocnik"),
(27, "Steffen Renato", "Pomocnik"),
(27, "Vargas Ruben", "Pomocnik"),
(27, "Xhaka Granit", "Pomocnik"),
(27, "Zuber Steven", "Pomocnik"),
(27, "Embolo Breel", "Napastnik"),
(27, "Gavranovic Mario", "Napastnik"),
(27, "Okafor Noah", "Napastnik"),
(27, "Seferovic Haris", "Napastnik"),

(16, "Ben Mustapha Farouk", "Bramkarz"),
(16, "Ben Said Bechir", "Bramkarz"),
(16, "Dahmen Aymen", "Bramkarz"),
(16, "Abdi Ali", "Obrońca"),
(16, "Ben Hamida Mohamed Amine", "Obrońca"),
(16, "Ben Lamin Adam", "Obrońca"),
(16, "Bronn Dylan", "Obrońca"),
(16, "Drager Mohamed", "Obrońca"),
(16, "Ghram Alaa", "Obrońca"),
(16, "Haddadi Oussama", "Obrońca"),
(16, "Ifa Bilel", "Obrońca"),
(16, "Bellamine Adem", "Pomocnik"),
(16, "Ben Larbi Firas", "Pomocnik"),
(16, "Ben Ouanes Mortadha", "Pomocnik"),
(16, "Ben Romdhane Mohamed Ali", "Pomocnik"),
(16, "Bguir Saad", "Pomocnik"),
(16, "Chaaleli Ghaylen", "Pomocnik"),
(16, "Ghandri Nader", "Pomocnik"),
(16, "Khaoui Saif-Eddine", "Pomocnik"),
(16, "Laidouni Aissa", "Pomocnik"),
(16, "Mejbri Hannibal", "Pomocnik"),
(16, "Achouri Elias", "Napastnik"),
(16, "Jaziri Seifeddine", "Napastnik"),
(16, "Jebali Issam", "Napastnik"),
(16, "Khazri Wahbi", "Napastnik"),
(16, "Khenissi Taha", "Napastnik"),

(31, "Campana Martin", "Bramkarz"),
(31, "De Amores Ravelo Guillermo Rafael", "Bramkarz"),
(31, "Muslera Fernando", "Bramkarz"),
(31, "Araujo Ronald", "Obrońca"),
(31, "Cabrera Leandro", "Obrońca"),
(31, "Caceres Martin", "Obrońca"),
(31, "Coates Sebastian", "Obrońca"),
(31, "Gimenez Jose Maria", "Obrońca"),
(31, "Godin Diego", "Obrońca"),
(31, "Olivera Miramontes Mathias", "Obrońca"),
(31, "Arambarri Mauro", "Pomocnik"),
(31, "Bentancur Rodrigo", "Pomocnik"),
(31, "Canobbio Graviz Agustin", "Pomocnik"),
(31, "De Arrascaeta Giorgian", "Pomocnik"),
(31, "De La Cruz Arcosa Diego Nicolas", "Pomocnik"),
(31, "Gorriaran Fontes Fernando", "Pomocnik"),
(31, "Pellistri Facundo", "Pomocnik"),
(31, "Torreira Lucas", "Pomocnik"),
(31, "Ugarte Manuel", "Pomocnik"),
(31, "Valverde Federico", "Pomocnik"),
(31, "Cavani Edinson", "Napastnik"),
(31, "Gomez Maximiliano", "Napastnik"),
(31, "Lopez Nicolas", "Napastnik"),
(31, "Nunez Darwin", "Napastnik"),
(31, "Rossi Diego", "Napastnik"),
(31, "Suarez Luis", "Napastnik"),

(8, "Davies Adam", "Bramkarz"),
(8, "Hennessey Wayne", "Bramkarz"),
(8, "King Tom", "Bramkarz"),
(8, "Ampadu Ethan", "Obrońca"),
(8, "Cabango Benjamin", "Obrońca"),
(8, "Davies Ben", "Obrońca"),
(8, "Denham Oliver", "Obrońca"),
(8, "Gunter Chris", "Obrońca"),
(8, "Mepham Chris", "Obrońca"),
(8, "Norrington-Davies Rhys", "Obrońca"),
(8, "Roberts Connor", "Obrońca"),
(8, "Rodon Joe", "Obrońca"),
(8, "Allen Joe", "Pomocnik"),
(8, "Burns Wes", "Pomocnik"),
(8, "Colwill Rubin", "Pomocnik"),
(8, "James Daniel", "Pomocnik"),
(8, "Levitt Dylan", "Pomocnik"),
(8, "Morrell Joseff", "Pomocnik"),
(8, "Ramsey Aaron", "Pomocnik"),
(8, "Smith Matthew", "Pomocnik"),
(8, "Williams Jonathan", "Pomocnik"),
(8, "Bale Gareth", "Napastnik"),
(8, "Johnson Brennan", "Napastnik"),
(8, "Matondo Rabbi", "Napastnik"),
(8, "Moore Kieffer", "Napastnik"),
(8, "Sorba Thomas", "Napastnik"),

(5, "Forster Fraser", "Bramkarz"),
(5, "Pickford Jordan", "Bramkarz"),
(5, "Pope Nick", "Bramkarz"),
(5, "Alexander-Arnold Trent", "Obrońca"),
(5, "Coady Conor", "Obrońca"),
(5, "Guehi Marc", "Obrońca"),
(5, "James Reece", "Obrońca"),
(5, "Justin James", "Obrońca"),
(5, "Maguire Harry", "Obrońca"),
(5, "Mings Tyrone", "Obrońca"),
(5, "Mitchell Tyrick", "Obrońca"),
(5, "Shaw Luke", "Obrońca"),
(5, "Bellingham Jude", "Pomocnik"),
(5, "Foden Phil", "Pomocnik"),
(5, "Gallagher Conor", "Pomocnik"),
(5, "Grealish Jack", "Pomocnik"),
(5, "Henderson Jordan", "Pomocnik"),
(5, "Mount Mason", "Pomocnik"),
(5, "Phillips Kalvin", "Pomocnik"),
(5, "Rice Declan", "Pomocnik"),
(5, "Saka Bukayo", "Pomocnik"),
(5, "Smith Rowe Emile", "Pomocnik"),
(5, "Abraham Tammy", "Napastnik"),
(5, "Bowen Jarrod", "Napastnik"),
(5, "Kane Harry", "Napastnik"),
(5, "Sterling Raheem", "Napastnik"),

(10, "Al Owais Mohammed", "Bramkarz"),
(10, "Al Qarni Fawaz", "Bramkarz"),
(10, "Al Rubaie Mohammed", "Bramkarz"),
(10, "Abdulhamid Saud", "Obrońca"),
(10, "Al Amri Abdulelah", "Obrońca"),
(10, "Al Bishi Abdulaziz", "Obrońca"),
(10, "Al Burayk Mohammed", "Obrońca"),
(10, "Al Harbi Moteb", "Obrońca"),
(10, "Al Khaibri Abdulmalek Abdullah", "Obrońca"),
(10, "Al Sahafi Ziyad", "Obrońca"),
(10, "Al Shahrani Yasser", "Obrońca"),
(10, "Al Tambakti Hassan Mohammed", "Obrońca"),
(10, "Alawjami Ali", "Obrońca"),
(10, "Al-Najei Sami", "Pomocnik"),
(10, "Al Dawsari Nasser", "Pomocnik"),
(10, "Al Dawsari Salem", "Pomocnik"),
(10, "Al Faraj Salman", "Pomocnik"),
(10, "Al Ghanam Sultan Abdullah", "Pomocnik"),
(10, "Al Hassan Ali", "Pomocnik"),
(10, "Al Khaibari Abdullah", "Pomocnik"),
(10, "Al Malki Abdulelah", "Pomocnik"),
(10, "Abdulrahman Al Obod", "Napastnik"),
(10, "Al Buraikan Firas", "Napastnik"),
(10, "Al Ghannam Khalid", "Napastnik"),
(10, "Al Hamdan Abdullah", "Napastnik"),
(10, "Al Muwallad Al Harbi Fahad Mosaed", "Napastnik"),

(9, "Armani Franco", "Bramkarz"),
(9, "Martinez Emiliano", "Bramkarz"),
(9, "Musso Juan", "Bramkarz"),
(9, "Acuna Marcos", "Obrońca"),
(9, "Foyth Juan", "Obrońca"),
(9, "Martinez Lisandro", "Obrońca"),
(9, "Martinez Quarta Lucas", "Obrońca"),
(9, "Molina Nahuel", "Obrońca"),
(9, "Montiel Gonzalo", "Obrońca"),
(9, "Otamendi Nicolas", "Obrońca"),
(9, "Pezzella German", "Obrońca"),
(9, "de Paul Rodrigo", "Pomocnik"),
(9, "Correa Angel", "Pomocnik"),
(9, "Correa Joaquin", "Pomocnik"),
(9, "Di Maria Angel", "Pomocnik"),
(9, "Rodriguez Guido", "Pomocnik"),
(9, "Lo Celso Giovani", "Pomocnik"),
(9, "Papu Gomez", "Pomocnik"),
(9, "Palacios Exequiel", "Pomocnik"),
(9, "Paredes Leandro", "Pomocnik"),
(9, "Alvarez Julian", "Napastnik"),
(9, "Dybala Paulo", "Napastnik"),
(9, "Gonzalez Nicolas", "Napastnik"),
(9, "Martinez Lautaro", "Napastnik"),
(9, "Messi Lionel", "Napastnik"),
(9, "Ocampos Lucas", "Napastnik"),

(14, "Redmayne Andrew", "Bramkarz"),
(14, "Ryan Mathew", "Bramkarz"),
(14, "Vukovic Danny", "Bramkarz"),
(14, "Atkinson Nathaniel", "Obrońca"),
(14, "Behich Aziz", "Obrońca"),
(14, "Genreau Denis", "Obrońca"),
(14, "Grant Rhyan", "Obrońca"),
(14, "Karacic Fran", "Obrońca"),
(14, "King Joel", "Obrońca"),
(14, "McGowan Ryan", "Obrońca"),
(14, "Rowles Kye", "Obrońca"),
(14, "Sainsbury Trent", "Obrońca"),
(14, "Degenek Milos", "Pomocnik"),
(14, "Dougall Kenneth", "Pomocnik"),
(14, "Hrustic Ajdin", "Pomocnik"),
(14, "Irvine Jackson", "Pomocnik"),
(14, "Jeggo James", "Pomocnik"),
(14, "Mabil Awer", "Pomocnik"),
(14, "McGree Riley", "Pomocnik"),
(14, "Mooy Aaron", "Pomocnik"),
(14, "Rogic Tom", "Pomocnik"),
(14, "Borrello Brandon", "Napastnik"),
(14, "Boyle Martin", "Napastnik"),
(14, "D'Agostino Nicholas", "Napastnik"),
(14, "Duke Mitchell", "Napastnik"),
(14, "Fornaroli Bruno", "Napastnik"),

(21, "Casteels Koen", "Bramkarz"),
(21, "Kaminski Thomas", "Bramkarz"),
(21, "Mignolet Simon", "Bramkarz"),
(21, "Alderweireld Toby", "Obrońca"),
(21, "Vertonghen Jan", "Obrońca"),
(21, "Boyata Dedryck", "Obrońca"),
(21, "Castagne Timothy", "Obrońca"),
(21, "Denayer Jason", "Obrońca"),
(21, "Meunier Thomas", "Obrońca"),
(21, "Foket Thomas", "Obrońca"),
(21, "Mechele Brandon", "Obrońca"),
(21, "De Bruyne Kevin", "Pomocnik"),
(21, "De Ketelaere Charles", "Pomocnik"),
(21, "Dendoncker Leander", "Pomocnik"),
(21, "Hazard Thorgan", "Pomocnik"),
(21, "Januzaj Adnan", "Pomocnik"),
(21, "Vanaken Hans", "Pomocnik"),
(21, "Witsel Axel", "Pomocnik"),
(21, "Praet Dennis", "Pomocnik"),
(21, "Trossard Leandro", "Pomocnik"),
(21, "Batshuayi Michy", "Napastnik"),
(21, "Carrasco Yannick", "Napastnik"),
(21, "Hazard Eden", "Napastnik"),
(21, "Lukaku Romelu", "Napastnik"),
(21, "Mertens Dries", "Napastnik"),
(21, "Openda Lois", "Napastnik"),

(25, "Alisson", "Bramkarz"),
(25, "Ederson", "Bramkarz"),
(25, "Everson", "Bramkarz"),
(25, "Alex Sandro", "Obrońca"),
(25, "Dani Alves", "Obrońca"),
(25, "Danilo", "Obrońca"),
(25, "Emerson Royal", "Obrońca"),
(25, "Felipe", "Obrońca"),
(25, "Telles Alex", "Obrońca"),
(25, "Militao Eder", "Obrońca"),
(25, "Silva Thiago", "Obrońca"),
(25, "Marquinhos", "Obrońca"),
(25, "Lucas Paqueta", "Pomocnik"),
(25, "Casemiro", "Pomocnik"),
(25, "Coutinho Philippe", "Pomocnik"),
(25, "Everton Ribeiro", "Pomocnik"),
(25, "Fabinho", "Pomocnik"),
(25, "Fred", "Pomocnik"),
(25, "Guimaraes Bruno", "Pomocnik"),
(25, "Antony", "Napastnik"),
(25, "Rodrygo", "Napastnik"),
(25, "Jesus Gabriel", "Napastnik"),
(25, "Vinicius Junior", "Napastnik"),
(25, "Matheus Cunha", "Napastnik"),
(25, "Neymar", "Napastnik"),
(25, "Raphinha", "Napastnik"),

(24, "Grbic Ivo", "Bramkarz"),
(24, "Ivusic Ivica", "Bramkarz"),
(24, "Livakovic Dominik", "Bramkarz"),
(24, "Vrsaljko Sime", "Obrońca"),
(24, "Vida Domagoj", "Obrońca"),
(24, "Gvardiol Josko", "Obrońca"),
(24, "Juranovic Josip", "Obrońca"),
(24, "Pongracic Marin", "Obrońca"),
(24, "Skoric Mile", "Obrońca"),
(24, "Sosa Borna", "Obrońca"),
(24, "Stanisic Josip", "Obrońca"),
(24, "Brozovic Marcelo", "Pomocnik"),
(24, "Ivanusec Luka", "Pomocnik"),
(24, "Jakic Kristijan", "Pomocnik"),
(24, "Kovacic Mateo", "Pomocnik"),
(24, "Majer Lovro", "Pomocnik"),
(24, "Modric Luka", "Pomocnik"),
(24, "Moro Nikola", "Pomocnik"),
(24, "Pasalic Mario", "Pomocnik"),
(24, "Sucic Luka", "Pomocnik"),
(24, "Brekalo Josip", "Napastnik"),
(24, "Budimir Ante", "Napastnik"),
(24, "Kramaric Andrej", "Napastnik"),
(24, "Livaja Marko", "Napastnik"),
(24, "Orsic Mislav", "Napastnik"),
(24, "Perisic Ivan", "Napastnik"),

(15, "Iversen Daniel", "Bramkarz"),
(15, "Ronnow Frederik", "Bramkarz"),
(15, "Schmeichel Kasper", "Bramkarz"),
(15, "Andersen Joachim", "Obrońca"),
(15, "Bah Alexander", "Obrońca"),
(15, "Boilesen Nicolai", "Obrońca"),
(15, "Christensen Andreas", "Obrońca"),
(15, "Kristensen Rasmus", "Obrońca"),
(15, "Maehle Joakim", "Obrońca"),
(15, "Wass Daniel", "Obrońca"),
(15, "Vestergaard Jannikr", "Obrońca"),
(15, "Pedersen Mads", "Obrońca"),
(15, "Billing Philip", "Pomocnik"),
(15, "Bruun Larsen Jacob", "Pomocnik"),
(15, "Damsgaard Mikkel", "Pomocnik"),
(15, "Delaney Thomas", "Pomocnik"),
(15, "Eriksen Christian", "Pomocnik"),
(15, "Hojbjerg Pierre-Emile", "Pomocnik"),
(15, "Jensen Mathias", "Pomocnik"),
(15, "Lindstrom Jesper", "Pomocnik"),
(15, "Braithwaite Martin", "Napastnik"),
(15, "Cornelius Andreas", "Napastnik"),
(15, "Dolberg Kasper", "Napastnik"),
(15, "Poulsen Yussuf", "Napastnik"),
(15, "Skov Robert", "Napastnik"),
(15, "Wind Jonas", "Napastnik"),

(2, "Dominguez Alexander", "Bramkarz"),
(2, "Galindez Hernan", "Bramkarz"),
(2, "Ortiz Pedro", "Bramkarz"),
(2, "Arboleda Robert", "Obrońca"),
(2, "Arreaga Xavier", "Obrońca"),
(2, "Caicedo Ante Romario Javier", "Obrońca"),
(2, "Castillo Segura Byron David", "Obrońca"),
(2, "Corozo Alman Janner Hitcler", "Obrońca"),
(2, "Estupinan Pervis", "Obrońca"),
(2, "Hincapie Piero", "Obrońca"),
(2, "Leon Fernando", "Obrońca"),
(2, "Arroyo Dixon", "Pomocnik"),
(2, "Caicedo Moises", "Pomocnik"),
(2, "Carcelen Carabali Michael Alexander", "Pomocnik"),
(2, "Cifuentes Charcopa Jose Adoni", "Pomocnik"),
(2, "Franco Alan", "Pomocnik"),
(2, "Gruezo Carlos", "Pomocnik"),
(2, "Ibarra Mina Romario Andres", "Pomocnik"),
(2, "Mena Angel", "Pomocnik"),
(2, "Mendez Jhegson", "Pomocnik"),
(2, "Caicedo Jordy", "Napastnik"),
(2, "Valencia Enner", "Napastnik"),
(2, "Estrada Michael", "Napastnik"),
(2, "Plata Gonzalo", "Napastnik"),
(2, "Preciado Eduar", "Napastnik"),
(2, "Reascos Djorkaeff", "Napastnik"),

(13, "Areola Alphonse", "Bramkarz"),
(13, "Lloris Hugo", "Bramkarz"),
(13, "Maignan Mike", "Bramkarz"),
(13, "Clauss Jonathan", "Obrońca"),
(13, "Digne Lucas", "Obrońca"),
(13, "Hernandez Lucas", "Obrońca"),
(13, "Hernandez Theo", "Obrońca"),
(13, "Kimpembe Presnel", "Obrońca"),
(13, "Kounde Jules", "Obrońca"),
(13, "Pavard Benjamin", "Obrońca"),
(13, "Saliba William", "Obrońca"),
(13, "Varane Raphael", "Obrońca"),
(13, "Guendouzi Matteo", "Pomocnik"),
(13, "Kante N'Golo", "Pomocnik"),
(13, "Nkunku Christopher", "Pomocnik"),
(13, "Pogba Paul", "Pomocnik"),
(13, "Rabiot Adrien", "Pomocnik"),
(13, "Tchouameni Aurelien", "Pomocnik"),
(13, "Thuram Marcus", "Pomocnik"),
(13, "Ben Yedder Wissam", "Napastnik"),
(13, "Benzema Karim", "Napastnik"),
(13, "Coman Kingsley", "Napastnik"),
(13, "Diaby Moussa", "Napastnik"),
(13, "Giroud Olivier", "Napastnik"),
(13, "Griezmann Antoine", "Napastnik"),
(13, "Mbappe Kylian", "Napastnik"),

(30, "Attah Richard", "Bramkarz"),
(30, "Nurudeen Abdul", "Bramkarz"),
(30, "Ofori Richard", "Bramkarz"),
(30, "Amartey Daniel", "Obrońca"),
(30, "Baba Abdul-Rahman", "Obrońca"),
(30, "Baffour Philomon", "Obrońca"),
(30, "Djiku Alexander", "Obrońca"),
(30, "Kamaheni Montari", "Obrońca"),
(30, "Korsah-Akoumah Dennis", "Obrońca"),
(30, "Mensah Gideon", "Obrońca"),
(30, "Mensah Jonathan", "Obrońca"),
(30, "Partey Thomas", "Pomocnik"),
(30, "Addo Edmund", "Pomocnik"),
(30, "Antweer Christopher", "Pomocnik"),
(30, "Baba Mohammed Iddrisu", "Pomocnik"),
(30, "Fatawu Abdul", "Pomocnik"),
(30, "Kudus Mohammed", "Pomocnik"),
(30, "Kyereh Daniel-Kofi", "Pomocnik"),
(30, "Owusu Elisha", "Pomocnik"),
(30, "Afena-Gyan Felix", "Napastnik"),
(30, "Afriyie Daniel", "Napastnik"),
(30, "Antwi-Adjei Christopher", "Napastnik"),
(30, "Ayew Andre", "Napastnik"),
(30, "Ayew Jordan", "Napastnik"),
(30, "Barnier Daniel", "Napastnik"),
(30, "Boakye Richmond", "Napastnik"),

(17, "de Gea David", "Bramkarz"),
(17, "Sanchez Robert", "Bramkarz"),
(17, "Simon Unai", "Bramkarz"),
(17, "Alba Jordi", "Obrońca"),
(17, "Alonso Marcos", "Obrońca"),
(17, "Azpilicueta Cesar", "Obrońca"),
(17, "Carvajal Daniel", "Obrońca"),
(17, "Garcia Eric", "Obrońca"),
(17, "Guillamon Hugo", "Obrońca"),
(17, "Laporte Aymeric", "Obrońca"),
(17, "Llorente Diego", "Obrońca"),
(17, "Martinez Inigo", "Obrońca"),
(17, "Torres Pau", "Obrońca"),
(17, "Gavi", "Pomocnik"),
(17, "Koke", "Pomocnik"),
(17, "Llorente Marcos", "Pomocnik"),
(17, "Olmo Dani", "Pomocnik"),
(17, "Pedri", "Pomocnik"),
(17, "Rodri", "Pomocnik"),
(17, "Sarabia Pablo", "Pomocnik"),
(17, "Soler Carlos", "Pomocnik"),
(17, "Fati Ansu", "Pomocnik"),
(17, "Morata Alvaro", "Napastnik"),
(17, "Torres Ferran", "Napastnik"),
(17, "de Tomas Raul", "Napastnik"),
(17, "Asensio Marco", "Napastnik"),

(4, "Cillessen Jasper", "Bramkarz"),
(4, "Drommel Joel", "Bramkarz"),
(4, "Flekken Mark", "Bramkarz"),
(4, "Ake Nathan", "Obrońca"),
(4, "Dumfries Denzel", "Obrońca"),
(4, "Hateboer Hans", "Obrońca"),
(4, "Malacia Tyrell", "Obrońca"),
(4, "Martins Indi Bruno", "Obrońca"),
(4, "van Dijk Virgil", "Obrońca"),
(4, "Timber Jurrien", "Obrońca"),
(4, "de Vrij Stefan", "Obrońca"),
(4, "de Ligt Matthijs", "Obrońca"),
(4, "Berghuis Steven", "Pomocnik"),
(4, "Bergwijn Steven", "Pomocnik"),
(4, "Blind Daley", "Pomocnik"),
(4, "de Jong Frenkie", "Pomocnik"),
(4, "Klaassen Davy", "Pomocnik"),
(4, "Koopmeiners Teun", "Pomocnik"),
(4, "Wijnaldum Georginio", "Pomocnik"),
(4, "de Roon Marten", "Pomocnik"),
(4, "Danjuma Arnaut", "Napastnik"),
(4, "Depay Memphis", "Napastnik"),
(4, "Gakpo Cody", "Napastnik"),
(4, "Weghorst Wout", "Napastnik"),
(4, "Lang Noa", "Napastnik"),
(4, "Malen Donyell", "Napastnik"),

(6, "Abedzadeh Amir", "Bramkarz"),
(6, "Akhbari Mohammadreza", "Bramkarz"),
(6, "Beiranvand Alireza", "Bramkarz"),
(6, "Esmaeilifar Danial", "Obrońca"),
(6, "Faraji Farshad", "Obrońca"),
(6, "Gholami Aref", "Obrońca"),
(6, "Hardani Saleh", "Obrońca"),
(6, "Hosseini Majid", "Obrońca"),
(6, "Jalali Abolfazl", "Obrońca"),
(6, "Kanaani Hossein", "Obrońca"),
(6, "Khalilzadeh Shoja", "Obrońca"),
(6, "Aghasi Kolahsorkhi Aaref", "Pomocnik"),
(6, "Amiri Vahid", "Pomocnik"),
(6, "Ebrahimi Omid", "Pomocnik"),
(6, "Ezatolahi Saeid", "Pomocnik"),
(6, "Ghoddos Saman", "Pomocnik"),
(6, "Gholizadeh Ali", "Pomocnik"),
(6, "Hajsafi Ehsan", "Pomocnik"),
(6, "Hosseinzadeh Amirhossein", "Pomocnik"),
(6, "Kamyabinia Kamaleddin", "Pomocnik"),
(6, "Mehdipour Mehdi", "Pomocnik"),
(6, "Alipour Ali", "Napastnik"),
(6, "Ansarifard Karim", "Napastnik"),
(6, "Azmoun Sardar", "Napastnik"),
(6, "Hashemian Vahid", "Napastnik"),
(6, "Jahanbakhsh Alireza", "Napastnik");


