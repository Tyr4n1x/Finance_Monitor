# Finance Monitor

**Finance Monitor** is a modern Blazor web application built on .NET 9 that empowers you to track, analyze, and visualize personal financial data with ease and precision.
Optimized for desktop browsers, Finance Monitor delivers a seamless, interactive experience for managing your money — prioritizing functionality and security.

---

## Key Features

### Bird’s-Eye Dashboard

* **Year-to-Date Overview** – View aggregated monthly expenses and incomes for the current year at a glance.
* **Category Breakdowns** – Interactive pie charts display your spending and earning categories to highlight where your money goes and comes from.
* **Secure Access** – The dashboard is accessible only to authenticated users, ensuring your data remains private and protected.

### Transactions: Expenses & Incomes

* **Easy Management** – Add, edit, or delete financial records effortlessly.
* **Custom Categories** – Create tailored categories to match your personal or business needs.
* **Filtered & Sortable Lists** – Browse, search, and sort all transactions in flexible, paginated views.
* **Authorization Required** – Transaction pages are gated by user login to safeguard your data.

### User Account Management

* **Built on Blazor Identity** – Leverages Microsoft’s Identity framework with custom visual and functional enhancements.
* **Email Verification** – Uses a secure, third-party email service to handle user confirmation steps efficiently.
* **External Login (Google)** – Register and sign in via Google OpenID Connect for added convenience.
* **Two-Factor Authentication** – Enforced on first login to bolster security.
* **Account Deletion** – Completely wipes all user data from the database upon account removal for transparency and privacy.

### Role-Based Authorization

* **User & Administrator Roles** – Assign roles to manage access levels.
* **Admin-Only User Management** – Administrators can view a secured list of all user accounts, change roles, or delete users as needed.

---

## Getting Started

### Prerequisites

* [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
* A modern web browser (Edge, Chrome, Firefox, Safari)

### Installation & Running

1. **Clone the repository**:

   ```bash
   git clone https://github.com/Tyr4n1x/Finance_Monitor.git
   cd Finance_Monitor
   ```
2. **Restore dependencies**:

   ```bash
   dotnet restore
   ```
3. **Run the application**:

   ```bash
   dotnet run --project Finance_Monitor
   ```
4. **Open in browser**:
   Navigate to `https://localhost:XXXX` (the URL shown in the console).

---

## Project Structure

```
Finance_Monitor/
│
├─ wwwroot/			# Static assets (CSS, JS, images)
├─ Components/			# Blazor Components
├─ Data/			# Database contexts
├─ Migrations/			# Database migrations
├─ Models/			# Class models
├─ Services/			# Data processing services
```

---

## Contribution Guidelines

Contributions are welcome! Please fork the repository and submit a pull request. Don’t hesitate to open issues or reach out with suggestions.

---

## License

This project is licensed under the [MIT License](LICENSE).
