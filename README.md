# ProjetoUpd8
CONFIGURAÇÕES INICIAIS DO PROJETO

-Acesse o projeto da API e encontre o arquivo "appsettings.json" e dentro da sessão "ConnectionString" -> "ServerConnection" coloque a referencia a sua instancia de banco de dados.(obs: Será necessario adicionar essa referencia nos 2 projetos, no projeto do front, só é necessario por conta do método POST, ao fazer direto da pagina .cshtml ele retornava o status 415, por conta disso foi criado um método no controler para consumir a api utilizandos os métodos POST, DELETE E PUT)


DETALHES DO PROJETO

-O projeto do front foi construido 100% com jquery e ajax e bootstrap, ele foi feito de uma maneira que pareça uma aplicação SPA(single-page-application) em nenhum momento tem a necessidade do reload da pagina, basicamente no html só tem o modal, a tabela é contruida via jquery de acordo com os dados recebidos da API, essa requisição também foi feita na própia pagina utilizando o AJAX. 


-A pagina conta com 5 botões: 
"Novo Cliente" Ao clicar nela, o modal é carregado para o registro de um novo cliente.
"Atualizar" esse botão é gerado dentro da tabela e cada indice vai ter um, ao clicar nele é gerado o modal com as informações do cliente escolhido.
"Excluir" esse botão é gerado dentro da tabela e cada indice vai ter um, ao clicar, o paciente escolhido é excluido pela API e ocorre um reload imperceptivel retirando aquele indice.  
"Salvar" Dentro do modal existe essa opção de salvar as informações do novo cliente ou clientes alterado, ao clicar nele é ativada uma função de validação dos campos.
"Cancelar" Dentro do modal, caso tenha um clique nele, o sistema fecha a modal e retorna para a tabela sem a necessidade de reiniciar a pagina


-Os dados das combos de Estado E Municipios são recuperados através do consumo de uma API do IBGE: https://servicodados.ibge.gov.br/api/docs/localidades e esse consumo é feito via ajax, sobre as funcionalidades, ao selecionar um Estado a dropdown de Municipios é atualizada automaticamente carregando os municipios daquela cidade.


-A manipulação da tabela é feita usando a biblioteca do https://datatables.net/, nela as funções de paginação e manipulação da tabela já estão prontos.


-A API em si, pode ser acessada pela seguinte URL: "https://localhost:7062/api/Cliente" após a execução Foi criado apenas um CRUD basico na API.

-Na parte do acesso ao banco de dados foi utilizado o EntityFrameworkCore junto com o SQL SERVER.




