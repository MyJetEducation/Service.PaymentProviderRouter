using MyYamlParser;

namespace Service.PaymentProviderRouter.Settings
{
	public class PaymentProviderUrlsSettingsModel
	{
		[YamlProperty("TestUrl")]
		public string TestUrl { get; set; }

		[YamlProperty("Test2Url")]
		public string Test2Url { get; set; }

		[YamlProperty("Test3Url")]
		public string Test3Url { get; set; }
	}
}