Projeto SeaGo
Resumo
O Projeto SeaGo é uma aplicação web desenvolvida com ASP.NET Core MVC para gerenciar o cadastro e login de indivíduos e empresas. 
O sistema inclui funcionalidades para manipulação de informações pessoais, detalhes de contato e detalhes técnicos para empresas operando em setores como cargueiros, 
petroleiros, pesqueiros, navios de passageiros e navios de contêineres.

Funcionalidades
Cadastro e login de usuários
Formulários separados para cadastro de indivíduos e empresas
Armazenamento e gerenciamento de detalhes pessoais e técnicos
Autenticação e autorização usando cookies
Operações CRUD para todos os modelos

Resumo dos Códigos
AccountController.cs: Controlador responsável pelo gerenciamento das ações de login, registro e logout.
HomeController.cs: Controlador responsável pelas ações padrão da home page.
Models: Contém as classes de modelo Account, Person, Company, ShipDetails, PersonAddress, PersonCompany e ApplicationDbContext, que representam as entidades do sistema e gerenciam a persistência dos dados.
Repositories: Contém as interfaces e implementações dos repositórios para Company e Person, seguindo o design pattern Repository.
Views: Contém as views Login e Register para renderização das páginas de login e registro, respectivamente, além das views padrão da home page.
Program.cs: Configuração inicial do aplicativo, incluindo a configuração do host web.
Startup.cs: Configuração dos serviços e middleware do aplicativo, incluindo configuração de banco de dados, autenticação e roteamento.