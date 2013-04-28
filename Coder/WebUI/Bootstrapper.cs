using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Coder.Infra;
using Coder.Core.Service;
using Coder.Service;


namespace Coder.WebUI
{
    public class Bootstrapper
    {
        public static void Bootstrap()
        {
            RouteConfigurator.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(IoC.Container));


            WindsorRegistrar.Register(typeof(IUserService), typeof(UserService));
            WindsorRegistrar.Register(typeof(ITeamContestService), typeof(TeamContestService));
            WindsorRegistrar.Register(typeof(ISingleContestService), typeof(SingleContestService));



            WindsorRegistrar.RegisterAllFromAssemblies("Coder.Data");
            WindsorRegistrar.RegisterAllFromAssemblies("Coder.Service");
            WindsorRegistrar.RegisterAllFromAssemblies("Coder.WebUI");
            
            // 默认情况下对 Entity Framework 使用 LocalDB
            Database.DefaultConnectionFactory = new SqlConnectionFactory(@"Data Source=(localdb)\v11.0; Integrated Security=True; MultipleActiveResultSets=True");

        }
    }
}