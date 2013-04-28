using System;
using Castle.Windsor;

namespace Coder.Infra
{
    /// <summary>
    /// 将把所有需要注入的controller和service进行注入
    /// 并且将xml文件中注册的借口实例注入 
    /// </summary>
    /// 
    public static class IoC
    {
        private static readonly object LockObj = new object();

        private static IWindsorContainer container = new WindsorContainer();

        public static IWindsorContainer Container
        {
            get { return container; }

            set
            {
                lock (LockObj)
                {
                    container = value;
                }
            }
        }

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }

        public static object Resolve(Type type)
        {
            return container.Resolve(type);
        }
    }
}
