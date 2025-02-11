# Blazor eShop

## Overview
Blazor eShop is an e-commerce platform for clothing products built using Blazor. Users can register as customers or administrators for testing purposes. The platform provides the following features:

- **Admin Features:**
  - Manage clothing categories
  - Add, update, and delete products with images
  - View and update order statuses
  
- **Customer Features:**
  - Register and log in
  - Browse paginated product lists with filters
  - Add products to a personal shopping cart
  - Purchase products
  - View the shopping cart with a cart icon displaying the item count

The platform includes **authentication and authorization** to manage access control.

---

## Prerequisites
Ensure you have the following installed before running the project:

- .NET SDK (latest stable version recommended)
- SQL Server (or SQL Server Express)
- Entity Framework Core CLI
- Visual Studio (recommended) or any IDE that supports Blazor projects

---

## Setup and Running the Project

### 1. Clone the Repository
```sh
git clone <repository_url>
```

### 2. Configure Database
Modify or keep the current `appsettings.json` to include your SQL Server connection string:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=BlazorEshop;Trusted_Connection=True;"
}
```

### 3. Apply Database Migrations
Run the following commands in the project directory:
```sh
dotnet ef database update
```
This will apply the latest migrations and create the necessary database schema.

### 4. Run the Application
Execute the following command to start the Blazor server:
```sh
dotnet run
```
The application will be available at `https://localhost:7038` or `http://localhost:5094`.

---

## Building the Project
To build the project, use:
```sh
dotnet build
```
This compiles the project and prepares it for deployment.

---
