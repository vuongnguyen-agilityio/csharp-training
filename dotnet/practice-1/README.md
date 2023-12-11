# Building Web API that supports for Store Management

- Timeline: 9 days
- Start Date: 2023-11-17

### Practice Scenarios

- Admin can:
  - Login
  - User management (CRUD)
    - Get all users with: Pagination, Filter, Order
  - Set role for a user
  - Product management
    - Get all products: Pagination, Filter, Order
    - Create product
    - Update product
    - Delete product

- User can:
  - Register/Login: By email/pass
  - Get all products: Pagination, Filter, Order
  - Add/Delete products in his/her carts
  - Buy all products on carts (cash on delivery)
  - Get the purchase history

- The user will receive an email notification (text only) after the order (optional)

### Tech-stack

- [x] Architecture: Clean Architecture
- [x] Database: PostgreSql
- [x] EF Core for data access
  - [ ] Generic Repository Pattern
  - [x] Unit of work patterns
- [x] Dependency Injection
- [ ] API versioning
- [ ] Using a mapper package For mapping (Mapster or AutoMapper)
- [x] Swashbuckle For API documentation
- [x] FluentValidation  For Model validations
- [x] Using Serilog for logging capabilities
- [x] Custom middleware to show the request and response with the timeline
- [x] XUnit & MOQ for Unit Testing
- [x] Integration Test With Docker
- [x] Source code analysis
  - [x] Using .Net Analyzer
- [x] Test app by Postman / Visual studio .http files
- [x] Deploy Using Docker

### Break Down Tasks and Estimation (Total: 9 Days)

1. Init Application Following Clean Architecture (1 day)
    - Init folder structure
    - Init Unit test with XUnit & MOQ
    - Define SQL server configuration
    - Init API versioning
    - Init Swagger & Swashbukle for API Documentation
    - Install .Net Analyzer
    - Init Serilog
2. Define Application Schemas (1 day)
    - Admin
    - User
    - Product
    - Cart
3. Implement Authentication & Authorization (1 day)
    - Register Admin
    - Register User
    - Login
4. Implement CRUD (4 days)
    - User CRUD (1 day)
    - Assign User Role
    - Product CRUD (0.5 day)
    - Cart CRUD (1 day)
    - Checkout API
    - Purchase History CRUD (1 day)
5. Deploy Application Using Docker (1.5 days)

