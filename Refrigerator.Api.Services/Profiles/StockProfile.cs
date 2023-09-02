using AutoMapper;
using Refrigerator.Api.Domain.Dto;
using Refrigerator.Api.Domain.Models;
using Refrigerator.Api.Domain.Requests;

namespace Refrigerator.Api.Services.Profiles
{
    public class StockProfile : Profile
    {
        public StockProfile() 
        {
            CreateMap<AddItemRequest, Stock>(MemberList.None);
            CreateMap<Stock, ExpiredItemDto>(MemberList.None);
        }   
    }
}
