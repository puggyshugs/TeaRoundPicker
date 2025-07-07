# Tea Round Picker Backend

A .NET Core Web API implementing a clean architecture pattern for managing tea round participants and selections.
- [The client side React app can be found here](https://github.com/puggyshugs/WhoMakesTheTea)

## Architecture

The backend follows a layered architecture approach:

```
TeaRoundPicker.Api/          # API Controllers and HTTP handling
TeaRoundPicker.Services/     # Business logic and service layer
TeaRoundPicker.Domain/       # Domain models, enums, and business rules
```

## Technologies Used

- **.NET 8.0** - Runtime and framework
- **ASP.NET Core** - Web API framework
- **System.Security.Cryptography** - Secure random number generation
- **In-Memory Caching** - Data persistence during runtime

## Project Structure

```
backend/
├── TeaRoundPicker.Api/
│   ├── Controllers/
│   │   ├── ParticipantController.cs
│   │   └── SelectionController.cs
│   ├── Program.cs
│   └── appsettings.json
├── TeaRoundPicker.Services/
│   ├── CacheService.cs
|   ├── Cache/
|   |   ├── Cache.cs
|   |   └── Interfaces/
|   |       └── ICache.cs
│   ├── Helpers/
│   │   └── FairnessHelper.cs
│   └── Interfaces/
│       └── ICacheService.cs
├── TeaRoundPicker.Domain/
│   ├── Models/
│   │   └── Participant.cs
|   |   └── Selection.cs
│   └── Enums/
│       └── SuccessMessages.cs
└── TeaRoundPicker.Cache/
    ├── Cache.cs
    └── Interfaces/
        └── ICache.cs
```

## Setup and Installation

### Prerequisites
- .NET 9.0 SDK
- Visual Studio 2022 / VS Code / Similar

### Running the Application

1. **Navigate to the API directory**
   ```bash
   cd TeaRoundPicker.Api
   ```

2. **Restore NuGet packages**
   ```bash
   dotnet restore
   ```

3. **Build the solution**
   ```bash
   dotnet build
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

5. **Verify the API is running**
   - Navigate to `http://localhost:5027/index.html` for API documentation
   - Or test with `curl http://localhost:5027/api/participant/getAll`

## API Endpoints

### Participant Management

#### Get All Participants
```http
GET /api/participant/getAll
```
Returns a list of all participants.

#### Get Specific Participant
```http
GET /api/participant/get/{name}
```
Returns a specific participant by name.

#### Create Single Participant
```http
POST /api/participant/create
Content-Type: application/json

"John Doe"
```
Creates a new participant with the given name.

#### Create Multiple Participants
```http
POST /api/participant/createMultiple
Content-Type: application/json

["Alice", "Bob", "Charlie"]
```
Creates multiple participants. All names must be unique.

### Selection

#### Select Random Participant
```http
GET /api/selection/select
```
Randomly selects a participant from all available participants.

## Key Components

### CacheService
Manages participant data through an in-memory cache. Handles:
- Participant creation and retrieval
- Duplicate name validation
- Data persistence during application runtime

### FairnessHelper
Provides cryptographically secure random selection using `System.Security.Cryptography.RandomNumberGenerator` to ensure fair participant selection.

### Controllers
- **ParticipantController**: Manages CRUD operations for participants
- **SelectionController**: Handles random participant selection

## Configuration

The application uses default ASP.NET Core configuration. Key settings:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

## Error Handling

The API implements comprehensive error handling:
- **400 Bad Request**: Invalid input data
- **404 Not Found**: Participant not found
- **409 Conflict**: Duplicate participant names
- **500 Internal Server Error**: Unexpected errors

## Security Considerations

- Uses cryptographically secure random number generation
- Input validation on all endpoints
- No sensitive data stored or transmitted
- CORS configured for frontend communication

## Development

### Adding New Features

1. **Domain Layer**: Add new models or enums to `TeaRoundPicker.Domain`
2. **Service Layer**: Implement business logic in `TeaRoundPicker.Services`
3. **API Layer**: Add new controllers or endpoints in `TeaRoundPicker.Api`

### Code Style

- Follow C# naming conventions
- Use dependency injection for service resolution
- Implement proper error handling and logging
- Write unit tests for new functionality

## Dependencies

- **Microsoft.AspNetCore.App** - Core ASP.NET functionality
- **System.Security.Cryptography** - Secure random number generation
