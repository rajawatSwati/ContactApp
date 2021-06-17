# ContactApp- Web Application Project in ASP.NET MVC and Web API

Project Name: - ContactApp
This application is for maintaining contact information.

Below are the lists of workflows:
-	List contacts – will display the list of contacts in the system
-	Add a contact – to create new contact in the system
-	Edit contact – to edit existing contact
-	Delete a contact – to delete the contact

Below details will be captured in the system:
-	First Name – Required field
-	Last Name – Required field
-	Email – Required field
-	Phone Number – Optional field
-	Status (Active/Inactive)

Validations:
-	Required field validations
-	Email format validation
-	Phone Number format validation

Structure of Project:

The web application is built using ASP.NET MVC and the web API is consumed in this project for different CRUD  operations.
Below are the three projects in the ContactApp.sln
-	App.Api – Rest API
-	ContactWebApp – Web application
-	ContactWebApp.Test – Test Project for web application

Structure of App.Api project:
-	App_Start – Config files
    -	UnityConfig.cs  - Unity container for dependency Injection
    - WebApiConfig.cs  - to define route template and default route 
-	Controllers – Api controller (endpoints for different crud operations)
-	DB – Repository and DB mapping class
-	Models – Entity class
-	Services – Service class (Mediator between the controller endpoint and the repository)
-	ORM(object-relational mapper) : NHibernet

Structure of ContactWebApp project:
-	App_Start – RouteConfig.cs
-	Controllers – MVC controller
-	Models – View model
-	Views – Different view for crud operations (List, Create, Edit and Delete)

ContactWebApp.Test – Default MSTest and Moq framework for unit testing the application.

For steps to run this application in localhost - follow document 'StepsToRunApplication.docx'
