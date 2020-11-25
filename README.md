# ecommerce-core-angular cheatsheet
## To run the project: cd API -> `dotnet watchrun`
## To stop server - `Ctrl + C`
### Add library project: `dotnet new classlib -o __NAME__`
### Add reference to project: `cd __project 1__ -> dotnet add reference ../__project 2__`
### Add Migration: `dotnet ef migrations add InitialCreate -p Infrastructure -s API -o Data/Migrations`
### Drop DB: `dotnet ef database drop -p Infrastructure -s API`
### Remove existing migration: `dotnet ef migrations remove -p Infrastructure -s API`