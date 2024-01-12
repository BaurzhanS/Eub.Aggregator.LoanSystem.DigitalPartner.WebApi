using AutoMapper;
using Eub.Aggregator.LoanSystem.DigitalPartner.Application.CQRS.Commands;
using Eub.Aggregator.LoanSystem.DigitalPartner.Application.CQRS.Queries;
using Eub.Aggregator.LoanSystem.DigitalPartner.Application.Services;
using Eub.Aggregator.LoanSystem.DigitalPartner.Domain.Models;
using Eub.Aggregator.LoanSystem.DigitalPartner.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Logging;
using Serilog.Core;

namespace Eub.Aggregator.LoanSystem.DigitalPartner.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableRateLimiting("fixed")]
    public class DigitalPartnerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DigitalPartnerController> _logger;
        private readonly IMapper _mapper;

        public DigitalPartnerController(IMediator mediator, ILogger<DigitalPartnerController> logger, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
        }
        
        [HttpPost("digitalPartner")]
        public async Task<Way4DigitalPartner> GetDigitalPartner([FromBody] Way4DigitalPartnerRequest query)
        {
            try
            {
                GetDigitalPartnerQuery getDigitalPartnerQuery = new(query.RequestId, query.IIN);

                var response = await _mediator.Send(getDigitalPartnerQuery);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured in {nameof(this.GetDigitalPartner)}. Message: {ex.Message}");
                throw;
            }
        }

        [HttpPost("client/create")]
        public async Task<CreateWay4DigitalPartnerResponse> CreateDigitalClient([FromBody] CreateWay4DigitalPartnerRequest query,
                                                                                [FromServices] DigitalPartnerService service)
        {
            try
            {
                var request = _mapper.Map<CreateDigitalClientCommand>(query);

                var response = await service.CreateDigitalClient(request);

                var partnerCreatedResponse = new CreateWay4DigitalPartnerResponse
                {
                    RespClass = response.RespClass,
                    RespCode = response.RespCode,
                    RespText = response.RespText,
                    TaxpayerIdentifier = response.TaxpayerIdentifier,
                    ResponseId = query.RequestId
                };

                return partnerCreatedResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured in {nameof(this.CreateDigitalClient)}. Message: {ex.Message}");
                throw;
            }
        }

        //[HttpPost("client/create")]
        //public async Task<CreateWay4DigitalPartnerResponse> CreateDigitalClient([FromBody] CreateWay4DigitalPartnerRequest query)
        //{
        //    try
        //    {
        //        var request = _mapper.Map<CreateDigitalClientCommand>(query);

        //        var response = await _mediator.Send(request);

        //        var partnerCreatedResponse = new CreateWay4DigitalPartnerResponse
        //        {
        //            RespClass = response.RespClass,
        //            RespCode = response.RespCode,
        //            RespText = response.RespText,
        //            TaxpayerIdentifier = response.TaxpayerIdentifier,
        //            ResponseId = query.RequestId
        //        };

        //        return partnerCreatedResponse;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Error occured in {nameof(this.CreateDigitalClient)}. Message: {ex.Message}");
        //        throw;
        //    }
        //}

        [HttpPost("contract/create")]
        public async Task<CreateWay4DigitalPartnerResponse> CreateContract([FromBody] CreateWay4Contract query)
        {
            try
            {
                var request = _mapper.Map<CreateContractCommand>(query);

                var response = await _mediator.Send(request);

                var partnerCreatedResponse = new CreateWay4DigitalPartnerResponse
                {
                    RespClass = response.RespClass,
                    RespCode = response.RespCode,
                    RespText = response.RespText,
                    TaxpayerIdentifier = response.TaxpayerIdentifier,
                    ResponseId = query.RequestId,
                    ContractNumber = response.ContractNumber
                };

                return partnerCreatedResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured in {nameof(this.CreateDigitalClient)}. Message: {ex.Message}");
                throw;
            }
        }

        [HttpPost("way4/create")]
        public async Task<CreateWay4PartnerResponse> CreatePartner([FromBody] CreateWay4PartnerRequest query)
        {
            try
            {
                var request = _mapper.Map<CreateDigitalPartnerWay4Command>(query);

                var response = await _mediator.Send(request);

                var partnerCreatedResponse = new CreateWay4PartnerResponse
                {
                    Result = response.ResultOut
                };

                return partnerCreatedResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured in {nameof(this.CreatePartner)}. Message: {ex.Message}");
                throw;
            }
        }

        [HttpPost("way4/info")]
        public async Task<GetDigitalPartnerWay4InfoResponse> GetDigitalPartnerInfo(GetDigitalPartnerWay4InfoRequest query)
        {
            try
            {
                var request = _mapper.Map<GetDigitalPartnerWay4InfoQuery>(query);

                var response = await _mediator.Send(request);

                var partnerCreatedResponse = new GetDigitalPartnerWay4InfoResponse
                {
                    ResultOut = response.ResultOut,
                    MerchantId = response.MerchantId,
                    MemberId = response.MemberId
                };

                return partnerCreatedResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured in {nameof(this.CreatePartner)}. Message: {ex.Message}");
                throw;
            }
        }
    }
}