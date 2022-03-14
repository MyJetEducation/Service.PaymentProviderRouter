using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Service.PaymentProviderRouter.Grpc;
using Service.Grpc;

namespace Service.PaymentProviderRouter.Client
{
    [UsedImplicitly]
    public class PaymentProviderRouterClientFactory : GrpcClientFactory
    {
        public PaymentProviderRouterClientFactory(string grpcServiceUrl, ILogger logger) : base(grpcServiceUrl, logger)
        {
        }

        public IGrpcServiceProxy<IPaymentProviderRouterService> GetPaymentProviderRouterService() => CreateGrpcService<IPaymentProviderRouterService>();
    }
}
