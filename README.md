# API Project

## Project Overview
This API enables users to retrieve and manipulate information over HTTP about the employees within the Northwind database.

### Application Dependencies

| Dependency                                | Version           | Description                                            | Docs                                                                                     |
| ----------------------------------------  | -----------------| ------------------------------------------------------ | ---------------------------------------------------------------------------------------- |
| AspNetCore.Mvc.NewtonsoftJson             | v.7.0.5 or later | JSON support for ASP.NET Core MVC using Newtonsoft.Json library. | https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.NewtonsoftJson/           |
| AspNetCore.OpenApi                        | v.7.0.5 or later | Generate OpenAPI docs and UI for ASP.NET Core APIs.    | https://www.nuget.org/packages/Microsoft.AspNetCore.OpenApi/                          |
| EntityFrameworkCore                       | v.7.0.5 or later | ORM for database access in .NET apps.                 | https://www.nuget.org/packages/Microsoft.EntityFrameworkCore                          |
| EntityFrameworkCore.InMemory              | v.7.0.5 or later | In-memory database provider for testing and dev.      | https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.InMemory                 |                          |
| EntityFrameworkCore.SqlServer  | v.7.0.5  or later | SQL Server database provider for Entity Framework Core.                 | https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer          |                                    |
| EntityFrameworkCore.Tools        | v.7.0.5 or later | Tools for Entity Framework Core, including migrations and scaffolding.     | https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools |
| VisualStudio.Web.CodeGeneration.Design     | v.7.0.6 or later | Design-time tools for code generation in Visual Studio.        | https://www.nuget.org/packages/Microsoft.VisualStudio.Web.CodeGeneration.Design/       |
| Moq         | v4.18.4  or later | Mock object framework for .NET unit testing.      | https://www.nuget.org/packages/Moq        |
| Newtonsoft.Json    | v.13.0.3 or later | Popular JSON library for .NET applications.          | https://www.nuget.org/packages/Newtonsoft.Json/                             |
| Swashbuckle.AspNetCore       | v.6.5.0  or later | Generate OpenAPI docs and UI for ASP.NET Core APIs.      | https://www.nuget.org/packages/Swashbuckle.AspNetCore            |

## Setup

To setup the project, clone this repository and run Program.cs (make sure to execute the sql file in the root of this project to setup the Northwind database first).

## Endpoints
The endpoints implemented, following the CRUD approach, are as follows:
		    "rel": "self",
		    "method": "GET"
		},
		{
		    "href": "api/employees/3",
		    "rel": "update_employee",
		    "method": "PUT"
		},
		{
		    "href": "api/employees/3",
		    "rel": "delete_employee",
		    "method": "DELETE"
		}
	    ]
	}
	```
	
- `POST` Employee: Creation of a new employee
	* `http://localhost/api/Employees`
	* Must include First and Last Name (other fields are optional)
	* Example input:
	 ```JSON
	{
	  "lastName": "string",
	  "firstName": "string",
	  "title": "string",
	  "titleOfCourtesy": "string",
	  "birthDate": "2023-04-05T09:15:04.504Z",
	  "hireDate": "2023-04-05T09:15:04.504Z",
	  "address": "string",
	} 
	```

- `PUT` Employee Details: Updates the details of a specific employee
	* `http://localhost/api/employees/{employeeId}`
	* Example input:
	```JSON
	{
- `POST` Employee: Creation of a new employee
	* `http://localhost/api/Employees`
	* Must include First and Last Name (other fields are optional)
	* Example input:
	 ```JSON
	{
	  "lastName": "string",
	  "firstName": "string",
	  "title": "string",
	  "titleOfCourtesy": "string",
	  "birthDate": "2023-04-05T09:15:04.504Z",
	  "hireDate": "2023-04-05T09:15:04.504Z",
	  "address": "string",
	} 
	```
	{
	      "employeeId": 20,
	      "lastName": "string",
	      "firstName": "string",
	      "title": "string",
	      "titleOfCourtesy": "string",
	}
	```
	
- `DELETE` Employee: Deletion of an existing employee
	* `http://localhost/api/Employees/{employeeId}`
	
	
## Contributors
 - [Matthew Handley](https://github.com/MHandley10) - Testing and Model Architecture
 - [Ahmed Idris](https://github.com/coffeeandcodee) - GET Methods and Services Deployment
 - [Daniel Manu](https://github.com/DanielManuM) - Scrum Master
 - [Philip Thomas](https://github.com/philipthomas6w) - Repositories Implementation
 - [Ahmed Bader](https://github.com/AhmedBader97) - POST and PUT Methods
 - [Vlad Stoyanov](https://github.com/VladStoyanovADP) - Testing, DELETE Method and HATEOAS Implementation

## Related


## Related
[Trello board](https://trello.com/b/qw9za4x1/apiproject)

[Retrospective](https://metroretro.io/BOI6HWNUEIKP)

[Retrospective](https://metroretro.io/BOI6HWNUEIKP)

[Presentation](https://www.canva.com/design/DAFiKdYun6E/NfkBmC7xZGBs0W-ttJipAw/view?utm_content=DAFiKdYun6E&utm_campaign=designshare&utm_medium=link&utm_source=publishsharelink)
