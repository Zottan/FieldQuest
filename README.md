# FieldQuest

**A learning-oriented C# and .NET project for recording wildlife observations.**

FieldQuest is a console application built with C# and .NET. It allows users to record wildlife observations, browse previously recorded entries, and view basic statistics.

The project is developed incrementally as a hands-on learning journey through modern C#, object-oriented programming, software architecture, persistence, testing, and eventually web API development.

## Current Features

- Record wildlife observations with species, observer, and individual count.
- Calculate points for each observation.
- List recorded observations.
- Display summary statistics.
- Persist observations in a local JSON file.
- Load previously saved observations when the application starts.
- Separate the user interface, business logic, and persistence layer.

## Technology Stack

- C#
- .NET SDK
- `System.Text.Json`
- Git and GitHub

## Project Structure

```text
FieldQuest/
├── Models/
│   └── Observation.cs
├── Services/
│   ├── IObservationRepository.cs
│   ├── JsonObservationRepository.cs
│   └── ObservationService.cs
├── UI/
│   └── ConsoleMenu.cs
├── Program.cs
├── FieldQuest.csproj
└── README.md
```

The structure reflects the current planned architecture. File names and folders may evolve as the project develops.

### Architecture Overview

- **Models** — represent the application's core data.
- **Services** — implement observation management and application rules.
- **Repositories** — handle data persistence behind an interface.
- **UI** — handles console interaction.
- **Program.cs** — creates and connects the application components.

The repository interface allows the persistence implementation to be replaced in the future without coupling the application service directly to JSON file operations.

## Getting Started

### Prerequisites

Install a supported .NET SDK from the official website:

https://dotnet.microsoft.com/download

Verify the installation:

```bash
dotnet --version
```

### Run the application

Clone the repository and enter the project directory:

```bash
git clone <repository-url>
cd FieldQuest
```

Run the application:

```bash
dotnet restore
dotnet run
```

If the repository contains a solution or the project file is located in a subdirectory, adjust the commands to match the actual repository structure.

## Data Persistence

Observations are stored in a local `fieldquest.json` file.

The application uses `System.Text.Json` to serialize C# objects into JSON and deserialize saved data when starting up.

The JSON file is local application data and should not be treated as a database or as a backup system.

## Learning Goals

The project is designed to explore:

- C# fundamentals and object-oriented programming
- Classes, properties, constructors, and collections
- Methods, validation, and exception handling
- LINQ and collection processing
- JSON serialization and file handling
- Separation of concerns and service classes
- Interfaces and repository abstractions
- Dependency injection
- Unit testing
- SQLite persistence
- ASP.NET Core and REST APIs

## Development Workflow

The project follows a lightweight GitHub Flow approach.

- `main` contains the stable version.
- Feature branches are used for new functionality.
- Bug fixes and refactoring are isolated in their own branches.
- Changes are reviewed and tested before being merged.

Branch naming examples:

```text
feature/dependency-injection
feature/sqlite-persistence
fix/json-load-error
refactor/service-layer
docs/readme
```

Commit messages follow a simple Conventional Commits style:

```text
feat: add observation statistics
fix: handle invalid observation count
refactor: separate persistence layer
docs: update README
test: add observation service tests
```

## Roadmap

- [x] Console-based observation entry
- [x] Observation listing and basic statistics
- [x] JSON-based persistence
- [x] Initial separation of UI, services, and data model
- [ ] Dependency injection container
- [ ] Improved persistence error handling
- [ ] Automated unit tests
- [ ] SQLite repository
- [ ] ASP.NET Core Web API
- [ ] Web-based user interface
- [ ] Mobile-friendly interface

## Project Status

**Learning project — actively evolving.**

Features and architecture may change as new .NET concepts are introduced and applied.

## License

No license has been selected yet. Add a license before explicitly permitting others to reuse, modify, or distribute the project.
