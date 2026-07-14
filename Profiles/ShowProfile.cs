using AutoMapper;
public class ShowProfile : Profile
    {
        public ShowProfile()
        {
            CreateMap<ShowEntity, ShowDto>();
            CreateMap<ShowDto, ShowEntity>();

            CreateMap<VenueDto, VenueEntity>();
            CreateMap<VenueEntity, VenueDto>();

            CreateMap<BandDto, BandEntity>();
            CreateMap<BandEntity, BandDto>();
        }
    }

