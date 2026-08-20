# Healthcare Appointment System

A personal portfolio project built with C# and ASP.NET Core Web API to demonstrate backend development, RESTful API design, Entity Framework Core, and MySQL database integration.

## Project Status

**In Development**

The project currently includes CRUD functionality for departments, providers, and patients. Appointment management and additional application features are planned for future development.

## Technologies

- C#
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- MySQL
- Pomelo.EntityFrameworkCore.MySql
- Swagger / OpenAPI
- Git / GitHub

## Current Features

- Department CRUD operations
- Provider CRUD operations
- Patient CRUD operations
- Entity Framework Core database integration
- MySQL relational database
- RESTful API endpoints
- Swagger/OpenAPI API documentation
- Basic relationship mapping between entities
- Secure local database credentials using .NET User Secrets

## Planned Features

- Appointment management
- Appointment scheduling business rules
- DTOs for API requests and responses
- Service layer
- Input validation
- Improved error handling
- Automated unit tests
- Continuous Integration with GitHub Actions

## Architecture

The application currently follows a simple ASP.NET Core Web API structure:

- Controllers/ — API controllers and HTTP endpoints
- Data/ — Entity Framework Core database context
- Models/ — Domain entities
- DTOs/ — Planned data transfer objects
- Services/ — Planned business logic layer
- Tests/ — Planned automated tests

## API Documentation

When running locally, Swagger is available at:

http://localhost:5230/swagger

## Database

The application uses MySQL with a database named:

healthcare_appointments

The project is intended for educational and portfolio purposes. All healthcare-related data used during development is fictional test data.

## Security

Database credentials are not stored in the source code. Local development credentials are managed using the .NET User Secrets feature.

Never commit passwords, API keys, connection strings containing credentials, or other sensitive information to the repository.

## Disclaimer

This is a personal educational portfolio project and is not intended for use in a clinical or production healthcare environment. It does not contain real patient information or protected health information (PHI).

## Author

Personal software development portfolio project.
