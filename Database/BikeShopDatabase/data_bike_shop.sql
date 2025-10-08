-----Thêm dữ liệu vào các bảng
-- ===========================================
-- CATEGORIES
-- ===========================================
INSERT INTO Categories (CategoryName, ParentId, States, Slug) VALUES
-- Level 1
(N'BICYCLES', NULL, 1, 'bicycles'),
(N'PARTS', NULL, 1, 'parts'),
(N'ACCESSORIES', NULL, 1, 'accessories'),
(N'EXTRAS', NULL, 1, 'extras'),

-- Level 2 - BICYCLES
(N'FIXED / SINGLE SPEED', 1, 1, 'fixed-single-speed'),
(N'CITY BIKES', 1, 1, 'city-bikes'),
(N'PREMIUM SERIES', 1, 1, 'premium-series'),

-- Level 2 - PARTS
(N'CHAINS', 2, 1, 'chains'),
(N'TUBES', 2, 1, 'tubes'),
(N'TIRES', 2, 1, 'tires'),
(N'DISC BREAKS', 2, 1, 'disc-breaks'),

-- Level 2 - ACCESSORIES
(N'LOCKS', 3, 1, 'locks'),
(N'HELMETS', 3, 1, 'helmets'),
(N'ARM COVERS', 3, 1, 'arm-covers'),
(N'JERSEYS', 3, 1, 'jerseys'),

-- Level 2 - EXTRAS
(N'CLASSIC BELL', 4, 1, 'classic-bell'),
(N'BOTTLE CAGE', 4, 1, 'bottle-cage'),
(N'TRUCK GRIP', 4, 1, 'truck-grip');

-- ===========================================
-- TAG NAME
-- ===========================================
INSERT INTO TagName (NameTag)
VALUES
(N'Hot'), (N'Sale'), (N'New'), (N'Best Seller'), (N'Limited');

-- ===========================================
-- PRODUCTS
-- ===========================================
INSERT INTO Products (ProductName, Price, PromotionPrice, ProductDescription, TagName, CategoryId, States)
VALUES
-- BICYCLES (Bicycles = 1)
-- MOUNTAIN BIKES (CategoryId = 5)
(N'Mountain Bike Alpha', 750.00, 699.00, N'Strong alloy frame, 27 gears, durable tires.', N'Mountain', 5, 1),
(N'Mountain Bike GreenX', 780.00, 720.00, N'Lightweight frame, Shimano gears, disc brakes.', N'Mountain', 5, 1),
(N'Mountain Bike SkyBlue', 820.00, 770.00, N'Perfect for off-road rides, hydraulic brakes.', N'Mountain', 5, 1),
(N'Mountain Bike Shadow', 890.00, 850.00, N'Carbon fork, strong grip tires.', N'Mountain', 5, 1),

-- SINGLE SPEED BIKES (CategoryId = 5)
(N'Single Speed Aero', 400.00, 350.00, N'Simple and sleek design for city use.', N'SingleSpeed', 5, 1),
(N'Single Speed Racer', 420.00, 370.00, N'Classic single speed with lightweight frame.', N'SingleSpeed', 5, 1),
(N'Single Speed Metro', 450.00, 390.00, N'Urban style, minimal maintenance.', N'SingleSpeed', 5, 1),
(N'Single Speed WhiteLine', 480.00, 420.00, N'Elegant white design for smooth riding.', N'SingleSpeed', 5, 1),

-- ROAD BIKES (CategoryId = 6)
(N'Road Bike Flash', 950.00, 899.00, N'Light carbon frame, 18 gears, fast performance.', N'Road', 6, 1),
(N'Road Bike Sprint', 980.00, 930.00, N'Perfect for long distance rides and speed.', N'Road', 6, 1),
(N'Road Bike OrangeX', 1020.00, 950.00, N'High traction tires, aerodynamic design.', N'Road', 6, 1),
(N'Road Bike SilverWing', 1100.00, 1049.00, N'Premium road bike with race-level parts.', N'Road', 6, 1),
-- ===========================
-- PARTS (Parent = 2)
-- ===========================
(N'KMC Z8.3 Bike Chain', 12.99, 10.99, N'Durable 8-speed chain for city and mountain bikes.', N'chain', 8, 1),
(N'Shimano CN-HG601 Chain', 24.99, 19.99, N'Shimano 11-speed chain with SIL-TEC coating.', N'chain', 8, 1),
(N'Schwalbe Inner Tube 700x23C', 7.99, 6.49, N'High-quality road bike inner tube with Presta valve.', N'tube', 9, 1),
(N'Michelin Airstop Tube 26x1.75', 6.49, 5.49, N'Durable inner tube for MTB bikes.', N'tube', 9, 1),
(N'Continental Grand Prix 5000 Tire', 64.99, 59.99, N'Performance road tire with excellent grip and durability.', N'tire', 10, 1),
(N'Maxxis Minion DHF Tire 27.5"', 59.99, 54.99, N'MTB tire designed for aggressive trail riding.', N'tire', 10, 1),
(N'Shimano XT Disc Brake Set', 89.99, 79.99, N'Hydraulic disc brake for powerful stopping performance.', N'disc-brake', 11, 1),
(N'Tektro HD-M275 Disc Brake', 74.50, 69.00, N'Affordable hydraulic brake set for beginners.', N'disc-brake', 11, 1),
(N'SRAM Centerline Rotor 160mm', 29.90, 24.99, N'Smooth braking and low vibration rotor.', N'disc-brake', 11, 1),
(N'Shimano BR-MT200 Brake Pads', 12.50, 10.99, N'Replacement pads for disc brakes.', N'disc-brake', 11, 1),

-- ===========================
-- ACCESSORIES (Parent = 3)
-- ===========================
(N'ABUS Steel-O-Chain 5805C Lock', 34.99, 29.99, N'Combination chain lock for everyday use.', N'lock', 12, 1),
(N'Kryptonite Keeper U-Lock', 49.99, 44.99, N'Strong U-lock with key system for high security.', N'lock', 12, 1),
(N'Giro Fixture Helmet', 54.99, 49.99, N'Lightweight helmet with adjustable fit system.', N'helmet', 13, 1),
(N'POC Omne Air Spin Helmet', 139.99, 129.99, N'Premium safety helmet for road cycling.', N'helmet', 13, 1),
(N'SunSleeve Arm Covers', 19.99, 15.99, N'UV-protection arm sleeves for sunny rides.', N'arm-cover', 14, 1),
(N'Castelli UPF 50+ Arm Sleeves', 34.99, 29.99, N'Comfortable cooling arm covers with UPF 50+.', N'arm-cover', 14, 1),
(N'Rapha Pro Team Jersey', 119.00, 109.00, N'Performance cycling jersey with aerodynamic fit.', N'jersey', 15, 1),
(N'Giant Team Jersey', 59.00, 54.00, N'Breathable jersey ideal for long summer rides.', N'jersey', 15, 1),
(N'Specialized BG Gel Gloves', 29.90, 24.90, N'Comfortable gloves with gel padding for shock absorption.', N'gloves', 15, 1),
(N'Lezyne Macro Drive 1300XL Light', 74.90, 69.90, N'Bright front light for night rides.', N'light', 15, 1),

-- ===========================
-- EXTRAS (Parent = 4)
-- ===========================
(N'Classic Chrome Bell', 8.99, 7.99, N'Retro-style bell with clear tone.', N'classic-bell', 16, 1),
(N'Black Alloy Bottle Cage', 6.49, 5.49, N'Lightweight aluminum water bottle holder.', N'bottle-cage', 17, 1),
(N'Carbon Fiber Bottle Cage', 12.99, 10.99, N'Ultra-light carbon cage for road bikes.', N'bottle-cage', 17, 1),
(N'MTB Truck Grip Set', 9.50, 8.49, N'Anti-slip grips for mountain bike handlebars.', N'truck-grip', 18, 1),
(N'Adjustable Bike Stand', 24.99, 21.99, N'Stable aluminum stand for garage or shop use.', N'stand', 18, 1),
(N'Portable Mini Pump', 15.99, 13.99, N'Pocket-sized pump with high pressure capability.', N'pump', 18, 1),
(N'Compact Repair Kit', 18.99, 15.99, N'Includes patches, levers, and mini tools.', N'repair-kit', 18, 1),
(N'Universal Mudguard Set', 14.50, 12.50, N'Front and rear mudguard kit fits most bikes.', N'mudguard', 18, 1),
(N'Round Rearview Mirror', 9.90, 8.90, N'360-degree adjustable handlebar mirror.', N'mirror', 18, 1),
(N'Front Basket Classic', 22.50, 19.99, N'Front-mounted basket ideal for city commuting.', N'basket', 18, 1);

-- ===========================================
-- SAMPLE DATA FOR PRODUCTS TABLE
-- ===========================================

SELECT * FROM Products

-- ===========================================
-- PRODUCT IMAGES
-- ===========================================
INSERT INTO ProductImages (ProductId, ImageUrl, SortOrder)
VALUES
-- MOUNTAIN BIKES
(1, N'/images/bik1.jpg', 1),
(1, N'/images/bik1.jpg', 2),
(1, N'/images/bik1.jpg', 3),

(2, N'/images/bik1.jpg', 1),
(2, N'/images/bik1.jpg', 2),
(2, N'/images/bik1.jpg', 3),

(3, N'/images/bik1.jpg', 1),
(3, N'/images/bik1.jpg', 2),
(3, N'/images/bik1.jpg', 3),

(4, N'/images/bik1.jpg', 1),
(4, N'/images/bik1.jpg', 2),
(4, N'/images/bik1.jpg', 3),

-- SINGLE SPEED
(5, N'/images/bik1.jpg', 1),
(5, N'/images/bik1.jpg', 2),
(5, N'/images/bik1.jpg', 3),

(6, N'/images/bik1.jpg', 1),
(6, N'/images/bik1.jpg', 2),
(6, N'/images/bik1.jpg', 3),

(7, N'/images/bik1.jpg', 1),
(7, N'/images/bik1.jpg', 2),
(7, N'/images/bik1.jpg', 3),

(8, N'/images/bik1.jpg', 1),
(8, N'/images/bik1.jpg', 2),
(8, N'/images/bik1.jpg', 3),

-- ROAD BIKES
(9, N'/images/bik1.jpg', 1),
(9, N'/images/bik1.jpg', 2),
(9, N'/images/bik1.jpg', 3),

(10, N'/images/bik1.jpg', 1),
(10, N'/images/bik1.jpg', 2),
(10, N'/images/bik1.jpg', 3),

(11, N'/images/bik1.jpg', 1),
(11, N'/images/bik1.jpg', 2),
(11, N'/images/bik1.jpg', 3),

(12, N'/images/bik1.jpg', 1),
(12, N'/images/bik1.jpg', 2),
(12, N'/images/bik1.jpg', 3),

-- ===========================
-- PARTS (ProductId 13–22)
-- ===========================

(13, N'/images/bik1.jpg', 1),
(13, N'/images/bik1.jpg', 2),
(13, N'/images/bik1.jpg', 3),

(14, N'/images/bik1.jpg', 1),
(14, N'/images/bik1.jpg', 2),
(14, N'/images/bik1.jpg', 3),

(15, N'/images/bik1.jpg', 1),
(15, N'/images/bik1.jpg', 2),
(15, N'/images/bik1.jpg', 3),

(16, N'/images/bik1.jpg', 1),
(16, N'/images/bik1.jpg', 2),
(16, N'/images/bik1.jpg', 3),

(17, N'/images/bik1.jpg', 1),
(17, N'/images/bik1.jpg', 2),
(17, N'/images/bik1.jpg', 3),

(18, N'/images/bik1.jpg', 1),
(18, N'/images/bik1.jpg', 2),
(18, N'/images/bik1.jpg', 3),

(19, N'/images/bik1.jpg', 1),
(19, N'/images/bik1.jpg', 2),
(19, N'/images/bik1.jpg', 3),

(20, N'/images/bik1.jpg', 1),
(20, N'/images/bik1.jpg', 2),
(20, N'/images/bik1.jpg', 3),

(21, N'/images/bik1.jpg', 1),
(21, N'/images/bik1.jpg', 2),
(21, N'/images/bik1.jpg', 3),

(22, N'/images/bik1.jpg', 1),
(22, N'/images/bik1.jpg', 2),
(22, N'/images/bik1.jpg', 3),

-- ===========================
-- ACCESSORIES (ProductId 23–32)
-- ===========================
(23, N'/images/bik1.jpg', 1),
(23, N'/images/bik1.jpg', 2),
(23, N'/images/bik1.jpg', 3),

(24, N'/images/bik1.jpg', 1),
(24, N'/images/bik1.jpg', 2),
(24, N'/images/bik1.jpg', 3),

(25, N'/images/bik1.jpg', 1),
(25, N'/images/bik1.jpg', 2),
(25, N'/images/bik1.jpg', 3),

(26, N'/images/bik1.jpg', 1),
(26, N'/images/bik1.jpg', 2),
(26, N'/images/bik1.jpg', 3),

(27, N'/images/bik1.jpg', 1),
(27, N'/images/bik1.jpg', 2),
(27, N'/images/bik1.jpg', 3),

(28, N'/images/bik1.jpg', 1),
(28, N'/images/bik1.jpg', 2),
(28, N'/images/bik1.jpg', 3),

(29, N'/images/bik1.jpg', 1),
(29, N'/images/bik1.jpg', 2),
(29, N'/images/bik1.jpg', 3),

(30, N'/images/bik1.jpg', 1),
(30, N'/images/bik1.jpg', 2),
(30, N'/images/bik1.jpg', 3),

(31, N'/images/bik1.jpg', 1),
(31, N'/images/bik1.jpg', 2),
(31, N'/images/bik1.jpg', 3),

(32, N'/images/bik1.jpg', 1),
(32, N'/images/bik1.jpg', 2),
(32, N'/images/bik1.jpg', 3),

-- ===========================
-- EXTRAS (ProductId 33–42)
-- ===========================
(33, N'/images/bik1.jpg', 1),
(33, N'/images/bik1.jpg', 2),
(33, N'/images/bik1.jpg', 3),

(34, N'/images/bik1.jpg', 1),
(34, N'/images/bik1.jpg', 2),
(34, N'/images/bik1.jpg', 3),

(35, N'/images/bik1.jpg', 1),
(35, N'/images/bik1.jpg', 2),
(35, N'/images/bik1.jpg', 3),

(36, N'/images/bik1.jpg', 1),
(36, N'/images/bik1.jpg', 2),
(36, N'/images/bik1.jpg', 3),

(37, N'/images/bik1.jpg', 1),
(37, N'/images/bik1.jpg', 2),
(37, N'/images/bik1.jpg', 3),

(38, N'/images/bik1.jpg', 1),
(38, N'/images/bik1.jpg', 2),
(38, N'/images/bik1.jpg', 3),

(39, N'/images/bik1.jpg', 1),
(39, N'/images/bik1.jpg', 2),
(39, N'/images/bik1.jpg', 3),

(40, N'/images/bik1.jpg', 1),
(40, N'/images/bik1.jpg', 2),
(40, N'/images/bik1.jpg', 3),

(41, N'/images/bik1.jpg', 1),
(41, N'/images/bik1.jpg', 2),
(41, N'/images/bik1.jpg', 3),

(42, N'/images/bik1.jpg', 1),
(42, N'/images/bik1.jpg', 2),
(42, N'/images/bik1.jpg', 3);


-- ===========================================
-- STAFFS
-- ===========================================
INSERT INTO Staffs (StaffName, AccountName, AccountPassword, StaffAddress, PhoneNumber, Email, DateOfBirth, Gender, Salary, Roles)
VALUES
(N'John Nguyen', N'john_admin', N'123456', N'12 Le Loi St, HCMC', N'0901234567', N'john@bikeshop.com', '1990-03-15', N'MALE', 15000000, 0),
(N'Linda Nguyen', N'linda_staff', N'123456', N'45 Nguyen Hue St, HCMC', N'0902345678', N'linda@bikeshop.com', '1995-05-20', N'FEMALE', 9000000, 1);

-- ===========================================
-- CUSTOMERS
-- ===========================================
INSERT INTO Customers (CustomerName, CustomerUsername, CustomerPassword, CustomerAddress, PhoneNumber, Email, DateOfBirth, Gender)
VALUES
(N'William Le', N'william123', N'pass123', N'25 Ly Thuong Kiet St, HCMC', N'0911111111', N'william@gmail.com', '1999-10-10', N'MALE'),
(N'Sophia Pham', N'sophia98', N'pass123', N'56 Nguyen Trai St, Hanoi', N'0922222222', N'sophia@gmail.com', '1998-08-05', N'FEMALE');

SELECT * FROM Customers

-- ===========================================
-- BILLS
-- ===========================================
INSERT INTO Bills (ProductId, CustomerId, StaffId, TotalItems, TotalAmount)
VALUES
(1, 1, 1, 1, 7000000),
(2, 2, 2, 1, 13500000);

-- ===========================================
-- BILL DETAIL
-- ===========================================
INSERT INTO BillDetail (OrderId, ProductId, ProductName, Price, PromotionPrice, Quantity, TotalPrice)
VALUES
(1, 1, N'Asama MTB 27.5', 7500000, 7000000, 1, 7000000),
(2, 2, N'Giant TCR Road Bike', 15000000, 13500000, 1, 13500000);

-- ===========================================
-- REVIEWS
-- ===========================================
INSERT INTO Reviews (UserId, UserName, ParentId, Content, Email, ProductId)
VALUES
(1, N'William Le', NULL, N'Great product! Fast delivery.', N'william@gmail.com', 1),
(2, N'Sophia Pham', NULL, N'Lightweight and beautiful design.', N'sophia@gmail.com', 2);

-- ===========================================
-- WEB SETTINGS
-- ===========================================
INSERT INTO WebSettings (Logo, MaxSizeImage, SettingDescription, SettingURL, Header, Footer)
VALUES
(N'/images/logo_bikeshop.png', 2048, N'Website configuration for BikeShop', N'https://bikeshop.com', N'Welcome to BikeShop', N'© 2025 BikeShop. All rights reserved.');

