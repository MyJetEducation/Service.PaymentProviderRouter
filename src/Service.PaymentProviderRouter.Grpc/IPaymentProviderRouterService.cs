using System.ServiceModel;
using System.Threading.Tasks;
using Service.PaymentProviderRouter.Grpc.Models;

namespace Service.PaymentProviderRouter.Grpc
{
	[ServiceContract]
	public interface IPaymentProviderRouterService
	{
		[OperationContract]
		ValueTask<PaymentProviderBridgeInfo> GetPaymentProviderBridgeAsync(GetPaymentProviderBridgeGrpcRequest request);
	}
}