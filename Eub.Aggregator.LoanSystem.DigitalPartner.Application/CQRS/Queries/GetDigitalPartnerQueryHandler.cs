using Eub.Aggregator.LoanSystem.DigitalPartner.Application.Helpers;
using Eub.Aggregator.LoanSystem.DigitalPartner.Application.IRepositoryServices;
using Eub.Aggregator.LoanSystem.DigitalPartner.Domain.Models;
using MediatR;

namespace Eub.Aggregator.LoanSystem.DigitalPartner.Application.CQRS.Queries
{
    public class GetDigitalPartnerQueryHandler : IRequestHandler<GetDigitalPartnerQuery, Way4DigitalPartner>
    {
        private readonly IDigitalPartnerRepo digitalPartnerRepo;

        public GetDigitalPartnerQueryHandler(IDigitalPartnerRepo digitalPartnerRepo)
        {
            this.digitalPartnerRepo = digitalPartnerRepo;
        }
        public async Task<Way4DigitalPartner> Handle(GetDigitalPartnerQuery request, CancellationToken cancellationToken)
        {
            var infoRequest = Way4DigitalPartnerRequestHelper.GetInformationRequest(request.IIN);

            var digitalPartner = await digitalPartnerRepo.GetDigitalPartner(infoRequest);

            return digitalPartner;
        }
    }
}
