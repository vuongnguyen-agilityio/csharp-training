# Development Guidelines

### Common Issues & Solutions

1. Migration Database in Clean Architecture

- When you have a solution with 2 projects API/WebApp and a DataAcess project you can pass in the options on the command line.
  ```
    My_Solution
       |DataAccess_Project
       |-- DbContext.cs
       |WebApp_Project
       |-- Startup.cs
  ```
- Change into the solution directory
  ```
  - CD My_Solution
  - dotnet ef migrations add InitialCreate --project DataAccess_Project --startup-project WebApp_Project
  - dotnet ef database update --project DataAccess_Project --startup-project WebApp_Project
  ```

  Reference: https://stackoverflow.com/a/69207083

2. Clean Architecture Reference
- https://www.youtube.com/watch?v=nE2MjN54few