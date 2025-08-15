# 📌 StudyProject

Projeto de estudo em **.NET 8** utilizando **Entity Framework Core** e **MySQL** para gerenciamento de pessoas, usuários e dispositivos.

## 📖 Descrição

O **StudyProject** é uma API de exemplo que gerencia:
- **Pessoas (Person)**
- **Usuários (User)** associados a uma pessoa
- **Dispositivos (Device)** atribuídos a um usuário

O objetivo é estudar e aplicar conceitos de:
- Relacionamentos entre entidades no **EF Core**
- **One-to-Many** (Person → Users)
- **One-to-One** (User → Device)
- DTOs para retorno customizado
- Boas práticas em repositórios e serviços

---

## 🗂 Estrutura do Projeto

```
StudyProject/
│
├── Controllers/
│   ├── PersonController.cs
│   └── UserController.cs
│
├── Models/
│   ├── Person.cs
│   ├── User.cs
│   └── Device.cs
│
├── DTOs/
│   ├── PersonUserDTO.cs
│   ├── UserDTO.cs
│   ├── CreateUserDTO.cs
│   └── CreateDeviceDTO.cs
│
├── Repositories/
│   ├── PersonRepository.cs
│   └── UserRepository.cs
│
├── Services/
│   ├── PersonService.cs
│   └── UserService.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Program.cs
└── README.md
```

---

## 🔗 Relacionamentos

- **Person** → **Users** (1:N)  
  Uma pessoa pode ter vários usuários.
- **User** → **Device** (1:1)  
  Um usuário possui um único dispositivo.

### Exemplo visual:

```
Person (1) --------- (N) User (1) --------- (1) Device
```

---

## ⚙️ Configuração do Banco de Dados

O projeto utiliza **MySQL** como banco de dados.

### Exemplo de `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=test_db;User=root;Password=123456;"
  }
}
```

No `Program.cs`:

```csharp
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 36))));
```

---

## 🚀 Executando o Projeto

### 1️⃣ Clonar o repositório
```bash
git clone https://github.com/seu-usuario/StudyProject.git
cd StudyProject
```

### 2️⃣ Restaurar dependências
```bash
dotnet restore
```

### 3️⃣ Criar o banco de dados e aplicar migrations
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 4️⃣ Rodar a API
```bash
dotnet run
```

---

## 📡 Endpoints Principais

### **Criar Pessoa**
`POST /api/person`

```json
{
  "name": "Mateus Sandes"
}
```

---

### **Criar Usuário com Device**
`POST /api/user/{personName}`

```json
{
  "login": "mateus.sandes@mailto.plus",
  "password": "Teste@123",
  "accesses": 44,
  "createDevicedTO": {
    "deviceName": "iPhone 15 Pro"
  }
}
```

---

### **Listar Pessoas e Usuários**
`GET /api/person`

Exemplo de retorno:

```json
[
  {
    "id": 1,
    "name": "Mateus Sandes",
    "personDto": [
      {
        "id": 1,
        "login": "mateus.sandes@mailto.plus",
        "password": "Teste@123",
        "accessess": 44,
        "personId": 1,
        "deviceId": 2
      }
    ]
  }
]
```

---

## 🛠 Tecnologias Utilizadas
- **.NET 8**
- **Entity Framework Core**
- **MySQL**
- **Pomelo.EntityFrameworkCore.MySql**
- **Swagger** para documentação

---

## 📜 Licença
Este projeto é apenas para fins de estudo e não possui licença específica.
