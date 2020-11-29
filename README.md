# ecommerce-core-angular cheatsheet

# DotNET Core
## To run the project: cd API -> `dotnet watch run`
## To stop server - `Ctrl + C`
### Add library project: `dotnet new classlib -o __NAME__`
### Add reference to project: `cd __project 1__ -> dotnet add reference ../__project 2__`
### Add Migration: `dotnet ef migrations add InitialCreate -p Infrastructure -s API -o Data/Migrations`
### Drop DB: `dotnet ef database drop -p Infrastructure -s API`
### Remove existing migration: `dotnet ef migrations remove -p Infrastructure -s API`

# Angular
### Create Angular project - `ng new client` -> y for routing
### TO run the project -  cd client -> `ng serve`
### Add bootstrap and fontawesome to project - `ng add ngx-bootstrap` `npm install font-awesome`
### Generate angular component cd client\src\_FLD_ -> `ng g c __NAME__`, and without tests: `src\app> ng g c __NAME__--skip-tests`
### Create module: `ng g m __NAME__`
### Create service: `ng g s __NAME__`