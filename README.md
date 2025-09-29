# Bike Shop Database Management

This project is a **Database Management Application** developed using **ASP.NET** and **SQL Server**, designed to manage the [BikeStores sample database](https://www.sqlservertutorial.net/sql-server-sample-database/).

> **Note:** This version represents the last working state of the project on my personal laptop and may not reflect the final product or internal versions at Convex Network S.R.L.

---

## Project Highlights

- **Database:** Utilizes the [BikeStores sample database](https://www.sqlservertutorial.net/sql-server-sample-database/) for a fictional retail bike store.
- **Features:** Implements basic CRUD operations to manage products, customers, orders, and inventory.
- **Technology Stack:** Developed with **ASP.NET** for the web interface and **SQL Server** for data storage.
<img width="1224" height="899" alt="image" src="https://github.com/user-attachments/assets/4a006f88-d9c5-4265-b5cd-5d93eadf4cf5" />

---

## Setup Instructions

1. Clone the repository:
   ```bash
   git clone https://github.com/DavidVladuca/DB-Management-Project.git
   ```
2. Open the project in **Visual Studio**.
3. Open **SQL Server Management Studio (SSMS)** and connect to your local SQL Server instance.
4. Ensure the **BikeStores database** is restored or attached to your server.
5. Update the connection string in `Web.config` to match your SQL Server instance. Example:
   ```xml
   <connectionStrings>
       <add name="BikeShopDB" 
            connectionString="Server=YOUR_SERVER_NAME;Database=BikeStores;Trusted_Connection=True;" 
            providerName="System.Data.SqlClient" />
   </connectionStrings>
   ```
   Replace `YOUR_SERVER_NAME` with the name of your SQL Server instance.
6. Run the application locally using IIS Express or your preferred server.
