using Eub.Aggregator.LoanSystem.DigitalPartner.Application.Helpers;
using Eub.Aggregator.LoanSystem.DigitalPartner.Application.IRepositoryServices;
using Eub.Aggregator.LoanSystem.DigitalPartner.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eub.Aggregator.LoanSystem.DigitalPartner.Application.CQRS.Commands
{
    public class CreateDigitalClientCommandHandler : IRequestHandler<CreateDigitalClientCommand, Way4DigitalPartner>
    {
        private readonly IDigitalPartnerRepo digitalPartnerRepo;

        public CreateDigitalClientCommandHandler(IDigitalPartnerRepo digitalPartnerRepo)
        {
            this.digitalPartnerRepo = digitalPartnerRepo;
        }

        public async Task<Way4DigitalPartner> Handle(CreateDigitalClientCommand request, CancellationToken cancellationToken)
        {
            var infoRequest = Way4DigitalPartnerRequestHelper.CreateDigitalClientRequest(request);

            var digitalPartner = await digitalPartnerRepo.CreateDigitalClient(infoRequest);

            return digitalPartner;
        }
    }
}
