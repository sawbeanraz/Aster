using Aster.Core.Domain.Contractors;
using Aster.System.Mapper;
using Aster.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aster.Web.Areas.Admin.Mapper
{
    public static class AdminMappingExtensions
    {
        public static TDestination MapTo<TSource, TDestination>(this TSource source) {
            return AsterMapperConfiguration.Mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination) {
            return AsterMapperConfiguration.Mapper.Map(source, destination);
        }




        #region Contractor Mapping
        public static ContractorModel ToModel(this Contractor entity) {
            return entity.MapTo<Contractor, ContractorModel>();
        }
        public static Contractor ToEntity(this ContractorModel model) {
            return model.MapTo<ContractorModel, Contractor>();
        }
        #endregion



        public static BankAccountModel ToModel(this ContractorBankAccount entity) {
            return entity.MapTo<ContractorBankAccount, BankAccountModel>();
        }

        public static ContractorBankAccount ToEntity(this BankAccountModel model) {
            return model.MapTo<BankAccountModel, ContractorBankAccount>();
        }


        
    }
}
