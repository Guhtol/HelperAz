using System.Diagnostics;
using Application.Refit;
using Application.SeedWork;
using Refit;

namespace Application.Command;
public class SendRequestToAzureFunction(IReadJsons readJsons, string azureFunctionUrl)
{
    private IReadJsons ReadJsons { get; } = readJsons;
    private string AzureFunctionUrl {get;} = azureFunctionUrl;
    public async Task ExecuteCommand()
    {
        Menu menuAzureFunctions = ReadJsons.FilesNames;
        (int key, string fileName) = menuAzureFunctions.StartAndGetValueSelected();

        Console.WriteLine("Deseja editar o input para envio do azure funciton?");
        Menu menuEditInputAzureFunction = new Dictionary<int, string>
        {
          {1, "Não"},
          {2, "Sim"}
        };

        (int keyOpenVsCode, _) = menuEditInputAzureFunction.StartAndGetValueSelected();

        if (keyOpenVsCode == 2)
        {
            var filePath = ReadJsons[key];
            using Process process = new();
            process.StartInfo = new()
            {
                UseShellExecute = true,
                FileName = $"code",
                Arguments = filePath,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            process.Start();
            Console.WriteLine("Digite qualquer tecla para continuar");
            Console.ReadKey();
        }

        var fileString = await ReadJsons.RedByKey(key).ConfigureAwait(false);
        var azureFunctionApi = RestService.For<IAzureFunctionRequest>(AzureFunctionUrl);
        var resultApi = await azureFunctionApi.SendRequest(fileName, new RequestAzureFunction(fileString));
        if (resultApi.IsSuccessStatusCode)
        {
            Console.WriteLine("A azure function {0} foi executada com os parametros {1}", fileName, fileString);
            return;
        }

        Console.WriteLine("Erro ao executar o procedimento {0}", resultApi.Error);
    }
}
