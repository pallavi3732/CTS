-- Create Database
CREATE DATABASE CTS_DeepSkilling;
GO

USE CTS_DeepSkilling;
GO

-- Products Table
CREATE TABLE Products
(
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10,2)
);

INSERT INTO Products VALUES
(1,'Laptop','Electronics',65000),
(2,'Mouse','Accessories',800),
(3,'Keyboard','Accessories',1500),
(4,'Monitor','Electronics',12000),
(5,'Printer','Office',9000),
(6,'Smart Phone','Electronics',45000),
(7,'Headphones','Accessories',2500),
(8,'Webcam','Accessories',3500);

--------------------------------------------------------

CREATE TABLE Customers
(
    CustomerID INT PRIMARY KEY,
    Name VARCHAR(100),
    Region VARCHAR(50)
);

INSERT INTO Customers VALUES
(101,'Rahul','South'),
(102,'Priya','North'),
(103,'Amit','East'),
(104,'Sneha','West'),
(105,'Kiran','South');

--------------------------------------------------------

CREATE TABLE Orders
(
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    OrderDate DATE,
    FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID)
);

INSERT INTO Orders VALUES
(1001,101,'2025-01-05'),
(1002,102,'2025-01-10'),
(1003,103,'2025-02-12'),
(1004,101,'2025-03-15'),
(1005,104,'2025-03-20'),
(1006,105,'2025-04-05'),
(1007,101,'2025-04-12'),
(1008,102,'2025-05-02');

--------------------------------------------------------

CREATE TABLE OrderDetails
(
    OrderDetailID INT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    FOREIGN KEY(OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY(ProductID) REFERENCES Products(ProductID)
);

INSERT INTO OrderDetails VALUES
(1,1001,1,2),
(2,1001,2,1),
(3,1002,3,2),
(4,1003,4,1),
(5,1004,5,1),
(6,1005,6,2),
(7,1006,7,3),
(8,1007,8,1),
(9,1008,1,1),
(10,1008,3,2);

PRINT 'Database Created Successfully';