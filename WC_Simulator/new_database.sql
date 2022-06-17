-- MySQL dump 10.13  Distrib 8.0.28, for Win64 (x86_64)
--
-- Host: localhost    Database: wc_simulator
-- ------------------------------------------------------
-- Server version	8.0.28

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `player`
--

DROP TABLE IF EXISTS `player`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `player` (
  `id_player` int unsigned NOT NULL AUTO_INCREMENT,
  `id_team` int unsigned NOT NULL,
  `name` varchar(50) NOT NULL,
  `position` enum('Bramkarz','Obrońca','Pomocnik','Napastnik') NOT NULL,
  PRIMARY KEY (`id_player`),
  KEY `fk_player_team` (`id_team`),
  CONSTRAINT `fk_player_team` FOREIGN KEY (`id_team`) REFERENCES `team` (`id_team`)
) ENGINE=InnoDB AUTO_INCREMENT=833 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `player`
--

LOCK TABLES `player` WRITE;
/*!40000 ALTER TABLE `player` DISABLE KEYS */;
INSERT INTO `player` VALUES (1,20,'Gonda Shuichi','Bramkarz'),(2,20,'Kawashima Eiji','Bramkarz'),(3,20,'Osako Keisuke','Bramkarz'),(4,20,'Endo Wataru','Obrońca'),(5,20,'Itakura Ko','Obrońca'),(6,20,'Nagatomo Yuto','Obrońca'),(7,20,'Nakatani Shinnosuke','Obrońca'),(8,20,'Nakayama Yuta','Obrońca'),(9,20,'Sakai Hiroki','Obrońca'),(10,20,'Sasaki Sho','Obrońca'),(11,20,'Tomiyasu Takehiro','Obrońca'),(12,20,'Doan Ritsu','Pomocnik'),(13,20,'Haraguchi Genki','Pomocnik'),(14,20,'Hatate Reo','Pomocnik'),(15,20,'Ito Hiroki','Pomocnik'),(16,20,'Kamada Daichi','Pomocnik'),(17,20,'Mitoma Kaoru','Pomocnik'),(18,20,'Morita Hidemasa','Pomocnik'),(19,20,'Shibasaki Gaku','Pomocnik'),(20,20,'Asano Takuma','Napastnik'),(21,20,'Furuhashi Kyogo','Napastnik'),(22,20,'Hayashi Daichi','Napastnik'),(23,20,'Ito Junya','Napastnik'),(24,20,'Kubo Takefusa','Napastnik'),(25,20,'Maeda Daizen','Napastnik'),(26,20,'Minamino Takumi','Napastnik'),(27,23,'Bono','Bramkarz'),(28,23,'Munir','Bramkarz'),(29,23,'Tagnaouti Ahmed Reda','Bramkarz'),(30,23,'Aguerd Nayef','Obrońca'),(31,23,'Alakouch Sofiane','Obrońca'),(32,23,'Attiat-Allal Yahya','Obrońca'),(33,23,'Chakla Soufiane','Obrońca'),(34,23,'Chibi Mohamed','Obrońca'),(35,23,'El Yamiq Jawad','Obrońca'),(36,23,'Hakimi Achraf','Obrońca'),(37,23,'Masina Adam','Obrońca'),(38,23,'Amallah Selim','Pomocnik'),(39,23,'Amrabat Sofyan','Pomocnik'),(40,23,'Barkok Aymen','Pomocnik'),(41,23,'Boufal Sofiane','Pomocnik'),(42,23,'Chair Ilias','Pomocnik'),(43,23,'El Karouani Souffian','Pomocnik'),(44,23,'Fajr Faycal','Pomocnik'),(45,23,'Harit Amine','Pomocnik'),(46,23,'Jabrane Yahya','Pomocnik'),(47,23,'Louza Imran','Pomocnik'),(48,23,'Aboukhlal Zakaria','Napastnik'),(49,23,'El Haddadi Munir','Napastnik'),(50,23,'El Kaabi Ayoub','Napastnik'),(51,23,'En Nesyri Youssef','Napastnik'),(52,23,'Mmaee Ryan','Napastnik'),(53,28,'Onana Andre','Bramkarz'),(54,28,'Epassy Devis','Bramkarz'),(55,28,'Omossola Simon Loti','Bramkarz'),(56,28,'Castelletto Jean-Charles','Obrońca'),(57,28,'Ebosse Enzo','Obrońca'),(58,28,'Fai Collins','Obrońca'),(59,28,'Mbaizo Olivier','Obrońca'),(60,28,'Moukoudi Harold','Obrońca'),(61,28,'Ngadeu Michael','Obrońca'),(62,28,'Onguene Jerome','Obrońca'),(63,28,'Oyongo Ambroise','Obrońca'),(64,28,'Anguissa Andre Zambo','Pomocnik'),(65,28,'Hongla Martin','Pomocnik'),(66,28,'Kunde Pierre','Pomocnik'),(67,28,'Lea Siliki James','Pomocnik'),(68,28,'Moumi Ngamaleu Nicolas','Pomocnik'),(69,28,'Neyou Yvan','Pomocnik'),(70,28,'Onana Jean','Pomocnik'),(71,28,'Ondoua Gael','Pomocnik'),(72,28,'Aboubakar Vincent','Napastnik'),(73,28,'Bahoken Stephane','Napastnik'),(74,28,'Bassogog Christian','Napastnik'),(75,28,'Choupo-Moting Eric Maxim','Napastnik'),(76,28,'Ganago Ignatius','Napastnik'),(77,28,'N\'Jie Clinton','Napastnik'),(78,28,'Toko Ekambi Karl','Napastnik'),(79,22,'Borjan Milan','Bramkarz'),(80,22,'Crepeau Maxime','Bramkarz'),(81,22,'Dayne St. Clair','Bramkarz'),(82,22,'Adekugbe Sam','Obrońca'),(83,22,'Brault-Guillard Zachary','Obrońca'),(84,22,'Cornelius Derek','Obrońca'),(85,22,'Davies Alphonso','Obrońca'),(86,22,'Gutierrez Cristian','Obrońca'),(87,22,'Henry Doneil','Obrońca'),(88,22,'Kennedy Scott','Obrońca'),(89,22,'Laryea Richie','Obrońca'),(90,22,'Miller Kamal','Obrońca'),(91,22,'Antunes Eustaquio Stephen','Pomocnik'),(92,22,'Buchanan Tajon','Pomocnik'),(93,22,'Edwards Raheem','Pomocnik'),(94,22,'Fraser Liam','Pomocnik'),(95,22,'Hutchinson Atiba','Pomocnik'),(96,22,'Johnston Alistair','Pomocnik'),(97,22,'Kaye Mark','Pomocnik'),(98,22,'Kone Ismael','Pomocnik'),(99,22,'Millar Liam','Pomocnik'),(100,22,'Brym Charles-Andreas','Napastnik'),(101,22,'Cavallini Lucas','Napastnik'),(102,22,'David Jonathan','Napastnik'),(103,22,'Hoilett Junior','Napastnik'),(104,22,'Larin Cyle','Napastnik'),(105,11,'Acevedo Carlos','Bramkarz'),(106,11,'Cota Rodolfo','Bramkarz'),(107,11,'Ochoa David','Bramkarz'),(108,11,'Aguirre Erick','Obrońca'),(109,11,'Alvarez Campos Kevin Nahin','Obrońca'),(110,11,'Alvarez Edson','Obrońca'),(111,11,'Angulo Jesus','Obrońca'),(112,11,'Araujo Julian','Obrońca'),(113,11,'Araujo Nestor','Obrońca'),(114,11,'Arteaga Gerardo','Obrońca'),(115,11,'Dominguez Julio','Obrońca'),(116,11,'Aguirre Erick','Pomocnik'),(117,11,'Alvarado Roberto','Pomocnik'),(118,11,'Antuna Uriel','Pomocnik'),(119,11,'Beltran Fernando','Pomocnik'),(120,11,'Carrillo Jordan','Pomocnik'),(121,11,'Chavez Luis','Pomocnik'),(122,11,'Cordova Sebastian','Pomocnik'),(123,11,'Corona Jesus','Pomocnik'),(124,11,'Flores Marcelo','Pomocnik'),(125,11,'Aguirre Eduardo','Napastnik'),(126,11,'Funes Mori Rogelio','Napastnik'),(127,11,'Gimenez Santiago Tomas','Napastnik'),(128,11,'Jimenez Raul','Napastnik'),(129,11,'Lainez Diego','Napastnik'),(130,11,'Lozano Hirving','Napastnik'),(131,19,'ter Stegen Marc-Andre','Bramkarz'),(132,19,'Neuer Manuel','Bramkarz'),(133,19,'Trapp Kevin','Bramkarz'),(134,19,'Ginter Matthias','Obrońca'),(135,19,'Gunter Christian','Obrońca'),(136,19,'Kehrer Thilo','Obrońca'),(137,19,'Klostermann Lukas','Obrońca'),(138,19,'Rudiger Antonio','Obrońca'),(139,19,'Schlotterbeck Nico','Obrońca'),(140,19,'Sule Niklas','Obrońca'),(141,19,'Tah Jonathan','Obrońca'),(142,19,'Draxler Julian','Pomocnik'),(143,19,'Goretzka Leon','Pomocnik'),(144,19,'Gundogan Ilkay','Pomocnik'),(145,19,'Havertz Kai','Pomocnik'),(146,19,'Henrichs Benjamin','Pomocnik'),(147,19,'Hofmann Jonas','Pomocnik'),(148,19,'Kimmich Joshua','Pomocnik'),(149,19,'Musiala Jamal','Pomocnik'),(150,19,'Weigl Julian','Pomocnik'),(151,19,'Adeyemi Karim','Napastnik'),(152,19,'Brandt Julian','Napastnik'),(153,19,'Gnabry Serge','Napastnik'),(154,19,'Muller Thomas','Napastnik'),(155,19,'Werner Timo','Napastnik'),(156,19,'Sane Leroy','Napastnik'),(157,1,'Al Sheeb Saad','Bramkarz'),(158,1,'Barsham Meshaal','Bramkarz'),(159,1,'Mohamed Ali Yousef Hassan','Bramkarz'),(160,1,'Ahmed Homam','Obrońca'),(161,1,'Al-Rawi Bassam Hisham','Obrońca'),(162,1,'Al Hajri Salem','Obrońca'),(163,1,'Assadalla Ali','Obrońca'),(164,1,'Hassan Abdelkarim','Obrońca'),(165,1,'Khoder Musab','Obrońca'),(166,1,'Khoukhi Boualem','Obrońca'),(167,1,'Madibo Assim Omer','Obrońca'),(168,1,'Mohamed Khidir Musaab','Obrońca'),(169,1,'Abdelrahman Fahmi','Pomocnik'),(170,1,'Al Bayati Mohammed','Pomocnik'),(171,1,'Al Hadhrami Naif','Pomocnik'),(172,1,'Al Haydos Hasan','Pomocnik'),(173,1,'Alahrak Abdullah','Pomocnik'),(174,1,'Boudiaf Karim','Pomocnik'),(175,1,'Hatim Abdulaziz','Pomocnik'),(176,1,'Muntari Mohammed','Pomocnik'),(177,1,'Afif Akram','Napastnik'),(178,1,'Ahmed Alaaeldin','Napastnik'),(179,1,'Almoez Ali','Napastnik'),(180,1,'Mazeed Khalid Muneer','Napastnik'),(181,1,'Mohammad Ismaeel','Napastnik'),(182,1,'Shehata Hazem','Napastnik'),(183,12,'Szczęsny Wojciech','Bramkarz'),(184,12,'Grabara Kamil','Bramkarz'),(185,12,'Skorupski Lukasz','Bramkarz'),(186,12,'Bednarek Jan','Obrońca'),(187,12,'Bereszynski Bartosz','Obrońca'),(188,12,'Bielik Krystian','Obrońca'),(189,12,'Cash Matty','Obrońca'),(190,12,'Glik Kamil','Obrońca'),(191,12,'Puchacz Tymoteusz','Obrońca'),(192,12,'Helik Michal','Obrońca'),(193,12,'Kamiński Marcin','Obrońca'),(194,12,'Kiwior Jakub','Obrońca'),(195,12,'Frankowski Przemyslaw','Pomocnik'),(196,12,'Góralski Jacek','Pomocnik'),(197,12,'Żurkowski Szymon','Pomocnik'),(198,12,'Kamiński Jakub','Pomocnik'),(199,12,'Klich Mateusz','Pomocnik'),(200,12,'Krychowiak Grzegorz','Pomocnik'),(201,12,'Zieliński Piotr','Pomocnik'),(202,12,'Szymaśski Sebastian','Pomocnik'),(203,12,'Moder Jakub','Pomocnik'),(204,12,'Zalewski Nicola','Pomocnik'),(205,12,'Lewandowski Robert','Napastnik'),(206,12,'Milik Arkadiusz','Napastnik'),(207,12,'Piątek Krzysztof','Napastnik'),(208,12,'Świderski Karol','Napastnik'),(209,32,'Gu Sung-Yun','Bramkarz'),(210,32,'Jo Hyeon-Woo','Bramkarz'),(211,32,'Kim Dong-Jun','Bramkarz'),(212,32,'Cho Yu-Min','Obrońca'),(213,32,'Choi Ji-Mook','Obrońca'),(214,32,'Hong Chul','Obrońca'),(215,32,'Jung Seung-Hyun','Obrońca'),(216,32,'Kang Sang-Woo','Obrońca'),(217,32,'Kim Jin-Su','Obrońca'),(218,32,'Kim Min-Jae','Obrońca'),(219,32,'Kim Moon-Hwan','Obrońca'),(220,32,'Hwang In-Beom','Pomocnik'),(221,32,'Jeong Woo-Yeong','Pomocnik'),(222,32,'Jung Woo-Young','Pomocnik'),(223,32,'Kim Dong-Hyun','Pomocnik'),(224,32,'Kim Jin-Kyu','Pomocnik'),(225,32,'Kim Tae-Hwan','Pomocnik'),(226,32,'Ko Seung-Beom','Pomocnik'),(227,32,'Kwon Chang-Hoon','Pomocnik'),(228,32,'Son Heung-Min','Napastnik'),(229,32,'Cho Young-Wook','Napastnik'),(230,32,'Eom Ji-Seong','Napastnik'),(231,32,'Hwang Hee-Chan','Napastnik'),(232,32,'Hwang Ui-Jo','Napastnik'),(233,32,'Kim Dae-Won','Napastnik'),(234,32,'Kim Gun-Hee','Napastnik'),(235,18,'Alvarado Esteban','Bramkarz'),(236,18,'Cruz Aaron','Bramkarz'),(237,18,'Moreira Leonel','Bramkarz'),(238,18,'Blanco Ricardo','Obrońca'),(239,18,'Calvo Francisco','Obrońca'),(240,18,'Duarte Oscar','Obrońca'),(241,18,'Fuller Spence Keysher','Obrońca'),(242,18,'Galo Orlando','Obrońca'),(243,18,'Lopez Douglas','Obrońca'),(244,18,'Martinez Carlos','Obrońca'),(245,18,'Mora Carlos','Obrońca'),(246,18,'Aguilera Brandon','Pomocnik'),(247,18,'Bennette Jewison','Pomocnik'),(248,18,'Borges Celso','Pomocnik'),(249,18,'Chacon Salas Daniel','Pomocnik'),(250,18,'Matarrita Ronald','Pomocnik'),(251,18,'Salas Youstin','Pomocnik'),(252,18,'Tejeda Yeltsin','Pomocnik'),(253,18,'Torres Gerson','Pomocnik'),(254,18,'Campbell Joel','Napastnik'),(255,18,'Contreras Anthony','Napastnik'),(256,18,'Martinez Alonso','Napastnik'),(257,18,'Ortiz Jose Guilermo','Napastnik'),(258,18,'Ruiz Bryan','Napastnik'),(259,18,'Suarez Aaron','Napastnik'),(260,18,'Venegas Johan','Napastnik'),(261,29,'Diogo Costa','Bramkarz'),(262,29,'Jose Sa','Bramkarz'),(263,29,'Patricio Rui','Bramkarz'),(264,29,'Cancelo Joao','Obrońca'),(265,29,'Dalot Diogo','Obrońca'),(266,29,'Djalo Tiago','Obrońca'),(267,29,'Duarte Domingos','Obrońca'),(268,29,'Fonte Jose','Obrońca'),(269,29,'Guerreiro Raphael','Obrońca'),(270,29,'Mendes Nuno','Obrońca'),(271,29,'Pepe','Obrońca'),(272,29,'Carvalho William','Pomocnik'),(273,29,'Danilo','Pomocnik'),(274,29,'Fernandes Bruno','Pomocnik'),(275,29,'Moutinho Joao','Pomocnik'),(276,29,'Neves Ruben','Pomocnik'),(277,29,'Nunes Matheus','Pomocnik'),(278,29,'Otavio','Pomocnik'),(279,29,'Palhinha Joao','Pomocnik'),(280,29,'Silva Bernardo','Pomocnik'),(281,29,'Diogo Jota','Napastnik'),(282,29,'Guedes Goncalo','Napastnik'),(283,29,'Horta Ricardo','Napastnik'),(284,29,'Joao Felix','Napastnik'),(285,29,'Leao Rafael','Napastnik'),(286,29,'Ronaldo Cristiano','Napastnik'),(287,3,'Dieng Seny','Bramkarz'),(288,3,'Faty Alioune Badara','Bramkarz'),(289,3,'Gomis Alfred','Bramkarz'),(290,3,'Ballo-Toure Fode','Obrońca'),(291,3,'Ciss Saliou','Obrońca'),(292,3,'Cisse Pape Abou','Obrońca'),(293,3,'Diallo Abdou','Obrońca'),(294,3,'Koulibaly Kalidou','Obrońca'),(295,3,'Mbaye Ibrahima','Obrońca'),(296,3,'Sarr Bouna','Obrońca'),(297,3,'Seck Abdoulaye','Obrońca'),(298,3,'Gueye Idrissa','Pomocnik'),(299,3,'Gueye Pape','Pomocnik'),(300,3,'Kouyate Cheikhou','Pomocnik'),(301,3,'Lopy Joseph','Pomocnik'),(302,3,'Loum Mamadou','Pomocnik'),(303,3,'Mendy Nampalys','Pomocnik'),(304,3,'Name Moustapha','Pomocnik'),(305,3,'Sarr Pape','Pomocnik'),(306,3,'Balde Keita','Napastnik'),(307,3,'Dia Boulaye','Napastnik'),(308,3,'Diallo Habib','Napastnik'),(309,3,'Diedhiou Famara','Napastnik'),(310,3,'Dieng Bamba','Napastnik'),(311,3,'Mane Sadio','Napastnik'),(312,3,'Sarr Ismaila','Napastnik'),(313,26,'Dmitrovic Marko','Bramkarz'),(314,26,'Ilic Marko','Bramkarz'),(315,26,'Milinkovic-Savic Vanja','Bramkarz'),(316,26,'Milenkovic Nikola','Obrońca'),(317,26,'Mitrovic Stefan','Obrońca'),(318,26,'Mladenovic Filip','Obrońca'),(319,26,'Nastasic Matija','Obrońca'),(320,26,'Pavlovic Strahinja','Obrońca'),(321,26,'Ristic Mihailo','Obrońca'),(322,26,'Terzic Aleksa','Obrońca'),(323,26,'Veljkovic Milos','Obrońca'),(324,26,'Djuricic Filip','Pomocnik'),(325,26,'Grujic Marko','Pomocnik'),(326,26,'Gudelj Nemanja','Pomocnik'),(327,26,'Ilic Ivan','Pomocnik'),(328,26,'Lazovic Darko','Pomocnik'),(329,26,'Lukic Sasa','Pomocnik'),(330,26,'Maksimovic Nemanja','Pomocnik'),(331,26,'Milinkovic-Savic Sergej','Pomocnik'),(332,26,'Racic Uros','Pomocnik'),(333,26,'Radonjic Nemanja','Pomocnik'),(334,26,'Zivkovic Andrija','Pomocnik'),(335,26,'Jovic Luka','Napastnik'),(336,26,'Kostic Filip','Napastnik'),(337,26,'Mitrovic Aleksandar','Napastnik'),(338,26,'Tadic Dusan','Napastnik'),(339,7,'Horvath Ethan','Bramkarz'),(340,7,'Johnson Sean','Bramkarz'),(341,7,'Slonina Gabriel','Bramkarz'),(342,7,'Adams Tyler','Obrońca'),(343,7,'Bello George','Obrońca'),(344,7,'Booth Taylor','Obrońca'),(345,7,'Cannon Reggie','Obrońca'),(346,7,'Carter-Vickers Cameron','Obrońca'),(347,7,'Che Justin','Obrońca'),(348,7,'Dest Sergino','Obrońca'),(349,7,'Gomez Jonathan','Obrońca'),(350,7,'Aaronson Brenden','Pomocnik'),(351,7,'Acosta Kellyn','Pomocnik'),(352,7,'Pulisic Christian','Pomocnik'),(353,7,'Reyna Giovanni','Pomocnik'),(354,7,'Clark Caden','Pomocnik'),(355,7,'Johnny','Pomocnik'),(356,7,'Lennon Brooks','Pomocnik'),(357,7,'Lletget Sebastian','Pomocnik'),(358,7,'Arriola Paul','Napastnik'),(359,7,'Cowell Cade','Napastnik'),(360,7,'Weah Timothy','Napastnik'),(361,7,'Morris Jordan','Napastnik'),(362,7,'Zardes Gyasi','Napastnik'),(363,7,'Siebatcheu Jordan','Napastnik'),(364,7,'Tillman Malik','Napastnik'),(365,27,'Kobel Gregor','Bramkarz'),(366,27,'Mvogo Yvon','Bramkarz'),(367,27,'Omlin Jonas','Bramkarz'),(368,27,'Akanji Manuel','Obrońca'),(369,27,'Comert Eray','Obrońca'),(370,27,'Elvedi Nico','Obrońca'),(371,27,'Lotomba Jordan','Obrońca'),(372,27,'Mbabu Kevin','Obrońca'),(373,27,'Rodriguez Ricardo','Obrońca'),(374,27,'Schar Fabian','Obrońca'),(375,27,'Stergiou Leonidas','Obrońca'),(376,27,'Widmer Silvan','Obrońca'),(377,27,'Aebischer Michel','Pomocnik'),(378,27,'Bottani Mattia','Pomocnik'),(379,27,'Frei Fabian','Pomocnik'),(380,27,'Freuler Remo','Pomocnik'),(381,27,'Shaqiri Xherdan','Pomocnik'),(382,27,'Sow Djibril','Pomocnik'),(383,27,'Steffen Renato','Pomocnik'),(384,27,'Vargas Ruben','Pomocnik'),(385,27,'Xhaka Granit','Pomocnik'),(386,27,'Zuber Steven','Pomocnik'),(387,27,'Embolo Breel','Napastnik'),(388,27,'Gavranovic Mario','Napastnik'),(389,27,'Okafor Noah','Napastnik'),(390,27,'Seferovic Haris','Napastnik'),(391,16,'Ben Mustapha Farouk','Bramkarz'),(392,16,'Ben Said Bechir','Bramkarz'),(393,16,'Dahmen Aymen','Bramkarz'),(394,16,'Abdi Ali','Obrońca'),(395,16,'Ben Hamida Mohamed Amine','Obrońca'),(396,16,'Ben Lamin Adam','Obrońca'),(397,16,'Bronn Dylan','Obrońca'),(398,16,'Drager Mohamed','Obrońca'),(399,16,'Ghram Alaa','Obrońca'),(400,16,'Haddadi Oussama','Obrońca'),(401,16,'Ifa Bilel','Obrońca'),(402,16,'Bellamine Adem','Pomocnik'),(403,16,'Ben Larbi Firas','Pomocnik'),(404,16,'Ben Ouanes Mortadha','Pomocnik'),(405,16,'Ben Romdhane Mohamed Ali','Pomocnik'),(406,16,'Bguir Saad','Pomocnik'),(407,16,'Chaaleli Ghaylen','Pomocnik'),(408,16,'Ghandri Nader','Pomocnik'),(409,16,'Khaoui Saif-Eddine','Pomocnik'),(410,16,'Laidouni Aissa','Pomocnik'),(411,16,'Mejbri Hannibal','Pomocnik'),(412,16,'Achouri Elias','Napastnik'),(413,16,'Jaziri Seifeddine','Napastnik'),(414,16,'Jebali Issam','Napastnik'),(415,16,'Khazri Wahbi','Napastnik'),(416,16,'Khenissi Taha','Napastnik'),(417,31,'Campana Martin','Bramkarz'),(418,31,'De Amores Ravelo Guillermo Rafael','Bramkarz'),(419,31,'Muslera Fernando','Bramkarz'),(420,31,'Araujo Ronald','Obrońca'),(421,31,'Cabrera Leandro','Obrońca'),(422,31,'Caceres Martin','Obrońca'),(423,31,'Coates Sebastian','Obrońca'),(424,31,'Gimenez Jose Maria','Obrońca'),(425,31,'Godin Diego','Obrońca'),(426,31,'Olivera Miramontes Mathias','Obrońca'),(427,31,'Arambarri Mauro','Pomocnik'),(428,31,'Bentancur Rodrigo','Pomocnik'),(429,31,'Canobbio Graviz Agustin','Pomocnik'),(430,31,'De Arrascaeta Giorgian','Pomocnik'),(431,31,'De La Cruz Arcosa Diego Nicolas','Pomocnik'),(432,31,'Gorriaran Fontes Fernando','Pomocnik'),(433,31,'Pellistri Facundo','Pomocnik'),(434,31,'Torreira Lucas','Pomocnik'),(435,31,'Ugarte Manuel','Pomocnik'),(436,31,'Valverde Federico','Pomocnik'),(437,31,'Cavani Edinson','Napastnik'),(438,31,'Gomez Maximiliano','Napastnik'),(439,31,'Lopez Nicolas','Napastnik'),(440,31,'Nunez Darwin','Napastnik'),(441,31,'Rossi Diego','Napastnik'),(442,31,'Suarez Luis','Napastnik'),(443,8,'Davies Adam','Bramkarz'),(444,8,'Hennessey Wayne','Bramkarz'),(445,8,'King Tom','Bramkarz'),(446,8,'Ampadu Ethan','Obrońca'),(447,8,'Cabango Benjamin','Obrońca'),(448,8,'Davies Ben','Obrońca'),(449,8,'Denham Oliver','Obrońca'),(450,8,'Gunter Chris','Obrońca'),(451,8,'Mepham Chris','Obrońca'),(452,8,'Norrington-Davies Rhys','Obrońca'),(453,8,'Roberts Connor','Obrońca'),(454,8,'Rodon Joe','Obrońca'),(455,8,'Allen Joe','Pomocnik'),(456,8,'Burns Wes','Pomocnik'),(457,8,'Colwill Rubin','Pomocnik'),(458,8,'James Daniel','Pomocnik'),(459,8,'Levitt Dylan','Pomocnik'),(460,8,'Morrell Joseff','Pomocnik'),(461,8,'Ramsey Aaron','Pomocnik'),(462,8,'Smith Matthew','Pomocnik'),(463,8,'Williams Jonathan','Pomocnik'),(464,8,'Bale Gareth','Napastnik'),(465,8,'Johnson Brennan','Napastnik'),(466,8,'Matondo Rabbi','Napastnik'),(467,8,'Moore Kieffer','Napastnik'),(468,8,'Sorba Thomas','Napastnik'),(469,5,'Forster Fraser','Bramkarz'),(470,5,'Pickford Jordan','Bramkarz'),(471,5,'Pope Nick','Bramkarz'),(472,5,'Alexander-Arnold Trent','Obrońca'),(473,5,'Coady Conor','Obrońca'),(474,5,'Guehi Marc','Obrońca'),(475,5,'James Reece','Obrońca'),(476,5,'Justin James','Obrońca'),(477,5,'Maguire Harry','Obrońca'),(478,5,'Mings Tyrone','Obrońca'),(479,5,'Mitchell Tyrick','Obrońca'),(480,5,'Shaw Luke','Obrońca'),(481,5,'Bellingham Jude','Pomocnik'),(482,5,'Foden Phil','Pomocnik'),(483,5,'Gallagher Conor','Pomocnik'),(484,5,'Grealish Jack','Pomocnik'),(485,5,'Henderson Jordan','Pomocnik'),(486,5,'Mount Mason','Pomocnik'),(487,5,'Phillips Kalvin','Pomocnik'),(488,5,'Rice Declan','Pomocnik'),(489,5,'Saka Bukayo','Pomocnik'),(490,5,'Smith Rowe Emile','Pomocnik'),(491,5,'Abraham Tammy','Napastnik'),(492,5,'Bowen Jarrod','Napastnik'),(493,5,'Kane Harry','Napastnik'),(494,5,'Sterling Raheem','Napastnik'),(495,10,'Al Owais Mohammed','Bramkarz'),(496,10,'Al Qarni Fawaz','Bramkarz'),(497,10,'Al Rubaie Mohammed','Bramkarz'),(498,10,'Abdulhamid Saud','Obrońca'),(499,10,'Al Amri Abdulelah','Obrońca'),(500,10,'Al Bishi Abdulaziz','Obrońca'),(501,10,'Al Burayk Mohammed','Obrońca'),(502,10,'Al Harbi Moteb','Obrońca'),(503,10,'Al Khaibri Abdulmalek Abdullah','Obrońca'),(504,10,'Al Sahafi Ziyad','Obrońca'),(505,10,'Al Shahrani Yasser','Obrońca'),(506,10,'Al Tambakti Hassan Mohammed','Obrońca'),(507,10,'Alawjami Ali','Obrońca'),(508,10,'Al-Najei Sami','Pomocnik'),(509,10,'Al Dawsari Nasser','Pomocnik'),(510,10,'Al Dawsari Salem','Pomocnik'),(511,10,'Al Faraj Salman','Pomocnik'),(512,10,'Al Ghanam Sultan Abdullah','Pomocnik'),(513,10,'Al Hassan Ali','Pomocnik'),(514,10,'Al Khaibari Abdullah','Pomocnik'),(515,10,'Al Malki Abdulelah','Pomocnik'),(516,10,'Abdulrahman Al Obod','Napastnik'),(517,10,'Al Buraikan Firas','Napastnik'),(518,10,'Al Ghannam Khalid','Napastnik'),(519,10,'Al Hamdan Abdullah','Napastnik'),(520,10,'Al Muwallad Al Harbi Fahad Mosaed','Napastnik'),(521,9,'Armani Franco','Bramkarz'),(522,9,'Martinez Emiliano','Bramkarz'),(523,9,'Musso Juan','Bramkarz'),(524,9,'Acuna Marcos','Obrońca'),(525,9,'Foyth Juan','Obrońca'),(526,9,'Martinez Lisandro','Obrońca'),(527,9,'Martinez Quarta Lucas','Obrońca'),(528,9,'Molina Nahuel','Obrońca'),(529,9,'Montiel Gonzalo','Obrońca'),(530,9,'Otamendi Nicolas','Obrońca'),(531,9,'Pezzella German','Obrońca'),(532,9,'de Paul Rodrigo','Pomocnik'),(533,9,'Correa Angel','Pomocnik'),(534,9,'Correa Joaquin','Pomocnik'),(535,9,'Di Maria Angel','Pomocnik'),(536,9,'Rodriguez Guido','Pomocnik'),(537,9,'Lo Celso Giovani','Pomocnik'),(538,9,'Papu Gomez','Pomocnik'),(539,9,'Palacios Exequiel','Pomocnik'),(540,9,'Paredes Leandro','Pomocnik'),(541,9,'Alvarez Julian','Napastnik'),(542,9,'Dybala Paulo','Napastnik'),(543,9,'Gonzalez Nicolas','Napastnik'),(544,9,'Martinez Lautaro','Napastnik'),(545,9,'Messi Lionel','Napastnik'),(546,9,'Ocampos Lucas','Napastnik'),(547,14,'Redmayne Andrew','Bramkarz'),(548,14,'Ryan Mathew','Bramkarz'),(549,14,'Vukovic Danny','Bramkarz'),(550,14,'Atkinson Nathaniel','Obrońca'),(551,14,'Behich Aziz','Obrońca'),(552,14,'Genreau Denis','Obrońca'),(553,14,'Grant Rhyan','Obrońca'),(554,14,'Karacic Fran','Obrońca'),(555,14,'King Joel','Obrońca'),(556,14,'McGowan Ryan','Obrońca'),(557,14,'Rowles Kye','Obrońca'),(558,14,'Sainsbury Trent','Obrońca'),(559,14,'Degenek Milos','Pomocnik'),(560,14,'Dougall Kenneth','Pomocnik'),(561,14,'Hrustic Ajdin','Pomocnik'),(562,14,'Irvine Jackson','Pomocnik'),(563,14,'Jeggo James','Pomocnik'),(564,14,'Mabil Awer','Pomocnik'),(565,14,'McGree Riley','Pomocnik'),(566,14,'Mooy Aaron','Pomocnik'),(567,14,'Rogic Tom','Pomocnik'),(568,14,'Borrello Brandon','Napastnik'),(569,14,'Boyle Martin','Napastnik'),(570,14,'D\'Agostino Nicholas','Napastnik'),(571,14,'Duke Mitchell','Napastnik'),(572,14,'Fornaroli Bruno','Napastnik'),(573,21,'Casteels Koen','Bramkarz'),(574,21,'Kaminski Thomas','Bramkarz'),(575,21,'Mignolet Simon','Bramkarz'),(576,21,'Alderweireld Toby','Obrońca'),(577,21,'Vertonghen Jan','Obrońca'),(578,21,'Boyata Dedryck','Obrońca'),(579,21,'Castagne Timothy','Obrońca'),(580,21,'Denayer Jason','Obrońca'),(581,21,'Meunier Thomas','Obrońca'),(582,21,'Foket Thomas','Obrońca'),(583,21,'Mechele Brandon','Obrońca'),(584,21,'De Bruyne Kevin','Pomocnik'),(585,21,'De Ketelaere Charles','Pomocnik'),(586,21,'Dendoncker Leander','Pomocnik'),(587,21,'Hazard Thorgan','Pomocnik'),(588,21,'Januzaj Adnan','Pomocnik'),(589,21,'Vanaken Hans','Pomocnik'),(590,21,'Witsel Axel','Pomocnik'),(591,21,'Praet Dennis','Pomocnik'),(592,21,'Trossard Leandro','Pomocnik'),(593,21,'Batshuayi Michy','Napastnik'),(594,21,'Carrasco Yannick','Napastnik'),(595,21,'Hazard Eden','Napastnik'),(596,21,'Lukaku Romelu','Napastnik'),(597,21,'Mertens Dries','Napastnik'),(598,21,'Openda Lois','Napastnik'),(599,25,'Alisson','Bramkarz'),(600,25,'Ederson','Bramkarz'),(601,25,'Everson','Bramkarz'),(602,25,'Alex Sandro','Obrońca'),(603,25,'Dani Alves','Obrońca'),(604,25,'Danilo','Obrońca'),(605,25,'Emerson Royal','Obrońca'),(606,25,'Felipe','Obrońca'),(607,25,'Telles Alex','Obrońca'),(608,25,'Militao Eder','Obrońca'),(609,25,'Silva Thiago','Obrońca'),(610,25,'Marquinhos','Obrońca'),(611,25,'Lucas Paqueta','Pomocnik'),(612,25,'Casemiro','Pomocnik'),(613,25,'Coutinho Philippe','Pomocnik'),(614,25,'Everton Ribeiro','Pomocnik'),(615,25,'Fabinho','Pomocnik'),(616,25,'Fred','Pomocnik'),(617,25,'Guimaraes Bruno','Pomocnik'),(618,25,'Antony','Napastnik'),(619,25,'Rodrygo','Napastnik'),(620,25,'Jesus Gabriel','Napastnik'),(621,25,'Vinicius Junior','Napastnik'),(622,25,'Matheus Cunha','Napastnik'),(623,25,'Neymar','Napastnik'),(624,25,'Raphinha','Napastnik'),(625,24,'Grbic Ivo','Bramkarz'),(626,24,'Ivusic Ivica','Bramkarz'),(627,24,'Livakovic Dominik','Bramkarz'),(628,24,'Vrsaljko Sime','Obrońca'),(629,24,'Vida Domagoj','Obrońca'),(630,24,'Gvardiol Josko','Obrońca'),(631,24,'Juranovic Josip','Obrońca'),(632,24,'Pongracic Marin','Obrońca'),(633,24,'Skoric Mile','Obrońca'),(634,24,'Sosa Borna','Obrońca'),(635,24,'Stanisic Josip','Obrońca'),(636,24,'Brozovic Marcelo','Pomocnik'),(637,24,'Ivanusec Luka','Pomocnik'),(638,24,'Jakic Kristijan','Pomocnik'),(639,24,'Kovacic Mateo','Pomocnik'),(640,24,'Majer Lovro','Pomocnik'),(641,24,'Modric Luka','Pomocnik'),(642,24,'Moro Nikola','Pomocnik'),(643,24,'Pasalic Mario','Pomocnik'),(644,24,'Sucic Luka','Pomocnik'),(645,24,'Brekalo Josip','Napastnik'),(646,24,'Budimir Ante','Napastnik'),(647,24,'Kramaric Andrej','Napastnik'),(648,24,'Livaja Marko','Napastnik'),(649,24,'Orsic Mislav','Napastnik'),(650,24,'Perisic Ivan','Napastnik'),(651,15,'Iversen Daniel','Bramkarz'),(652,15,'Ronnow Frederik','Bramkarz'),(653,15,'Schmeichel Kasper','Bramkarz'),(654,15,'Andersen Joachim','Obrońca'),(655,15,'Bah Alexander','Obrońca'),(656,15,'Boilesen Nicolai','Obrońca'),(657,15,'Christensen Andreas','Obrońca'),(658,15,'Kristensen Rasmus','Obrońca'),(659,15,'Maehle Joakim','Obrońca'),(660,15,'Wass Daniel','Obrońca'),(661,15,'Vestergaard Jannikr','Obrońca'),(662,15,'Pedersen Mads','Obrońca'),(663,15,'Billing Philip','Pomocnik'),(664,15,'Bruun Larsen Jacob','Pomocnik'),(665,15,'Damsgaard Mikkel','Pomocnik'),(666,15,'Delaney Thomas','Pomocnik'),(667,15,'Eriksen Christian','Pomocnik'),(668,15,'Hojbjerg Pierre-Emile','Pomocnik'),(669,15,'Jensen Mathias','Pomocnik'),(670,15,'Lindstrom Jesper','Pomocnik'),(671,15,'Braithwaite Martin','Napastnik'),(672,15,'Cornelius Andreas','Napastnik'),(673,15,'Dolberg Kasper','Napastnik'),(674,15,'Poulsen Yussuf','Napastnik'),(675,15,'Skov Robert','Napastnik'),(676,15,'Wind Jonas','Napastnik'),(677,2,'Dominguez Alexander','Bramkarz'),(678,2,'Galindez Hernan','Bramkarz'),(679,2,'Ortiz Pedro','Bramkarz'),(680,2,'Arboleda Robert','Obrońca'),(681,2,'Arreaga Xavier','Obrońca'),(682,2,'Caicedo Ante Romario Javier','Obrońca'),(683,2,'Castillo Segura Byron David','Obrońca'),(684,2,'Corozo Alman Janner Hitcler','Obrońca'),(685,2,'Estupinan Pervis','Obrońca'),(686,2,'Hincapie Piero','Obrońca'),(687,2,'Leon Fernando','Obrońca'),(688,2,'Arroyo Dixon','Pomocnik'),(689,2,'Caicedo Moises','Pomocnik'),(690,2,'Carcelen Carabali Michael Alexander','Pomocnik'),(691,2,'Cifuentes Charcopa Jose Adoni','Pomocnik'),(692,2,'Franco Alan','Pomocnik'),(693,2,'Gruezo Carlos','Pomocnik'),(694,2,'Ibarra Mina Romario Andres','Pomocnik'),(695,2,'Mena Angel','Pomocnik'),(696,2,'Mendez Jhegson','Pomocnik'),(697,2,'Caicedo Jordy','Napastnik'),(698,2,'Valencia Enner','Napastnik'),(699,2,'Estrada Michael','Napastnik'),(700,2,'Plata Gonzalo','Napastnik'),(701,2,'Preciado Eduar','Napastnik'),(702,2,'Reascos Djorkaeff','Napastnik'),(703,13,'Areola Alphonse','Bramkarz'),(704,13,'Lloris Hugo','Bramkarz'),(705,13,'Maignan Mike','Bramkarz'),(706,13,'Clauss Jonathan','Obrońca'),(707,13,'Digne Lucas','Obrońca'),(708,13,'Hernandez Lucas','Obrońca'),(709,13,'Hernandez Theo','Obrońca'),(710,13,'Kimpembe Presnel','Obrońca'),(711,13,'Kounde Jules','Obrońca'),(712,13,'Pavard Benjamin','Obrońca'),(713,13,'Saliba William','Obrońca'),(714,13,'Varane Raphael','Obrońca'),(715,13,'Guendouzi Matteo','Pomocnik'),(716,13,'Kante N\'Golo','Pomocnik'),(717,13,'Nkunku Christopher','Pomocnik'),(718,13,'Pogba Paul','Pomocnik'),(719,13,'Rabiot Adrien','Pomocnik'),(720,13,'Tchouameni Aurelien','Pomocnik'),(721,13,'Thuram Marcus','Pomocnik'),(722,13,'Ben Yedder Wissam','Napastnik'),(723,13,'Benzema Karim','Napastnik'),(724,13,'Coman Kingsley','Napastnik'),(725,13,'Diaby Moussa','Napastnik'),(726,13,'Giroud Olivier','Napastnik'),(727,13,'Griezmann Antoine','Napastnik'),(728,13,'Mbappe Kylian','Napastnik'),(729,30,'Attah Richard','Bramkarz'),(730,30,'Nurudeen Abdul','Bramkarz'),(731,30,'Ofori Richard','Bramkarz'),(732,30,'Amartey Daniel','Obrońca'),(733,30,'Baba Abdul-Rahman','Obrońca'),(734,30,'Baffour Philomon','Obrońca'),(735,30,'Djiku Alexander','Obrońca'),(736,30,'Kamaheni Montari','Obrońca'),(737,30,'Korsah-Akoumah Dennis','Obrońca'),(738,30,'Mensah Gideon','Obrońca'),(739,30,'Mensah Jonathan','Obrońca'),(740,30,'Partey Thomas','Pomocnik'),(741,30,'Addo Edmund','Pomocnik'),(742,30,'Antweer Christopher','Pomocnik'),(743,30,'Baba Mohammed Iddrisu','Pomocnik'),(744,30,'Fatawu Abdul','Pomocnik'),(745,30,'Kudus Mohammed','Pomocnik'),(746,30,'Kyereh Daniel-Kofi','Pomocnik'),(747,30,'Owusu Elisha','Pomocnik'),(748,30,'Afena-Gyan Felix','Napastnik'),(749,30,'Afriyie Daniel','Napastnik'),(750,30,'Antwi-Adjei Christopher','Napastnik'),(751,30,'Ayew Andre','Napastnik'),(752,30,'Ayew Jordan','Napastnik'),(753,30,'Barnier Daniel','Napastnik'),(754,30,'Boakye Richmond','Napastnik'),(755,17,'de Gea David','Bramkarz'),(756,17,'Sanchez Robert','Bramkarz'),(757,17,'Simon Unai','Bramkarz'),(758,17,'Alba Jordi','Obrońca'),(759,17,'Alonso Marcos','Obrońca'),(760,17,'Azpilicueta Cesar','Obrońca'),(761,17,'Carvajal Daniel','Obrońca'),(762,17,'Garcia Eric','Obrońca'),(763,17,'Guillamon Hugo','Obrońca'),(764,17,'Laporte Aymeric','Obrońca'),(765,17,'Llorente Diego','Obrońca'),(766,17,'Martinez Inigo','Obrońca'),(767,17,'Torres Pau','Obrońca'),(768,17,'Gavi','Pomocnik'),(769,17,'Koke','Pomocnik'),(770,17,'Llorente Marcos','Pomocnik'),(771,17,'Olmo Dani','Pomocnik'),(772,17,'Pedri','Pomocnik'),(773,17,'Rodri','Pomocnik'),(774,17,'Sarabia Pablo','Pomocnik'),(775,17,'Soler Carlos','Pomocnik'),(776,17,'Fati Ansu','Pomocnik'),(777,17,'Morata Alvaro','Napastnik'),(778,17,'Torres Ferran','Napastnik'),(779,17,'de Tomas Raul','Napastnik'),(780,17,'Asensio Marco','Napastnik'),(781,4,'Cillessen Jasper','Bramkarz'),(782,4,'Drommel Joel','Bramkarz'),(783,4,'Flekken Mark','Bramkarz'),(784,4,'Ake Nathan','Obrońca'),(785,4,'Dumfries Denzel','Obrońca'),(786,4,'Hateboer Hans','Obrońca'),(787,4,'Malacia Tyrell','Obrońca'),(788,4,'Martins Indi Bruno','Obrońca'),(789,4,'van Dijk Virgil','Obrońca'),(790,4,'Timber Jurrien','Obrońca'),(791,4,'de Vrij Stefan','Obrońca'),(792,4,'de Ligt Matthijs','Obrońca'),(793,4,'Berghuis Steven','Pomocnik'),(794,4,'Bergwijn Steven','Pomocnik'),(795,4,'Blind Daley','Pomocnik'),(796,4,'de Jong Frenkie','Pomocnik'),(797,4,'Klaassen Davy','Pomocnik'),(798,4,'Koopmeiners Teun','Pomocnik'),(799,4,'Wijnaldum Georginio','Pomocnik'),(800,4,'de Roon Marten','Pomocnik'),(801,4,'Danjuma Arnaut','Napastnik'),(802,4,'Depay Memphis','Napastnik'),(803,4,'Gakpo Cody','Napastnik'),(804,4,'Weghorst Wout','Napastnik'),(805,4,'Lang Noa','Napastnik'),(806,4,'Malen Donyell','Napastnik'),(807,6,'Abedzadeh Amir','Bramkarz'),(808,6,'Akhbari Mohammadreza','Bramkarz'),(809,6,'Beiranvand Alireza','Bramkarz'),(810,6,'Esmaeilifar Danial','Obrońca'),(811,6,'Faraji Farshad','Obrońca'),(812,6,'Gholami Aref','Obrońca'),(813,6,'Hardani Saleh','Obrońca'),(814,6,'Hosseini Majid','Obrońca'),(815,6,'Jalali Abolfazl','Obrońca'),(816,6,'Kanaani Hossein','Obrońca'),(817,6,'Khalilzadeh Shoja','Obrońca'),(818,6,'Aghasi Kolahsorkhi Aaref','Pomocnik'),(819,6,'Amiri Vahid','Pomocnik'),(820,6,'Ebrahimi Omid','Pomocnik'),(821,6,'Ezatolahi Saeid','Pomocnik'),(822,6,'Ghoddos Saman','Pomocnik'),(823,6,'Gholizadeh Ali','Pomocnik'),(824,6,'Hajsafi Ehsan','Pomocnik'),(825,6,'Hosseinzadeh Amirhossein','Pomocnik'),(826,6,'Kamyabinia Kamaleddin','Pomocnik'),(827,6,'Mehdipour Mehdi','Pomocnik'),(828,6,'Alipour Ali','Napastnik'),(829,6,'Ansarifard Karim','Napastnik'),(830,6,'Azmoun Sardar','Napastnik'),(831,6,'Hashemian Vahid','Napastnik'),(832,6,'Jahanbakhsh Alireza','Napastnik');
/*!40000 ALTER TABLE `player` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `single_group`
--

DROP TABLE IF EXISTS `single_group`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `single_group` (
  `id_group` int unsigned NOT NULL AUTO_INCREMENT,
  `id_first_pl_team` int unsigned DEFAULT '1',
  `id_second_pl_team` int unsigned DEFAULT '2',
  `id_tournament` int unsigned NOT NULL,
  `letter` enum('A','B','C','D','E','F','G','H') NOT NULL,
  PRIMARY KEY (`id_group`),
  KEY `fk_group_fteam` (`id_first_pl_team`),
  KEY `fk_group_steam` (`id_second_pl_team`),
  KEY `fk_group_tournament` (`id_tournament`),
  CONSTRAINT `fk_group_fteam` FOREIGN KEY (`id_first_pl_team`) REFERENCES `team` (`id_team`),
  CONSTRAINT `fk_group_steam` FOREIGN KEY (`id_second_pl_team`) REFERENCES `team` (`id_team`),
  CONSTRAINT `fk_group_tournament` FOREIGN KEY (`id_tournament`) REFERENCES `tournament` (`id_tournament`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `single_group`
--

LOCK TABLES `single_group` WRITE;
/*!40000 ALTER TABLE `single_group` DISABLE KEYS */;
INSERT INTO `single_group` VALUES (1,1,2,1,'A'),(2,1,2,1,'B'),(3,1,2,1,'C'),(4,1,2,1,'D'),(5,1,2,1,'E'),(6,1,2,1,'F'),(7,1,2,1,'G'),(8,1,2,1,'H');
/*!40000 ALTER TABLE `single_group` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `single_match`
--

DROP TABLE IF EXISTS `single_match`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `single_match` (
  `id_match` int unsigned NOT NULL AUTO_INCREMENT,
  `id_first_team` int unsigned DEFAULT NULL,
  `id_second_team` int unsigned DEFAULT NULL,
  `id_tournament` int unsigned NOT NULL,
  `abbr_first` varchar(3) DEFAULT NULL,
  `abbr_second` varchar(3) DEFAULT NULL,
  `name_first` varchar(35) DEFAULT NULL,
  `name_second` varchar(35) DEFAULT NULL,
  `match_code` int unsigned NOT NULL,
  `goals_first_team` int DEFAULT NULL,
  `goals_second_team` int DEFAULT NULL,
  PRIMARY KEY (`id_match`),
  KEY `fk_match_fteam` (`id_first_team`),
  KEY `fk_match_steam` (`id_second_team`),
  KEY `fk_match_tournament` (`id_tournament`),
  CONSTRAINT `fk_match_fteam` FOREIGN KEY (`id_first_team`) REFERENCES `team` (`id_team`),
  CONSTRAINT `fk_match_steam` FOREIGN KEY (`id_second_team`) REFERENCES `team` (`id_team`),
  CONSTRAINT `fk_match_tournament` FOREIGN KEY (`id_tournament`) REFERENCES `tournament` (`id_tournament`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `single_match`
--

LOCK TABLES `single_match` WRITE;
/*!40000 ALTER TABLE `single_match` DISABLE KEYS */;
/*!40000 ALTER TABLE `single_match` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `team`
--

DROP TABLE IF EXISTS `team`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `team` (
  `id_team` int unsigned NOT NULL AUTO_INCREMENT,
  `id_group` int unsigned NOT NULL,
  `name` varchar(35) NOT NULL,
  `short_name` varchar(3) NOT NULL,
  `coach` varchar(30) NOT NULL,
  `def_factor` float NOT NULL,
  `att_factor` float NOT NULL,
  PRIMARY KEY (`id_team`),
  KEY `fk_team_group` (`id_group`),
  CONSTRAINT `fk_team_group` FOREIGN KEY (`id_group`) REFERENCES `single_group` (`id_group`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `team`
--

LOCK TABLES `team` WRITE;
/*!40000 ALTER TABLE `team` DISABLE KEYS */;
INSERT INTO `team` VALUES (1,1,'Katar','QAT','Félix Sánchez Bas',0.5,0.5),(2,1,'Ekwador','ECU','Gustavo Alfaro',0.5,0.5),(3,1,'Senegal','SEN','Aliou Cissé',0.5,0.5),(4,1,'Holandia','NED','Louis van Gaal',0.5,0.5),(5,2,'Anglia','ENG','Gareth Southgate',0.5,0.5),(6,2,'Iran','IRN','Dragan Skočić',0.5,0.5),(7,2,'Stany Zjednoczone','USA','Gregg Berhalter',0.5,0.5),(8,2,'Walia','WAL','Robert Page',0.5,0.5),(9,3,'Argentyna','ARG','Lionel Scaloni',0.5,0.5),(10,3,'Arabia Saudyjska','KSA','Hervé Renard',0.5,0.5),(11,3,'Meksyk','MEX','Gerardo Martino',0.5,0.5),(12,3,'Polska','POL','Czesław Michniewicz',0.5,0.5),(13,4,'Francja','FRA','Didier Deschamps',0.5,0.5),(14,4,'Australia','AUS','Graham Arnold',0.5,0.5),(15,4,'Dania','DEN','Kasper Hjulmand',0.5,0.5),(16,4,'Tunezja','TUN','Mondher Kebaier',0.5,0.5),(17,5,'Hiszpania','ESP','Luis Enrique',0.5,0.5),(18,5,'Kostaryka','CRC','Luis Fernando Suárez',0.5,0.5),(19,5,'Niemcy','GER','Hans-Dieter Flick',0.5,0.5),(20,5,'Japonia','JPN','Hajime Moriyasu',0.5,0.5),(21,6,'Belgia','BEL','Roberto Martínez',0.5,0.5),(22,6,'Kanada','CAN','John Herdman',0.5,0.5),(23,6,'Maroko','MAR','Vahid Halilhodžić',0.5,0.5),(24,6,'Chorwacja','CRO','Zlatko Dalić',0.5,0.5),(25,7,'Brazylia','BRA','Tite',0.5,0.5),(26,7,'Serbia','SRB','Dragan Stojković',0.5,0.5),(27,7,'Szwajcaria','SUI','Murat Yakın',0.5,0.5),(28,7,'Kamerun','CMR','Rigobert Song',0.5,0.5),(29,8,'Portugalia','POR','Fernando Santos',0.5,0.5),(30,8,'Ghana','GHA','Otto Addo',0.5,0.5),(31,8,'Urugwaj','URU','Diego Alonso',0.5,0.5),(32,8,'Korea Południowa','KOR','Paulo Bento',0.5,0.5);
/*!40000 ALTER TABLE `team` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tournament`
--

DROP TABLE IF EXISTS `tournament`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tournament` (
  `id_tournament` int unsigned NOT NULL AUTO_INCREMENT,
  `id_user` int unsigned NOT NULL,
  `t_name` varchar(30) DEFAULT 'tournament_1',
  PRIMARY KEY (`id_tournament`),
  KEY `fk_tournament_user` (`id_user`),
  CONSTRAINT `fk_tournament_user` FOREIGN KEY (`id_user`) REFERENCES `user` (`id_user`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tournament`
--

LOCK TABLES `tournament` WRITE;
/*!40000 ALTER TABLE `tournament` DISABLE KEYS */;
INSERT INTO `tournament` VALUES (1,1,'tournament_1');
/*!40000 ALTER TABLE `tournament` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `id_user` int unsigned NOT NULL AUTO_INCREMENT,
  `login` varchar(16) NOT NULL,
  `password` binary(32) NOT NULL,
  `creation_date` datetime NOT NULL,
  `last_log_date` datetime NOT NULL,
  `security_question` varchar(64) NOT NULL,
  `security_answer` binary(32) NOT NULL,
  PRIMARY KEY (`id_user`),
  UNIQUE KEY `login` (`login`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'admin',_binary 'PJ��U�H��)�4⣳4\�G\�|w>��>܎','2022-06-15 21:47:06','2022-06-17 10:48:45','Jak ma na nazwisko najlepszy napastnik?',_binary '���\�Z>iW\n�\�� \Z\0\�-V\�Q\�^\�F�矮');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-06-17 11:22:40
