using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Service.Core.Client.Extensions;
using Service.Grpc;
using Service.PaymentProviderRepository.Grpc;
using Service.PaymentProviderRepository.Grpc.Models;
using Service.PaymentProviderRouter.Grpc;
using Service.PaymentProviderRouter.Grpc.Models;
using Service.PaymentProviderRouter.Settings;

namespace Service.PaymentProviderRouter.Services
{
	public class PaymentProviderRouterService : IPaymentProviderRouterService
	{
		private readonly ILogger<PaymentProviderRouterService> _logger;
		private readonly IGrpcServiceProxy<IPaymentProviderRepositoryService> _providerRepositoryService;

		public PaymentProviderRouterService(ILogger<PaymentProviderRouterService> logger, IGrpcServiceProxy<IPaymentProviderRepositoryService> providerRepositoryService)
		{
			_logger = logger;
			_providerRepositoryService = providerRepositoryService;
		}

		public async ValueTask<PaymentProviderBridgeInfo> GetPaymentProviderBridgeAsync(GetPaymentProviderBridgeGrpcRequest request)
		{
			ValueTask<PaymentProviderBridgeInfo> GetNoProviderResult() => ValueTask.FromResult(new PaymentProviderBridgeInfo());

			PaymentProvidersGrpcResponse providersResponse = await _providerRepositoryService.Service.GetProviders();
			PaymentProviderGrpcModel[] providers = providersResponse?.Items;
			if (providers == null)
			{
				_logger.LogError("Can't get providers list for request {@request}.", request);
				return await GetNoProviderResult();
			}

			PaymentProviderGrpcModel provider = providers
				.Where(prov => prov.Currencies.IsNullOrEmpty() || prov.Currencies.Contains(request.Currency))
				.Where(prov => prov.SupportCountries.IsNullOrEmpty() || prov.SupportCountries.Contains(request.Country))
				.Where(prov => prov.RestrictedCountries.IsNullOrEmpty() || !prov.RestrictedCountries.Contains(request.Country))
				.OrderByDescending(prov => prov.Weight)
				.FirstOrDefault();

			if (provider == null)
			{
				_logger.LogError("Can't find provider for request {@request}.", request);
				return await GetNoProviderResult();
			}

			string providerCode = provider.Code;
			string providerUrl = GetProviderUrl(providerCode);

			if (providerUrl == null)
			{
				_logger.LogError("Can't find provider {code} url for request {@request}.", providerCode, request);
				return await GetNoProviderResult();
			}

			_logger.LogInformation("Provider {code} selected for payment request {@request}.", providerCode, request);

			return new PaymentProviderBridgeInfo
			{
				ProviderCode = providerCode,
				ServiceUrl = providerUrl
			};
		}

		private static string GetProviderUrl(string providerCode)
		{
			PaymentProviderUrlsSettingsModel urls = Program.ReloadedSettings(model => model.ProviderUrls).Invoke();

			return providerCode switch {
				"test" => urls.TestUrl,
				"test2" => urls.Test2Url,
				"test3" => urls.Test3Url, 
				_ => null
				};
		}
	}
}