using Abstractions.Common.Interfaces;
using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abstractions.DI
{
    /// <summary>
    /// A static factory class to manage the instantiation of AppCommand objects for
    /// the requested types and named types
    /// </summary>
    public static class AppCommandFactory
    {
        /// <summary>
        /// Uses the Autofac ILifetimeScope and the provided typeName value to instantiate the correct
        /// type instance from among the registered types.
        /// </summary>
        /// <typeparam name="T">The type on which the AppCommand instance will act.</typeparam>
        /// <param name="scope">The Autofac ILifetimeScope.</param>
        /// <param name="typeName">The typeName to be used for resolving the specific operation.</param>
        /// <returns></returns>
        public static IAppCommand<T> GetAppCommand<T>(ILifetimeScope scope, string typeName)
        {
            // This code has some 'splainin' to do.

            // Notice that the only things explicitly constructed in this factory method are instances of TypedParameter.
            // These allow the Autofac DI framework to supply parameters to the constructors of the types it looks up
            // from the constructed ILifetimeScope. The idea here is that it's not the job of our components to figure out
            // what concrete objects they need in order to carry out their tasks. We depend on the DI framework to do that
            // work for us. However, our example has multiple implementations of the same interface, and our code needs
            // help to figure out which concrete instance they need, but only using a minimal set of common knowledge:
            // the type on which the calculation operates, and a string value that further disambiguates the selection of
            // interface implementations.

            // We set up the resourceId and calculation early so we can resolve them differently based on the generic type
            var resourceId = string.Empty;
            ICalculation<T> calculation = null;

            if (typeof(T) == typeof(string))
            {
                // Right now, we only have one string calculation, so we don't resolve named classes here (but we could).
                // We also need to say which resource ID to look up
                resourceId = "Abstractions.Common.SourceData.Strings.json";
                calculation = scope.Resolve<ICalculation<T>>();
            }
            else // blindly assuming we're working with doubles if not strings
            {
                // Yes, this code is really optimistic and assumes that if you aren't after strings, you're after doubles.
                // (Hey, it's sample code.) 
                resourceId = "Abstractions.Common.SourceData.Numerics.txt";
                calculation = scope.ResolveNamed<ICalculation<T>>(typeName);
            }

            // The IPairwiseFileProvider implmentations need an assembly parameter and a resourceId parameter,
            // and this code supplies them.
            var provider = scope.Resolve<IPairwiseFileProvider<T>>(
                new TypedParameter(typeof(System.Reflection.Assembly), typeof(Abstractions.Common.NumericFile).Assembly),
                new TypedParameter(typeof(string), resourceId));

            // You must pass the ICalculation to Resolve, since there is more than one type register to resolve to the ICalculation.
            // TODO: Matt Zion, did you want to say something else here?
            var appCommand = scope.Resolve<IAppCommand<T>>(
                new TypedParameter(typeof(ICalculation<T>), calculation),
                new TypedParameter(typeof(IPairwiseFileProvider<T>), provider)
            );
            return appCommand;
        }
    }
}
