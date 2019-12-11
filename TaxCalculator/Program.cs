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

            containerBuilder.RegisterType<ImaginariaRateProvider>().As<IRatesProvider>();
            containerBuilder.RegisterType<TaxCalculatorService>().As<ITaxCalculatorService>();
            containerBuilder.RegisterType<Engine>().AsSelf();

            var container = containerBuilder.Build();

            var engine = container.Resolve<Engine>();

            engine.Run();
        }
    }
}

