"# LeaderboardAPI" 
A robust and secure Web API designed and implemented using .NET 8 to manage the lifecycle of a competition, including contestant registration, real-time leaderboard generation, reward assignment, and secure administrative operations. The API adheres to modern RESTful best practices and maintains a clean, scalable codebase.

✨ Key Features
This API supports the complete operational needs of a competition platform:

🛡️ Security & Administration
Admin-Only Dashboard: Implemented a dedicated set of secure endpoints for administrative tasks, ensuring only authorized personnel can manage competition data.

Authentication & Authorization: Integrated ASP.NET Core Identity and JWT (JSON Web Tokens) for robust token-based authentication and granular authorization to secure sensitive operations.

🧑‍💻 Contestant Management
Registration Endpoints: Developed specific endpoints for contestant enrollment, requiring a unique seat number and name for secure registration.

CRUD Operations: Full management capabilities for contestant records, accessible only via authenticated admin roles.

🏆 Leaderboard and Results
Real-time Leaderboard: Implemented efficient endpoints to generate and retrieve the global competition leaderboard.

Advanced Filtering: Support for dynamic search functionality and weekly results filtering to provide focused insights into contestant performance.

🥇 Flexible Reward System
Multi-Attribute Rewards: Built features to assign and track contestant rewards across four distinct, customizable attributes:

Points (e.g., score accumulation)

Badges (e.g., participation, completion)

Medals (e.g., top finishes)

Ranks (e.g., competitive placement)

🛠️ Technology Stack
The project is built on a modern, high-performance Microsoft technology stack:

Category

Technology

Description

Backend

.NET 8 (C#)

High-performance runtime and modern C# features.

API Framework

ASP.NET Core (Web API)

Framework for building fast, cross-platform HTTP services.

Database

SQL Server

Primary relational data store.

ORM

EF-Core

Object-Relational Mapper for seamless database interaction.

Security

JWT, Identity

Token-based authentication and user/role management.

Utilities

CORS

Configured to handle cross-origin requests securely.

Validation

Fluent Validation

Used for clear, separate, and expressive model validation.

🏗️ Architecture and Design Patterns
The architecture is designed for maintainability, testability, and scalability, following industry best practices:

RESTful API Design: Adhered to principles of clean resource naming, standard HTTP methods, and appropriate status codes.

Repository Pattern: Decoupled business logic from data access logic, ensuring easy substitution of the data store.

Dependency Injection (DI): Utilized ASP.NET Core's built-in DI for managing service lifetimes and inversion of control, promoting loose coupling.

Options Pattern: Employed for securely and cleanly accessing application configurations (e.g., JWT settings, connection strings).

Clean and Maintainable Code: Focused on clarity, consistent naming conventions, and extensive use of C# best practices.

⚙️ Local Setup and Installation
Prerequisites
.NET 8 SDK

SQL Server (LocalDB, Express, or full instance)

A suitable IDE (Visual Studio, VS Code)

Steps
Clone the Repository:

git clone [[repository-url](https://github.com/MunzerBasher/LeaderboardAPI]
cd [LeaderboardAPI]

Update Configuration:

Open appsettings.json.

Update the ConnectionStrings:DefaultConnection to point to your local SQL Server instance.

Update the JWT settings (Issuer, Audience, Key) in the relevant configuration section.

Apply Migrations:
Navigate to the project directory containing the EF-Core migrations and run:

dotnet ef database update

This will create the necessary database and tables (including Identity tables).

Run the Application:

dotnet run

The API should start and typically be accessible at https://localhost:7000 (or the configured port).
