# Recipe Box

#### An Epicodus two day project in CSharp xUnit testing

#### **By Jordan Loop and Andrew Glines**

## Description

This web application will allow a user to tag recipes.

|Behavior| Input (User Action/Selection) |Description|
|---|:---:|:---:|


## Setup/Installation Requirements

Must have current version of .Net and Mono installed. Will require database file to work correctly, see download instructions below.

Copy all files and folders to your desktop or {git clone} the project using this link DO NOT FORGET TO PUT LINK HERE.

To recreate the databases using SQLCMD in powershell on a windows operating system type:
* > create database recipebox > go
* > create table recipes (id INT IDENTITY(1,1), name VARCHAR(255), instructions VARCHAR(255)) > go
* > create table join_recipes_tags (id INT IDENTITY(1,1), id_recipes INT, id_tags INT) > go
* > create table tags (id INT IDENTITY(1,1), name VARCHAR(255))  > go
* > create table ingredients (id INT IDENTITY(1,1), name VARCHAR(255)) > go  
* > create table join_ingredients_recipes (id INT IDENTITY(1,1), id_ingredients INT, id_recipes INT) > go

Navigate to the folder in your Windows powershell and run {dnu restore} to compile the file then run {dnx kestrel} to start the web server. In your web browser address bar, navigate to {//localhost:5004} to get to the home page.

## Known Bugs

* No known bugs.

## Support and contact details

If you have any issues or have questions, ideas, concerns, or contributions please contact the contributor through Github.

## Technologies Used

* C#
* Nancy
* Razor
* xUnit
* JSON
* HTML
* CSS
* Bootstrap

### License
This software is licensed under the MIT license.

Copyright (c) 2017 **Jordan Loop, Andrew Glines, and Epicodus**
