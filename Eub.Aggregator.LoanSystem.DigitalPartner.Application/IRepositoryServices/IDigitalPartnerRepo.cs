using Eub.Aggregator.LoanSystem.DigitalPartner.Application.CQRS.Commands;
using Eub.Aggregator.LoanSystem.DigitalPartner.Application.CQRS.Queries;
using Eub.Aggregator.LoanSystem.DigitalPartner.Application.Models;
using Eub.Aggregator.LoanSystem.DigitalPartner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFX.Models;

namespace Eub.Aggregator.LoanSystem.DigitalPartner.Application.IRepositoryServices
{
    public interface IDigitalPartnerRepo
    {
        Task<Way4DigitalPartner> GetDigitalPartner(ObjectAppData request);
        Task<Way4DigitalPartner> CreateDigitalClient(ObjectAppData request);
        Task<Way4DigitalPartner> CreateContract(ObjectAppData request);
        Task<CreateDigitalPartnerWay4Response> CreateDigitalPartner(CreateDigitalPartnerWay4Command request);
        Task<Way4DigitalPartnerInfo> GetDigitalPartnerInfo(GetDigitalPartnerWay4InfoQuery request);
    }
}
