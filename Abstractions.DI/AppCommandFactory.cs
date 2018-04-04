using Abstractions.Common.Interfaces;
using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abstractions.DI
{
    public static class AppCommandFactory
    {
        public static IAppCommand CreateAppCommand(ILifetimeScope scope, string typeName)
        {
            var calculation = scope.ResolveNamed<ICalculation>(typeName);
            var provider = scope.Resolve<INumericFileProvider>(
                new TypedParameter(typeof(System.Reflection.Assembly), typeof(Abstractions.Common.NumericFile).Assembly),
                new TypedParameter(typeof(string), "Abstractions.Common.SourceData.Numerics.txt"));

            var appCommand = scope.Resolve<IAppCommand>(new TypedParameter(typeof(ICalculation), calculation));
            return appCommand;
        }
    }
}
