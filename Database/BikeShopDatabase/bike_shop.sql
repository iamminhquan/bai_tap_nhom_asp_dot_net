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
    ImageUrl NVARCHAR(255) NULL,
    Price DECIMAL(18, 2) NOT NULL,
    PromotionPrice DECIMAL(18, 2) NOT NULL,
    ProductDescription NVARCHAR(255) NULL,
    TagName NVARCHAR(100) NULL,
    CategoryId INT NOT NULL,                 -- FK to Categories
    States TINYINT NOT NULL DEFAULT 1,       -- 0 = Stopped, 1 = On Sale, 2 = Out of Stock, 3 = Hidden
    ProductType NVARCHAR(255) NOT NULL
);

-- ===========================================
-- TAG NAME
-- ===========================================
CREATE TABLE Tags (
    TagId INT PRIMARY KEY IDENTITY(1, 1),
    TagName NVARCHAR(100) NOT NULL
);

-- ===========================================
-- CATEGORIES
-- ===========================================
CREATE TABLE Categories (
    CategoryId INT PRIMARY KEY IDENTITY(1, 1),
    CategoryName NVARCHAR(100) NOT NULL,
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
-- USERS
-- ===========================================
CREATE TABLE Users (
    UserId INT IDENTITY PRIMARY KEY,
    Username NVARCHAR(100) NOT NULL,
    HashedPassword NVARCHAR(255) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Roles TINYINT NOT NULL, -- 0=Customer, 1=Staff, 2=Admin
    States TINYINT DEFAULT 1
);

-- ===========================================
-- CUSTOMERS
-- ===========================================
CREATE TABLE Customers (
    CustomerId INT IDENTITY PRIMARY KEY,
    UserId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId),
    Address NVARCHAR(255)
);

-- ===========================================
-- STAFFS
-- ===========================================
CREATE TABLE Staffs (
    StaffId INT IDENTITY PRIMARY KEY,
    UserId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId),
    StartDate DATETIME DEFAULT GETDATE(),
    Salary DECIMAL(18, 2)
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
    TotalAmount DECIMAL(18, 2) NOT NULL               -- Total payment
);

-- ===========================================
-- BILL DETAIL
-- ===========================================
CREATE TABLE BillDetail (
    OrderDetailId INT PRIMARY KEY IDENTITY(1, 1),
    OrderId INT NOT NULL,                    -- FK to Bills
    ProductId INT NOT NULL,                  -- FK to Products
    ProductName NVARCHAR(100) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    PromotionPrice DECIMAL(18, 2) NOT NULL,
    Quantity INT NOT NULL,
    TotalPrice DECIMAL(18, 2) NOT NULL
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
