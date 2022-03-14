using MyJetWallet.Sdk.Service;
using MyYamlParser;

namespace Service.PaymentProviderRouter.Settings
{
	public class SettingsModel
	{
		[YamlProperty("PaymentProviderRouter.SeqServiceUrl")]
		public string SeqServiceUrl { get; set; }

		[YamlProperty("PaymentProviderRouter.ZipkinUrl")]
		public string ZipkinUrl { get; set; }

		[YamlProperty("PaymentProviderRouter.ElkLogs")]
		public LogElkSettings ElkLogs { get; set; }

		[YamlProperty("PaymentProviderRouter.PaymentProviderRepositoryServiceUrl")]
		public string PaymentProviderRepositoryServiceUrl { get; set; }

		[YamlProperty("PaymentProviderRouter.PaymentProviderUrls")]
		public PaymentProviderUrlsSettingsModel ProviderUrls { get; set; }
	}
}