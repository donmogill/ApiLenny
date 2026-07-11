using AutoMapper;
public class ShowProfile : Profile
    {
        public ShowProfile()
        {
            CreateMap<ShowEntity, ShowDto>();
            CreateMap<VenueEntity, VenueDto>();
            CreateMap<ShowDto, ShowEntity>();
        }
    }

