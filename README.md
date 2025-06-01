# 🧱 Clean Architecture Product API with MediatR & Docker

This is a **.NET 8 Web API** project built with **Clean Architecture** principles. It uses **MediatR** to implement a clean **CQRS pattern** for handling CRUD operations on products. The application is fully **containerized using Docker** for easy setup and deployment.

---

## ✨ Features

- ✅ Clean Architecture (Domain, Application, Infrastructure, Web layers)
- ✅ MediatR for implementing CQRS (Command & Query Responsibility Segregation)
- ✅ Entity Framework Core + SQL Server
- ✅ Docker & Docker Compose support
- ✅ Environment-based configuration via `appsettings.json` and environment variables
- ✅ RESTful API with standard CRUD endpoints

---

## 🛠️ Technologies Used

- ASP.NET Core 8
- MediatR
- Entity Framework Core
- SQL Server
- Docker & Docker Compose

---

## 🚀 Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/Amirwsen/CQRS.git
cd CQRS
```

### 2. Configure Docker

Make sure you have Docker installed and running.
```bash
docker-compose up --build

```