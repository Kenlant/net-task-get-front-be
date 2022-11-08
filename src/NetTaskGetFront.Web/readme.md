# NetTaskGetFront.Web

Presentation layer. Contains all web related logic like configuring web server, controllers, routing and etc.
Also servers as service locator since combines all dependencies accross projects

## Dependencies

- Nswag - OpenApi implementation. Can be accessed by /api route
- Serilog - logging library. For now configured only file and console loggings

## Configuration

Configuration can be found in appsettings.json file. Please use your own ApiKey and database connection string to setup application

## Migrations

Project was configured to create database and apply migrations atomatically
