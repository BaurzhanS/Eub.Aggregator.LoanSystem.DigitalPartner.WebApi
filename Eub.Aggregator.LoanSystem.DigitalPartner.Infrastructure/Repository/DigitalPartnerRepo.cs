using AutoMapper;
using Eub.Adapter.Way4.Transactional.DigitalPartner;
using Eub.Adapter.Way4Ufx.Info.gRPC.Protos.V1;
using Eub.Aggregator.LoanSystem.DigitalPartner.Application.CQRS.Commands;
using Eub.Aggregator.LoanSystem.DigitalPartner.Application.CQRS.Queries;
using Eub.Aggregator.LoanSystem.DigitalPartner.Application.IRepositoryServices;
using Eub.Aggregator.LoanSystem.DigitalPartner.Application.Models;
using Eub.Aggregator.LoanSystem.DigitalPartner.Domain.Models;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UFX.Models;

namespace Eub.Aggregator.LoanSystem.DigitalPartner.Infrastructure.Repository
{
    public class DigitalPartnerRepo: IDigitalPartnerRepo
    {
        private readonly UfxInfo.UfxInfoClient ufxClient;
        private readonly Way4TransactionalDigitalPartner.Way4TransactionalDigitalPartnerClient way4Client;
        private readonly IMapper _mapper;
        private readonly ILogger<DigitalPartnerRepo> _logger;
        public DigitalPartnerRepo(IMapper mapper,
                                  UfxInfo.UfxInfoClient ufxClient,
                                  ILogger<DigitalPartnerRepo> logger,
                                  Way4TransactionalDigitalPartner.Way4TransactionalDigitalPartnerClient way4Client)
        {
            this._mapper = mapper;
            this.ufxClient = ufxClient;
            this.way4Client = way4Client;
            this._logger = logger;
        }

        public async Task<Way4DigitalPartner> GetDigitalPartner(UFX.Models.ObjectAppData request)
        {
            _logger.LogDebug("Calling the {method_name} method", nameof(GetDigitalPartner));
            _logger.LogTrace("Incoming parameters for the {method_name} method: {params}", nameof(GetDigitalPartner), JsonSerializer.Serialize(request));

            try
            {
                var partnerRequest = _mapper.Map<Adapter.Way4Ufx.Info.gRPC.Protos.V1.ObjectAppData>(request);

                _logger.LogTrace("Request Data to adapter: {params}", JsonSerializer.Serialize(partnerRequest, new JsonSerializerOptions()
                {
                    ReferenceHandler = ReferenceHandler.Preserve, // https://learn.microsoft.com/en-us/ef/core/querying/related-data/serialization
                }));

                var response = await ufxClient.InformationAsync(partnerRequest);

                _logger.LogDebug("Response of the post request was received");
                _logger.LogTrace("Returned data from adapter: {params}", JsonSerializer.Serialize(response, new JsonSerializerOptions()
                {
                    ReferenceHandler = ReferenceHandler.Preserve, // https://learn.microsoft.com/en-us/ef/core/querying/related-data/serialization
                }));

                var digitalPartnerResponse = new Way4DigitalPartner();

                if (response.ResponseCode.Equals("0"))
                {
                    var parameters = response.Data.Information.DataResponse.ContractResponse.First().Contract;

                    digitalPartnerResponse.RespCode = response.ResponseCode;
                    digitalPartnerResponse.RespClass = response.ResponseClass;
                    digitalPartnerResponse.RespText = response.ResponseText;
                    digitalPartnerResponse.ClientType = parameters.ClientType;
                    digitalPartnerResponse.ClientCategory = parameters.ClientCategory;
                    digitalPartnerResponse.ContractNumber = parameters.ContractIDT.ContractNumber;
                    digitalPartnerResponse.ClientNumber = parameters.ContractIDT.Client.ClientInfo.ClientNumber;
                    digitalPartnerResponse.ShortName = parameters.ContractIDT.Client.ClientInfo.ShortName;
                    digitalPartnerResponse.TaxpayerIdentifier = parameters.ContractIDT.Client.ClientInfo.TaxpayerIdentifier;
                    digitalPartnerResponse.Currency = parameters.Currency;
                    digitalPartnerResponse.ProductCode1 = parameters.Product.ProductCode1;
                    digitalPartnerResponse.AccountScheme = parameters.Product.AccountScheme;
                    digitalPartnerResponse.ContractSubType = parameters.Product.ContractSubType;
                    digitalPartnerResponse.ServicePack = parameters.Product.ServicePack;
                    digitalPartnerResponse.ProductName = parameters.Product.ProductName;
                    digitalPartnerResponse.ContractRole = parameters.Product.ContractRole;
                    digitalPartnerResponse.DateOpen = parameters.DateOpen;
                    digitalPartnerResponse.StatusCode = response.Data.Information.DataResponse.ContractResponse.First().Info.Status.StatusCode;
                    digitalPartnerResponse.StatusClass = response.Data.Information.DataResponse.ContractResponse.First().Info.Status.StatusClass;
                }

                if (response.ResponseCode.Equals("1930"))
                {
                    digitalPartnerResponse.RespCode = response.ResponseCode;
                    digitalPartnerResponse.RespClass = response.ResponseClass;
                    digitalPartnerResponse.RespText = response.ResponseText;
                }

                return digitalPartnerResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Way4DigitalPartner> CreateDigitalClient(UFX.Models.ObjectAppData request)
        {
            _logger.LogDebug("Calling the {method_name} method", nameof(CreateDigitalClient));
            _logger.LogTrace("Incoming parameters for the {method_name} method: {params}", nameof(CreateDigitalClient), JsonSerializer.Serialize(request));

            try
            {
                var partnerRequest = _mapper.Map<Adapter.Way4Ufx.Info.gRPC.Protos.V1.ObjectAppData>(request);

                _logger.LogTrace("Request Data to adapter: {params}", JsonSerializer.Serialize(partnerRequest, new JsonSerializerOptions()
                {
                    ReferenceHandler = ReferenceHandler.Preserve, // https://learn.microsoft.com/en-us/ef/core/querying/related-data/serialization
                }));

                var response = await ufxClient.ApplicationAsync(partnerRequest);

                _logger.LogDebug("Response of the post request was received");
                _logger.LogTrace("Returned data from adapter: {params}", JsonSerializer.Serialize(response, new JsonSerializerOptions()
                {
                    ReferenceHandler = ReferenceHandler.Preserve, // https://learn.microsoft.com/en-us/ef/core/querying/related-data/serialization
                }));

                var digitalPartnerResponse = new Way4DigitalPartner();

                if (response.ResponseCode.Equals("0"))
                {
                    var parameters = response.Data.Application.Data.Client;

                    digitalPartnerResponse.RespCode = response.ResponseCode;
                    digitalPartnerResponse.RespClass = response.ResponseClass;
                    digitalPartnerResponse.RespText = response.ResponseText;
                    digitalPartnerResponse.TaxpayerIdentifier = parameters.ClientInfo.RegNumber;
                }
                else
                {
                    digitalPartnerResponse.RespCode = response.ResponseCode;
                    digitalPartnerResponse.RespClass = response.ResponseClass;
                    digitalPartnerResponse.RespText = response.ResponseText;
                }

                return digitalPartnerResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Way4DigitalPartner> CreateContract(UFX.Models.ObjectAppData request)
        {
            _logger.LogDebug("Calling the {method_name} method", nameof(CreateContract));
            _logger.LogTrace("Incoming parameters for the {method_name} method: {params}", nameof(CreateContract), JsonSerializer.Serialize(request));

            try
            {
                var partnerRequest = _mapper.Map<Adapter.Way4Ufx.Info.gRPC.Protos.V1.ObjectAppData>(request);

                _logger.LogTrace("Request Data to adapter: {params}", JsonSerializer.Serialize(partnerRequest, new JsonSerializerOptions()
                {
                    ReferenceHandler = ReferenceHandler.Preserve, // https://learn.microsoft.com/en-us/ef/core/querying/related-data/serialization
                }));

                var response = await ufxClient.ApplicationAsync(partnerRequest);

                _logger.LogDebug("Response of the post request was received");
                _logger.LogTrace("Returned data from adapter: {params}", JsonSerializer.Serialize(response, new JsonSerializerOptions()
                {
                    ReferenceHandler = ReferenceHandler.Preserve, // https://learn.microsoft.com/en-us/ef/core/querying/related-data/serialization
                }));

                var digitalPartnerResponse = new Way4DigitalPartner();

                if (response.ResponseCode.Equals("0"))
                {
                    var parameters = response.Data.Application.ObjectFor.ClientIDT.ClientInfo;

                    var contractNumber = response.Data.Application.DataResponse.ContractResponse.FirstOrDefault()?.Contract.ContractIDT.ContractNumber;

                    digitalPartnerResponse.RespCode = response.ResponseCode;
                    digitalPartnerResponse.RespClass = response.ResponseClass;
                    digitalPartnerResponse.RespText = response.ResponseText;
                    digitalPartnerResponse.TaxpayerIdentifier = parameters.RegNumber;
                    digitalPartnerResponse.ContractNumber = contractNumber;
                }
                else
                {
                    digitalPartnerResponse.RespCode = response.ResponseCode;
                    digitalPartnerResponse.RespClass = response.ResponseClass;
                    digitalPartnerResponse.RespText = response.ResponseText;
                }

                return digitalPartnerResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<CreateDigitalPartnerWay4Response> CreateDigitalPartner(CreateDigitalPartnerWay4Command request)
        {
            _logger.LogDebug("Calling the {method_name} method", nameof(CreateDigitalPartner));
            _logger.LogTrace("Incoming parameters for the {method_name} method: {params}", nameof(CreateDigitalPartner), JsonSerializer.Serialize(request));

            try
            {
                var partnerRequest = _mapper.Map<CreateDigitalPartnerRequest>(request);

                _logger.LogTrace("Request Data to adapter: {params}", JsonSerializer.Serialize(partnerRequest, new JsonSerializerOptions()
                {
                    ReferenceHandler = ReferenceHandler.Preserve, // https://learn.microsoft.com/en-us/ef/core/querying/related-data/serialization
                }));

                var response = await way4Client.CreateDigitalPartnerAsync(partnerRequest);

                _logger.LogDebug("Response of the post request was received");
                _logger.LogTrace("Returned data from adapter: {params}", JsonSerializer.Serialize(response, new JsonSerializerOptions()
                {
                    ReferenceHandler = ReferenceHandler.Preserve, // https://learn.microsoft.com/en-us/ef/core/querying/related-data/serialization
                }));

                var digitalPartnerResponse = new CreateDigitalPartnerWay4Response();

                digitalPartnerResponse.ResultOut = response.ResultOut;

                return digitalPartnerResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Way4DigitalPartnerInfo> GetDigitalPartnerInfo(GetDigitalPartnerWay4InfoQuery request)
        {
            _logger.LogDebug("Calling the {method_name} method", nameof(CreateDigitalPartner));
            _logger.LogTrace("Incoming parameters for the {method_name} method: {params}", nameof(CreateDigitalPartner), JsonSerializer.Serialize(request));

            try
            {
                var partnerRequest = _mapper.Map<GetDigitalPartnerInfoRequest>(request);

                _logger.LogTrace("Request Data to adapter: {params}", JsonSerializer.Serialize(partnerRequest, new JsonSerializerOptions()
                {
                    ReferenceHandler = ReferenceHandler.Preserve, // https://learn.microsoft.com/en-us/ef/core/querying/related-data/serialization
                }));

                var response = await way4Client.GetDigitalPartnerInfoAsync(partnerRequest);

                _logger.LogDebug("Response of the post request was received");
                _logger.LogTrace("Returned data from adapter: {params}", JsonSerializer.Serialize(response, new JsonSerializerOptions()
                {
                    ReferenceHandler = ReferenceHandler.Preserve, // https://learn.microsoft.com/en-us/ef/core/querying/related-data/serialization
                }));

                var digitalPartnerResponse = new Way4DigitalPartnerInfo();

                digitalPartnerResponse.ResultOut = response.ResultOut;
                digitalPartnerResponse.MemberId = response.MemberId;
                digitalPartnerResponse.MerchantId = response.MerchantId;

                return digitalPartnerResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
