using AutoMapper;
using Eub.Adapter.Way4.Transactional.DigitalPartner;
using Eub.Adapter.Way4Ufx.Info.gRPC.Protos.V1;
using Eub.Aggregator.LoanSystem.DigitalPartner.Application.CQRS.Commands;
using Eub.Aggregator.LoanSystem.DigitalPartner.Application.CQRS.Queries;

namespace Eub.Aggregator.LoanSystem.DigitalPartner.Infrastructure.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Google.Protobuf.WellKnownTypes.Timestamp, DateTime>().ConvertUsing(x => x.ToDateTime());
            CreateMap<DateTime, Google.Protobuf.WellKnownTypes.Timestamp>().ConvertUsing(x => Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(x, DateTimeKind.Utc)));
            CreateMap<string, string>().ConvertUsing(x => x ?? String.Empty);

            CreateMap<UFX.Models.Message<UFX.Models.UFXInformation<UFX.Models.ObjectAppData>>, Message>().ReverseMap();
            CreateMap<UFX.Models.Message<UFX.Models.UFXApplication<UFX.Models.ObjectAppData>>, Message>().ReverseMap();
            CreateMap<UFX.Models.Message<UFX.Models.UFXDoc<UFX.Models.TransferData>>, Message>().ReverseMap();
            CreateMap<UFX.Models.Message<UFX.Models.UFXData>, Message>().ReverseMap();
            CreateMap<UFX.Models.UFXInformation<UFX.Models.ObjectAppData>, UfxData>().ReverseMap();
            CreateMap<UFX.Models.UFXApplication<UFX.Models.ObjectAppData>, UfxData>().ReverseMap();
            CreateMap<UFX.Models.UFXDoc<UFX.Models.TransferData>, UfxData>().ReverseMap();
            CreateMap<UFX.Models.UFXData, UfxData>().ReverseMap();
            CreateMap<UFX.Models.ObjectAppData, ObjectAppData>().ReverseMap();
            CreateMap<UFX.Models.TransferData, TransferData>().ReverseMap();
            CreateMap<UFX.Models.Source, Source>().ReverseMap();
            CreateMap<UFX.Models.ValidationDtls, ValidationDtls>().ReverseMap();
            CreateMap<UFX.Models.ResultDetails, ResultDetails>().ReverseMap();
            CreateMap<UFX.Models.ObjectFor, ObjectFor>().ReverseMap();
            CreateMap<UFX.Models.ClientIDT, ClientIDT>().ReverseMap();
            CreateMap<UFX.Models.ClientInfo, ClientInfo>().ReverseMap();
            CreateMap<UFX.Models.ContractIDT, ContractIDT>().ReverseMap();
            CreateMap<UFX.Models.Data, Data>().ReverseMap();
            CreateMap<UFX.Models.DataResponse, DataResponse>().ReverseMap();
            CreateMap<UFX.Models.Status, Status>().ReverseMap();
            CreateMap<UFX.Models.AddData, AddData>().ReverseMap();
            CreateMap<UFX.Models.Parameter, Parameter>().ReverseMap();
            CreateMap<UFX.Models.ObjectSubAppData, ObjectSubAppData>().ReverseMap();
            CreateMap<UFX.Models.Contract, Contract>().ReverseMap();
            CreateMap<UFX.Models.Client, Client>().ReverseMap();
            CreateMap<UFX.Models.Address, Address>().ReverseMap();
            CreateMap<UFX.Models.AppInfo, AppInfo>().ReverseMap();
            CreateMap<UFX.Models.ProduceCard, ProduceCard>().ReverseMap();
            CreateMap<UFX.Models.SetStatus, SetStatus>().ReverseMap();
            CreateMap<UFX.Models.SetLimit, SetLimit>().ReverseMap();
            CreateMap<UFX.Models.Classifier, Classifier>().ReverseMap();
            CreateMap<UFX.Models.Instalment, Instalment>().ReverseMap();
            CreateMap<UFX.Models.InstalmentEarlyRepayment, InstalmentEarlyRepayment>().ReverseMap();
            CreateMap<UFX.Models.ContractUsage, ContractUsage>().ReverseMap();
            CreateMap<UFX.Models.PlasticInfo, PlasticInfo>().ReverseMap();
            CreateMap<UFX.Models.PhoneList, PhoneList>().ReverseMap();
            CreateMap<UFX.Models.PhoneInfo, PhoneInfo>().ReverseMap();
            CreateMap<UFX.Models.AdditionalInfo, AdditionalInfo>().ReverseMap();
            CreateMap<UFX.Models.ClientResponse, ClientResponse>().ReverseMap();
            CreateMap<UFX.Models.ContractResponse, ContractResponse>().ReverseMap();
            CreateMap<UFX.Models.Product, Product>().ReverseMap();
            CreateMap<UFX.Models.ContractInfo, ContractInfo>().ReverseMap();
            CreateMap<UFX.Models.ContractStatus, ContractStatus>().ReverseMap();
            CreateMap<UFX.Models.Filter, Filter>().ReverseMap();
            CreateMap<UFX.Models.ActivityPeriod, ActivityPeriod>().ReverseMap();
            CreateMap<UFX.Models.ProductionParameters, ProductionParameters>().ReverseMap();
            CreateMap<UFX.src.Models.Data.Types.SecurityParameters, SecurityParameters>().ReverseMap();
            CreateMap<UFX.Models.CreditLimit, CreditLimit>().ReverseMap();
            CreateMap<UFX.Models.Money, Money>().ReverseMap();
            CreateMap<UFX.Models.AdditionalContractInfo, AdditionalContractInfo>().ReverseMap();
            CreateMap<UFX.Models.Balance, Balance>().ReverseMap();
            CreateMap<UFX.Models.ContractUsageResponse, ContractUsageResponse>().ReverseMap();
            CreateMap<UFX.Models.ContractUsageInfo, ContractUsageInfo>().ReverseMap();
            CreateMap<UFX.Models.VisaToken, VisaToken>().ReverseMap();
            CreateMap<UFX.Models.VisaTokenParameter, VisaTokenParameter>().ReverseMap();
            CreateMap<UFX.Models.DocumentInfo, DocumentInfo>().ReverseMap();
            CreateMap<UFX.Models.TransactionType, TransactionType>().ReverseMap();
            CreateMap<UFX.Models.TransactionCode, TransactionCode>().ReverseMap();
            CreateMap<UFX.Models.DisputeRules, DisputeRules>().ReverseMap();
            CreateMap<UFX.Models.DocumentReferenceNumber, DocumentReferenceNumber>().ReverseMap();
            CreateMap<UFX.Models.ContractWrapper, ContractWrapper>().ReverseMap();
            CreateMap<UFX.Models.CardInfo, CardInfo>().ReverseMap();
            CreateMap<UFX.src.Models.Data.Types.SecurityData, SecurityData>().ReverseMap();
            CreateMap<UFX.Models.TransactionInfo, TransactionInfo>().ReverseMap();
            CreateMap<UFX.Models.TransactionExtraInfo, TransactionExtraInfo>().ReverseMap();
            CreateMap<UFX.Models.Billing, Billing>().ReverseMap();

            CreateMap<CreateDigitalPartnerWay4Command, CreateDigitalPartnerRequest>().ReverseMap();
            CreateMap<GetDigitalPartnerWay4InfoQuery, GetDigitalPartnerInfoRequest>().ReverseMap();
        }
    }
}
