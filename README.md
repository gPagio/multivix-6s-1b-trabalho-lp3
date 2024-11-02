# 🐴 Go Horse Voos Comerciais API
Este é a API Go Horse Voos Comerciais, uma API que resolve questões de gerenciamento das passagens para companhias de transporte aéreo.

## 💡Objetivo
O objetivo deste desafio foi proporcionar uma experiência real no mundo do desenvolvimento a partir de uma avaliação processual (trabalho). Foi proposto para os alunos a contrução de uma `API Rest`, a qual seria o `backend` de uma aplicação que gerencia passagens para companhia de transporte aéreo realizando um `CRUD`.

## 📝 End Points
### 🟢 Swagger
Os end points dessa API estão mapeados com o Swagger. Para acessar esse mapeamento, rode o projeto e entre em:

```
http://localhost:5225/swagger/index.html
```

### 🐶 Bruno
Além do Swagger, na pasta raiz do projeto existe uma pasta chamada endpoints, onde a mesma possui todos os endpoints usados para testar a API.

Para fazer o uso desses arquivos intale o [`Bruno`](https://www.usebruno.com/) e importe a coleção de endpoints (pasta mencionada anteriormente) pelo botão `Open Collection`, o qual pode ser encontrado clicando em três pontinhos do lado esquerdo da tela.

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
