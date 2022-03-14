using Autofac;
using Microsoft.Extensions.Logging;
using Service.PaymentProviderRepository.Client;

namespace Service.PaymentProviderRouter.Modules
{
	public class ServiceModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterPaymentProviderRepositoryClient(Program.Settings.PaymentProviderRepositoryServiceUrl, Program.LogFactory.CreateLogger(typeof (PaymentProviderRepositoryClientFactory)));
		}
	}
}