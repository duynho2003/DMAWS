CREATE TABLE Categories
(      
    CategoryID INTEGER PRIMARY KEY identity(202301,1),
    CategoryName VARCHAR(50),
    [Description] VARCHAR(255)
);
GO
CREATE TABLE Products(
	ProductID INTEGER PRIMARY KEY identity(1001,1),
    ProductName VARCHAR(50),
    CategoryID INTEGER,
    Price NUMERIC,
	Quantity INTEGER,
	FOREIGN KEY (CategoryID) REFERENCES Categories (CategoryID),
);
----
INSERT INTO Categories VALUES('Dairy Products','Cheeses');
INSERT INTO Categories VALUES('Seafood','Seaweed and fish');
SELECT * FROM Categories
SELECT * FROM Products
----
INSERT INTO Products VALUES('Chais',202301,2000,18);
INSERT INTO Products VALUES('Chang',202301,1500,11);
INSERT INTO Products VALUES('Aniseed Syrup',202302,1700,10);