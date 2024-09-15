### integrantes da equipe:<br>

|Rm|Nome|Turma
|--|--|--|
RM99503|Arthur Koga|TDSA
RM552254|Gabriel Benjamim|TDSA
RM550684|Henry Ribeiro|TDSR
RM99538|Murilo José|TDSR
RM98021|Pedro Sena|TDSA

 Sprint 3 .Net
#### Uma Api com estrutura de um e-commerce

## Arquitetura da API 
### Monolítico:
 O projeto esta em fase inicial,então optamos por utilizar o modelo monolítico. O sistemas foi pensado para corporativo interno que não exige escalabilidade massiva, a manutenção de um único código base simplifica o ciclo de desenvolvimento e operação. Sendo mais Simples e tendo baixo custo de produção inicial.

### Vantagens:
- **Desenvolvimento Rápido:** O desenvolvimento de uma aplicação monolítica tende a ser mais rápido, já que não há necessidade de criar contratos de interface entre diferentes serviços ou lidar com as complexidades da comunicação entre componentes distribuídos.
- **Desempenho em Cenários Simples:** Em aplicações que não demandam uma grande escalabilidade ou processamento distribuído, um monolito pode oferecer melhor desempenho, pois elimina a latência na comunicação entre serviços separados.
- **Facilidade de Testes e Depuração:** Como tudo está centralizado, realizar testes e depurar problemas é mais direto. Não é necessário se preocupar com comunicação entre serviços distribuídos, o que simplifica a correção de bugs.
---

## Diferenças entre arquitetura Monolítica e Microservices

### Monolítica

#### A arquitetura monolítica é um estilo de construção de software no qual todas as funcionalidades de uma aplicação estão centralizadas em um único código-base. Esse tipo de arquitetura era amplamente utilizado em projetos de software no passado

- Facilidade inicial de desenvolvimento: Para projetos pequenos, é mais rápido e simples começar com uma arquitetura monolítica, já que tudo está centralizado e não há necessidade de gerenciar comunicações entre serviços.

- Dificuldade de escalabilidade: A escalabilidade é mais complexa, pois geralmente é preciso escalar toda a aplicação, mesmo que apenas uma parte dela necessite de mais recursos.

- Manutenção complicada em sistemas grandes: À medida que o sistema cresce, a manutenção torna-se difícil, com equipes maiores enfrentando desafios para gerenciar o código, os testes e a implantação.

- Unidade única: Todo o sistema (front-end, back-end, lógica de negócio, banco de dados) está em um único aplicativo ou código-base.

- Implantação conjunta: Todo o sistema é implantado como uma unidade, o que significa que qualquer mudança ou atualização requer a reimplantação completa da aplicação.

---

### Microservices

#### A arquitetura de microservices é um estilo de design de software em que uma aplicação é dividida em vários serviços pequenos e independentes, cada um responsável por uma função específica do sistema. Esses serviços são executados separadamente, se comunicam entre si por meio de APIs ou mensagens assíncronas, e podem ser desenvolvidos, implantados e escalados de forma autônoma.

- Divisão por serviços independentes: O sistema é dividido em vários serviços menores, onde cada um é responsável por uma funcionalidade específica. Cada serviço tem seu próprio ciclo de vida, banco de dados (ou compartilhado) e pode ser desenvolvido, implantado e escalado separadamente.

- Baixo acoplamento: Os serviços são fracamente acoplados e comunicam-se entre si por meio de APIs (geralmente usando HTTP/REST ou mensagens assíncronas). Isso facilita a alteração de um serviço sem impactar os demais.

- Desenvolvimento distribuído: Permite que diferentes equipes trabalhem em serviços distintos de forma autônoma, usando tecnologias e frameworks diferentes, se necessário.

- Maior resiliência: Como os serviços são independentes, falhas em um serviço específico não necessariamente afetam o sistema inteiro, aumentando a tolerância a falhas.

- Complexidade de gerenciamento: A complexidade de gerenciar uma arquitetura multiservice pode ser maior, pois cada serviço requer seu próprio monitoramento, manutenção, integração e gerenciamento de dependências.
