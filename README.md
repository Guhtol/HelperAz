# HelperAz
Projeto para enviar requisições Http para Azure Function com objetivo de testar localmente


## Configuração

Na pasta storage dentro do projeto Infrastructure adicone o json com o nome da sua AzureFunction, dentro inclua o payload da requisição.

![exemplo 01](https://github.com/Guhtol/HelperAz/assets/12552971/3694927f-36d9-4874-af21-df0f35c984ac)

## Instação

1- Realize o build em modo release da aplicação 

Via Commando
``` cmd
 cd \PastaDoPojeto
 dotnet build -c Release
```

2- O caminho do executável estára dentro da pasta HelperAz\src\Presentation\bin\Release\net7.0, copie o caminho completo até net7.0 e inclua nas variaveis de ambiente 

Exemplo:
``` cmd
  c:\git\HelperAz\src\Presentation\bin\Release\net7.0
```

## Como utilizar

Basta executar o comando haz, que ira apresentar as AzureFunction que foram criadas na pasta storage


![image 02](https://github.com/Guhtol/HelperAz/assets/12552971/be50dfb8-3d00-4a82-97a9-65170fc76a2c)


## Adicional

Requer visual code instalado para edição do payload caso queira editar antes de enviar para a Azure Function

