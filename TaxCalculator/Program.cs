using Autofac;
using TaxCalculator.Contracts;
using TaxCalculator.Infrastructure;
using TaxCalculator.Services;

namespace TaxCalculator
{
    public class Program
    {
        public static void Main()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new AutofacConfig.AutofacConfig());
            var container = containerBuilder.Build();

            var engine = container.Resolve<IEngine>();

            engine.Run();
        }
    }
}

