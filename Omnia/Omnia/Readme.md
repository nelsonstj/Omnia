# Sales API DDD

## Descrição

Esta é uma API para gerenciamento de vendas seguindo os princípios de **Domain-Driven Design (DDD)**. A API permite:

- Criar vendas
- Listar todas as vendas
- Obter detalhes de uma venda específica
- Cancelar uma venda
- Listar clientes, filiais e produtos

## Tecnologias Utilizadas

- **.NET Framework (C#)**
- **ASP.NET Web API**
- **Armazenamento baseado em arquivos JSON** (sem banco de dados)
- **Injeção de Dependência**
- **Eventos de Domínio** (Domain Events)
- **Swagger** (para documentação da API)
---

## Configuração do Projeto

### 1. Clonar o Repositório

```sh
git clone <URL_DO_REPOSITORIO>
cd SalesApiDDD
```

### 2. Configurar Arquivos de Dados

Os dados são armazenados em arquivos JSON dentro da pasta `Infrastructure/Persistence`. Certifique-se de que os seguintes arquivos existam:

```
Infrastructure/Persistence/sales.json
Infrastructure/Persistence/customers.json
Infrastructure/Persistence/branches.json
Infrastructure/Persistence/products.json
```

Caso os arquivos não existam, a API os criará automaticamente.

### 3. Configurar `appsettings.json`

Verifique se o arquivo `appsettings.json` está corretamente configurado:

```json
{
  "DataStorage": {
    "SalesFilePath": "Infrastructure/Persistence/sales.json",
    "CustomersFilePath": "Infrastructure/Persistence/customers.json",
    "BranchesFilePath": "Infrastructure/Persistence/branches.json",
    "ProductsFilePath": "Infrastructure/Persistence/products.json"
  }
}
```

### 4. Executar a API

No terminal/prompt de comando, rode:

```sh
dotnet run
```

A API estará disponível em:

```
http://localhost:5000
```

### 5. Acessar a Documentação via Swagger

O Swagger está configurado para facilitar a interação com a API. Após iniciar a aplicação, acesse:

```
http://localhost:5000/swagger
```

Isso permitirá testar os endpoints diretamente pelo navegador.

---

## Endpoints Disponíveis

### Criar uma Venda

**POST** `/api/sales`

```json
{
  "saleDate": "2024-03-14T12:00:00",
  "customer": "Nelson",
  "branch": "Branch A",
  "items": [
    {
      "product": "Product A",
      "quantity": 5,
      "unitPrice": 10.00
    }
  ]
}
```

**Resposta:** `201 Created`

```json
{
  "id": 1,
  "saleNumber": "S000001",
  "saleDate": "2024-03-14T12:00:00",
  "customer": "Nelson",
  "branch": "Branch A",
  "totalAmount": 45.00,
  "items": [
    {
      "product": "Product A",
      "quantity": 5,
      "unitPrice": 10.00,
      "discount": 5.00,
      "total": 45.00
    }
  ],
  "isCancelled": false
}
```

### Listar todas as Vendas

**GET** `/api/sales`

### Obter uma Venda Específica

**GET** `/api/sales/{id}`

### Cancelar uma Venda

**POST** `/api/sales/{id}/cancel`

### Listar Clientes

**GET** `/api/customers`

### Listar Filiais

**GET** `/api/branches`

### Listar Produtos

**GET** `/api/products`

---

## Regras de Negócio

- Compras **acima de 4 itens idênticos** recebem **10% de desconto**.
- Compras **entre 10 e 20 itens idênticos** recebem **20% de desconto**.
- **Não é possível vender mais de 20 itens idênticos**.
- **Compras abaixo de 4 itens não têm desconto**.

---

## Testando a API

### Usando `curl`

```sh
curl -X GET http://localhost:5000/api/sales
```

### Usando Postman ou Insomnia

- Importar os endpoints manualmente
- Enviar requisições para os endpoints mencionados

### Usando Swagger

Após rodar a aplicação, acesse:

```
http://localhost:5000/swagger
```

Lá, é possível testar os endpoints diretamente na interface web.

---

## Contato

Caso tenha dúvidas ou sugestões, entre em contato.

