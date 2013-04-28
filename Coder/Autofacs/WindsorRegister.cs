using System;
using Castle.MicroKernel.Registration;

namespace Coder.Infra
{
    public class WindsorRegistrar
    {
        public static void RegisterObject(string objectName ,Type implementationType)
        {
            IoC.Container.Register(Component.For(implementationType).Named(objectName));
        }

        public static void RegisterSingleton(Type interfaceType, Type implementationType)
        {
            IoC.Container.Register(Component.For(interfaceType).ImplementedBy(implementationType).LifeStyle.Singleton);
        }

        public static void Register(Type interfaceType, Type implementationType)
        {
            IoC.Container.Register(Component.For(interfaceType).ImplementedBy(implementationType).LifeStyle.PerWebRequest);
        }

        public static void RegisterAllFromAssemblies(string a)
        {
            IoC.Container.Register(Types.FromAssemblyNamed(a).Pick().WithService.FirstInterface().Configure(c => c.LifestylePerWebRequest()));
        }
    }
}
