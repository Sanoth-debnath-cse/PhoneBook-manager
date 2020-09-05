-- phpMyAdmin SQL Dump
-- version 4.8.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 05, 2020 at 02:36 PM
-- Server version: 10.1.34-MariaDB
-- PHP Version: 7.2.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `phonebook`
--

-- --------------------------------------------------------

--
-- Table structure for table `contacts`
--

CREATE TABLE `contacts` (
  `Id` int(18) NOT NULL,
  `First_Name` varchar(64) NOT NULL,
  `Last_Name` varchar(64) NOT NULL,
  `Mobile` varchar(64) NOT NULL,
  `Email` varchar(64) NOT NULL,
  `Category` enum('HOME','FAMILY','FRIENDS','OFFICE','BUSINESS') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `contacts`
--

INSERT INTO `contacts` (`Id`, `First_Name`, `Last_Name`, `Mobile`, `Email`, `Category`) VALUES
(1, 'Sanoth', 'debnath', '01768869412', 'sanotcse14@gmail.com', 'HOME'),
(2, 'nazmus', 'sakib', '01521410716', 'sakib@gmail.com', 'FRIENDS'),
(4, 'azhar', 'islam', '01838974398', 'azhar@gmail.com', 'FRIENDS'),
(5, 'tamim', 'ibne sohidullah', '01573687632', 'tamimcse@gmail.com', 'HOME'),
(6, 'akash', 'islam', '01763218768', 'akash@lgmail.com', 'OFFICE'),
(7, 'naimur', 'jahin', '0163872623', 'jahin@gmail.com', 'OFFICE'),
(8, 'jahid', 'khan', '01775236871', 'khan@gmail.com', 'BUSINESS'),
(11, 'Nayon', 'debnath', '01838540999', 'nayondebnath444@gmail.com', 'FAMILY');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `contacts`
--
ALTER TABLE `contacts`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `contacts`
--
ALTER TABLE `contacts`
  MODIFY `Id` int(18) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
