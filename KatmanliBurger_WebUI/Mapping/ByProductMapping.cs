using AutoMapper;
using KatmanliBurger_DATA.Concretes;
using KatmanliBurger_UI.DTOs.ProductViewDtos;

namespace KatmanliBurger_UI.Mapping
{
	public class ByProductMapping:Profile
	{
        public ByProductMapping()
        {
			CreateMap<ByProduct, ProductViewDto>().
			ForMember(x => x.CategoryName, y => y.MapFrom(z => z.Category.Name)).ReverseMap();
		}
    }
}
