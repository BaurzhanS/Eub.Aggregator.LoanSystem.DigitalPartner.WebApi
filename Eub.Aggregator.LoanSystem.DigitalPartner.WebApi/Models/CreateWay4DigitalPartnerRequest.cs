namespace Eub.Aggregator.LoanSystem.DigitalPartner.WebApi.Models
{
    public class CreateWay4DigitalPartnerRequest
    {
        public string RequestId { get; set; }
        public string Institution { get; set; }
        public string ShortName { get; set; }
        public string TaxpayerIdentifier { get; set; }
        public string PartnerName { get; set; }
    }
}
