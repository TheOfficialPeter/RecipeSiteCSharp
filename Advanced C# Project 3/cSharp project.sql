create database Recipes
GO

drop database Recipes 
GO

drop table Users
drop table RecipeInformation
drop table Recipes
GO

use Recipes
GO

create table Users(
email nchar(100),
username nchar(100) primary key,
password_ nchar(100),
security_ nchar(100)
)

create table Recipes(
recipeNum int primary key,
recipeName nchar(100),
recipeRating int,
recipeOwner nchar(100),
)

create table RecipeInformation(
recipeNum int,
recipeIngredients nchar(1000),
recipeMethod nchar(999)
)
GO