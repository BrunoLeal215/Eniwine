# Eniwine
Avaliação Hands-on - Descubra o assassino


## DESCRIÇÃO DO PROJETO ENIWINE
Tecnologia utilizadas:
⦁	Visual Studio Professional 2017;
⦁	Sql Server Express 2017

## DATABASE
A modelagem escolhida para desenvolvimento do teste foi criar 3 tabelas simples SEM relação entre elas
pois a lógica de qual suspeito, local e arma correta são válidadas pelo Back-end.
 
A conexão escolhida para uso da base de dados foi Database-first utilizando EntityFramework pela exigência nas regras do teste 
que pedia a geração de um script de criação da base de dados. Se fosse utilizada a metodologia Code-first, seria necessário gerar 
um DbInitialize que implicaria em desenvolvimento fora do escopo descrito no teste.

Para executar os scripts da base de dados utilizada no projeto BAIXE o arquivo SQlScripts.sql localizado na mesma pasta deste documento 
e abra o mesmo no Sql Server Management Studio. Execute o script com F5, ou clicando no botão EXECUTE.

## FRONT-END
O front-end utilizado foi razor e bootstrap nativo do visual studio 2017 MVC. A escolha de utilizar bootstrap foi devido a praticidade de utilizar algo nativo e usar o tempo restante para desenvolvimento do back end.

## EXECUTANDO O PROJETO NO VISUAL STUDIO

- Através do git clone o projeto num diretório da sua escolha pelo link https://github.com/BrunoLeal215/Eniwine.git.
- Execute o arquivo EniWine.sln para abrir no Visual Studio 2017.
- Certifique-se que a base de dados está devidamente conectada no projeto atráves do SERVER EXPLORER, localizado na opção VIEW >> Server Explorer
no Visual Studio
- Execute a aplicação com F5.

*Obs.: Podem ocorrer erros variados na execução desse procedimento que depende do ambiente onde a aplicação será executada.
Caso ocorra problemas na execução deste procedimento por favor entrar em contato com o administrador.


