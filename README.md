# <h1 align = "center"> Factory

## <h3 align = "center"> Entity Framework in ASP.NET MVC, Many to Many Relationships 8.7.20

## <h2 align = "center"> About

<p align = "center"> This is an application for a factory. The user may create new machines and engineers, and connect those objects with a many to many relationship.

## **✅REQUIREMENTS**
* Install [Git v2.62.2+](https://git-scm.com/downloads/)
* Install [.NET version 3.1 SDK v2.2+](https://dotnet.microsoft.com/download/dotnet-core/2.2)
* Install [Visual Studio Code](https://code.visualstudio.com/)
* Install [MySql Workbench](https://www.mysql.com/products/workbench/)

## **💻SETUP**
* to clone this content, copy the url provided by the green 'Code' button in GitHub
* in command line use the command 'git clone (GitHub url)'
* open the program in a code editor
* navigate to the Factory directory and type dotnet build in the command line to compile the code
* remaining in the Factory directory type dotnet ef database update to create the database
* type dotnet run in the command line to run the program


## 🔍Specs

| Behavior    | Input | Output |
| :---------- | ----- | -----: |
| Program can create an Engineer object | none | none |
| Engineer object holds engineer name and machines they are licensed to repair | none | none |
| Program can show list of all engineers | none | list |
| Program can show engineer details, including machines they are licensed to repair | none | none |
| Program can create new engineers | none | none |
| Program can create a Machine object | none | none |
| Machine object holds machine name and engineers licensed to repair them | none | none |
| Program can show list of all machines | none | list |
| Program can show machine details, including engineers licensed to repair them | none | none |
| Program can create new machines | none | none |
| Engineer <=> Machine reflects many to many relationship | none | none |
| Join relationships between Engineer & Machine can be added or deleted | none | none |

As a patron, I want to check a book out, so that I can take it home with me.

As a patron, I want to know how many copies of a book are on the shelf, so that I can see if any are available. (Hint: make a copies table; a book should have many copies.)

- a search to find a book. 
- in details of a book - show how many copies of a book there are left
- where are we adding copies?(ie into our copies table) on our website.  
    - in copies create, viewbagbookname and "add/submit" a copy in the table.
- 
-be able to obtain and pass a copyId.
-be able to find first copyid that isnt already checked out. in controller.
-change that copyid record to true.
-

## 🐛Known Bugs

_No known bugs_

## 📫Support and contact details

Contact : Megan Hepner

## 🔧Technologies Used

* C#
* ASP.NET MVC
* Entity
* MySql


## **📘 License**
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

