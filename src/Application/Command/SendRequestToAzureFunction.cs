using System.Diagnostics;
using Application.Refit;
using Application.SeedWork;
using Refit;

namespace Application.Command;
public class SendRequestToAzureFunction
{
    private IReadJsons ReadJsons { get; }
    public SendRequestToAzureFunction(IReadJsons readJsons)
    {
        ReadJsons = readJsons;
    }

    public async Task ExecuteCommand()
    {
        Menu menuAzureFunctions = ReadJsons.FilesNames;
        (int key, string fileName) = menuAzureFunctions.StartAndGetValueSelected();

        Console.WriteLine("Deseja editar o input para envio do azure funciton?");
        Menu menuEditInputAzureFunction = new Dictionary<int, string>
        {
          {1, "Sim"},
          {2, "Não"}
        };

        (int keyOpenVsCode, _) = menuEditInputAzureFunction.StartAndGetValueSelected();

        if (keyOpenVsCode == 1)
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
        var azureFunctionApi = RestService.For<IAzureFunctionRequest>("http://localhost:7042");
        var resultApi = await azureFunctionApi.SendRequest(fileName, new RequestAzureFunction(fileString));
        if (resultApi.IsSuccessStatusCode)
        {
            Console.WriteLine("A azure function {0} foi executada com os parametros {1}", fileName, fileString);
            return;
        }

        Console.WriteLine("Erro ao executar o procedimento", resultApi.Error);
    }
}
