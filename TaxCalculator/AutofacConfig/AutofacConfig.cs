using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
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
            containerBuilder.RegisterType<TaxCalculatorService>().As<ITaxCalculatorService>();
            containerBuilder.RegisterType<ConsoleReader>().As<IReader>().SingleInstance();
            containerBuilder.RegisterType<ConsoleWriter>().As<IWriter>().SingleInstance();
            containerBuilder.RegisterType<Engine>().As<IEngine>();
        }
    }
}