-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: scheta
-- ------------------------------------------------------
-- Server version	8.0.42

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `ci`
--

/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ci` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Summa` int NOT NULL,
  `DohRash` int NOT NULL,
  `Balans` int NOT NULL,
  `Den` int NOT NULL,
  `Mes` int NOT NULL,
  `God` int NOT NULL,
  `Primechanie` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ci`
--

LOCK TABLES `ci` WRITE;
/*!40000 ALTER TABLE `ci` DISABLE KEYS */;
INSERT INTO `ci` VALUES (1,0,1,0,12,8,2025,'Открытие счёта Центр-Инвест');
INSERT INTO `ci` VALUES (2,4000,1,4000,14,8,2025,'Зачисление стипендии');
INSERT INTO `ci` VALUES (3,-500,2,3500,14,8,2025,'Покупка канцтоваров');
INSERT INTO `ci` VALUES (7,-1000,2,2500,23,8,2025,'Перевод на счёт в ВТБ');
/*!40000 ALTER TABLE `ci` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `doh`
--

/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `doh` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Oper` varchar(7) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `doh`
--

LOCK TABLES `doh` WRITE;
/*!40000 ALTER TABLE `doh` DISABLE KEYS */;
INSERT INTO `doh` VALUES (1,'Доход');
INSERT INTO `doh` VALUES (2,'Расход');
/*!40000 ALTER TABLE `doh` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mesac`
--

/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mesac` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Nazv` varchar(9) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mesac`
--

LOCK TABLES `mesac` WRITE;
/*!40000 ALTER TABLE `mesac` DISABLE KEYS */;
INSERT INTO `mesac` VALUES (1,'Январь');
INSERT INTO `mesac` VALUES (2,'Февраль');
INSERT INTO `mesac` VALUES (3,'Март');
INSERT INTO `mesac` VALUES (4,'Апрель');
INSERT INTO `mesac` VALUES (5,'Май');
INSERT INTO `mesac` VALUES (6,'Июнь');
INSERT INTO `mesac` VALUES (7,'Июль');
INSERT INTO `mesac` VALUES (8,'Август');
INSERT INTO `mesac` VALUES (9,'Сентябрь');
INSERT INTO `mesac` VALUES (10,'Октябрь');
INSERT INTO `mesac` VALUES (11,'Ноябрь');
INSERT INTO `mesac` VALUES (12,'Декабрь');
/*!40000 ALTER TABLE `mesac` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `prci`
--

SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `prci` AS SELECT 
 1 AS `ID`,
 1 AS `Summa`,
 1 AS `Oper`,
 1 AS `Balans`,
 1 AS `Den`,
 1 AS `Nazv`,
 1 AS `God`,
 1 AS `Primechanie`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `prsber`
--

SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `prsber` AS SELECT 
 1 AS `ID`,
 1 AS `Summa`,
 1 AS `Oper`,
 1 AS `Balans`,
 1 AS `Den`,
 1 AS `Nazv`,
 1 AS `God`,
 1 AS `Primechanie`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `prvtb`
--

SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `prvtb` AS SELECT 
 1 AS `ID`,
 1 AS `Summa`,
 1 AS `Oper`,
 1 AS `Balans`,
 1 AS `Den`,
 1 AS `Nazv`,
 1 AS `God`,
 1 AS `Primechanie`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `sber`
--

/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sber` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Summa` int NOT NULL,
  `DohRash` int NOT NULL,
  `Balans` int NOT NULL,
  `Den` int NOT NULL,
  `Mes` int NOT NULL,
  `God` int NOT NULL,
  `Primechanie` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sber`
--

LOCK TABLES `sber` WRITE;
/*!40000 ALTER TABLE `sber` DISABLE KEYS */;
INSERT INTO `sber` VALUES (1,0,1,0,13,8,2025,'Открытие Сбер счёта');
INSERT INTO `sber` VALUES (2,3000,1,3000,14,8,2025,'Пополнение счёта');
INSERT INTO `sber` VALUES (3,-225,2,2775,14,8,2025,'Пкупка в Магните');
/*!40000 ALTER TABLE `sber` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vtb`
--

/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vtb` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Summa` int NOT NULL,
  `DohRash` int NOT NULL,
  `Balans` int NOT NULL,
  `Den` int NOT NULL,
  `Mes` int NOT NULL,
  `God` int NOT NULL,
  `Primechanie` text NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vtb`
--

LOCK TABLES `vtb` WRITE;
/*!40000 ALTER TABLE `vtb` DISABLE KEYS */;
INSERT INTO `vtb` VALUES (1,0,1,0,11,8,2025,'Открытие ВТБ счёта');
INSERT INTO `vtb` VALUES (2,5000,1,5000,14,8,2025,'Пополнение счёта');
INSERT INTO `vtb` VALUES (3,-325,2,4675,14,8,2025,'Покупка на Ozon');
INSERT INTO `vtb` VALUES (10,1000,1,5675,23,8,2025,'Перевод со счёта Центр - Инвест');
/*!40000 ALTER TABLE `vtb` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'scheta'
--

--
-- Final view structure for view `prci`
--

/*!50001 DROP VIEW IF EXISTS `prci`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `prci` AS select `c`.`ID` AS `ID`,`c`.`Summa` AS `Summa`,`d`.`Oper` AS `Oper`,`c`.`Balans` AS `Balans`,`c`.`Den` AS `Den`,`m`.`Nazv` AS `Nazv`,`c`.`God` AS `God`,`c`.`Primechanie` AS `Primechanie` from ((`ci` `c` left join `doh` `d` on((`c`.`DohRash` = `d`.`ID`))) left join `mesac` `m` on((`c`.`Mes` = `m`.`ID`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `prsber`
--

/*!50001 DROP VIEW IF EXISTS `prsber`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `prsber` AS select `s`.`ID` AS `ID`,`s`.`Summa` AS `Summa`,`d`.`Oper` AS `Oper`,`s`.`Balans` AS `Balans`,`s`.`Den` AS `Den`,`m`.`Nazv` AS `Nazv`,`s`.`God` AS `God`,`s`.`Primechanie` AS `Primechanie` from ((`sber` `s` left join `doh` `d` on((`s`.`DohRash` = `d`.`ID`))) left join `mesac` `m` on((`s`.`Mes` = `m`.`ID`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `prvtb`
--

/*!50001 DROP VIEW IF EXISTS `prvtb`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `prvtb` AS select `v`.`ID` AS `ID`,`v`.`Summa` AS `Summa`,`d`.`Oper` AS `Oper`,`v`.`Balans` AS `Balans`,`v`.`Den` AS `Den`,`m`.`Nazv` AS `Nazv`,`v`.`God` AS `God`,`v`.`Primechanie` AS `Primechanie` from ((`vtb` `v` left join `doh` `d` on((`v`.`DohRash` = `d`.`ID`))) left join `mesac` `m` on((`v`.`Mes` = `m`.`ID`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-08-23 13:33:06
