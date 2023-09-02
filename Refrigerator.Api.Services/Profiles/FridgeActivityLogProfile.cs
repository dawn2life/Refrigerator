using AutoMapper;
using Refrigerator.Api.Domain.Dto;
using Refrigerator.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator.Api.Services.Profiles
{
    public class FridgeActivityLogProfile : Profile
    {
        public FridgeActivityLogProfile()
        {
            CreateMap<Stock, FridgeActivityLog>(MemberList.None)
                .ForMember(d => d.ActivityDate, m => m.MapFrom(s => s.PurchaseDate));

            CreateMap<FridgeActivityLog, FridgeActivityLogDto>(MemberList.None)
                .ForMember(x => x.Type, m => m.MapFrom(s => s.Type.ToString()));
        }
    }
}
