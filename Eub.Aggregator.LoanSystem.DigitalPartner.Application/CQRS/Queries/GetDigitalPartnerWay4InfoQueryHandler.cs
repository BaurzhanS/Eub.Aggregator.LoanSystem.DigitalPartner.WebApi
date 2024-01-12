using Eub.Aggregator.LoanSystem.DigitalPartner.Application.Helpers;
using Eub.Aggregator.LoanSystem.DigitalPartner.Application.IRepositoryServices;
using Eub.Aggregator.LoanSystem.DigitalPartner.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eub.Aggregator.LoanSystem.DigitalPartner.Application.CQRS.Queries
{
    public class GetDigitalPartnerWay4InfoQueryHandler : IRequestHandler<GetDigitalPartnerWay4InfoQuery, Way4DigitalPartnerInfo>
    {
        private readonly IDigitalPartnerRepo digitalPartnerRepo;

        public GetDigitalPartnerWay4InfoQueryHandler(IDigitalPartnerRepo digitalPartnerRepo)
        {
            this.digitalPartnerRepo = digitalPartnerRepo;
        }
        public async Task<Way4DigitalPartnerInfo> Handle(GetDigitalPartnerWay4InfoQuery request, CancellationToken cancellationToken)
        {
            var digitalPartner = await digitalPartnerRepo.GetDigitalPartnerInfo(request);

            return digitalPartner;
        }
    }
}
