-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 11, 2026 at 10:14 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `fancydressshop`
--

-- --------------------------------------------------------

--
-- Table structure for table `customers`
--

CREATE TABLE `customers` (
  `customer_id` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `role` varchar(50) NOT NULL DEFAULT 'Customer',
  `full_name` varchar(100) NOT NULL,
  `address` varchar(255) DEFAULT NULL,
  `phone_number` varchar(15) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `birth_date` date DEFAULT NULL,
  `profile_image` varchar(255) DEFAULT NULL,
  `status` varchar(50) NOT NULL DEFAULT 'Active',
  `ban_reason` varchar(255) DEFAULT NULL,
  `ban_until` datetime DEFAULT NULL,
  `bank_name` varchar(100) NOT NULL,
  `account_number` varchar(20) NOT NULL,
  `account_name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `customers`
--

INSERT INTO `customers` (`customer_id`, `username`, `password`, `role`, `full_name`, `address`, `phone_number`, `email`, `created_at`, `birth_date`, `profile_image`, `status`, `ban_reason`, `ban_until`, `bank_name`, `account_number`, `account_name`) VALUES
(1, 'admin', 'admin12345', 'Admin', 'นางสาวจุฑามณี บุญประคม', 'มข ไข่', '0651111111', 'frenxxxx@gmail.com', '2025-09-26 13:26:28', '2025-09-26', 'ProfileImages\\84dcab6a-7d92-4a77-9200-fd31a11148e6.jpg', 'Active', '', '2025-11-18 08:42:48', 'ธนาคารกรุงไทย (KTB)', '1234567899', 'ชนัญชิดา'),
(2, 'Ung', '123456', 'Customer', 'ชนัญชิดา', 'มข', '0987654356', 'chananchida@kkumail.com', '2025-10-11 15:51:21', '2025-10-24', 'ProfileImages\\2_638978758822239504.jpg', 'Active', NULL, NULL, 'ธนาคารกรุงไทย (KTB)', '2345678901', 'ชนัญชิดา'),
(3, 'yok', '1234', 'customer', 'หยก', 'มข', '0934567854', 'yok1234@gmail.com', '2025-11-03 10:22:11', '2025-11-03', 'ProfileImages\\15003587-8741-45cd-a7dc-0246c52c844e.jpg', 'Active', '', '2025-11-22 22:50:57', 'ธนาคารกรุงไทย (KTB)', '1234567891', 'กนกนภา'),
(5, 'Noomnim', 'noom1234', 'customer', 'นางสาวนุ่มนิ่ม น่ารัก', 'กองบริการหอพักนักศึกษา (หอพักส่วนกลาง) ที่อยู่ 123 หมู่ 16 ถนนมิตรภาพ ตำบลในเมือง อำเภอเมือง จังหวัดขอนแก่น 40002', '0923495867', 'Noomnim24@gmail.com', '2025-11-05 09:03:35', '2025-11-05', 'ProfileImages\\507345c2-ac77-42e7-aa77-b713732b92c3.jpg', 'Active', '', '2025-11-05 16:18:30', 'ธนาคารกสิกรไทย (KBANK)', '1234567898', 'นุ่มนิ่ม'),
(6, 'Warin', '12345', 'Customer', 'วาริน อาบน้ำบ่อย', 'มขไข่', '0873456748', 'warin@gmail.com', '2025-11-22 04:51:19', '2025-11-05', 'ProfileImages\\15003587-8741-45cd-a7dc-0246c52c844e.jpg', 'Active', '', '2025-11-22 11:49:42', 'ธนาคารกรุงไทย (KTB)', '1247531245', 'วาริน');

-- --------------------------------------------------------

--
-- Table structure for table `dresses`
--

CREATE TABLE `dresses` (
  `dress_id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `description` text DEFAULT NULL,
  `category` varchar(50) DEFAULT NULL,
  `rental_price_per_day` decimal(10,2) NOT NULL,
  `deposit_price` decimal(10,2) NOT NULL,
  `image_path` varchar(255) DEFAULT NULL,
  `status` varchar(20) NOT NULL DEFAULT 'Available'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `dresses`
--

INSERT INTO `dresses` (`dress_id`, `name`, `description`, `category`, `rental_price_per_day`, `deposit_price`, `image_path`, `status`) VALUES
(1, 'เมดคลาสสิก', 'สไตล์: ชุดเมดคลาสสิกที่ได้รับแรงบันดาลใจจากสไตล์ฝรั่งเศส\r\n\n\nวัสดุ: ผลิตจากผ้าคุณภาพดี สวมใส่สบาย ระบายอากาศได้ดี\r\n\n\nรายละเอียดการออกแบบ: ตกแต่งด้วยลูกไม้สวยงามที่คอเสื้อ แขนเสื้อ และชายกระโปรง มาพร้อมผ้ากันเปื้อนและที่คาดผมเข้าชุด\r\nสิ่งที่ได้รับในชุด: ในชุดประกอบด้วย: เดรส, ผ้ากันเปื้อน, ที่คาดผม', 'ชุดคอสเพลย์', 500.00, 150.00, 'DressImages/girlmaid.png', 'Available'),
(2, 'White Princess', 'ชุดเจ้าสาวทรง บอลกาวน์ สีขาวงาช้าง/ขาวออฟไวท์ คอเสื้อทรง หัวใจ และมีผ้าลูกไม้ซีทรูคลุมด้านบนช่วงคอและไหล่ แขนเสื้อสั้นแบบเปิดไหล่เล็กน้อย ตัวเสื้อช่วงบนเป็น คอร์เซ็ท เน้นเข้ารูป ปักด้วยลูกไม้และเลื่อม/ไข่มุกอย่างละเอียด กระโปรงบานฟูฟ่องทำจากผ้าซาตินและผ้าโปร่ง มีชายกระโปรงลากยาว ให้ลุคสง่างามดุจเจ้าหญิง', 'ชุดราตรี', 3000.00, 900.00, 'DressImages/whiteprincess.png', 'Available'),
(4, 'The Grand Marshal', 'ชุดราชองครักษ์ ทรง Morning Coat สีขาวสะอาดตา คอตั้งแบบจีน มีขลิบและกระดุมสีทองคู่ตลอดแนวหน้า ตัวเสื้อมีดีไซน์หางยาวผ่าด้านหลัง ด้านในบุด้วยผ้าสีทองอ่อนหรือครีม มาพร้อมกับกางเกงทรง Riding Breeches เน้นความสมบูรณ์แบบด้วยสายสะพายสีน้ำเงินหลวง พร้อมเหรียญตรา และพู่/เชือกสีทองที่บ่า ให้ลุคสง่าและมีอำนาจ', 'ชุดราตรี', 3000.00, 900.00, 'DressImages/whiteprince.png', 'Available'),
(5, 'The Cozy Fox', 'ชุดแฟนซีแบบชุดนอน สีส้ม และมีส่วนท้องเป็นสีขาว มีซิปด้านหน้าหรือกระดุมสำหรับสวมใส่ มีฮู้ดติดหูขนาดใหญ่และมีดีไซน์หน้าสัตว์บนฮู้ด เนื้อผ้าเป็นแบบนุ่ม เหมาะสำหรับใส่เป็นชุดนอน, ชุดปาร์ตี้, หรือชุดลำลองในงานแฟนซี สวมใส่สบาย ทรงหลวม', 'ชุดสัตว์', 500.00, 150.00, 'DressImages/catorage.png', 'Available'),
(7, 'The Pop Kimono', 'ชุดแฟนซีสไตล์ กิโมโน หรือชุดประจำชาติเอเชียที่ได้รับอิทธิพลจาก วัฒนธรรมป๊อป โทนสีหลักคือสีฟ้าสด แดง และส้ม ผ้าพิมพ์ลายการ์ตูน/ตัวละครแอนิเมชัน ผสมผสานกับลายดอกไม้ดั้งเดิม มาพร้อมกับโอบิ ขนาดใหญ่ สีทอง/น้ำตาลเข้ม และ เครื่องประดับศีรษะแบบจีน/ญี่ปุ่น ที่มีความอลังการ ให้ลุคที่ผสมผสานความดั้งเดิมและความทันสมัยอย่างลงตัว', 'ชุดประจำชาติ', 2700.00, 810.00, 'DressImages/Kimono.png', 'Available'),
(9, 'The Caribbean Pirate', 'ชุดแฟนซีสไตล์ โจรสลัด ประกอบด้วยเสื้อโค้ทตัวยาวสีดำ ขลิบทองที่คอปกและแขนเสื้อ ด้านในสวมเสื้อเชิ้ตสีขาว/ครีมแขนพอง กางเกงสามส่วนลายทางสีขาวดำ มีผ้าคาดเอวสีแดง-เขียว-ดำ และสายคาดไหล่หนัง มาพร้อมกับอุปกรณ์เสริมครบชุด: หมวกโจรสลัด และผ้าคาดหัวสีแดง ให้ลุคกัปตันโจรสลัดที่แข็งแกร่งและมีเสน่ห์', 'ชุดโจรสลัด', 1500.00, 150.00, 'DressImages/Pirate.png', 'Available'),
(10, 'The Lilac Fairy', 'ชุดแฟนซีสไตล์แฟรี่ โทนสีม่วงอ่อน และขาว ตัวเสื้อเป็นคอร์เซ็ท ประดับด้วยลูกปัด เพชรสีชมพูอมม่วง ช่วงกระโปรงสั้นด้านในแบบกลีบดอกไม้ และมีผ้าโปร่งยาวลากพื้นด้านหลัง มาพร้อมกับเครื่องประดับครบชุด: ปีกขนาดใหญ่ที่ปักลายอย่างละเอียด, มงกุฎ , และสร้อยคอยห้อยระย้า เน้นความวิจิตรบรรจงและแฟนตาซี เหมาะสำหรับงานประกวด, งานปาร์ตี้ธีมเทพนิยาย, หรือการแสดง', 'ชุดคอสเพลย์', 3500.00, 1050.00, 'DressImages/fairy.png', 'Available'),
(11, 'Black Cat Masquerade', 'ชุดแฟนซีสไตล์ Gothic สีดำล้วน ตัวเสื้อเป็นคอร์เซ็ท เข้ารูป ประดับด้วยเพชร และลูกไม้ ปกคอเป็นขนนกหรือขนฟูฟ่อง กระโปรงสั้นด้านหน้าและยาวด้านหลังแบบ High-Low  ซ้อนด้วยผ้าตาข่า มาพร้อมกับที่คาดผมหูแมว และที่รัดข้อมือ ถุงมือสั้น เพิ่มความเซ็กซี่และน่าค้นหา เหมาะสำหรับงานปาร์ตี้ฮาโลวีน หรือปาร์ตี้แฟนซีธีมดาร์ก', 'ชุดแมว', 1200.00, 360.00, 'DressImages/blackcat.png', 'Available'),
(12, 'The Heavenly Angel', 'ชุดแฟนซีสไตล์ Angel โทนสีครีม หรือขาวงาช้าง ชุดเดรสทรงตรง แขนยาวผ้าชีฟอง ตัวชุดปักประดับด้วยลูกปัดคริสตัลสีทองและสีใส เป็นลวดลายหรูหราบริเวณอกและชายกระโปรง ชายกระโปรงตัดแบบไม่สมมาตร มีเข็มขัดผ้าผูกเอว มาพร้อมกับปีกขนนกสีขาวขนาดใหญ่ และที่คาดผมประดับเพชรคริสตัล ให้ลุคบริสุทธิ์และศักดิ์สิทธิ์', 'ชุดนางฟ้า', 2500.00, 750.00, 'DressImages/angel.png', 'Available'),
(13, 'The Survey Corps', 'ชุดคอสเพลย์ Attack on Titan ประกอบด้วย: เสื้อแจ็คเก็ตครอปหนังเทียมสีน้ำตาลอ่อน พร้อมตราสัญลักษณ์หน่วยสำรวจที่แขนและกระเป๋า, เสื้อเชิ้ตขาวด้านใน, และที่สำคัญคือ ชุดเข็มขัดและสายรัดหนังที่พันรอบลำตัวและขา รวมถึงสายรัดต้นขาและอุปกรณ์เสริม ชุดนี้เน้นความสมจริงและรายละเอียดของสายรัดต่าง ๆ', 'ชุดคอสเพลย์', 2100.00, 630.00, 'DressImages/aot.png', 'Available'),
(14, 'Moon Princess', 'ชุดคอสเพลย์ Sailor Moon ประกอบด้วย: เสื้อคอปกกะลาสี สีขาว-น้ำเงิน แขนกุด กระโปรงจีบรอบ สีน้ำเงินเข้ม มาพร้อมกับโบว์สีแดงขนาดใหญ่ (บริเวณหน้าอกและด้านหลัง) โชคเกอร์สีแดง และปลอกข้อมือสีน้ำเงินขาว\r\nชุดคอสเพลย์', 'ชุดคอสเพลย์', 1500.00, 450.00, 'DressImages/moonprincess.png', 'Available'),
(15, 'The Forest Sentinel', 'ชุดแฟนซีสไตล์ Elven Warrior โทนสีเขียวเข้มและสีน้ำตาล วัสดุทำเลียนแบบหนัง, ขนนก/ใบไม้ และเกราะทองเหลืองหรือทองแดง ตัวเสื้อเป็นคอร์เซ็ทเน้นเข้ารูป ประดับด้วยอัญมณีสีเขียวหยก/มรกต มีดีเทลใบไม้ซ้อนกันเป็นชั้น ๆ บริเวณบ่าและชายกระโปรงสั้น มาพร้อมกับปลอกแขนยาว ปลอกข้อมือ และเครื่องประดับคอขนาดใหญ่เหมาะสำหรับงานคอสเพลย์ระดับพรีเมียม, งานแฟนตาซี, หรือการแสดงที่ต้องการความสมจริง\r\nชุดแฟนซี', 'ชุดแฟนซี', 4000.00, 1200.00, 'DressImages/elf.png', 'Available'),
(16, 'The Mystic Robe', 'ชุดแฟนซีสไตล์ พ่อมดโทนสีน้ำเงินเข้ม มีฮู้ดคลุมศีรษะ และแขนเสื้อทรงกระดิ่ง ตัวชุดคลุมยาวถึงพื้น มีลายปักสีทอง/สลักบริเวณชายกระโปรงและลำตัว เข็มขัดผ้าสีม่วงเข้ม และผ้าคาดเอวปักลายสีทอง มีสายโซ่และเครื่องรางห้อยระย้าที่ไหล่ ให้ลุคลึกลับและทรงพลัง', 'ชุดพ่อมด/แม่มด', 2100.00, 630.00, 'DressImages/vampirem.png', 'Available');

-- --------------------------------------------------------

--
-- Table structure for table `dress_inventory`
--

CREATE TABLE `dress_inventory` (
  `inventory_id` int(11) NOT NULL,
  `dress_id` int(11) NOT NULL,
  `size` varchar(50) NOT NULL,
  `total_quantity` int(11) NOT NULL DEFAULT 0,
  `available_quantity` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `dress_inventory`
--

INSERT INTO `dress_inventory` (`inventory_id`, `dress_id`, `size`, `total_quantity`, `available_quantity`) VALUES
(1, 1, 'S', 11, 10),
(3, 2, 'L', 7, 6),
(6, 2, 'M', 2, 1),
(7, 4, 'L', 4, 4),
(8, 4, 'M', 2, 0),
(9, 4, 'XL', 3, 3),
(10, 5, 'M', 2, 2),
(11, 5, 'XL', 4, 3),
(12, 1, 'XXL', 1, 0),
(13, 2, 'S', 2, 2),
(14, 2, 'XL', 5, 5),
(21, 7, 'S', 6, 6),
(22, 9, 'S', 10, 10),
(23, 9, 'L', 10, 10),
(24, 9, 'XL', 5, 5),
(25, 9, 'M', 10, 10),
(26, 10, 'XS', 15, 15),
(27, 10, 'S', 10, 10),
(28, 10, 'M', 10, 10),
(29, 10, 'L', 10, 9),
(30, 10, 'XL', 5, 5),
(31, 11, 'XXL', 5, 5),
(32, 11, 'XL', 5, 5),
(33, 11, 'L', 12, 12),
(34, 11, 'M', 10, 10),
(35, 11, 'S', 15, 15),
(36, 12, 'S', 18, 18),
(37, 12, 'M', 20, 20),
(38, 12, 'L', 14, 14),
(39, 12, 'XL', 4, 4),
(40, 13, 'M', 15, 15),
(41, 13, 'XL', 5, 5),
(42, 14, 'M', 10, 10),
(43, 14, 'FreeSize', 5, 5),
(44, 15, 'M', 10, 10),
(45, 15, 'L', 5, 5),
(46, 16, 'S', 10, 10),
(47, 16, 'M', 14, 13);

-- --------------------------------------------------------

--
-- Table structure for table `rentals1`
--

CREATE TABLE `rentals1` (
  `rental_id` int(11) NOT NULL,
  `customer_id` int(11) NOT NULL,
  `rental_date` datetime NOT NULL,
  `due_date` datetime NOT NULL,
  `return_date` datetime DEFAULT NULL,
  `total_price` decimal(10,2) NOT NULL,
  `deposit_amount` decimal(10,2) NOT NULL,
  `outstanding_balance` decimal(10,2) DEFAULT NULL,
  `status` varchar(50) NOT NULL,
  `payment_status` varchar(50) NOT NULL,
  `payment_slip_path` varchar(255) DEFAULT NULL,
  `fine_slip_path` varchar(255) DEFAULT NULL,
  `notes` text NOT NULL,
  `creation_time` datetime NOT NULL DEFAULT current_timestamp(),
  `handover_date` datetime DEFAULT NULL,
  `payment_confirmed_date` datetime DEFAULT NULL,
  `finalize_date` datetime DEFAULT NULL,
  `refund_slip_path` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `rentals1`
--

INSERT INTO `rentals1` (`rental_id`, `customer_id`, `rental_date`, `due_date`, `return_date`, `total_price`, `deposit_amount`, `outstanding_balance`, `status`, `payment_status`, `payment_slip_path`, `fine_slip_path`, `notes`, `creation_time`, `handover_date`, `payment_confirmed_date`, `finalize_date`, `refund_slip_path`) VALUES
(1, 2, '2025-11-04 00:00:00', '2025-11-05 00:00:00', '2025-11-21 00:00:00', 500.00, 150.00, 0.00, 'Closed', 'Refunded', 'PaymentSlips\\1_25681104145031_PAYMENT.png', 'Slips\\1_25681104155310_FINE.png', 'he', '2025-11-03 16:47:02', '2025-11-04 14:50:56', '2025-11-04 14:50:51', '2025-11-04 21:48:53', 'RefundSlips\\1_REFUND_25681104214853.jpg'),
(2, 2, '2025-11-04 00:00:00', '2025-11-05 00:00:00', '2025-11-04 00:00:00', 500.00, 150.00, 0.00, 'Closed', 'Refunded', 'PaymentSlips\\2_25681104141658_PAYMENT.png', NULL, 'ee', '2025-11-03 16:55:01', '2025-11-04 14:49:18', '2025-11-04 14:18:50', '2025-11-22 20:22:16', 'RefundSlips\\2_REFUND_25681122202216.jpg'),
(5, 2, '2025-11-04 00:00:00', '2025-11-05 00:00:00', NULL, 2000.00, 150.00, NULL, 'Cancelled', 'Cancelled', NULL, NULL, '\n[Customer] Manually cancelled.', '2025-11-04 10:56:05', NULL, NULL, NULL, NULL),
(6, 2, '2025-11-04 00:00:00', '2025-11-05 00:00:00', '2025-11-27 00:00:00', 650.00, 150.00, 0.00, 'Completed', 'Paid', 'PaymentSlips\\RENTAL_6_25681104175603.jpg', 'Slips\\6_25681122202645_FINE.jpg', '\n[System] Returned. Fine: 1,100.00. Deposit: 150.00. Refund due: 0.00. Outstanding: 950.00.', '2025-11-04 17:53:49', '2025-11-24 00:00:00', '2025-11-22 20:23:17', '2025-11-27 00:00:00', NULL),
(7, 2, '2025-11-04 00:00:00', '2025-11-05 00:00:00', '2025-11-07 00:00:00', 4550.00, 1050.00, 700.00, 'Returned', 'Paid', 'PaymentSlips\\RENTAL_7_25681104175706.jpg', NULL, '', '2025-11-04 17:56:52', '2025-11-05 14:47:53', '2025-11-05 14:47:33', NULL, NULL),
(8, 5, '2025-11-07 00:00:00', '2025-11-13 00:00:00', '2025-11-16 00:00:00', 78120.00, 3720.00, 0.00, 'Completed', 'Paid', 'PaymentSlips\\RENTAL_8_25681105160827.jpg', 'Slips\\8_25681105162148_FINE.jpg', '', '2025-11-05 16:07:35', '2025-11-05 16:17:52', '2025-11-05 16:17:00', '2025-11-05 16:22:30', NULL),
(9, 5, '2025-11-17 00:00:00', '2025-11-18 00:00:00', NULL, 1560.00, 360.00, 0.00, 'Pending Payment', 'Unpaid', NULL, NULL, '', '2025-11-17 13:43:59', NULL, NULL, NULL, NULL),
(10, 5, '2025-11-20 00:00:00', '2025-11-21 00:00:00', NULL, 3900.00, 900.00, 0.00, 'Pending Confirmation', 'Pending', 'PaymentSlips\\RENTAL_10_25681120215131.jpg', NULL, '', '2025-11-20 21:51:22', NULL, NULL, NULL, NULL),
(11, 5, '2025-11-20 00:00:00', '2025-11-21 00:00:00', NULL, 1950.00, 450.00, 0.00, 'Pending Confirmation', 'Pending', 'PaymentSlips\\RENTAL_11_25681120220913.jpg', NULL, '', '2025-11-20 22:09:06', NULL, NULL, NULL, NULL),
(12, 5, '2025-11-20 00:00:00', '2025-11-21 00:00:00', '2025-11-28 00:00:00', 7800.00, 1800.00, 2400.00, 'Returned', 'Paid', 'PaymentSlips\\RENTAL_12_25681120221213.jpg', 'Slips\\12_25681122213103_FINE.jpg', '\n[System] Returned. Fine: 4,200.00. Deposit: 1,800.00. Refund due: 0.00. Outstanding: 2,400.00.', '2025-11-20 22:12:07', '2025-11-23 00:00:00', '2025-11-22 21:29:50', NULL, NULL),
(13, 5, '2025-11-20 00:00:00', '2025-11-21 00:00:00', '2025-11-24 00:00:00', 650.00, 150.00, 0.00, 'Completed', 'Paid', 'PaymentSlips\\RENTAL_13_25681120221726.jpg', NULL, '\n[System] Returned. Fine: 150.00. Deposit: 150.00. Refund due: 0.00. Outstanding: 0.00.', '2025-11-20 22:17:19', '2025-11-23 00:00:00', '2025-11-22 21:29:10', NULL, NULL),
(14, 2, '2025-11-21 00:00:00', '2025-11-30 00:00:00', NULL, 83700.00, 2700.00, 0.00, 'Pending Confirmation', 'Pending', 'PaymentSlips\\RENTAL_14_25681121212631.jpg', NULL, '', '2025-11-21 21:26:25', NULL, NULL, NULL, NULL),
(15, 2, '2026-01-10 00:00:00', '2026-01-13 00:00:00', NULL, 11550.00, 1050.00, 0.00, 'Confirmed', 'Paid', 'PaymentSlips\\RENTAL_15_25690110144510.jpg', NULL, '', '2026-01-10 14:40:07', NULL, '2026-01-11 15:28:43', NULL, NULL),
(16, 2, '2026-01-10 00:00:00', '2026-01-11 00:00:00', NULL, 2730.00, 630.00, 0.00, 'Pending Payment', 'Unpaid', NULL, NULL, '', '2026-01-10 19:13:02', NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `rental_details`
--

CREATE TABLE `rental_details` (
  `rental_detail_id` int(11) NOT NULL,
  `rental_id` int(11) NOT NULL,
  `dress_inventory_id` int(11) NOT NULL,
  `rental_quantity` int(11) NOT NULL,
  `price_at_rental` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `rental_details`
--

INSERT INTO `rental_details` (`rental_detail_id`, `rental_id`, `dress_inventory_id`, `rental_quantity`, `price_at_rental`) VALUES
(4, 1, 1, 1, 500.00),
(5, 2, 3, 1, 500.00),
(8, 5, 1, 1, 500.00),
(9, 6, 1, 1, 500.00),
(10, 7, 6, 1, 3000.00),
(11, 7, 10, 1, 500.00),
(12, 8, 11, 1, 500.00),
(13, 8, 18, 2, 1200.00),
(14, 8, 9, 1, 3000.00),
(15, 8, 13, 2, 3000.00),
(16, 8, 12, 1, 500.00),
(17, 9, 18, 1, 1200.00),
(18, 10, 8, 1, 3000.00),
(19, 11, 11, 1, 500.00),
(20, 11, 1, 1, 500.00),
(21, 11, 12, 1, 500.00),
(22, 12, 3, 1, 3000.00),
(23, 12, 6, 1, 3000.00),
(24, 13, 1, 1, 500.00),
(25, 14, 3, 1, 3000.00),
(26, 14, 6, 1, 3000.00),
(27, 14, 8, 1, 3000.00),
(28, 15, 29, 1, 3500.00),
(29, 16, 47, 1, 2100.00);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`customer_id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- Indexes for table `dresses`
--
ALTER TABLE `dresses`
  ADD PRIMARY KEY (`dress_id`);

--
-- Indexes for table `dress_inventory`
--
ALTER TABLE `dress_inventory`
  ADD PRIMARY KEY (`inventory_id`),
  ADD UNIQUE KEY `uq_dress_size` (`dress_id`,`size`);

--
-- Indexes for table `rentals1`
--
ALTER TABLE `rentals1`
  ADD PRIMARY KEY (`rental_id`),
  ADD KEY `fk_rentals1_customer` (`customer_id`);

--
-- Indexes for table `rental_details`
--
ALTER TABLE `rental_details`
  ADD PRIMARY KEY (`rental_detail_id`),
  ADD KEY `fk_rentaldetails_rentals1` (`rental_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `customers`
--
ALTER TABLE `customers`
  MODIFY `customer_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `dresses`
--
ALTER TABLE `dresses`
  MODIFY `dress_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT for table `dress_inventory`
--
ALTER TABLE `dress_inventory`
  MODIFY `inventory_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=48;

--
-- AUTO_INCREMENT for table `rentals1`
--
ALTER TABLE `rentals1`
  MODIFY `rental_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT for table `rental_details`
--
ALTER TABLE `rental_details`
  MODIFY `rental_detail_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=30;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `dress_inventory`
--
ALTER TABLE `dress_inventory`
  ADD CONSTRAINT `fk_dress_id` FOREIGN KEY (`dress_id`) REFERENCES `dresses` (`dress_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `rentals1`
--
ALTER TABLE `rentals1`
  ADD CONSTRAINT `fk_rentals1_customer` FOREIGN KEY (`customer_id`) REFERENCES `customers` (`customer_id`) ON UPDATE CASCADE;

--
-- Constraints for table `rental_details`
--
ALTER TABLE `rental_details`
  ADD CONSTRAINT `fk_rentaldetails_rentals1` FOREIGN KEY (`rental_id`) REFERENCES `rentals1` (`rental_id`) ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
