using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StatWinner.AccountManagement.BLL.Common.UserAccount;
using StatWinner.AccountManagement.BLL.Mongo;
using StatWinner.Configuration.Interfaces;
using StatWinner.Configuration.MongoDBProvider;
using StatWinner.Notification.BLL.Mongo;
using StatWinner.NotificationEngine.BLL.Common;
using StructureMap;
using StructureMap.Pipeline;

namespace StatWinner.Web
{
    public static class DependencyResolverStartup
    {
        public static void Resolve()
        {
            var container = new Container();
            StatWinner.Common.DependencyInjection.DependencyContainer = container;
            container.Configure(
                x =>
                    x.For<IConfigurationManager>()
                        .LifecycleIs(new SingletonLifecycle())
                        .Use<MongoDBConfigurationManager>());
            container.Configure(x => x.For<IUserAccountManagement>().Use<MongoUserAccountManagement>());
            container.Configure(x => x.For<IEventManagement>().Use<MongoEventManagement>());

        }
    }
}