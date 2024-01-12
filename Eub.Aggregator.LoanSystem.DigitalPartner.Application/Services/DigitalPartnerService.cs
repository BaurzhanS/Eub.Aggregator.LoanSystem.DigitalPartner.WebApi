using Eub.Aggregator.LoanSystem.DigitalPartner.Application.CQRS.Commands;
using Eub.Aggregator.LoanSystem.DigitalPartner.Application.Helpers;
using Eub.Aggregator.LoanSystem.DigitalPartner.Application.IRepositoryServices;
using Eub.Aggregator.LoanSystem.DigitalPartner.Application.Models;
using Eub.Aggregator.LoanSystem.DigitalPartner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFX.Models;

namespace Eub.Aggregator.LoanSystem.DigitalPartner.Application.Services
{
    public interface IDigitalPartnerService
    {
        public Task<Way4DigitalPartner> CreateDigitalClient(CreateDigitalClientCommand request);
        public Task<Way4DigitalPartner> CreateContract(UFX.Models.ObjectAppData request);
        public Task<CreateDigitalPartnerWay4Response> CreateDigitalPartner(CreateDigitalPartnerWay4Command request);
    }
    public class DigitalPartnerService : IDigitalPartnerService
    {
        private readonly IDigitalPartnerRepo digitalPartnerRepo;
        public DigitalPartnerService(IDigitalPartnerRepo digitalPartnerRepo)
        {
            this.digitalPartnerRepo = digitalPartnerRepo;
        }
        public async Task<Way4DigitalPartner> CreateContract(ObjectAppData request)
        {
            CreateContractCommand req = new CreateContractCommand
            {
                Institution = request.Institution
            };
            var infoRequest = Way4DigitalPartnerRequestHelper.CreateContractRequest(req);

            var digitalPartner = await digitalPartnerRepo.CreateContract(infoRequest);

            return digitalPartner;
        }

        public async Task<Way4DigitalPartner> CreateDigitalClient(CreateDigitalClientCommand request)
        {
            var infoRequest = Way4DigitalPartnerRequestHelper.CreateDigitalClientRequest(request);

            var digitalPartner = await digitalPartnerRepo.CreateDigitalClient(infoRequest);

            return digitalPartner;
        }

        public async Task<CreateDigitalPartnerWay4Response> CreateDigitalPartner(CreateDigitalPartnerWay4Command request)
        {
            var digitalPartner = await digitalPartnerRepo.CreateDigitalPartner(request);

            return digitalPartner;
        }
    }
}
