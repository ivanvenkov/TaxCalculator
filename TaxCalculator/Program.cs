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
            containerBuilder.RegisterType<ConsoleReader>().As<IReader>().SingleInstance();
            containerBuilder.RegisterType<ConsoleWriter>().As<IWriter>().SingleInstance();
            containerBuilder.RegisterType<Engine>().As<IEngine>();

            var container = containerBuilder.Build();

            var engine = container.Resolve<IEngine>();

            engine.Run();
        }
    }
}

