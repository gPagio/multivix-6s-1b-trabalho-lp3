# 🐴 Go Horse Voos Comerciais API
Este é a API Go Horse Voos Comerciais, uma API que resolve questões de gerenciamento das passagens para companhias de transporte aéreo.

## 💡Objetivo
O objetivo deste desafio foi proporcionar uma experiência real no mundo do desenvolvimento a partir de uma avaliação processual (trabalho). Foi proposto para os alunos a contrução de uma `API Rest`, a qual seria o `backend` de uma aplicação que gerencia passagens para companhia de transporte aéreo realizando um `CRUD`.

## 📝 End Points
Os end points dessa API estão mapeados com o Swagger. Para acessar esse mapeamento, rode o projeto e entre em:

```
http://localhost:5225/swagger/index.html
```

Dentre os end points, está listado abaixo as possibilidades disponibilizadas pelos mesmos:

1. Cadastrar Cliente
1. Listar Todos os Clientes Cadastrados
1. Listar Cliente por CPF
1. Cadastrar Companhia Operante
1. Listar Todas as Companhias Operantes
1. Cadastrar Locais
1. Listar Todos os Locais
1. Realizar CheckIn
1. Emitir Relatório de Ocupação
1. Emitir Relatório de Vendas
1. Cadastrar Reserva
1. Cancelar Reserva
1. Listar Voo por ID
1. Listar Voo por ID de Origem, ID de Origem, Data de Ida e Data de Volta (Se aplicável)
1. Cadastrar Voo

## 📌 Dependências
Para o correto funcionamento do Go Horse Voos Comerciais, é necessário realizar a instalação das dependências abaixo. Clique no hyperlink em cada uma delas para ir a respectiva página de downloads.
 - [`PostgreSQL`](https://www.postgresql.org/download/): Banco de dados usado pelo Go Horse Voos Comerciais

## ⚙️ Configurações
Antes de executar o projeto devemos configurar algumas variáveis de ambiente em nossa máquina.

Abaixo estão listadas as variáveis de deverão ser criadas e o conteúdo que deve conter em cada uma delas:
|Variável|Conteúdo|Exemplo|
|---|---|---|
|`GHVC_DB_HOST`|Host do banco de dados|127.0.0.1|
|`GHVC_DB_PORT`|Informa a porta para conexão do banco de dados|5432|
|`GHVC_DB_DATABASE`|Informa o nome do banco de dados|go-horse-voos-comerciais|
|`GHVC_DB_USER`|Informa a senha do usuário definido na variável anterior|postgres|
|`GHVC_DB_PASSWORD`|Informa a chave secreta utilizada para assinar e verificar a autenticidade dos tokens JWT. Deve ser um número aleatório e secreto.|123456|

## 🚀 Uso
Para executar o projeto temos duas opções:

### 1ª Opção
Abra o mesmo com a `IDE Visual Studio 2022`, ao lado do botão que roda os projetos, clique na seta e selecione `http`. Após a etapa anterior basta executar o projeto.

### 2ª Opção
Entre na pasta do projeto pelo terminal e execute o comando abaixo:

```
dotnet run
```

Em seguida, basta usar normalmente os end poins para realizar as ações desejadas.

## ⚠️ Avisos
1. Este projeto foi construído e testado sobre o `.NET 8.0`, dessa forma recomendamos o uso do mesmo durante a execução do mesmo.
