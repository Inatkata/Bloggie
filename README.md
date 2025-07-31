# Bloggie – Dev Blog Platform

**Bloggie** is a fully functional blog website designed for developers to create, manage, and interact with technical blog posts. It’s built using the ASP.NET Core MVC framework and demonstrates real-world applications of concepts learned during the ASP.NET Advanced course at SoftUni.

---

## 🚀 Features

### 👥 User Management
- Microsoft Identity integration for registration and login
- Role-based access control with predefined roles:
  - **User**
  - **Admin**
  - **Super Admin**

### ✍️ Blog Management
- Create, edit, and delete dev-related blog posts
- Add blog tags and categories for easier navigation
- Use of rich text WYSIWYG editor (Quill.js / TinyMCE)

### 🧭 Blog Listings
- Home page with paginated blog feed
- Filter and search by category or tag
- SEO-friendly URLs and metadata

### 💬 User Interaction
- Users can like blog posts
- Commenting system with authentication
- Display total likes and comments per blog post

### 🌄 Image Uploads
- Integration with Cloudinary API for image hosting
- Upload and manage images within blog posts

---

## 🛠️ Technologies Used

- **ASP.NET Core 8.0**
- **Entity Framework Core**
- **SQL Server**
- **Razor Pages (MVC)**
- **Bootstrap 5**
- **Microsoft Identity**
- **Cloudinary API**
- **xUnit (Unit Testing)**
- **Git & GitHub**

---

## 🧱 Architecture

- Follows **MVC** design pattern
- Organized using **Areas**:
  - `/Admin` for content moderation and user roles
  - `/User` for blog creation and management
- Uses **ViewModels** and **DTOs** to decouple domain models from UI logic
- Business logic encapsulated in **Services** with dependency injection
- Data access through **Repositories** (optional based on structure)

---

## 📦 Entity Models

- **Blog**
- **User**
- **Category**
- **Comment**
- **Like**
- **Role**

---

## 🔐 Security Features

- CSRF protection using `AntiForgeryToken`
- XSS protection via HTML sanitization and Razor escaping
- SQL Injection prevention through EF Core
- Input validation on both client and server side
- Authorization filters for role-based access

---

## 🧪 Unit Testing

- Business logic and services tested using **xUnit**
- Over **65% coverage** for core features (tested: BlogService, CommentService, CategoryService)
- Mocks used for repository dependencies

---

## 🌐 Responsive UI

- Built with **Bootstrap 5** for mobile-first design
- Custom themes and layouts with Razor partials and sections
- Designed for usability on **desktop**, **tablet**, and **mobile**

---

## 📂 Error Handling

- Custom views for:
  - `404 - Not Found`
  - `500 - Internal Server Error`
- Exception filters and try-catch blocks in services and controllers

---

## 🔎 Additional Features

- **Pagination** for blogs and comments
- **Search** by keyword and category
- **Database seeding** with initial categories, admin user, and test posts
- **SEO optimization** with human-readable URLs (`/blogs/my-first-post`)

---

## 🌍 Source Control (GitHub)

- Project repository is public
- Contains at least:
  - **20+ commits**
  - **Commits over 5+ different days**
- Repository includes `.gitignore`, `README.md`, seeded data, and all required project files

---

## 📅 Project Details

- Course: **ASP.NET Advanced – June 2025**
- Platform: **SoftUni**
- Deadline: **13 August 2025**
- Defense Date: **17 August 2025**

---

## 👩‍💻 Author

**Sevdalina Ventsislavova Kavalova**  
GitHub: [Inatkata](https://github.com/Inatkata)  


---


## 📃 License

MIT License – free to use for educational purposes.
