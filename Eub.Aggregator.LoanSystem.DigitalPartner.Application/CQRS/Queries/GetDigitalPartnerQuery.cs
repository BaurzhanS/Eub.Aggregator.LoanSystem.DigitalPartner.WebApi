using Eub.Aggregator.LoanSystem.DigitalPartner.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eub.Aggregator.LoanSystem.DigitalPartner.Application.CQRS.Queries
{
    public class GetDigitalPartnerQuery: IRequest<Way4DigitalPartner>
    {
        public string RequestId { get; set; }
        public string IIN { get; set; }
        public GetDigitalPartnerQuery(string requestId, string iin)
        {
            this.RequestId = requestId;
            this.IIN = iin; 
        }
    }
}
