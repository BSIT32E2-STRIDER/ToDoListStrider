This project is a To-Do List application built using ASP.NET Core 8 and follows the Onion Architecture. The application uses an in-memory database for data persistence.

-Onion Architecture-

Onion Architecture is a Onion Architecture is a software architecture that adheres to the principles of separation of concerns and maintainability. 
It's composed of multiple concentric layers interfacing with each other towards the core. In this architecture, the inner layers are independent of the outer layers, meaning changes to the outer layers do not affect the inner ones.

-Layers-

1. Domain Layer (Core Layer): 
This is the inner-most layer and houses the business logic. It is independent of the other layers. It includes entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

2. Application Layer: This layer orchestrates the application's activity. It doesn't contain any business logic. It does, however, orchestrate the business objects to perform tasks for the application.

3. Infrastructure Layer: This layer provides generic technical capabilities that support the layers above it. It provides communication between layers through interfaces. In our case, it's where the in-memory database is implemented.

-In_Memory Database-

The application uses an in-memory database as its data store. An in-memory database is a database management system that primarily relies on main memory for computer data storage. 
It is contrasted with database management systems that employ a disk storage mechanism.In our application, we use it for simplicity and speed, as it allows us to perform CRUD operations without the need for setting up a physical database.
However, please note that the data in an in-memory database is temporary and will be lost once the application stops running.
