CREATE DATABASE Task1Cookbook_Kiselev; 

USE Task1Cookbook_Kiselev;

CREATE TABLE dbo.Dishes (
	DishID int PRIMARY KEY CLUSTERED IDENTITY(1,1),
	DishName nvarchar(50) NOT NULL
);

CREATE TABLE dbo.Units(
	UnitID INT PRIMARY KEY CLUSTERED IDENTITY(1,1),
	UnitName nvarchar(50) NOT NULL,
);

CREATE TABLE dbo.Ingredients(
	IngredientID INT PRIMARY KEY CLUSTERED IDENTITY(1,1),
	IngredientName nvarchar(50) NOT NULL,
	UnitID INT NOT NULL,
	UnitPrice INT NOT NULL,
	CONSTRAINT PriceMustBePositive CHECK (UnitPrice >= 0),
	CONSTRAINT FK_to_Units_UnitID FOREIGN KEY (UnitID) REFERENCES dbo.Units(UnitID)
);


CREATE TABLE dbo.IngredientsInDishes(
	DishID INT NOT NULL,
	IngredientID INT NOT NULL,
	Quantity INT NOT NULL,
	CONSTRAINT FK_to_Dishes_DishID FOREIGN KEY (DishID) REFERENCES dbo.Dishes(DishID),
	CONSTRAINT FK_to_Ingredients_IngredientID FOREIGN KEY (IngredientID) REFERENCES dbo.Ingredients(IngredientID),
	CONSTRAINT QuantityMustBePositive CHECK (Quantity >= 0),
);

ALTER TABLE dbo.Units ADD CONSTRAINT AK_UnitName UNIQUE(UnitName);
ALTER TABLE dbo.Dishes ADD CONSTRAINT AK_DishName UNIQUE(DishName);
ALTER TABLE dbo.Ingredients ADD CONSTRAINT AK_IngredientName UNIQUE(IngredientName);
ALTER TABLE dbo.IngredientsInDishes ADD CONSTRAINT AK_DishIngredientPair UNIQUE(DishID,IngredientID);

CREATE TABLE dbo.Orders(
	OrderID INT PRIMARY KEY CLUSTERED IDENTITY(1,1),
	OrderDate DATETIME not null,
	Total INT NOT NULL
);

CREATE TABLE dbo.OrdersDetails(
	OrderID INT NOT NULL,
	DishID INT NOT NULL,
	DishCount INT NOT NULL,
	CONSTRAINT FK_to_Orders_OrderID FOREIGN KEY (OrderID) REFERENCES dbo.Orders(OrderID),
	CONSTRAINT FK_from_Orders_to_Dishes_DishID FOREIGN KEY (DishID) REFERENCES dbo.Dishes(DishID)
);

ALTER TABLE dbo.OrdersDetails ADD CONSTRAINT AK_OrderDishPair UNIQUE(OrderID,DishID);

GO
CREATE PROCEDURE GetOrdersReport @dateFrom date,@dateTo date
AS
SELECT OrderID,OrderDate,Total FROM Orders where OrderDate >= @dateFrom AND OrderDate <= @dateTo;


