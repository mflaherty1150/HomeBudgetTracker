using AutoMapper;
using HomeBudget.Data;
using HomeBudget.Models.Place;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Models.Maps
{
    public class PlaceMapProfile : Profile
    {
        public PlaceMapProfile()
        {
            CreateMap<PlaceEntity, PlaceCreate>();
            CreateMap<PlaceEntity, PlaceListItem>();
            CreateMap<PlaceEntity, PlaceDetail>();
            CreateMap<PlaceEntity, PlaceEdit>();

            CreateMap<PlaceCreate, PlaceEntity>();
            CreateMap<PlaceListItem, PlaceEntity>();
            CreateMap<PlaceDetail, PlaceEntity>();
            CreateMap<PlaceEdit, PlaceEntity>();
        }
    }
}
