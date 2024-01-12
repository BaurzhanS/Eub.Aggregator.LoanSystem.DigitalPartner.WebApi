using Eub.Aggregator.LoanSystem.DigitalPartner.Application.Helpers;
using Eub.Aggregator.LoanSystem.DigitalPartner.Application.IRepositoryServices;
using Eub.Aggregator.LoanSystem.DigitalPartner.Application.Models;
using Eub.Aggregator.LoanSystem.DigitalPartner.Domain.Models;
using MediatR;


namespace Eub.Aggregator.LoanSystem.DigitalPartner.Application.CQRS.Commands
{
    public class CreateDigitalPartnerWay4CommandHandler : IRequestHandler<CreateDigitalPartnerWay4Command, CreateDigitalPartnerWay4Response>
    {
        private readonly IDigitalPartnerRepo digitalPartnerRepo;

        public CreateDigitalPartnerWay4CommandHandler(IDigitalPartnerRepo digitalPartnerRepo)
        {
            this.digitalPartnerRepo = digitalPartnerRepo;
        }
        public async Task<CreateDigitalPartnerWay4Response> Handle(CreateDigitalPartnerWay4Command request, CancellationToken cancellationToken)
        {
            var digitalPartner = await digitalPartnerRepo.CreateDigitalPartner(request);

            return digitalPartner;
        }
    }
}
