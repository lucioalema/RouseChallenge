using System;
using System.Threading;
using System.Threading.Tasks;
using MarketAuction.Api.Dtos;
using MarketAuction.Api.Exceptions;
using MarketAuction.Api.Models;
using MediatR;

namespace MarketAuction.Api.Queries
{
    public class GetMarketAuctionValueHandler : IRequestHandler<GetMarketAuctionValue, MarketAuctionValueDto>
    {
        private readonly IScheduleRepository scheduleRepository;
        private readonly IEquipmentRepository equipmentRepository;

        public GetMarketAuctionValueHandler(IScheduleRepository scheduleRepository, IEquipmentRepository equipmentRepository)
        {
            this.scheduleRepository = scheduleRepository ?? throw new ArgumentNullException(nameof(scheduleRepository));
            this.equipmentRepository = equipmentRepository ?? throw new ArgumentNullException(nameof(equipmentRepository));
        }

        public async Task<MarketAuctionValueDto> Handle(GetMarketAuctionValue request, CancellationToken cancellationToken)
        {
            var equipment = await this.equipmentRepository.GetById(request.EquipmentId);
            if (equipment == null)
                throw new NotFoundDomainException($"There is no equipment with Id: { request.EquipmentId }");

            var schedule = await this.scheduleRepository.GetByYearAndSaleDetailsId(request.Year, request.EquipmentId);
            if (schedule == null)
                throw new NotFoundDomainException($"The equipment { equipment.Model.Name } does not have schedule for the year: { request.Year }");

            return new MarketAuctionValueDto(equipment.SaleDetails.Cost * schedule.MarketRatio, equipment.SaleDetails.Cost * schedule.AuctionRatio);
        }
    }
}
