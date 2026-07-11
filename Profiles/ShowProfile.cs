using AutoMapper;
public class ShowProfile : Profile
    {
        public ShowProfile()
        {
            CreateMap<ShowEntity, ShowDto>();
        }
    }

