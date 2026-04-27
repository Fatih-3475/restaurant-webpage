# ApiWebV1 🍽️

> **Restaurant Management System** — ASP.NET Core 10 Web API + MVC Admin Panel

![.NET](https://img.shields.io/badge/.NET-10-512BD4?style=flat-square)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-14+-336791?style=flat-square)
![EF Core](https://img.shields.io/badge/EF_Core-10-purple?style=flat-square)
![Cookie Auth](https://img.shields.io/badge/Auth-Cookie-green?style=flat-square)
![Swagger](https://img.shields.io/badge/API-Swagger-orange?style=flat-square)

---

## 📌 About the Project

ApiWebV1 is a full-stack restaurant management system built on ASP.NET Core 10. It consists of two main components:

- **ApiWebV1 (Backend)** — RESTful Web API with PostgreSQL, Entity Framework Core, AutoMapper, and FluentValidation.
- **ApiProjeWeb.UI (Frontend)** — ASP.NET Core MVC admin panel with Cookie Authentication and admin-only route protection.

---

## 🔐 Authentication & Security

The admin panel is protected with ASP.NET Core Cookie Authentication:

- Only authenticated admin users can access the admin panel
- All controllers are protected with `[Authorize]` attribute
- Public restaurant homepage is accessible to everyone via `[AllowAnonymous]`
- Admin credentials are stored in `appsettings.json` (excluded from Git via `.gitignore`)
- Login / Logout functionality implemented in `LoginController`

---

## 🛠️ Technology Stack

| Category | Technology | Version / Note |
|---|---|---|
| Platform | ASP.NET Core | .NET 10 |
| Database | PostgreSQL + Npgsql | EF Core 10 |
| ORM | Entity Framework Core | Code-First + Migrations |
| Mapping | AutoMapper | ReverseMap support |
| Validation | FluentValidation | DI integrated |
| Authentication | Cookie Authentication | Admin-only access |
| API Docs | Swashbuckle (Swagger) | Swagger UI included |
| Admin UI | Otika Bootstrap Admin | Bootstrap 4 based |
| Frontend | Yummy Red 1.0.0 | Restaurant theme |

---

## 📁 Project Structure

### Backend — `ApiWebV1/`

| Folder / File | Description |
|---|---|
| `Controllers/` | 13 API controllers (full CRUD) |
| `Entities/` | EF Core entity classes |
| `Dtos/` | Request & Response DTO objects |
| `Context/ApiContext.cs` | DbContext — 13 DbSets |
| `Mapping/GeneralMapping.cs` | AutoMapper profile |
| `Migrations/` | 6 EF Core migrations |
| `ValidationRules/` | FluentValidation rules |
| `appsettings.example.json` | Config template (no secrets) |

### Frontend — `ApiProjeWeb.UI/`

| Folder / File | Description |
|---|---|
| `Controllers/LoginController.cs` | Admin login / logout |
| `Controllers/DefaultController.cs` | Public homepage `[AllowAnonymous]` |
| `Controllers/ (others)` | 14 MVC controllers with `[Authorize]` |
| `Views/Login/Index.cshtml` | Otika-themed login page |
| `Views/` | List, Create, Update views per entity |
| `appsettings.example.json` | Config template (no secrets) |

---

## ⚙️ Setup & Running

### Prerequisites

- .NET 10 SDK
- PostgreSQL 14+
- Visual Studio 2022 or VS Code

### 1. Configure appsettings.json

Copy `appsettings.example.json` to `appsettings.json` and fill in your values:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=ApiDb;Username=postgres;Password=YOUR_PASSWORD"
  },
  "AdminCredentials": {
    "Username": "admin",
    "Password": "YOUR_ADMIN_PASSWORD"
  }
}
```

### 2. Apply Migrations

```bash
cd ApiWebV1
dotnet ef database update
```

### 3. Run the API

```bash
dotnet run --project ApiWebV1
```

Swagger UI: `https://localhost:{PORT}/swagger`

### 4. Run the Admin Panel

```bash
dotnet run --project ApiProjeWeb.UI
```

Navigate to `/Login/Index` to sign in.

---

## 🔒 Security Notes

- `appsettings.json` is excluded from Git via `.gitignore` — never commit it
- Use `appsettings.example.json` as a template for other developers
- All admin routes require authentication — unauthenticated users are redirected to login

---
---

# ApiWebV1 🍽️

> **Restoran Yönetim Sistemi** — ASP.NET Core 10 Web API + MVC Admin Panel

---

## 📌 Proje Hakkında

ApiWebV1, ASP.NET Core 10 üzerine inşa edilmiş tam kapsamlı bir restoran yönetim sistemidir. İki ana bileşenden oluşur:

- **ApiWebV1 (Backend)** — PostgreSQL veritabanı, Entity Framework Core ORM, AutoMapper ile DTO dönüşümü ve FluentValidation ile girdi doğrulaması sağlayan RESTful Web API.
- **ApiProjeWeb.UI (Frontend)** — Tam CRUD arayüzü, Cookie tabanlı kimlik doğrulama ve `[Authorize]` ile korunan MVC admin paneli.

---

## 🔐 Kimlik Doğrulama ve Güvenlik

Admin paneli ASP.NET Core Cookie Authentication ile korunmaktadır:

- Admin paneline yalnızca giriş yapmış admin kullanıcılar erişebilir
- Tüm controller'lar `[Authorize]` attribute'u ile korunmaktadır
- Halka açık restoran ana sayfası `[AllowAnonymous]` ile herkese açıktır
- Admin bilgileri `appsettings.json`'da saklanır ve `.gitignore` ile Git'ten gizlenir
- Giriş / Çıkış işlemleri `LoginController` üzerinden yönetilir

---

## 🛠️ Teknoloji Stack

| Kategori | Teknoloji | Sürüm / Not |
|---|---|---|
| Platform | ASP.NET Core | .NET 10 |
| Veritabanı | PostgreSQL + Npgsql | EF Core 10 |
| ORM | Entity Framework Core | Code-First + Migration |
| Mapping | AutoMapper | ReverseMap desteği |
| Doğrulama | FluentValidation | DI entegrasyonu |
| Kimlik Doğrulama | Cookie Authentication | Sadece admin erişimi |
| API Dokümantasyon | Swashbuckle (Swagger) | Swagger UI dahil |
| Admin Şablonu | Otika Bootstrap Admin | Bootstrap 4 tabanlı |
| Ön Yüz | Yummy Red 1.0.0 | Restoran teması |

---

## 📁 Proje Yapısı

### Backend — `ApiWebV1/`

| Klasör / Dosya | Açıklama |
|---|---|
| `Controllers/` | 13 API controller (tam CRUD) |
| `Entities/` | EF Core entity sınıfları |
| `Dtos/` | Request & Response DTO nesneleri |
| `Context/ApiContext.cs` | DbContext — 13 DbSet |
| `Mapping/GeneralMapping.cs` | AutoMapper profili |
| `Migrations/` | 6 EF Core migration |
| `ValidationRules/` | FluentValidation kuralları |
| `appsettings.example.json` | Yapılandırma şablonu (şifresiz) |

### Frontend — `ApiProjeWeb.UI/`

| Klasör / Dosya | Açıklama |
|---|---|
| `Controllers/LoginController.cs` | Admin giriş / çıkış |
| `Controllers/DefaultController.cs` | Halka açık ana sayfa `[AllowAnonymous]` |
| `Controllers/ (diğerleri)` | `[Authorize]` korumalı 14 MVC controller |
| `Views/Login/Index.cshtml` | Otika temalı giriş sayfası |
| `Views/` | Her entity için Liste, Oluştur, Güncelle view'ları |
| `appsettings.example.json` | Yapılandırma şablonu (şifresiz) |

---

## ⚙️ Kurulum ve Çalıştırma

### Ön Gereksinimler

- .NET 10 SDK
- PostgreSQL 14+
- Visual Studio 2022 veya VS Code

### 1. appsettings.json Yapılandır

`appsettings.example.json` dosyasını kopyalayıp `appsettings.json` olarak kaydet:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=ApiDb;Username=postgres;Password=SIFREN"
  },
  "AdminCredentials": {
    "Username": "admin",
    "Password": "ADMIN_SIFREN"
  }
}
```

### 2. Migration Uygula

```bash
cd ApiWebV1
dotnet ef database update
```

### 3. API'yi Çalıştır

```bash
dotnet run --project ApiWebV1
```

Swagger UI: `https://localhost:{PORT}/swagger`

### 4. Admin Panelini Çalıştır

```bash
dotnet run --project ApiProjeWeb.UI
```

`/Login/Index` adresine giderek admin bilgilerinle giriş yap.

---

## 🔒 Güvenlik Notları

- `appsettings.json` `.gitignore` ile Git'ten gizlenmiştir — asla commit etme
- Diğer geliştiriciler için `appsettings.example.json` şablon olarak kullanılır
- Tüm admin rotaları kimlik doğrulama gerektirir — giriş yapmamış kullanıcılar login sayfasına yönlendirilir
