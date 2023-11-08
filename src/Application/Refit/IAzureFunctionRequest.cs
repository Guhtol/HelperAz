using Refit;

namespace Application.Refit;

public interface IAzureFunctionRequest
{
    [Post("/admin/functions/{azureFunctionName}")]
    Task<IApiResponse> SendRequest(string azureFunctionName, [Body(BodySerializationMethod.Serialized)] RequestAzureFunction input);
}

public record RequestAzureFunction(string Input);