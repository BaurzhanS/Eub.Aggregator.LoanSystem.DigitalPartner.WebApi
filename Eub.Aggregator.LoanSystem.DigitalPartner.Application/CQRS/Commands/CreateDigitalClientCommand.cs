using Eub.Aggregator.LoanSystem.DigitalPartner.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eub.Aggregator.LoanSystem.DigitalPartner.Application.CQRS.Commands
{
    public class CreateDigitalClientCommand : IRequest<Way4DigitalPartner>
    {
        public string RequestId { get; set; }
        public string Institution { get; set; }
        public string ShortName { get; set; }
        public string TaxpayerIdentifier { get; set; }
        public string PartnerName { get; set; }
    }
}
