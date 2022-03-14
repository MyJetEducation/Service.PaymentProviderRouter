using System.Runtime.Serialization;

namespace Service.PaymentProviderRouter.Grpc.Models
{
	[DataContract]
	public class PaymentProviderBridgeInfo
	{
		[DataMember(Order = 1)]
		public string ProviderCode { get; set; }

		[DataMember(Order = 2)]
		public string ServiceUrl { get; set; }
	}
}