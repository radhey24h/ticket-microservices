using AutoMapper;
using FMECA.Application.Features.MetadataFMECA.Commands.Insert;
using FMECA.Application.Features.MetadataFMECA.Commands.Update;
using FMECA.Application.Features.MetadataFMECA.Queries.GetAllMetadatFMECA;
using FMECA.Domain.Entities;

namespace FMECA.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<MetadataFMECA, MetadatFMECADTO>().ReverseMap();
        CreateMap<MetadataFMECA, CreateMetadatFMECACommand>().ReverseMap();
        CreateMap<MetadataFMECA, UpdateMetadatFMECACommand>().ReverseMap();
    }

}
