Este repositório contém o desenvolvimento dois projetos sendo uma API Back-End para consumo de EndPoints e um cliente Front-End.


# API BackEnd (crudapi)
 - Desenvolvida em C# com .NET 5;
 - Documentação de API com Swagger;
 - Conexão em banco de dados PostgreSQL;
 - Uso de injeção de dependência
 - Testes unitários com mock

# Cliente Front-End (crudweb)
 - Desenvolvido em Angular 12;
 - plugin UI Antd-Zorro;
 - CRUD completo de uma entidade;


# Como compilar aplicações (Não é necessário compilar para rodar usando imagens do DockerHub)

Frameworks necessários para compilação da API Back-End:
 - .NET 5.0;
Frameworks necessários para compilação do cliente Front-End:
 - Angular versão 12 ou posterior;
 - Node.js versão 14 ou posterior;


# Como rodar a aplicação via Docker

 1. Necessário ter o serviço docker instalado
 2. Se posicionar como containers linux;
 3. Efetuar o clone do repositório;
 4. Acessar a pasta 'Crud' via Prompt de Comando(cmd);
 5. executar o comando: docker-compose up
 6. Aguardar a instalação das imagens e a criação da network com os containers;

Será criado uma network chamada 'crud' contendo 4 containers docker:

- crud: network
	- crud-pgadmin-1: ferramenta para gerenciamento do banco de dados PostgreSQL;
	- crud-postgresql_database-1: banco de dados PostgreSQL;
	- crud-crudweb-1: cliente Front-End desenvolvido, link de acesso: http://localhost:8081/home
	- crud-crudapi-1: API Backend desenvolvida, link de acesso: http://localhost:6060/swagger