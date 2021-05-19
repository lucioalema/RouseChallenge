using MarketAuction.Api.Dtos;
using MarketAuction.Api.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketAuction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketAuctionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MarketAuctionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<MarketAuctionValueDto> GetMarketAuctionValue(int year, int equipmentId)
        {
            return await _mediator.Send(new GetMarketAuctionValue() { Year = year, EquipmentId = equipmentId});
        }
    }
}
