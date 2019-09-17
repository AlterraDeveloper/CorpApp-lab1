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