# 🚀 Real-Time Chat Application using SignalR

A simple yet powerful **real-time chat application** built with **ASP.NET Core SignalR** and **Entity Framework Core**.
This project demonstrates how to implement real-time communication, group messaging, and message persistence in a clean and practical way.

---

## 📌 Features

* 💬 Real-time messaging (broadcast to all clients)
* 👥 Group chat support
* 🔔 Live notifications when users join groups
* 💾 Message storage using Entity Framework Core
* 🔌 Connection lifecycle handling (connect / disconnect)

---

## 🛠️ Tech Stack

* ASP.NET Core
* SignalR
* Entity Framework Core
* SQL Server (or any EF-supported database)
* C#

---

## ⚙️ Setup & Installation

### 1️⃣ Clone the repository

```bash
git clone https://github.com/yosif-taha/SignalR.git
cd SignalR
```

### 2️⃣ Configure Database

Update your connection string in:

```json
appsettings.json
```

```json
"ConnectionStrings": {
  "DefaultConnection": "Server = .; Database = ChatProject; Trusted_Connection = True; TrustServerCertificate = True "
}
```

---

### 3️⃣ Apply Migrations

```bash
add-migration InitialCreate
update-database
```

---

### 4️⃣ Run the Application

```bash
dotnet run
```

---

### 5️⃣ Open in Browser

```
https://localhost:7027/
```

---

## 🔌 SignalR Hub Methods (API Usage)

### 📤 Send Message to All Clients

```csharp
sendmessage(chatMessage)
```

* Saves message to database
* Broadcasts to all connected users

---

### 👥 Join Group

```csharp
jointogroup(groupname, name)
```

* Adds user to a group
* Notifies other group members

---

### 📩 Send Message to Group

```csharp
sendmessagetogroup(name, groupname, message)
```

* Sends message only to a specific group

---

## 🧠 How It Works

* **SignalR Hub** acts as the communication bridge between server and clients
* Clients connect using a unique **ConnectionId**
* Messages are:

  * Stored in database (via EF Core)
  * Broadcasted instantly using SignalR

---


## 📂 Project Structure

```
/Hubs
  └── ChatHub.cs

/Data
  └── ChatContext.cs

/Models
  └── ChatMessage.cs
```

---

## 🚀 Future Improvements

* 🔐 Authentication & Authorization (JWT / Identity)
* 🟢 Online/Offline user status
* 📨 Private messaging (1-to-1)
* 📱 Frontend UI (Html / JS)
* 📊 Message history pagination

---


