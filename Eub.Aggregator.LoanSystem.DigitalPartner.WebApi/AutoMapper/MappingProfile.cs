using AutoMapper;
using Eub.Aggregator.LoanSystem.DigitalPartner.Application.CQRS.Commands;
using Eub.Aggregator.LoanSystem.DigitalPartner.Application.CQRS.Queries;
using Eub.Aggregator.LoanSystem.DigitalPartner.WebApi.Models;

namespace Eub.Aggregator.LoanSystem.DigitalPartner.WebApi.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateWay4DigitalPartnerRequest, CreateDigitalClientCommand>();
            CreateMap<CreateWay4Contract, CreateContractCommand>();
            CreateMap<CreateWay4PartnerRequest, CreateDigitalPartnerWay4Command>();
            CreateMap<GetDigitalPartnerWay4InfoRequest, GetDigitalPartnerWay4InfoQuery>();
        }
    }
}
