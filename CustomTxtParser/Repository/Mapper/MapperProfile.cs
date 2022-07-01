using AutoMapper;
using DomainModels.Models.Entities;
using DomainModels.Models.ViewModels;

namespace Repository.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Transaction, TransactionIndexViewModel>().ReverseMap();
            CreateMap<SettlementDetail, SettlementDetailViewModel>().ReverseMap();
            CreateMap<SettlementCategory, SettlementCategoryViewModel>().ReverseMap();
            CreateMap<FinancialInstitution, FinancialInstitutionViewModel>().ReverseMap();
        }
    }
}
