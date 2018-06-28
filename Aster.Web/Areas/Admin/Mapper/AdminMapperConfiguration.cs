using Aster.Core.Domain.Contractors;
using Aster.System.Mapper;
using Aster.Web.Areas.Admin.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aster.Web.Areas.Admin.Mapper
{
    public class DomainModelMapperConfiguration : Profile, IAsterMapper {

        public DomainModelMapperConfiguration() {
            CreateMap<Contractor, ContractorModel>()
                .ForMember(dest => dest.BankAccounts, mo => mo.Ignore());
            CreateMap<ContractorModel, Contractor>();

            CreateMap<ContractorBankAccount, BankAccountModel>();
            CreateMap<BankAccountModel, ContractorBankAccount>();
        }

        public int Order => 10;
    }
}
