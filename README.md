# BulkyBook Web - E-Commerce Application

BulkyBook Web is a full-stack e-commerce web application built with **ASP.NET Core MVC** and **Entity Framework Core**.  
It implements a robust admin and customer interface for managing books, categories, and orders, following clean architecture principles.

---

## 🚀 Features

- **User Authentication & Authorization**
  - Register, Login, and Logout
  - Role-based access for Admin and Customer
- **Admin Panel**
  - Manage Categories, Products, and Orders
  - CRUD operations with server-side validation
- **Shopping Features**
  - Browse books by category
  - Add to cart, checkout, and place orders
- **Responsive Design**
  - Built with **Bootstrap** for mobile-friendly UI
- **Entity Framework Core**
  - Code-first migrations and SQL Server integration

---

## 🛠 Tech Stack

- **Backend:** ASP.NET Core MVC (.NET 6+)
- **Frontend:** HTML5, CSS3, JavaScript, Bootstrap
- **Database:** Microsoft SQL Server
- **ORM:** Entity Framework Core
- **Authentication:** ASP.NET Core Identity
- **Version Control:** Git & GitHub

---

## 📂 Project Structure

BulkyBookWeb/
│
├── BulkyBookWeb/ # Main web project
├── BulkyBook.Models/ # Entity models
├── BulkyBook.DataAccess/ # EF Core DbContext and repositories
├── BulkyBook.Utility/ # Helper classes and constants
└── BulkyBookWeb/Views/ # Razor views for MVC


---

## ⚙️ Setup Instructions

### Prerequisites
- [.NET 6 SDK or later](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio 2022 or later](https://visualstudio.microsoft.com/) with ASP.NET and web development workload

### Steps to Run Locally
1. **Clone the repository**
   ```bash
   git clone https://github.com/ambika-01/BulkyBookWeb-Ecommerce.git
   cd BulkyBookWeb-Ecommerce
2. Configure the database connection
   Open appsettings.json
   Update the DefaultConnection string with your SQL Server details
3. Apply migrations
  cd BulkyBookWeb
  dotnet ef database update
4. Run the application
   dotnet run


👩‍💻 Usage
Admin Login: Allows access to dashboard and management features
Customer Login: Enables browsing, adding to cart, and ordering
Manage products and categories via admin panel
Place orders and view order history as a customer

✨ Author
Developed by Ambika
📧 Contact: ambikapatil2023@gmail.com
🌐 GitHub: https://github.com/ambika-01
