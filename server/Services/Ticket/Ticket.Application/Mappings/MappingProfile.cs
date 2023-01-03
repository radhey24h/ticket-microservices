using AutoMapper;
using FMECA.Application.Features.MetadataFMECA.Commands.Insert;
using FMECA.Application.Features.MetadataFMECA.Commands.Update;
using FMECA.Application.Features.MetadataFMECA.Queries.GetAllFMECA;
using FMECA.Domain.Entities;

namespace FMECA.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<FMECADetails, FMECADTO>().ReverseMap();
        CreateMap<FMECADetails, CreateFMECADetailsCommand>().ReverseMap();
        CreateMap<FMECADetails, UpdateFMECADetailsCommand>().ReverseMap();
    }

}
