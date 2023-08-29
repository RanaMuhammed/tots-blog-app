Repository: Tots Blog App Backend

Welcome to the Tots Blog App Backend repository! This project serves as the backend implementation for the Tots Blog App, built using ASP.NET Core, Entity Framework, and a plethora of REST APIs. The backend handles various aspects of the blog application, including user authentication using JWT tokens.

## Project Overview

Tots Blog App is a platform designed to empower users to share their thoughts, stories, and insights through the art of blogging. The backend of this application is a crucial component that facilitates user authentication, manages blog posts, comments, and interactions, ensuring a seamless experience for both bloggers and readers.

## Key Features

- **ASP.NET Core:** The project is built on the robust foundation of ASP.NET Core, a versatile and high-performance framework for building web applications and APIs.

- **Entity Framework:** We leverage Entity Framework, an object-relational mapper, to simplify database interactions, allowing us to work with database entities as .NET objects.

- **REST APIs:** The backend primarily exposes RESTful APIs that enable communication between the frontend and the server. These APIs handle operations related to user management, blog posts, comments, and more.

- **JWT Authentication:** JSON Web Tokens (JWT) are utilized to ensure secure and stateless user authentication. This helps maintain user sessions and secures sensitive endpoints.

## Getting Started

Follow these steps to get the Tots Blog App Backend up and running on your local machine:

1. **Clone the Repository:**
   ```
   git clone https://github.com/your-username/tots-blog-app-backend.git
   ```

2. **Navigate to the Project Directory:**
   ```
   cd tots-blog-app-backend
   ```

3. **Install Dependencies:**
   ```
   dotnet restore
   ```

4. **Configure the Database:**
   Update the database connection string in `appsettings.json` to point to your local database instance.

5. **Run Migrations:**
   ```
   dotnet ef database update
   ```

6. **Run the Application:**
   ```
   dotnet run
   ```

The application should now be running on `http://localhost:5000`.


## Feedback and Support

If you encounter any issues, have suggestions, or need assistance, please create an issue in the repository. We encourage open communication and appreciate your feedback.

---------- Packages to install from the package Manager ----------
1. Microsoft.EntityFrameworkCore
2. Microsoft.EntityFrameworkCore.SqlServer
3. Microsoft.EntityFrameworkCore.Tools
4. Microsoft.AspNetCore.Authentication.JwtBearer
5. Microsoft.AspNetCore.Identity.EntityFrameworkCore
6. Microsoft.EntityFrameworkCore.Design
8. Microsoft.VisualStudio.Web.CodeGeneration.Design
9. System.IdentityModel.Tokens.Jwt