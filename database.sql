/*
SQLyog Enterprise - MySQL GUI v6.06
Host - 5.5.16 : Database - kartunama
*********************************************************************
Server version : 5.5.16
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

create database if not exists `kartunama`;

USE `kartunama`;

/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

/*Table structure for table `barang` */

DROP TABLE IF EXISTS `barang`;

CREATE TABLE `barang` (
  `no` int(1) NOT NULL,
  `ukuran` varchar(10) DEFAULT NULL,
  `harga` int(7) DEFAULT NULL,
  PRIMARY KEY (`no`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `barang` */

insert  into `barang`(`no`,`ukuran`,`harga`) values (1,'9 X 6',3000);

/*Table structure for table `customer` */

DROP TABLE IF EXISTS `customer`;

CREATE TABLE `customer` (
  `kode_customer` int(7) NOT NULL AUTO_INCREMENT,
  `nama_customer` varchar(50) DEFAULT NULL,
  `alamat` varchar(50) DEFAULT NULL,
  `no_hp` varchar(15) DEFAULT NULL,
  `kantor` varchar(50) DEFAULT NULL,
  `directory_foto` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`kode_customer`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=latin1;

/*Data for the table `customer` */

insert  into `customer`(`kode_customer`,`nama_customer`,`alamat`,`no_hp`,`kantor`,`directory_foto`) values (9,'coba 1','tes','tes','tes','image_customer/9'),(12,'Rizal','Kertosari','008','IT Solution','image_customer/12'),(13,'Ahmad Rizal Afani','Kertosari','087755925565','IT Solution','image_customer/13');

/*Table structure for table `pembayaran` */

DROP TABLE IF EXISTS `pembayaran`;

CREATE TABLE `pembayaran` (
  `kode_customer` int(7) NOT NULL,
  `banyak_pesanan` int(5) DEFAULT NULL,
  `harga_satuan` int(7) DEFAULT NULL,
  `tanggal` date DEFAULT NULL,
  PRIMARY KEY (`kode_customer`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `pembayaran` */

insert  into `pembayaran`(`kode_customer`,`banyak_pesanan`,`harga_satuan`,`tanggal`) values (12,100,3000,'2013-01-21'),(13,200,3000,'2013-01-22');

/*Table structure for table `pengambilan` */

DROP TABLE IF EXISTS `pengambilan`;

CREATE TABLE `pengambilan` (
  `kode_customer` int(7) NOT NULL,
  `pengambil` varchar(100) DEFAULT NULL,
  `tanggal` date DEFAULT NULL,
  PRIMARY KEY (`kode_customer`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `pengambilan` */

/*Table structure for table `userapp` */

DROP TABLE IF EXISTS `userapp`;

CREATE TABLE `userapp` (
  `userlogin` varchar(50) NOT NULL,
  `password` varchar(50) DEFAULT NULL,
  `username` varchar(50) DEFAULT NULL,
  `alamat` varchar(50) DEFAULT NULL,
  `no_hp` varchar(15) DEFAULT NULL,
  `jabatan` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`userlogin`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `userapp` */

insert  into `userapp`(`userlogin`,`password`,`username`,`alamat`,`no_hp`,`jabatan`) values ('anonimous','monyet','anoman','Alas Purwo','0090009','Designer'),('customer','','customer','','','customer'),('mahrus_roni','roni','Mahrussahroni','Muncar','008','Manager'),('rizal','rizal','Rizal Afani','Kertosari','087755925565','Kasir');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
