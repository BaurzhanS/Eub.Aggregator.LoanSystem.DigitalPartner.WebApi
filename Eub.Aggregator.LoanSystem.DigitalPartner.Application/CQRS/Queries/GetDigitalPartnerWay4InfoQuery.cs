using Eub.Aggregator.LoanSystem.DigitalPartner.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eub.Aggregator.LoanSystem.DigitalPartner.Application.CQRS.Queries
{
    public class GetDigitalPartnerWay4InfoQuery : IRequest<Way4DigitalPartnerInfo>
    {
        public string RequestId { get; set; }
        public string RRN { get; set; }
        public string CardNumber { get; set; }

        //public GetDigitalPartnerWay4InfoQuery(string requestId, string rrn, string cardNumber)
        //{
        //    this.RequestId = requestId;
        //    this.RRN = rrn;
        //    this.CardNumber = cardNumber;
        //}
    }
}
