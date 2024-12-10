**Estrutura DDD:**
- **Domain**: Contém as entidades e os services, separa a regra de negócio e entidade de negócio do resto do sistema.
- **Application**: Orquestra a chamada entre infraestrutura e o domínio da aplicação.
- **Infrastructure**: Implementa repositórios, contexto de banco (AppDbContext) e segurança (JWT), de forma geral,
                      prover os recursos técnicos e detalhes de implementação necessários ao funcionamento da aplicação.

## Desafios Encontrados

1. **Qual banco utilizar**:
   Foi escolhido a utilização do Sqlite em memória e o entityFrameWork, visando facilitar a executação da api localmente.

2. **Qual forma de autenticação do usuário**:  
   Optou-se por utilizar token JWT, visando simplicidade e visto que é gravar diretamente como cookie ao chamar a api
   e é fácil de enviar o cookie no header para requisições que necessitam autenticação.

3. **Documentação com o Swagger**:  
   Para facilitar a chamada de métodos, foi adicionado a documentação com o swagger, já que ao executar a api local o swagger já fica habilitado.

4. **Abstraçao, Desacomplamento e Implementação futura de testes*:
   Para facilitar a mudança de tecnologias, facilitar a criação de testes unitários e de integração, no futuro e trabalhar
   e estruturar as particularidades de implementaçao, forma utilizadas interfaces nas camadas de serviço e infra.


### Pré-requisitos

- **.NET 9.0 SDK** instalado
- **Node.js (>=16)** e **npm** ou **yarn** instalados
- **Git** instalado
