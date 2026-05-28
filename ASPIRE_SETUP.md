# .NET Aspire Setup for Spec Kit App

## Overview

This application uses **.NET Aspire** for local development orchestration. Aspire provides a unified way to manage multiple services (backend API, PostgreSQL database, admin tools) locally.

## Prerequisites

- .NET 10.0 or later
- Docker Desktop (for running PostgreSQL container)
- PostgreSQL 17+ (if not using Docker)

## Project Structure

- **AppHost**: Aspire orchestration host that manages all services
- **ServiceDefaults**: Shared service configuration
- **backend**: ASP.NET Core API service
- **frontend**: React/Vite frontend application (optional in Aspire)

## Recommended: Running with Docker Compose (Quick Start)

The quickest way to get started locally is using Docker Compose.

### Step 1: Create docker-compose.yml

In the root directory (`c:\Users\TestUser\spec-kit-app\spec-kit-app`), create `docker-compose.yml`:

```yaml
version: '3.8'

services:
  postgres:
    image: postgres:17
    container_name: spec-kit-postgres
    environment:
      POSTGRES_PASSWORD: postgres
      POSTGRES_DB: goaltracker
    ports:
      - "5432:5432"
    volumes:
      - postgres_data:/var/lib/postgresql/data
    healthcheck:
      test: ["CMD-SHELL", "pg_isready -U postgres"]
      interval: 10s
      timeout: 5s
      retries: 5

  pgadmin:
    image: dpage/pgadmin4:latest
    container_name: spec-kit-pgadmin
    environment:
      PGADMIN_DEFAULT_EMAIL: admin@example.com
      PGADMIN_DEFAULT_PASSWORD: admin
    ports:
      - "5050:80"
    depends_on:
      - postgres

volumes:
  postgres_data:
```

### Step 2: Start Services with Docker Compose

```bash
docker-compose up -d
```

### Step 3: Build the Backend

```bash
cd backend
dotnet build
```

### Step 4: Apply Migrations (First Time Only)

```bash
cd backend
dotnet ef database update
```

### Step 5: Run the Backend API

```bash
cd backend
dotnet run
```

The backend API will start on `http://localhost:5000`

### Accessing Services

- **Backend API**: http://localhost:5000
- **Swagger UI**: http://localhost:5000/swagger/ui
- **PgAdmin**: http://localhost:5050
  - Email: `admin@example.com`
  - Password: `admin`

### Step 6: Stop Services

```bash
docker-compose down
```

---

## Alternative: Aspire AppHost (Advanced)

The `AppHost` project uses .NET Aspire for more advanced orchestration. Due to DCP/Dashboard components not being available globally in .NET 10, use this approach if you want to manage services programmatically.

### Build the solution

```bash
cd c:\Users\TestUser\spec-kit-app\spec-kit-app
dotnet build
```

### Configuration for AppHost

The AppHost is configured to:
1. Start a PostgreSQL container named `postgres`
2. Create a database named `goalsdb`
3. Start PgAdmin management tool
4. Launch the backend API service

### Database Connection (When Using AppHost)

Connection string: `Server=postgres;Port=5432;Database=goalsdb;User Id=postgres;Password=postgres;`

The backend automatically receives this from Aspire when orchestrated.

---

## Running Backend API Standalone

If you only want to run the API without Aspire or Docker Compose:

### Option 1: With Local PostgreSQL

1. Install PostgreSQL 17 locally
2. Create a database: `goaltracker`
3. Update `appsettings.Development.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=goaltracker;Username=postgres;Password=yourpassword"
  }
}
```

4. Run migrations:
```bash
cd backend
dotnet ef database update
```

5. Start the API:
```bash
dotnet run
```

### Option 2: In-Memory Database (Development Only)

Update `backend/Program.cs` to use in-memory EF Core:

```csharp
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("GoalsDb"));
```

This is useful for testing without any external database.

---

## Database Migrations

### Apply Migrations

```bash
cd backend
dotnet ef database update
```

### Create a New Migration

```bash
cd backend
dotnet ef migrations add MigrationName
dotnet ef database update
```

### View Pending Migrations

```bash
cd backend
dotnet ef migrations list
```

---

## Troubleshooting

### PostgreSQL Connection Error

**Error**: `Connection refused` or `Host not found`

**Solution**:
- Ensure Docker Desktop is running: `docker ps`
- Check if containers are running: `docker-compose ps`
- Restart services: `docker-compose down && docker-compose up -d`

### Port Already in Use

**Error**: `Address already in use: bind`

**Solutions**:
1. Change ports in `docker-compose.yml` or `appsettings.json`
2. Kill process using port: `netstat -ano | findstr :5432` (Windows)
3. Stop conflicting containers: `docker stop container_name`

### Migration Errors

**Error**: `The seed data contains entities of type that cannot be tracked`

**Solution**: Clear previous migrations and regenerate:
```bash
cd backend
dotnet ef database drop -f
dotnet ef database update
```

### Aspire Dashboard Not Appearing

In .NET 10, Aspire packages don't include global Dashboard/DCP components. Use Docker Compose instead for simpler local development, or configure AppHost with custom event handlers.

---

## Next Steps

1. **Quick Start**: Use Docker Compose setup (recommended for most local development)
2. **API Testing**: Use Swagger UI at http://localhost:5000/swagger/ui
3. **Database Management**: Use PgAdmin at http://localhost:5050
4. **Frontend Development**: Run frontend separately with `npm run dev` in the `frontend` folder

---

## References

- [.NET Aspire Documentation](https://learn.microsoft.com/en-us/dotnet/aspire/)
- [Entity Framework Core Migrations](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/)
- [Docker Compose Documentation](https://docs.docker.com/compose/)

