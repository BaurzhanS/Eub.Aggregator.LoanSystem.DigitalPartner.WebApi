using Eub.Aggregator.LoanSystem.DigitalPartner.Application.Models;
using Eub.Aggregator.LoanSystem.DigitalPartner.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eub.Aggregator.LoanSystem.DigitalPartner.Application.CQRS.Commands
{
    public class CreateDigitalPartnerWay4Command : IRequest<CreateDigitalPartnerWay4Response>
    {
        public string RequestId { get; set; }
        public string PartnerName { get; set; }
        public string MemberId { get; set; }
        public string MerchantId { get; set; }
        public string AmndOfficer { get; set; }
        public string PartnerContract { get; set; }
    }
}
