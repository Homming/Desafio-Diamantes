# Desafio-Diamantes
Repositório para a entrega da resolução do problema proposto a ser resolvido em C# pelo grupo Voalle.

# Configuração
É necessário a criação de um arquivo <strong>.env</strong>
com os seguintes valores na raiz do projeto <strong>Diamantes</strong>

```
email=seu_email
senha=sua_senha
```
Com estas informações, a classe que cuida do envio de e-mail estará alimentada com as informações necessárias para o envio do e-mail via smtp gmail.

⚠️ Aviso: Atente-se as configurações de uso de aplicativos não seguros do gmail, para a permissão de envio de e-mails pela aplicação.

# Execução
Para a execução da aplicação, utilize os seguintes comandos:
```
$ cd src
$ dotnet restore
$ cd Diamantes
$ dotnet run
```

Para a execução dos testes unitários da aplicação, utilize os seguintes comandos
```
$ cd src
$ dotnet restore
$ cd Diamantes.Test
$ dotnet test
```
Pronto :)

## Criador
Nicholas Torres
