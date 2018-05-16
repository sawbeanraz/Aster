using Aster.Core.Services.Candidates;
using Aster.Core.Services.Users;
using Aster.System.Abstractions;
using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.Web.Framework {
    public class CoreDependencyRegistrar : IDependencyRegistrar {
        public int Order => 10;

        public void Register(ContainerBuilder builder) {

            builder.RegisterType<UserService>().As<IUserService>()
                .InstancePerLifetimeScope();


            builder.RegisterType<CandidateService>().As<ICandidateService>()
                .InstancePerLifetimeScope();
        }
    }
}