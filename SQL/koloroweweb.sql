-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sty 12, 2025 at 07:05 PM
-- Wersja serwera: 10.4.32-MariaDB
-- Wersja PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `koloroweweb`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `employees`
--

CREATE TABLE `employees` (
  `Principals` text NOT NULL,
  `GroupRed` text NOT NULL,
  `GroupYellow` text NOT NULL,
  `GroupBlue` text NOT NULL,
  `GroupGreen` text NOT NULL,
  `Specialists` text NOT NULL,
  `Id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `employees`
--

INSERT INTO `employees` (`Principals`, `GroupRed`, `GroupYellow`, `GroupBlue`, `GroupGreen`, `Specialists`, `Id`) VALUES
('Skład dyrekcji przedszkola.', 'Skład grupy czerwonej.', 'Skład grupy żółtej.', 'Skład grupy niebieskiej.', 'Skład grupy zielonej.', 'Skład grupy zatrudnionych specjalistów.', 1);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `images`
--

CREATE TABLE `images` (
  `Id` int(11) NOT NULL,
  `FileName` text NOT NULL,
  `PostId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `images`
--

INSERT INTO `images` (`Id`, `FileName`, `PostId`) VALUES
(6, '/ImageGallery/1.png', NULL),
(7, '/ImageGallery/2.png', NULL),
(8, '/ImageGallery/3.png', NULL),
(9, '/ImageGallery/4.png', NULL),
(10, '/ImageGallery/5.png', NULL),
(11, '/ImageGallery/6.png', NULL),
(12, '/ImageGallery/7.png', NULL),
(13, '/ImageGallery/8.png', NULL),
(14, '/ImageGallery/9.png', NULL),
(15, '/ImageGallery/10.png', NULL),
(16, '/ImageGallery/11.png', NULL),
(17, '/ImageGallery/12.png', NULL),
(18, '/ImageGallery/13.png', NULL),
(19, '/ImageGallery/14.png', NULL),
(20, '/ImageGallery/15.png', NULL),
(21, '/ImageGallery/16.png', NULL),
(22, '/PostImages/1alt.png', 24),
(23, '/PostImages/2alt.png', 25),
(24, '/PostImages/4alt.png', 27),
(25, '/PostImages/5alt.png', 28),
(26, '/PostImages/6alt.png', 29);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `offers`
--

CREATE TABLE `offers` (
  `Id` int(11) NOT NULL,
  `Title` text NOT NULL,
  `Content` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `offers`
--

INSERT INTO `offers` (`Id`, `Title`, `Content`) VALUES
(3, 'Tytuł pierwszej oferty.', '<p>Zawartość pierwszej oferty.</p>'),
(4, 'Tytuł drugiej oferty.', '<p>Zawartość drugiej oferty.</p>'),
(5, 'Tytuł trzeciej oferty.', '<p>Zawartość trzeciej oferty.</p>');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `posts`
--

CREATE TABLE `posts` (
  `Id` int(11) NOT NULL,
  `Date` date NOT NULL,
  `Content` text NOT NULL,
  `Title` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `posts`
--

INSERT INTO `posts` (`Id`, `Date`, `Content`, `Title`) VALUES
(24, '2025-01-11', '<p>Zawartość pierwszego postu.</p>', 'Tytuł pierwszego postu.'),
(25, '2025-01-11', '<p>Zawartość drugiego postu.</p>', 'Tytuł drugiego postu.'),
(26, '2025-01-11', '<p>Zawartość trzeciego postu.</p>', 'Tytuł trzeciego postu.'),
(27, '2025-01-11', '<p>Zawartość czwartego postu.</p>', 'Tytuł czwartego postu.'),
(28, '2025-01-11', '<p>Zawartość piątego postu.</p>', 'Tytuł piątego postu.'),
(29, '2025-01-11', '<p>Zawartość szóstego postu.</p>', 'Tytuł szóstego postu.');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `users`
--

CREATE TABLE `users` (
  `Id` int(11) NOT NULL,
  `Username` varchar(100) NOT NULL,
  `PasswordHash` varchar(511) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`Id`, `Username`, `PasswordHash`) VALUES
(5, 'Admin', '$2a$11$7FgPa8sihCTYYpNd4yqkde5V6f5nQRcYg9XM2U6ON3UdK/f17BMmm');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `employees`
--
ALTER TABLE `employees`
  ADD PRIMARY KEY (`Id`);

--
-- Indeksy dla tabeli `images`
--
ALTER TABLE `images`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `ImagesPostsFK` (`PostId`);

--
-- Indeksy dla tabeli `offers`
--
ALTER TABLE `offers`
  ADD PRIMARY KEY (`Id`);

--
-- Indeksy dla tabeli `posts`
--
ALTER TABLE `posts`
  ADD PRIMARY KEY (`Id`);

--
-- Indeksy dla tabeli `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `employees`
--
ALTER TABLE `employees`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `images`
--
ALTER TABLE `images`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- AUTO_INCREMENT for table `offers`
--
ALTER TABLE `offers`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `posts`
--
ALTER TABLE `posts`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `images`
--
ALTER TABLE `images`
  ADD CONSTRAINT `ImagesPostsFK` FOREIGN KEY (`PostId`) REFERENCES `posts` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
