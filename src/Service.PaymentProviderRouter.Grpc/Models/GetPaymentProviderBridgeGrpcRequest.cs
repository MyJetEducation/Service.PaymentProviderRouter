using System;
using System.Runtime.Serialization;

namespace Service.PaymentProviderRouter.Grpc.Models
{
	[DataContract]
	public class GetPaymentProviderBridgeGrpcRequest
	{
		[DataMember(Order = 1)]
		public Guid? UserId { get; set; }

		[DataMember(Order = 2)]
		public decimal Amount { get; set; }

		[DataMember(Order = 3)]
		public string Currency { get; set; }

		[DataMember(Order = 4)]
		public string Country { get; set; }

		[DataMember(Order = 5)]
		public string ServiceCode { get; set; }
	}
}