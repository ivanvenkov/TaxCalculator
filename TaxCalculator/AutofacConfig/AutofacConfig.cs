using Autofac;
using TaxCalculator.Contracts;
using TaxCalculator.Infrastructure;
using TaxCalculator.Services;

namespace TaxCalculator.AutofacConfig
{
    public class AutofacConfig : Autofac.Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<RatesProvider>().As<IRatesProvider>();
            containerBuilder.RegisterType<InputValidator>().As<IInputValidator>();
            containerBuilder.RegisterType<TaxCalculatorService>().As<ITaxCalculatorService>();
            containerBuilder.RegisterType<ConsoleReader>().As<IReader>().SingleInstance();
            containerBuilder.RegisterType<ConsoleWriter>().As<IWriter>().SingleInstance();
            containerBuilder.RegisterType<Engine>().As<IEngine>();
        }
    }
}