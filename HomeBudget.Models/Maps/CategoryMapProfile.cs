using AutoMapper;
using HomeBudget.Data;
using HomeBudget.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Models.Maps
{
    public class CategoryMapProfile : Profile
    {
        public CategoryMapProfile()
        {
            CreateMap<CategoryEntity, CategoryCreate>();
            CreateMap<CategoryEntity, CategoryListItem>();
            CreateMap<CategoryEntity, CategoryDetail>();
            CreateMap<CategoryEntity, CategoryEdit>();

            CreateMap<CategoryCreate, CategoryEntity>();
            CreateMap<CategoryListItem, CategoryEntity>();
            CreateMap<CategoryDetail, CategoryEntity>();
            CreateMap<CategoryEdit, CategoryEntity>();
        }
    }
}
