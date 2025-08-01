# 📝 BlogApi

Um projeto simples de API de blog, desenvolvido com .NET, que demonstra os princípios SOLID, validações, autenticação básica, notificações em tempo real com SignalR, e boas práticas de arquitetura.

---

## 🚀 Tecnologias Utilizadas

- ASP.NET Core 8
- Entity Framework Core (com banco InMemory ou PostgreSQL)
- SignalR (Notificações em tempo real)
- FluentValidation (Validações)
- Rate Limiting (Segurança)
- xUnit + Moq (Testes unitários)
- Swagger (Documentação automática)

---

## 📂 Estrutura de Pastas

```
src/
├── BlogApi.Domain
├── BlogApi.Application
├── BlogApi.Infrastructure
├── BlogApi.WebApi
└── BlogApi.Tests
```

---

## ⚙️ Como Rodar Localmente

1. **Clone o repositório**  
   `git clone https://github.com/seuusuario/BlogApi.git`

2. **Navegue até o diretório do projeto**  
   `cd BlogApi/src/BlogApi.WebApi`

3. **Execute o projeto**  
   `dotnet run`

4. **Acesse a documentação Swagger**  
   [http://localhost:5000/swagger](http://localhost:5000/swagger)

---

## 🔐 Endpoints

- `POST /auth/register` - Registrar usuário
- `POST /auth/login` - Login
- `GET /posts` - Listar todos os posts
- `GET /posts/{id}` - Obter um post
- `POST /posts` - Criar novo post
- `PUT /posts/{id}` - Editar post
- `DELETE /posts/{id}` - Excluir post

---

## 🧪 Testes

Para rodar os testes:

```bash
cd src/BlogApi.Tests
dotnet test
```

---

## 📡 WebSockets

Conecte-se a `ws://localhost:5000/notificationHub` para receber eventos como:

```json
"NewPost": {
  "title": "Título do post",
  "content": "Conteúdo...",
  "author": "Autor",
  "createdAt": "data"
}
```

---

## 🧰 Extras

- ✅ Validações com FluentValidation
- ✅ SignalR para notificação em tempo real
- ✅ Testes unitários para autenticação e postagens
- ✅ Rate limiting para segurança básica

---

## 👨‍💻 Autor

Desenvolvido por Maurício Carvalho - [LinkedIn](https://www.linkedin.com/in/mauriciocarvalhodev)

---

## 🖼️ Licença

MIT
