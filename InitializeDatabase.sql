DROP DATABASE recipes

CREATE DATABASE recipes
GO

DROP TABLE recipes.dbo.Recipes

CREATE TABLE recipes.dbo.Recipes
(
	[Id] INT NOT NULL,
	[Name] VARCHAR(255) NOT NULL,
	[Style] VARCHAR(255) NOT NULL,
	[Notes] VARCHAR(1024) NULL,
	[BrewDate] DATETIME NULL,
	[OriginalGravity] DECIMAL (18, 3) NULL,
	[FinalGravity] DECIMAL (18, 3) NULL,
	[ABV] DECIMAL (18, 3) NOT NULL,
	[IBU] DECIMAL (18, 3) NULL,
	[SRM] DECIMAL (18, 3) NULL,
    [Carbs] DECIMAL (18, 3) NULL,
    [Calories] INT NULL,
    [Efficiency] DECIMAL (18, 3) NULL,
	CONSTRAINT [recipes_pk] PRIMARY KEY ([Id])
)

GO

INSERT INTO recipes.Recipes(Id, Name, Style, ABV)
VALUES (123456, 'La Saison', 'Saison', 8.6);

GO