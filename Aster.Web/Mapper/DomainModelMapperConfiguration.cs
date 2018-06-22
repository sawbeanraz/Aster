using Aster.Core.Domain.Contractors;
using Aster.System.Mapper;
using Aster.Web.Areas.Admin.Models;
using AutoMapper;

namespace Aster.Web.Mapper {
    public class DomainModelMapperConfiguration: Profile, IAsterMapper
    {

        public DomainModelMapperConfiguration() {
            CreateMap<Contractor, ContractorModel>();
            CreateMap<ContractorModel, Contractor>();
        }

        public int Order => 0;
    }
}
