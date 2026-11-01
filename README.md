# DalilAcademy

A simple REST API for managing an educational platform: students, courses, instructors, and enrollments.

> **Status: In development.** This is a learning project and it is still being built.

## Purpose

DalilAcademy was built as a hands-on project to learn the fundamentals of **ASP.NET Core** and **Entity Framework Core**, and to practice structuring a real application with clean architecture.

## Tech Stack

- ASP.NET Core Web API
- Entity Framework Core
- Onion Architecture

## Architecture

The solution is split into three projects following Onion Architecture:

| Project | Responsibility |
|---|---|
| **API** | Controllers, middleware, and application entry point |
| **Core** | Domain entities and abstractions |
| **Infrastructure** | Data access and implementations |

Layers are wired together using Dependency Injection, with the Repository and Service patterns.

## Features

- Manage students, courses, instructors, and enrollments
- Repository and Service patterns
- Dependency Injection
- EF Core data layer with Fluent API entity configurations
- Code-first migrations
- DTOs with explicit mapping
- Request validation
- Global exception-handling middleware with consistent error responses


## Author

**Talal Mehdawi**
GitHub: [TalalMehdawi](https://github.com/TalalMehdawi)