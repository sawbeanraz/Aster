<<<<<<< HEAD
﻿using Aster.Core.Services.Candidates;
=======
﻿using Aster.Core.Services.Contractors;
>>>>>>> 7bf30bca19e647fe74841342c59cc092554d7bd0
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


<<<<<<< HEAD
            builder.RegisterType<CandidateService>().As<ICandidateService>()
=======
            builder.RegisterType<ContractorService>().As<IContractorService>()
>>>>>>> 7bf30bca19e647fe74841342c59cc092554d7bd0
                .InstancePerLifetimeScope();
        }
    }
}