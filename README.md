# HelperAz
Projeto para auxiliar na depuração local de Azure Function Isolated.

## Configuração

Na pasta storage dentro do projeto Infrastructure adicone o json com o nome da sua AzureFunction, dentro inclua o payload da requisição.

![exemplo 01](https://github.com/Guhtol/HelperAz/assets/12552971/3694927f-36d9-4874-af21-df0f35c984ac)

## Instação

1- Execute o script powershell installAndUpdateProject.ps1 que se encontra dentro da pasta raiz do projeto

Via Commando
``` cmd
 cd CaminhoCompleto + PastadoProjeto -- exemplo C:\HelperAz
.\installAndUpdateProject.ps1   
```
**Obs:** Por enquanto o script está voltado para o windows utilizando power shell.

## Como utilizar

Basta executar o comando haz, que ira apresentar as AzureFunction que foram criadas na pasta storage


![image 02](https://github.com/Guhtol/HelperAz/assets/12552971/be50dfb8-3d00-4a82-97a9-65170fc76a2c)


## Adicional

Requer visual code instalado para edição do payload caso queira editar antes de enviar para a Azure Function

