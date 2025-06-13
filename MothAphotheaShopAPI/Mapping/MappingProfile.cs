using AutoMapper;

namespace MothAphotheaShopAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ActiveCompound, ActitveCompoundDTO>();

            CreateMap<Aroma, AromaDTO>();

            CreateMap<Contraindication, ContraindicationDTO>();

            CreateMap<Effect, EffectDTO>();

            CreateMap<FlavorNote, FlavorNoteDTO>();


            CreateMap<Ingredient, IngredientDTO>()
                .ForMember(dest => dest.FlavorsIds, opt => opt.Ignore())
                .ForMember(dest => dest.EffectsIds, opt => opt.Ignore())
                .ForMember(dest => dest.WarningsIds, opt => opt.Ignore());


            CreateMap<IngredientType, IngredientTypeDTO>();


            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.IngridientsIds, opt => opt.Ignore())
                .ForMember(dest => dest.FlavorsIds, opt => opt.Ignore())
                .ForMember(dest => dest.EffectsIds, opt => opt.Ignore())
                .ForMember(dest => dest.WarningsIds, opt => opt.Ignore());


            CreateMap<ProductType, ProductTypeDTO>();

            CreateMap<Texture, TextureDTO>();

        }
    }
}
