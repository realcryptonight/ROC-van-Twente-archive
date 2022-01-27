-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Gegenereerd op: 04 dec 2021 om 18:59
-- Serverversie: 10.4.22-MariaDB
-- PHP-versie: 7.4.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `themepark`
--

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `coasters`
--

CREATE TABLE `coasters` (
  `id` int(11) NOT NULL,
  `name` text NOT NULL,
  `park` int(11) NOT NULL,
  `build_year` date NOT NULL,
  `manufacturer` int(11) NOT NULL,
  `type` int(11) NOT NULL,
  `height` double NOT NULL,
  `speed` double NOT NULL,
  `gforce` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `coasters`
--

INSERT INTO `coasters` (`id`, `name`, `park`, `build_year`, `manufacturer`, `type`, `height`, `speed`, `gforce`) VALUES
(1, 'Goliath', 1, '2002-04-05', 1, 1, 46.8, 106, -1),
(2, 'Speed of Sound', 1, '2002-04-05', 2, 2, 35.5, 75.6, 5.2);

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `coastertypes`
--

CREATE TABLE `coastertypes` (
  `id` int(11) NOT NULL,
  `type` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `coastertypes`
--

INSERT INTO `coastertypes` (`id`, `type`) VALUES
(1, 'Mega Coaster'),
(2, 'Boomerang');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `countries`
--

CREATE TABLE `countries` (
  `id` int(3) NOT NULL,
  `name` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `countries`
--

INSERT INTO `countries` (`id`, `name`) VALUES
(1, 'Unknown'),
(2, 'Netherlands');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `manufacturer`
--

CREATE TABLE `manufacturer` (
  `id` int(11) NOT NULL,
  `name` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `manufacturer`
--

INSERT INTO `manufacturer` (`id`, `name`) VALUES
(1, 'Intamin AG'),
(2, 'Vekoma');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `parks`
--

CREATE TABLE `parks` (
  `id` int(11) NOT NULL,
  `name` text NOT NULL,
  `open_since` date NOT NULL,
  `owner` text NOT NULL,
  `country` int(3) NOT NULL,
  `address` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `parks`
--

INSERT INTO `parks` (`id`, `name`, `open_since`, `owner`, `country`, `address`) VALUES
(1, 'Walibi Holland', '1971-05-21', 'Compagnie des Alpes', 2, 'Spijkweg 30, 8256 RJ Biddinghuizen'),
(2, 'Efteling', '1952-05-31', 'Stichting Natuurpark de Efteling', 2, 'Europalaan 1, 5171 KW Kaatsheuvel');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `session_id` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `users`
--

INSERT INTO `users` (`id`, `username`, `password`, `session_id`) VALUES
(1, 'DanielMarkink', 'ThisIsNotThePassword!', 'vfdzhfdxghfdgnhfsdjytfhtrjhrdhdhd'),
(2, 'realcryptonight', '$2y$10$ZXF3dHk0M2I1dnc0NmIhK.zJZvHKflod9X2AyNRBEOD2GkCYO1dAW', 'WH4TdkoFYz26rs5q2MHWnT');

--
-- Indexen voor geëxporteerde tabellen
--

--
-- Indexen voor tabel `coasters`
--
ALTER TABLE `coasters`
  ADD PRIMARY KEY (`id`),
  ADD KEY `manufacturer` (`manufacturer`),
  ADD KEY `park` (`park`),
  ADD KEY `type` (`type`);

--
-- Indexen voor tabel `coastertypes`
--
ALTER TABLE `coastertypes`
  ADD PRIMARY KEY (`id`);

--
-- Indexen voor tabel `countries`
--
ALTER TABLE `countries`
  ADD PRIMARY KEY (`id`);

--
-- Indexen voor tabel `manufacturer`
--
ALTER TABLE `manufacturer`
  ADD PRIMARY KEY (`id`);

--
-- Indexen voor tabel `parks`
--
ALTER TABLE `parks`
  ADD PRIMARY KEY (`id`),
  ADD KEY `Parks_ibfk_1` (`country`);

--
-- Indexen voor tabel `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT voor geëxporteerde tabellen
--

--
-- AUTO_INCREMENT voor een tabel `coasters`
--
ALTER TABLE `coasters`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT voor een tabel `coastertypes`
--
ALTER TABLE `coastertypes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT voor een tabel `countries`
--
ALTER TABLE `countries`
  MODIFY `id` int(3) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT voor een tabel `manufacturer`
--
ALTER TABLE `manufacturer`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT voor een tabel `parks`
--
ALTER TABLE `parks`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT voor een tabel `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Beperkingen voor geëxporteerde tabellen
--

--
-- Beperkingen voor tabel `coasters`
--
ALTER TABLE `coasters`
  ADD CONSTRAINT `Coasters_ibfk_1` FOREIGN KEY (`manufacturer`) REFERENCES `manufacturer` (`id`),
  ADD CONSTRAINT `Coasters_ibfk_2` FOREIGN KEY (`park`) REFERENCES `parks` (`id`),
  ADD CONSTRAINT `Coasters_ibfk_3` FOREIGN KEY (`type`) REFERENCES `coastertypes` (`id`);

--
-- Beperkingen voor tabel `parks`
--
ALTER TABLE `parks`
  ADD CONSTRAINT `Parks_ibfk_1` FOREIGN KEY (`country`) REFERENCES `countries` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
