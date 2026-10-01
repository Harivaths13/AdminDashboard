# AdminDashboard

### September 20, 2026

* **Update:** Reset the database, created and seeded the `Product` entity with EF Core migrations, and connected it to a live Tailwind CSS inventory dashboard.

### September 27, 2026

***SQL Server Setup***
<img width="1917" height="948" alt="image" src="https://github.com/user-attachments/assets/49bea2b8-e425-4456-a7e9-a8ca0213eb1a" />

### September 29, 2026

* **Update:** Implemented `ProductsApiController` with endpoints to retrieve live JSON product data (`/api/productsapi`) and export database records as a downloadable `.json` file (`/api/productsapi/download`).
* **UI:** Added an "Export JSON" button with responsive Tailwind styling directly to the inventory table header.
### October 01, 2026

* **Update:** Implemented `POST` (`/api/productsapi`) and `DELETE` (`/api/productsapi/{id}`) endpoints in `ProductsApiController` for full RESTful product lifecycle management.
* **UI:** Integrated an interactive "Add Product" modal form and per-row delete action buttons with responsive Tailwind CSS styling directly on the dashboard inventory table.
* **Database:** Verified manual SQL item insertion directly into LocalDB and resolved Razor layout script rendering.
