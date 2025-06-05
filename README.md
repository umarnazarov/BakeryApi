# Bakery API

This application was developed for Web Application module, as coursework portfolio project @ WIUT by student ID: 00013630

---

## 📌 Project Description

This is a backend RESTful API built using ASP.NET Core Web API with Entity Framework Core (Code-First). It manages bakery data such as Products and Categories with full CRUD functionality. The API is documented using Swagger and follows clean architecture principles, including the Repository Pattern.

---

## ✅ Features

- ASP.NET Core Web API (.NET 7)
- Entity Framework Core with SQL Server
- Code-First Migrations
- Repository Pattern for Data Access
- DTO-based clean API contracts
- Swagger UI documentation
- Supports full CRUD for Products and Categories

---

## 🛠 Requirements

- [.NET 7 SDK](https://dotnet.microsoft.com/download)
- SQL Server (LocalDB or full SQL Server)
- Visual Studio or VS Code

---

## 🚀 How to Run the Project

1. **Clone the repository**

```bash
git clone https://github.com/YOUR_USERNAME/BakeryApi.git
cd BakeryApi
```

2. **Install dependencies (if needed)**

```bash
Most dependencies are managed via the .csproj file.
```

3. **Apply Migrations and Create Database**

```bash
bash
Copy
Edit
dotnet ef database update
```

4. **Run the API**

```bash

bash
Copy
Edit
dotnet run
```
