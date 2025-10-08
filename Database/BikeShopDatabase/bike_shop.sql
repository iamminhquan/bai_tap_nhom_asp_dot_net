CREATE DATABASE BikeShop;
GO

USE BikeShop;
GO

-- ===========================================
-- PRODUCTS
-- ===========================================
CREATE TABLE Products (
    ProductId INT PRIMARY KEY IDENTITY(1, 1),
    ProductName NVARCHAR(100) NOT NULL,
    Price MONEY NOT NULL,
    PromotionPrice MONEY NOT NULL,
    ProductDescription NVARCHAR(255) NULL,
    TagName NVARCHAR(100) NULL,
    CategoryId INT NOT NULL,                 -- FK to Categories
    States TINYINT NOT NULL DEFAULT 1        -- 0 = Stopped, 1 = On Sale, 2 = Out of Stock, 3 = Hidden
);

-- ===========================================
-- PRODUCT IMAGES
-- ===========================================
CREATE TABLE ProductImages (
    ImageId INT PRIMARY KEY IDENTITY(1, 1),
    ProductId INT NOT NULL,                  -- FK to Products
    ImageUrl NVARCHAR(255) NOT NULL,         -- Image link
    SortOrder INT DEFAULT 0,                 -- Used to sort images
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);

-- ===========================================
-- TAG NAME
-- ===========================================
CREATE TABLE TagName (
    TagId INT PRIMARY KEY IDENTITY(1, 1),
    NameTag NVARCHAR(100) NOT NULL
);

-- ===========================================
-- CATEGORIES
-- ===========================================
CREATE TABLE Categories (
    CategoryId INT PRIMARY KEY IDENTITY(1, 1),
    CategoryName NVARCHAR(100) NOT NULL,
    ParentId INT NULL,
    States TINYINT NOT NULL DEFAULT 1,       -- 0 = Stopped, 1 = On Sale, 2 = Out of Stock, 3 = Hidden
    Slug NVARCHAR(150) NULL
);

-- ===========================================
-- REVIEWS
-- ===========================================
CREATE TABLE Reviews (
    ReviewId INT PRIMARY KEY IDENTITY(1, 1),
    UserId INT NULL,
    UserName NVARCHAR(100) NOT NULL,
    ParentId INT NULL,
    Content TEXT NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    DateTimes DATE NOT NULL DEFAULT GETDATE(),
    ProductId INT NOT NULL                   -- FK to Products
);

-- ===========================================
-- STAFFS
-- ===========================================
CREATE TABLE Staffs (
    StaffId INT PRIMARY KEY IDENTITY(1, 1),
    StaffName NVARCHAR(100) NOT NULL,
    AccountName NVARCHAR(50) NOT NULL UNIQUE,
    AccountPassword NVARCHAR(255) NOT NULL,
    StaffAddress NVARCHAR(255) NOT NULL,
    PhoneNumber NVARCHAR(10) NOT NULL,
    Email NVARCHAR(50) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Gender NVARCHAR(6) DEFAULT N'MALE',
    StartDate DATE NOT NULL DEFAULT GETDATE(),
    Salary MONEY NOT NULL,
    States TINYINT NOT NULL DEFAULT 1,       -- 0 = Inactive, 1 = Active
    Roles TINYINT NOT NULL                   -- Role = Admin or Staff
);

-- ===========================================
-- CUSTOMERS
-- ===========================================
CREATE TABLE Customers (
    CustomerId INT PRIMARY KEY IDENTITY(1, 1),
    CustomerName NVARCHAR(100) NOT NULL,
    CustomerUsername NVARCHAR(50) NOT NULL UNIQUE,
    CustomerPassword NVARCHAR(255) NOT NULL,
    CustomerAddress NVARCHAR(255) NOT NULL,
    PhoneNumber NVARCHAR(10) NOT NULL,
    Email NVARCHAR(50) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Gender NVARCHAR(6) DEFAULT N'MALE',
    States TINYINT NOT NULL DEFAULT 1        -- 0 = Inactive, 1 = Active
);

-- ===========================================
-- BILLS (ORDERS)
-- ===========================================
CREATE TABLE Bills (
    OrderId INT PRIMARY KEY IDENTITY(1, 1),
    ProductId INT NOT NULL,                  -- FK to Products
    CustomerId INT NOT NULL,                 -- FK to Customers
    StaffId INT NOT NULL,                    -- FK to Staffs
    OrderDate DATETIME NOT NULL DEFAULT GETDATE(),
    TotalItems INT NOT NULL,                 -- Total quantity
    TotalAmount MONEY NOT NULL               -- Total payment
);

-- ===========================================
-- BILL DETAIL
-- ===========================================
CREATE TABLE BillDetail (
    OrderDetailId INT PRIMARY KEY IDENTITY(1, 1),
    OrderId INT NOT NULL,                    -- FK to Bills
    ProductId INT NOT NULL,                  -- FK to Products
    ProductName NVARCHAR(100) NOT NULL,
    Price MONEY NOT NULL,
    PromotionPrice MONEY NOT NULL,
    Quantity INT NOT NULL,
    TotalPrice MONEY NOT NULL
);

-- ===========================================
-- WEB SETTINGS
-- ===========================================
CREATE TABLE WebSettings (
    SettingId INT PRIMARY KEY IDENTITY(1, 1),
    Logo NVARCHAR(255) NOT NULL,
    MaxSizeImage INT NOT NULL,
    SettingDescription NVARCHAR(255) NULL,
    SettingURL NVARCHAR(255) NOT NULL,
    Header NVARCHAR(255) NOT NULL,
    Footer NVARCHAR(255) NOT NULL
);
