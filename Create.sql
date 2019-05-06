DROP TABLE Everything
DROP TABLE Cart
DROP TABLE [Order]
DROP TABLE Product
DROP TABLE Customer


CREATE TABLE Customer(
custId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
firstName NVARCHAR(50),
lastName NVARCHAR(50),
phoneNumber NVARCHAR(12)
)

CREATE TABLE Product(
prodId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
prodName NVARCHAR(100),
price DECIMAL(19,2) NOT NULL,
prodWeight DECIMAL(19,6) NOT NULL,
inStock BIT NOT NULL
)

CREATE TABLE [Order](
orderId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
custId INT NOT NULL,
poNumber NVARCHAR(30),
orderDate DATETIME,

FOREIGN KEY(custId) REFERENCES Customer(custId)
)

CREATE TABLE Cart(
orderId INT NOT NULL,
prodId INT NOT NULL,
quantity INT,

PRIMARY KEY(orderId, prodId),
FOREIGN KEY(orderId) REFERENCES [Order](orderId),
FOREIGN KEY(prodId) REFERENCES Product(prodId)
)

CREATE TABLE Everything(
custId INT NOT NULL,
prodId INT NOT NULL,
orderId INT NOT NULL,

cartOrderId INT NOT NULL,
cartProdId INT NOT NULL,

FOREIGN KEY(custId) REFERENCES Customer(custId),
FOREIGN KEY(prodId) REFERENCES Product(prodId),
FOREIGN KEY(orderId) REFERENCES [Order](orderId),

FOREIGN KEY(cartOrderId,cartProdId) REFERENCES Cart(orderId,prodId)--,
--FOREIGN KEY(cartProdId) REFERENCES Cart(prodId),
)