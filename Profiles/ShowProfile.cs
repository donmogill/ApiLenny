using AutoMapper;
public class ShowProfile : Profile
    {
        public ShowProfile()
        {
            CreateMap<ShowEntity, ShowDto>();
            CreateMap<ShowDto, ShowEntity>();
            CreateMap<VenueEntity, VenueDto>();
            CreateMap<VenueDto, VenueEntity>();
        }
    }

