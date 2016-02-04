-- phpMyAdmin SQL Dump
-- version 3.5.1
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Feb 04, 2016 at 02:58 PM
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
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_slovenian_ci AUTO_INCREMENT=2 ;

--
-- Dumping data for table `obicnopitanje`
--

INSERT INTO `obicnopitanje` (`id`, `nivo`, `tekst`, `tacanodgovor`, `odgovor1`, `odgovor2`, `odgovor3`, `kreiran`) VALUES
(1, 0, 'おはようございます', 'Good morning.', 'Good evening.', 'Goodbye.', 'Good afternoon.', '2016-02-04');

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
