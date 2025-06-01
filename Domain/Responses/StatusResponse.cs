using System.Text.Json;

namespace Domain.Responses;

public class StatusResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public Dictionary<string, string>? Data { get; set; }

    /*public static object PrintAsJson(int statusCode, string message, Dictionary<string, string>? data = null)
    {
        var response = new StatusResponse
        {
            StatusCode = statusCode,
            Message = message,
            Data = data
        };

        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(response, options);
        Console.WriteLine(json);

        return json;
    }*/
}