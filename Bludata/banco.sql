-- --------------------------------------------------------
-- Servidor:                     127.0.0.1
-- Versão do servidor:           5.7.26 - MySQL Community Server (GPL)
-- OS do Servidor:               Win64
-- HeidiSQL Versão:              10.2.0.5599
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Copiando estrutura do banco de dados para bludata
DROP DATABASE IF EXISTS `bludata`;
CREATE DATABASE IF NOT EXISTS `bludata` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `bludata`;

-- Copiando estrutura para tabela bludata.empresa
DROP TABLE IF EXISTS `empresa`;
CREATE TABLE IF NOT EXISTS `empresa` (
  `CD_EMPRESA` int(6) NOT NULL AUTO_INCREMENT,
  `CD_ESTADO` int(6) DEFAULT NULL,
  `NOME_FANTASIA` varchar(30) DEFAULT NULL,
  `CNPJ` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`CD_EMPRESA`)
) ENGINE=MyISAM AUTO_INCREMENT=22 DEFAULT CHARSET=latin1;

-- Exportação de dados foi desmarcado.

-- Copiando estrutura para tabela bludata.estado
DROP TABLE IF EXISTS `estado`;
CREATE TABLE IF NOT EXISTS `estado` (
  `CD_ESTADO` int(6) NOT NULL AUTO_INCREMENT,
  `DS_ESTADO` varchar(30) NOT NULL,
  `DS_SIGLA` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`CD_ESTADO`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- Exportação de dados foi desmarcado.

-- Copiando estrutura para tabela bludata.fornecedor
DROP TABLE IF EXISTS `fornecedor`;
CREATE TABLE IF NOT EXISTS `fornecedor` (
  `CD_FORNECEDOR` int(6) NOT NULL AUTO_INCREMENT,
  `CD_EMPRESA` int(6) NOT NULL DEFAULT '0',
  `NM_FORNECEDOR` varchar(100) DEFAULT NULL,
  `DT_CADASTRO` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `NR_CNPJ` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`CD_FORNECEDOR`)
) ENGINE=MyISAM AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;

-- Exportação de dados foi desmarcado.

-- Copiando estrutura para tabela bludata.telefone_fornecedor
DROP TABLE IF EXISTS `telefone_fornecedor`;
CREATE TABLE IF NOT EXISTS `telefone_fornecedor` (
  `CD_FORNECEDOR` int(20) NOT NULL AUTO_INCREMENT,
  `NR_TELEFONE` varchar(30) NOT NULL,
  PRIMARY KEY (`CD_FORNECEDOR`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- Exportação de dados foi desmarcado.

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
