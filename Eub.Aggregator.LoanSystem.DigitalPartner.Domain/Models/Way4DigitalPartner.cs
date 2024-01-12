using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eub.Aggregator.LoanSystem.DigitalPartner.Domain.Models
{
    public class Way4DigitalPartner
    {
        public string ResponseId { get; set; }
        public string RespClass { get; set; }
        public string RespCode { get; set; }
        public string RespText { get; set; }
        public string ClientType { get; set; }
        public string ClientCategory { get; set; }
        public string ContractNumber { get; set; }
        public string ClientNumber { get; set; }
        public string ShortName { get; set; }
        public string TaxpayerIdentifier { get; set; }
        public string Currency { get; set; }
        public string ProductCode1 { get; set; }
        public string AccountScheme { get; set; }
        public string ContractSubType { get; set; }
        public string ServicePack { get; set; }
        public string ProductName { get; set; }
        public string ContractRole { get; set; }
        public string DateOpen { get; set; }
        public string StatusCode { get; set; }
        public string StatusClass { get; set; }
        public string Error_msg { get; set; }
    }
}
