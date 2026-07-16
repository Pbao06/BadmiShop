# Badminton Equipment Management System

A web-based management system developed to streamline inventory tracking and order processing for badminton equipment shops.

##  Features
- **Inventory Management:** Effortlessly add, update, and track badminton rackets, shuttlecocks, and apparel.
- **Order Processing:** Efficient system for managing customer orders and status tracking.
- **Minimalist UI:** Clean and intuitive interface for an optimal user experience.
- **Payment Integration:** VNPay integration is currently in progress (work-in-progress).

## 🛠 Tech Stack
- **Framework:** ASP.NET Core MVC
- **Database:** SQL Server
- **Language:** C#
- **Tools:** Visual Studio, Git
  
## 🏗️ Project Architecture & Data Model
This system is built with a relational architecture to ensure data integrity and scalable performance. The core modules are connected through well-defined relationships, enabling efficient inventory and order lifecycle management.

*   **User & Auth Module:** Implements role-based access control, distinguishing between Admins and Customers to manage system security.
*   **Product & Category System:** Products are structured with categorized inventory (Rackets, Shoes, Shuttlecocks), linked to specific brands for better filtering and management.
*   **Order & Transaction Engine:** Designed with a robust relational flow:
    *   One-to-Many relationship between **Customers** and **Orders**.
    *   Many-to-Many relationship between **Orders** and **Products** (via the *OrderDetail* table), which captures transaction-specific pricing and quantities.
*   **Inventory Tracking:** Real-time stock management logic ensures inventory accuracy, preventing overselling during the checkout process.

**Database Schema Highlights:**
- `Users`: Handles authentication and profile management.
- `Products`: The primary catalog for all equipment, tracking price, stock levels, and brand association.
- `Categories`: Organizes inventory types for intuitive navigation.
- `Orders`: Stores transaction states, shipping details, and timestamps.
- `OrderDetails`: Junction table linking orders to items, preserving historical price data at the time of purchase.

---

## 📸 Screenshots

- ![Dashboard Admin](https://github.com/user-attachments/assets/692a598b-19a5-4fde-905f-afa8a66cb313)
- ![Inventory Admin](https://github.com/user-attachments/assets/e0fbbcb2-fe3a-4685-a4da-f4ea15fb846f)
- ![Detail product](https://github.com/user-attachments/assets/8ed2a0f6-22de-4cc3-adcb-ee54ee0ff293)
- ![Cart](https://github.com/user-attachments/assets/ee7e370c-a8d4-46c2-a733-89c8c63c0692)
- ![Payment](https://github.com/user-attachments/assets/4255f140-9637-416a-864c-aa80281bc2a9)
- ![History order](https://github.com/user-attachments/assets/3d6ecf8c-e056-4dc7-bc25-86a09e59e02f)


## 🚀 Live Demo
You can view the project at: https://project-web-bat.onrender.com
> **Note:** This project is currently deployed on Render's free tier. Please note that the server may go to "sleep" after periods of inactivity. If the page takes a while to load (or shows a 50x error) upon first access, please wait a few seconds while the server wakes up.

## 💡 How to Run Locally
1. Clone this repository: `git clone https://github.com/Pbao06/Project_web_bat`
2. Open the solution in **Visual Studio**.
3. Configure your connection string in `appsettings.json` to point to your local **SQL Server**.
4. Run the application!
5. **Admin Access:**
   - **Email:** `Pbao06@gmail.com`
   - **Password:** `Phangiabao`

## 👤 Author
**Phan Gia Bảo** - [GitHub Profile](https://github.com/Pbao06) siuu 
