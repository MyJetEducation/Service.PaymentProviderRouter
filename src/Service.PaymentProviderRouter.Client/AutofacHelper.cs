using Autofac;
using Microsoft.Extensions.Logging;
using Service.PaymentProviderRouter.Grpc;
using Service.Grpc;

// ReSharper disable UnusedMember.Global

namespace Service.PaymentProviderRouter.Client
{
    public static class AutofacHelper
    {
        public static void RegisterPaymentProviderRouterClient(this ContainerBuilder builder, string grpcServiceUrl, ILogger logger)
        {
            var factory = new PaymentProviderRouterClientFactory(grpcServiceUrl, logger);

            builder.RegisterInstance(factory.GetPaymentProviderRouterService()).As<IGrpcServiceProxy<IPaymentProviderRouterService>>().SingleInstance();
        }
    }
}
