using AutoMapper;

namespace MothAphotheaShopAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Aroma, AromaDTO>();
            CreateMap<AromaDTO, Aroma>();


            CreateMap<Contraindication, ContraindicationDTO>();
            CreateMap<ContraindicationDTO, Contraindication>();


            CreateMap<Effect, EffectDTO>();
            CreateMap<EffectDTO, Effect>();


            CreateMap<FlavorNote, FlavorNoteDTO>();
            CreateMap<FlavorNoteDTO, FlavorNote>();


            CreateMap<Ingredient, IngredientInsertDTO>()
                .ForMember(dest => dest.TypeId, opt => opt.Ignore())
                .ForMember(dest => dest.AromasIds, opt => opt.Ignore())
                .ForMember(dest => dest.TexturesIds, opt => opt.Ignore())
                .ForMember(dest => dest.FlavorsIds, opt => opt.Ignore())
                .ForMember(dest => dest.EffectsIds, opt => opt.Ignore())
                .ForMember(dest => dest.ContraindicationingsIds, opt => opt.Ignore());
            CreateMap<IngredientInsertDTO, Ingredient>()
                .ForMember(dest => dest.Type, opt => opt.Ignore())
                .ForMember(dest => dest.Aromas, opt => opt.Ignore())
                .ForMember(dest => dest.Textures, opt => opt.Ignore())
                .ForMember(dest => dest.FlavorNotes, opt => opt.Ignore())
                .ForMember(dest => dest.Effects, opt => opt.Ignore())
                .ForMember(dest => dest.Contraindications, opt => opt.Ignore());


            CreateMap<Ingredient, IngredientViewDTO>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Aromas, opt => opt.MapFrom(src => src.Aromas))
                .ForMember(dest => dest.Textures, opt => opt.MapFrom(src => src.Textures))
                .ForMember(dest => dest.Flavors, opt => opt.MapFrom(src => src.FlavorNotes))
                .ForMember(dest => dest.Effects, opt => opt.MapFrom(src => src.Effects))
                .ForMember(dest => dest.Contraindications, opt => opt.MapFrom(src => src.Contraindications));
            CreateMap<IngredientViewDTO, Ingredient>()
                .ForMember(dest => dest.Type, opt => opt.Ignore())
                .ForMember(dest => dest.Aromas, opt => opt.Ignore())
                .ForMember(dest => dest.Textures, opt => opt.Ignore())
                .ForMember(dest => dest.FlavorNotes, opt => opt.Ignore())
                .ForMember(dest => dest.Effects, opt => opt.Ignore())
                .ForMember(dest => dest.Contraindications, opt => opt.Ignore());


            CreateMap<IngredientType, IngredientTypeDTO>();
            CreateMap<IngredientTypeDTO, IngredientType>();


            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.IngridientsIds, opt => opt.Ignore())
                .ForMember(dest => dest.TypeId, opt => opt.Ignore())
                .ForMember(dest => dest.AromasIds, opt => opt.Ignore())
                .ForMember(dest => dest.TexturesIds, opt => opt.Ignore())
                .ForMember(dest => dest.FlavorsIds, opt => opt.Ignore())
                .ForMember(dest => dest.EffectsIds, opt => opt.Ignore())
                .ForMember(dest => dest.ContraindicationsIds, opt => opt.Ignore());
            CreateMap<ProductDTO, Product>()
                .ForMember(dest => dest.IngredientList, opt => opt.Ignore())
                .ForMember(dest => dest.Type, opt => opt.Ignore())
                .ForMember(dest => dest.Aromas, opt => opt.Ignore())
                .ForMember(dest => dest.Textures, opt => opt.Ignore())
                .ForMember(dest => dest.FlavorNotes, opt => opt.Ignore())
                .ForMember(dest => dest.Effects, opt => opt.Ignore())
                .ForMember(dest => dest.Contraindications, opt => opt.Ignore());


            CreateMap<ProductType, ProductTypeDTO>();
            CreateMap<ProductTypeDTO, ProductType>();


            CreateMap<Purchase, PurchaseDTO>()
                .ForMember(dest => dest.ProductIds, opt => opt.Ignore())
                .ForMember(dest => dest.PaymentMethodId, opt => opt.Ignore());
            CreateMap<PurchaseDTO, Purchase>()
                .ForMember(dest => dest.Products, opt => opt.Ignore())
                .ForMember(dest => dest.PaymentMethod, opt => opt.Ignore());


            CreateMap<Texture, TextureDTO>();
            CreateMap<TextureDTO, Texture>();

        }
    }
}
