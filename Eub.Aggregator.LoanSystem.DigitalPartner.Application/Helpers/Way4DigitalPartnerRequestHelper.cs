using Eub.Aggregator.LoanSystem.DigitalPartner.Application.CQRS.Commands;
using UFX.Models;

namespace Eub.Aggregator.LoanSystem.DigitalPartner.Application.Helpers
{
    public static class Way4DigitalPartnerRequestHelper
    {
        public static ObjectAppData GetInformationRequest(string iin)
        {
            return new ObjectAppData
            {
                ObjectType = "Contract",
                ActionType = "Inquiry",
                ResultDetails = new ResultDetails
                {
                    Parameters = new List<Parameter>
                    {
                        new Parameter
                        {
                            ParameterCode = "Children",
                            Value = "Y"
                        }, new Parameter
                        {
                            ParameterCode = "Client",
                            Value = "IDT"
                        }, new Parameter
                        {
                            ParameterCode = "Product",
                            Value = "Y"
                        }, new Parameter
                        {
                            ParameterCode = "Status",
                            Value = "Y"
                        }
                    }
                },
                ObjectFor = new ObjectFor
                {
                    ClientIDT = new ClientIDT
                    {
                        ClientType = "MR",
                        ClientInfo = new ClientInfo
                        {
                            RegNumber = iin
                        }
                    }
                }
            };
        }

        public static ObjectAppData CreateDigitalClientRequest(CreateDigitalClientCommand request)
        {
            return new ObjectAppData
            {
                RegNumber = Guid.NewGuid().ToString(),
                Institution = request.Institution,
                ObjectType = "Client",
                ActionType = "AddOrUpdate",
                ObjectFor = new ObjectFor
                {
                    ClientIDT = new ClientIDT
                    {
                        ClientInfo = new ClientInfo
                        {
                            RegNumber = request.TaxpayerIdentifier,
                            ShortName = "<<<NONE>>>"
                        }
                    }
                },
                Data = new Data
                {
                    Client = new Client
                    {
                        ClientType = "M_RES",
                        ClientInfo = new ClientInfo
                        {
                            RegNumber = request.TaxpayerIdentifier,
                            ShortName = request.ShortName,
                            CompanyName = request.PartnerName
                        }
                    }
                }
            };
        }

        public static ObjectAppData CreateContractRequest(CreateContractCommand request)
        {
            return new ObjectAppData
            {
                RegNumber = Guid.NewGuid().ToString(),
                Institution = request.Institution,
                ObjectType = "Contract",
                ActionType = "Add",
                ResultDetails = new ResultDetails
                {
                    Parameters = new List<Parameter>
                    {
                        new Parameter
                        {
                            ParameterCode = "Response",
                            Value = "Y"
                        }
                    }
                },
                ObjectFor = new ObjectFor
                {
                    ClientIDT = new ClientIDT
                    {
                        ClientInfo = new ClientInfo
                        {
                            RegNumber = request.TaxpayerIdentifier,
                            ShortName = "<<<NONE>>>"
                        }
                    }
                },
                Data = new Data
                {
                    Contract = new Contract
                    {
                        Product = new Product
                        {
                            ProductCode1 = "PARTNER"
                        }
                    }
                }
            };
        }
    }
}
