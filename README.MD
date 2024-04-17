# Fast Endpoint Example

This is an example of an application developed with .NET 8 using FastEndpoint, Entity Framework, and CQRS.

## Installation

### Prerequisites

- [.NET SDK 8](https://dotnet.microsoft.com/download)

### Installation Steps

1. Clone this repository to your local machine:

    ```bash
    git clone https://github.com/your-username/fast-endpoint-example.git
    ```

2. Navigate to the project directory:

    ```bash
    cd fast-endpoint-example
    ```

3. Restore the NuGet packages:

    ```bash
    dotnet restore
    ```

4. Configure the connection string to your database in `appsettings.json`.

5. Start the application:

    ```bash
    dotnet run
    ```

## Migrations

1. Create a new migration:
    ```bash
    dotnet ef migrations add DatabaseInitialApproach --project ../Example.Infrastructure/Example.Infrastructure.csproj --startup-project ./
    ```

## Contribution

Contributions are welcome! If you wish to contribute to this project, follow these steps:

1. Create a new issue.
2. Fork the repository.
3. Create a branch for your feature: `git checkout -b feature/NewFeature`.
4. Make your changes and commit: `git commit -m 'Add a new feature'`.
5. Push the branch: `git push origin feature/NewFeature`.
6. Submit a pull request.

## License
This project is licensed under the [MIT License](https://opensource.org/licenses/MIT).
