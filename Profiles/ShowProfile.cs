using AutoMapper;
public class ShowProfile : Profile
    {
        public ShowProfile()
        {
            CreateMap<Show, ShowDto>();
            CreateMap<ShowDto, Show>();

            CreateMap<VenueDto, Venue>();
            CreateMap<Venue, VenueDto>();

            CreateMap<BandDto, Band>();
            CreateMap<Band, BandDto>();
        }
    }

