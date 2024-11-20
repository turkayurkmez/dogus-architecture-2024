// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information
using auth.Server;
using Grpc.Core;
using Grpc.Net.Client;
using System.Net.Security;
using System.Web;

Console.WriteLine("Hello, World!");
string? token = null;
var exiting = false;

using var channel = GrpcChannel.ForAddress("https://localhost:7183");
var client = new Greeter.GreeterClient(channel);

Console.WriteLine(".................");
Console.WriteLine("1. Karşılama servisi....");
Console.WriteLine("2. Authenticate....");
Console.WriteLine("3. Çıkış");


while (!exiting)
{
    var keyInfo = Console.ReadKey(true);
    switch (keyInfo.KeyChar)
    {
        case '1':
            greetings(client, token);
            break;
        case '2':
            token = await Authenticate();
            break;
        case '3':
            exiting = true;
            break;
    }
}

async Task greetings(Greeter.GreeterClient client, string? token)
{
    Console.WriteLine("istek gönderiliyor");
    Console.WriteLine(string.IsNullOrEmpty(token) ? "Token yok" : token);
    try
    {
        Metadata? headers = null;
        if (token != null)
        {
            headers = new Metadata();
            headers!.Add("Authorization", $"Bearer {token}");
        }

        var response = await client.SayHelloAsync(new HelloRequest { Name = "turkay" }, headers);
        Console.WriteLine(response.Message);
    }
    catch (RpcException ex1)
    {

        Console.WriteLine($"Rpc hatası oluştu... Hata: {ex1.Status.StatusCode}");
    }
    catch (Exception ex2)
    {
        Console.WriteLine($"Bir hata oluştu... Hata: {ex2.Message}");

    }


}

async Task<string?> Authenticate()
{
    string user = "turkay";
    using var httpClient = new HttpClient();
    using var request = new HttpRequestMessage
    {
        Method = HttpMethod.Get,
        RequestUri = new Uri($"https://localhost:7183/login?name={HttpUtility.UrlEncode(user)}"),
        Version = new Version(2, 0)
    };

    using var tokenResponse = await httpClient.SendAsync(request);
    tokenResponse.EnsureSuccessStatusCode();
    var token = await tokenResponse.Content.ReadAsStringAsync();
    Console.WriteLine("Token alındı");
    return token;

}