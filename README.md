# LIR - Social Media Plapform for Digital Artists and Animators

Welcome to the backend platform for our social media web application tailored for digital artists and animators. This project is built using .NET and GraphQL API, designed to provide robust and efficient services. Below you'll find the project structure and essential information to get started.

## Introduction

This backend platform serves as the core for our social media web application aimed at digital artists and people who create animations. It handles various aspects including user management, posts, chats, and more, through a well-defined modular architecture.

## Features

- **Publish Your Works**: Share your digital artworks and animations as posts.
- **Add Comments**: Engage with posts by adding comments.
- **Subscribe to Users**: Follow other artists to stay updated with their latest works.
- **Chat with Users**: Communicate with other users through chat functionality.

## Architecture

The project follows a Modular Monolith architecture, which divides the application into separate, self-contained modules that encapsulate their own domain logic, but still runs as a single application. This approach offers several benefits, such as improved maintainability, better separation of concerns, and a clear structure, while avoiding the complexity of a fully distributed microservices architecture. Each module contains its own application logic, domain models, infrastructure, and persistence layers.

### Project Structure

```plaintext
src
├── Modules
│   ├── Chats
│   ├── Posts
│   └── Users
│       ├── Modules.Users.Application
│       ├── Modules.Users.Domain
│       ├── Modules.Users.Endpoints
│       ├── Modules.Users.Infrastructure
│       └── Modules.Users.Persistence
├── Lir.Api
└── Common
```
### Database Diagram

The following diagram illustrates the database schema:

<a href="https://ibb.co/60G9d0X"><img src="https://i.ibb.co/r2q8W2d/lir-drawio-1.png" alt="lir-drawio-1" border="0"></a>

## Getting Started

To get started with the project, follow these steps:

1. **Clone the repository**:
    ```bash
    git clone https://github.com/Lir-PRO/lir-backend.git
    cd lir-backend
    ```

2. **Set up the database**:
    - Ensure PostgreSQL is installed and running.
    - Update the connection strings and Auth0 credentials in the project configuration files.

3. **Start the application**:
    ```bash
    dotnet run --project src/Lir.Api
    ```

## Technologies Used

- **.NET 8**
- **GraphQL**
- **Entity Framework Core**
- **PostgreSQL**
- **MassTransit**
- **Auth0**

## Project Setup with Docker

To facilitate easy setup and deployment, Docker files are included in this repository. Follow these instructions to run the project using Docker.

### Building the Docker Image (For Local Development)

If you need to build a custom version of the Docker image locally (e.g., for development or testing changes), follow these steps:

1. **Build the Docker Image:**

   ```bash
   docker build -t mariiaprylutska/lir_backend -f Dockerfile
   ```
2. **Run the Docker Containers Using Docker Compose**
    ```bash
   docker-compose up
   ```
    

