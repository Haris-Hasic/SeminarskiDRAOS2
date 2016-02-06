-- phpMyAdmin SQL Dump
-- version 3.5.1
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Feb 06, 2016 at 01:10 PM
-- Server version: 5.5.24-log
-- PHP Version: 5.3.13

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `draosbaza`
--

-- --------------------------------------------------------

--
-- Table structure for table `obicnopitanje`
--

CREATE TABLE IF NOT EXISTS `obicnopitanje` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nivo` int(11) NOT NULL,
  `tekst` varchar(500) CHARACTER SET utf8 NOT NULL,
  `tacanodgovor` varchar(100) CHARACTER SET utf8 NOT NULL,
  `odgovor1` varchar(100) CHARACTER SET utf8 NOT NULL,
  `odgovor2` varchar(100) CHARACTER SET utf8 NOT NULL,
  `odgovor3` varchar(100) CHARACTER SET utf8 NOT NULL,
  `kreiran` date NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_slovenian_ci AUTO_INCREMENT=17 ;

--
-- Dumping data for table `obicnopitanje`
--

INSERT INTO `obicnopitanje` (`id`, `nivo`, `tekst`, `tacanodgovor`, `odgovor1`, `odgovor2`, `odgovor3`, `kreiran`) VALUES
(1, 0, 'おはようございます', 'Good morning.', 'Good evening.', 'Goodbye.', 'Good afternoon.', '2016-02-04'),
(2, 0, 'こんにちは', 'Good afternoon', 'Good evening', 'Good morning', 'Goodbye', '2016-02-06'),
(3, 0, 'こんばんは', 'Good evening', 'Good afternoon', 'Good morning', 'Goodbye', '2016-02-06'),
(4, 0, 'さようなら', 'Goodbye', 'Good morning', 'Good afternoon', 'Welcome home', '2016-02-06'),
(5, 0, 'おやすみなさい', 'Good night', 'Good morning', 'Good afternoon.', 'I am home', '2016-02-06'),
(6, 0, 'ありがとう ございます', 'Thank you', 'Welcome to our store', 'Hello', 'Nice to meet you', '2016-02-06'),
(7, 0, 'すみません', 'Excuse me', 'Thank you', 'No, not at all', 'I''m home', '2016-02-06'),
(8, 0, 'いいえ', 'No, not at all', 'Thank you', 'Goodbye', 'Excuse me', '2016-02-06'),
(9, 0, 'いってきます', 'I''ll go and come back', 'Please go and come back', 'I''m home', 'Welcome home', '2016-02-06'),
(10, 0, 'いってらっしゃい', 'Please go and come back', 'I''ll go and come back', 'I''m home', 'Welcome home', '2016-02-06'),
(11, 0, 'ただいま', 'I''m home', 'Welcome home', 'I''ll go and come back', 'Good evening', '2016-02-06'),
(12, 0, 'おかえりなさい', 'Welcome home', 'I''ll go and come back', 'I''m home', 'Good night', '2016-02-06'),
(13, 0, 'いただきます', 'Thank you for the meal (before eating)', 'Thank you for the meal (after eating)', 'Please go and come back', 'I''ll go and come back', '2016-02-06'),
(14, 0, 'ごちそうさまでした', 'Thank you for the meal (after eating)', 'Thank you for the meal (before eating)', 'Please go and come back', 'I''ll go and come back', '2016-02-06'),
(15, 0, 'はじめまして', 'How do you do?', 'Thank you for the meal (after eating)', 'I''m home', 'Good evening', '2016-02-06'),
(16, 0, 'よろしくおねがいします', 'Nice to meet you', 'How do you do?', 'I''m home', 'Good evening', '2016-02-06');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Ime` varchar(50) COLLATE utf8_slovenian_ci NOT NULL,
  `Prezime` varchar(50) COLLATE utf8_slovenian_ci NOT NULL,
  `Username` varchar(50) COLLATE utf8_slovenian_ci NOT NULL,
  `Password` varchar(100) COLLATE utf8_slovenian_ci NOT NULL,
  `DatumRodenja` date NOT NULL,
  `NivoZnanja` varchar(20) COLLATE utf8_slovenian_ci NOT NULL,
  `Komentar` varchar(1000) COLLATE utf8_slovenian_ci NOT NULL,
  `Slika` blob NOT NULL,
  `Kreiran` date NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_slovenian_ci AUTO_INCREMENT=21 ;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`ID`, `Ime`, `Prezime`, `Username`, `Password`, `DatumRodenja`, `NivoZnanja`, `Komentar`, `Slika`, `Kreiran`) VALUES
(17, 'Haris', 'Hasic', 'haris', 'ca8dbd404e5dec1b3a7afce308176e51', '1992-04-15', 'Intermediate', 'Jer Jer Jer Jer Jer Jer Jer Jer Jer Jer Jer Jer Jer Jer Jer Jer Jer Jer Jer Jer Jer Jer Jer Jer.', 0x53797374656d2e44726177696e672e4269746d6170, '2016-01-12'),
(19, 'Began', 'Azinovic', 'bego', '98f58894a67190addfe3c02808f43213', '2016-01-13', 'Begginer', 'asdasdasasdasdassssssssssssssssssssssssssssssssssssssscc acaacsa\ncacsasc\nasca\nscasc\ns\nc\nasc\nacs\nasc\nc\nsa', 0x53797374656d2e44726177696e672e4269746d6170, '2016-01-13'),
(20, 'Haris56', 'Hasic123', 'hare', '199a8b33a8aaa3313dc43709f433124a', '2016-01-13', 'Intermediate', 'sdgdsgdsfgdfg', 0x53797374656d2e44726177696e672e4269746d6170, '2016-01-13');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
