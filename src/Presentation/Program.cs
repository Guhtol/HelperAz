using Application.Command;
using Infrastructure;

var sendRequest = new SendRequestToAzureFunction(new ReadJsons());
await sendRequest.ExecuteCommand();