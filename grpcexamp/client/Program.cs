// See https://aka.ms/new-console-template for more information
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using Grpc.Net.Client;
using server;
using client;
using System.Runtime.InteropServices;
using Google.Protobuf;
namespace client{
    class Program{
        
        static async Task Main(string[] args){
            Console.WriteLine("Calling a GRPC Service!");
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = 
            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var httpClient = new HttpClient(httpClientHandler);
            using var channel = GrpcChannel.ForAddress("https://localhost:7110",
                                                       new GrpcChannelOptions { HttpClient = httpClient });
            var client =  new ExportItem.ExportItemClient(channel);
            try{
                var filter = Console.ReadLine();
                QueryRequest q = new QueryRequest();
                q.Filter = filter;
                using (var clientData = client.FindItems(q)){
                    while(await clientData.ResponseStream.MoveNext(CancellationToken.None)){
                        var thisItem = clientData.ResponseStream.Current;
                        Console.WriteLine(thisItem);
                    }
                }
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
            }
            
        }
    }
}


