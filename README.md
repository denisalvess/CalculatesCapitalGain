# Ganho de Capital

CLI para calcular o imposto a ser pago sobre lucros ou prejuízos de operações no mercado financeiro de ações.

## Estrutura da aplicação 

A arquitetura escolhida foi  Hexagonal com Clean Architecture , usando boas praticas de programação com: DDD, CLEAN CODE  e SOLID.
A camada de aplicação coordena a execução de uma tarefa e delega para a camada de dominio.

Futuramente podemos adicionar mais uma camada de Infrastrutura para conexões externas.
Uma melhria seria implementar o CQRS


## Exemplo de execução local 

Navegue até o diretório da aplicação exe
```
 cd rsc/CalculatesCapitalGain
```
```
$ dotnet run ../UnitTest/data/case_01/input.txt
[{"tax": 0.0}, {"tax": 0.0}, {"tax": 0.0}]
```

```
$ dotnet run ../UnitTest/data/case_02/input.txt
[{"tax": 0.0}, {"tax": 10000.0}, {"tax": 0.0}]
```

```
dotnet run ../UnitTest/data/case_03/input.txt
[{"tax": 0.0}, {"tax": 0.0}, {"tax": 1000.0}]
```

```
dotnet run ../UnitTest/data/case_10/input.txt
[{"tax": 0.00}, {"tax": 0.00}, {"tax": 1000.00}]
[{"tax": 0.00}, {"tax": 0.00}, {"tax": 0.00}]
[{"tax": 0.00}, {"tax": 0.00}, {"tax": 0.00}, {"tax": 10000.00}]
[{"tax": 0.00}, {"tax": 0.00}, {"tax": 0.00}, {"tax": 0.00}, {"tax": 3000.00}]
```

## Utilizando a aplicação com Docker

Para construir uma imagem Docker execute os seguintes comando:

```
$ docker build -t calculatescapitalgain .
```

Agora é possível executar a aplicação via Docker passando os cenários de testes de 1 à 12

```
$ docker run  calculatescapitalgain /app/data/case_10/input.txt
[{"tax": 0.00}, {"tax": 0.00}, {"tax": 1000.00}]
[{"tax": 0.00}, {"tax": 0.00}, {"tax": 0.00}]
[{"tax": 0.00}, {"tax": 0.00}, {"tax": 0.00}, {"tax": 10000.00}]
[{"tax": 0.00}, {"tax": 0.00}, {"tax": 0.00}, {"tax": 0.00}, {"tax": 3000.00}]
```


## Testando a aplicação

Para teste local navegue até a pasta da aplicação de teste:

```
$ cd rsc/UnitTest
```

Depois execudo o comando:

```
$ dotnet test
```

Ao executar o Docker a aplicação será testada


## Explicação da aplicação

CalculatesCapitalGain/
├── src/
│ ├── Application/
│ │ ├── Ports/ # Interfaces para comunicação com o mundo externo
│ │ ├── UseCases/ # Implementações dos casos de uso
│ ├── Domain/
│ │ ├── Constantes/ # Constantes usadas no domínio
│ │ ├── Entities/ # Entidades principais do domínio
│ │ ├── Exceptions/ # Exceções específicas do domínio
│ ├── UnitTest/ # Testes unitários para a aplicação
│ ├── CalculatesCapitalGain
│ │ ├── Program.cs # Ponto de entrada da aplicação
│ │

Camadas Explicadas
- Application:
   - Ports: Contém interfaces que definem contratos para comunicação com o mundo externo.     Isso pode incluir interfaces para repositórios, serviços externos, etc.
   - UseCases: Implementações dos casos de uso da aplicação. Cada caso de uso representa uma operação específica que a aplicação pode realizar, encapsulando a lógica de negócios.
- Domain:
  - Constantes: Armazena valores constantes que são usados em todo o domínio, como taxas fixas ou limites.
  - Entities: Define as entidades principais do domínio, que são objetos que possuem identidade e estado.
  - Exceptions: Contém exceções específicas do domínio que são usadas para tratar erros de forma consistente.
- UnitTest:
Contém testes unitários para verificar a funcionalidade das diferentes partes da aplicação. Os testes garantem que cada unidade de código funcione conforme esperado.
- CalculatesCapitalGain:
  - Program.cs: O ponto de entrada da aplicação, onde a execução começa. Ele geralmente configura o ambiente e inicia a aplicação.
- Dockerfile: Arquivo de configuração para containerização da aplicação com Docker, permitindo que ela seja executada em ambientes isolados.
Notas Adicionais
Clean Architecture: A estrutura do projeto segue princípios de Clean Architecture, que promove a separação de responsabilidades e facilita a manutenção e escalabilidade.
- README.md: Documento que fornece uma visão geral do projeto, instruções de configuração e execução, e informações sobre como contribuir.
Essa estrutura modular ajuda a manter o código organizado e facilita a colaboração e a manutenção do projeto.
