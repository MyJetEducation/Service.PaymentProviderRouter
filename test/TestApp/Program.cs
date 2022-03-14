using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc.Client;
using Service.PaymentProviderRouter.Client;
using Service.PaymentProviderRouter.Grpc.Models;

namespace TestApp
{
    public class Program
    {
        private static async Task Main(string[] args)
        {
            GrpcClientFactory.AllowUnencryptedHttp2 = true;
            var logger = LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger<Program>();

            Console.Write("Press enter to start");
            Console.ReadLine();

            var factory = new PaymentProviderRouterClientFactory("http://localhost:5001", logger);
            var serviceProxy = factory.GetPaymentProviderRouterService();
            var client = serviceProxy.Service;

            //var resp = await client.SayHelloAsync(new HelloGrpcRequest {Name = "Alex"});
            //Console.WriteLine(resp?.Message);

            Console.WriteLine("End");
            Console.ReadLine();
        }
    }
}
