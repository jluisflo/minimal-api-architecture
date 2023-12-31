![image](https://github.com/jluisflo/minimal-api-architecture/assets/77704331/eaf50219-e083-4219-985c-b5dcaf4a1ead)

# Minimal API Project

This is a minimal API project built with .NET 8.0 and C#. It uses a module-based structure with separate handlers for each operation.

## Description

The project includes modules for managing users, with handlers for adding, retrieving, and deleting users. Each handler is a static class with a single `Handle` method that performs the operation.

The project uses Mapster for object mapping, specifically for mapping between DTOs and data models. It also uses a custom repository pattern for data access, with a separate repository interface and implementation for users.

## Dependencies

- .NET 8.0
- Mapster
- FluentValidation
- EntityFramework InMemory
- Swagger (Swashbuckle)

## Setup

To run this project, you need .NET 8.0 SDK installed on your machine. Once installed, you can run the project using the `dotnet run` command in the root directory of the project.

## Usage

The API includes the following endpoints:

- `GET /users`: Retrieves all users.
- `GET /users/{id}`: Retrieves a user by ID.
- `POST /users`: Adds a new user.
- `DELETE /users/{id}`: Deletes a user by ID.

You can test these endpoints using a tool like Postman, or by using the included Swagger UI at `https://localhost:5001/swagger`.

## API Key Validation

This project uses an API key for authentication. The API key should be included in the header of each request with the key `X-API-KEY`.

The project includes a middleware that checks for the presence and validity of the API key in the request headers. If the API key is not provided or is invalid, the middleware returns a 401 Unauthorized status code. If the API key is valid, the request is allowed to proceed.

To configure the API key, you can set it in the `appsettings.json` file under the `ApiKeys` section.

To use the API key in Swagger, click the "Authorize" button in the Swagger UI and enter your API key. Swagger will include the `X-API-KEY` header in all requests.

## Contributing

This project is not currently accepting contributions.

## License

This project is licensed under the MIT License.
