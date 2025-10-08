-- ProductImages → Products
ALTER TABLE ProductImages
ADD CONSTRAINT FK_ProductImages_Products
FOREIGN KEY (ProductId) REFERENCES Products(ProductId);

-- Products → Categories
ALTER TABLE Products
ADD CONSTRAINT FK_Products_Categories
FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId);

-- Reviews → Products
ALTER TABLE Reviews
ADD CONSTRAINT FK_Reviews_Products
FOREIGN KEY (ProductId) REFERENCES Products(ProductId);

-- Bills → Customers
ALTER TABLE Bills
ADD CONSTRAINT FK_Bills_Customers
FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId);

-- Bills → Staffs
ALTER TABLE Bills
ADD CONSTRAINT FK_Bills_Staffs
FOREIGN KEY (StaffId) REFERENCES Staffs(StaffId);

-- Bills → Products
ALTER TABLE Bills
ADD CONSTRAINT FK_Bills_Products
FOREIGN KEY (ProductId) REFERENCES Products(ProductId);

-- BillDetail → Bills
ALTER TABLE BillDetail
ADD CONSTRAINT FK_BillDetail_Bills
FOREIGN KEY (OrderId) REFERENCES Bills(OrderId);

-- BillDetail → Products
ALTER TABLE BillDetail
ADD CONSTRAINT FK_BillDetail_Products
FOREIGN KEY (ProductId) REFERENCES Products(ProductId);