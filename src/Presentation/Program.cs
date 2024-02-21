using Application.Command;
using Infrastructure;
using Microsoft.Extensions.Configuration;

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .AddEnvironmentVariables()
                            .Build();

var azureFunctionUrl = configuration.GetValue<string>("AzureFunctionUrl") ?? string.Empty;
if (string.IsNullOrEmpty(azureFunctionUrl))
{
    Console.WriteLine("Configuração AzureFunctionUrl não encontrada no arquivo appsetings.json");
    return;
}

var sendRequest = new SendRequestToAzureFunction(new ReadJsons(), azureFunctionUrl);
await sendRequest.ExecuteCommand();