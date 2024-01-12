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
    public class CreateContractCommandHandler : IRequestHandler<CreateContractCommand, Way4DigitalPartner>
    {
        private readonly IDigitalPartnerRepo digitalPartnerRepo;

        public CreateContractCommandHandler(IDigitalPartnerRepo digitalPartnerRepo)
        {
            this.digitalPartnerRepo = digitalPartnerRepo;
        }

        public async Task<Way4DigitalPartner> Handle(CreateContractCommand request, CancellationToken cancellationToken)
        {
            var infoRequest = Way4DigitalPartnerRequestHelper.CreateContractRequest(request);

            var digitalPartner = await digitalPartnerRepo.CreateContract(infoRequest);

            return digitalPartner;
        }
    }
}
