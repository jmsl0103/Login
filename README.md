# Full-Stack Registration Application

A complete registration system built with React frontend, ASP.NET Core 8 Web API backend, and SQL Server database, all containerized with Docker.

## Features

- **Frontend**: Modern React application with Vite build system
- **Backend**: ASP.NET Core 8 Web API with Entity Framework Core
- **Database**: SQL Server 2022 with persistent data storage
- **Security**: Secure password hashing using ASP.NET Identity
- **Containerization**: Docker containers for all services
- **Production Ready**: Multi-stage builds and optimized configurations

## Architecture

- **Frontend**: React + Vite + TypeScript + Tailwind CSS
- **Backend**: ASP.NET Core 8 + Entity Framework Core
- **Database**: SQL Server 2022
- **Containerization**: Docker + Docker Compose

## Quick Start

1. **Prerequisites**:
   - Docker and Docker Compose installed
   - Ports 3000, 8080, and 1433 available

2. **Run the application**:
   ```bash
   docker-compose up --build
   ```

3. **Access the application**:
   - Frontend: http://localhost:3000
   - API: http://localhost:8080
   - API Documentation: http://localhost:8080/swagger
   - SQL Server: localhost:1433 (sa/YourStrong@Passw0rd)

## Database Schema

```sql
Users Table:
- Id (int, Primary Key, Identity)
- Email (nvarchar(256), Unique, Required)
- PasswordHash (nvarchar(500), Required)
```

## API Endpoints

- `POST /api/users/register` - Register a new user
  - Request: `{ "email": "user@example.com", "password": "password123" }`
  - Response: `{ "success": true, "message": "User registered successfully!" }`

## Development

### Running Individual Services

**Frontend Development**:
```bash
npm install
npm run dev
```

**Backend Development**:
```bash
cd api
dotnet run
```

**Database Only**:
```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourStrong@Passw0rd" \
  -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
```

### Environment Variables

The application uses the following environment variables:

- `ConnectionStrings__DefaultConnection`: SQL Server connection string
- `ASPNETCORE_ENVIRONMENT`: ASP.NET Core environment (Development/Production)
- `ASPNETCORE_URLS`: API listening URLs

## Security Features

- Password hashing using ASP.NET Core Identity PasswordHasher
- CORS configuration for frontend-backend communication
- Input validation and sanitization
- Secure database connection with TrustServerCertificate
- Non-root user in Docker containers

## Production Deployment

The application includes:
- Multi-stage Docker builds for optimized images
- Nginx configuration for serving React frontend
- Health checks for SQL Server
- Persistent volumes for database storage
- Proper networking between containers

## Troubleshooting

1. **SQL Server connection issues**: Wait for the health check to pass before the API starts
2. **CORS errors**: Ensure the frontend URL matches the CORS policy in the API
3. **Port conflicts**: Make sure ports 3000, 8080, and 1433 are available