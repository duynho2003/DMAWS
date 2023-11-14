CREATE TABLE Customers
(      
    CustomerID INTEGER PRIMARY KEY IDENTITY(1,1),
    CustomerName VARCHAR(60),
    CustomerAddress VARCHAR(150),
	CustomerPhone VARCHAR(20),
);
GO

CREATE TABLE Orders(
    OrderID INTEGER PRIMARY KEY IDENTITY(10248,1),
	OrderDate DATETIME,
    CustomerID INTEGER,
	ProductName VARCHAR(50),
	Price decimal(15,2),
	Quantity int,
    FOREIGN KEY (CustomerID) REFERENCES Customers (CustomerID),
);
GO