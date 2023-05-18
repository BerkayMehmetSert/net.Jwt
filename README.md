# Net JWT Example

This project is a .NET Core web API that allows user registration and authentication using JWT (JSON Web Tokens). Users can register and then log in to the application. Authenticated users can obtain a token, which grants them access to protected endpoints for the duration of the token's validity.

## Installing

1. Clone the repository
```
git clone https://github.com/BerkayMehmetSert/net.GenericRepository.git
```

2. Install dependencies
```
dotnet restore
```

3. Create database
```
dotnet ef database update
```

4. Run the project
```
dotnet run
```

## Usage

**Admin user credentials:**

```text
Email: example@example.com
Password: 1234
```

### Products

**Get all products**

🔒 Roles : **Admin, User**

```bash
GET /api/product
```

Response body:
```json
{
  "success": true,
  "message": "Product retrieved successfully",
  "data": [
    {
      "id": "4b4663fb-a819-413e-9d15-bd0b577138a1",
      "name": "Product 1",
      "description": "Description 1",
      "price": 100
    },
    {
      "id": "ef481be9-7363-4420-b62a-546d2a93420b",
      "name": "Product 2",
      "description": "Description 2",
      "price": 110
    }
  ]
}
```

**Get product by id**

🔒 Roles : **Admin, User**

```bash
GET /api/product/{id}
```

Response body:
```json
{
  "success": true,
  "message": "Product retrieved successfully",
  "data": {
    "id": "4b4663fb-a819-413e-9d15-bd0b577138a1",
    "name": "Product 1",
    "description": "Description 1",
    "price": 100
  }
}
```

**Create product**

🔒 Roles : **Admin**

```bash
POST /api/product
```

Request body:
```json
{
  "name": "Product 1",
  "description": "Description 1",
  "price": 110
}
```

Response body:
```json
{
  "success": true,
  "message": "Product updated successfully"
}
```

**Update product**

🔒 Roles : **Admin**

```bash
PUT /api/product/{id}
```

Request body:
```json
{
  "name": "Product 1",
  "description": "Description 1",
  "price": 110
}
```

Response body:
```json
{
  "success": true,
  "message": "Product updated successfully"
}
```

**Delete product**

🔒 Roles : **Admin**

```bash
DELETE /api/product/{id}
```

Response body:
```json
{
  "success": true,
  "message": "Product deleted successfully"
}
```

### Users

**Get all users**

🔒 Roles : **Admin**

```bash
GET /api/user
```

Response body:
```json
{
  "success": true,
  "messages": "User retrieved successfully.",
  "data": [
    {
      "firstName": "First name 1",
      "lastName": "Last name 1",
      "email": "example@mail.com",
      "role": "User",
      "id": "63f8aa21-2efe-4610-05b8-08db5798e211"
    },
    {
      "firstName": "Admin",
      "lastName": "Admin",
      "email": "example@example.com",
      "role": "Admin",
      "id": "aa25a39a-8be7-4c48-b88b-56d9b78d2f2e"
    }
  ]
}
```

**Get user by id**

🔒 Roles : **Admin**

```bash
GET /api/user/{id}
```

Response body:
```json
{
  "success": true,
  "messages": "User retrieved successfully.",
  "data": {
    "firstName": "First name 1",
    "lastName": "Last name 1",
    "email": "example@mail.com",
    "role": "User",
    "id": "63f8aa21-2efe-4610-05b8-08db5798e211"
  }
}
```

**Create user**

```bash
POST /api/user
```

Request body:
```json
{
  "firstName": "First name 1",
  "lastName": "Last name 1",
  "email": "example@mail.com",
  "password": "123456"
}
```

Response body:
```json
{
  "success": true,
  "messages": "User created successfully."
}
```

**Update user**

🔒 Roles : **Admin**

```bash
PUT /api/user/{id}
```

Request body:
```json
{
  "firstName": "First name 1",
  "lastName": "Last name 1",
  "email": "example@mail.com",
  "password": "123456"
}
```

Response body:
```json
{
  "success": true,
  "messages": "User updated successfully."
}
```

**Delete user**

🔒 Roles : **Admin**

```bash
DELETE /api/user/{id}
```

Response body:
```json
{
  "success": true,
  "messages": "User deleted successfully."
}
```

### Token

**Create a token**

```bash
POST /api/token
```

Request body:
```json
{
  "email": "example@example.com",
  "password": "1234"
}
```

Response body:

```json
{
  "success": true,
  "token": {
    "accessToken": "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImFhMjVhMzlhLThiZTctNGM0OC1iODhiLTU2ZDliNzhkMmYyZSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6ImV4YW1wbGVAZXhhbXBsZS5jb20iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsIkZ1bGxOYW1lIjoiQWRtaW4gQWRtaW4iLCJSb2xlIjoiQWRtaW4iLCJFbWFpbCI6ImV4YW1wbGVAZXhhbXBsZS5jb20iLCJBY2NvdW50SWQiOiJhYTI1YTM5YS04YmU3LTRjNDgtYjg4Yi01NmQ5Yjc4ZDJmMmUiLCJleHAiOjE2ODQ0MTk3MzIsImlzcyI6ImV4YW1wbGUuY29tIiwiYXVkIjoiZXhhbXBsZS5jb20ifQ.TLxm0TUA-dwqcoml6nXf46awgibnMLz-VLT3ma9kck0",
    "expireTime": "2023-05-18T14:22:12.9313189Z",
    "role": "Admin"
  }
}
```
