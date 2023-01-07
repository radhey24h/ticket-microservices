using AutoMapper;
using FMECA.Application.Features.MetadataFMECA.Commands.Insert;
using FMECA.Application.Features.MetadataFMECA.Commands.Update;
using FMECA.Application.Features.MetadataFMECA.Queries.GetAllMetadatFMECA;
using FMECA.Application.Features.MetadataFMECA.Queries.GetMyOpenFMECA;
using FMECA.Domain.Entities;

namespace FMECA.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<MetadataFMECA, MyOpenFMECADTO>().ReverseMap();
        CreateMap<MetadataFMECA, MetadatFMECAReportDTO>().ReverseMap();
        CreateMap<MetadataFMECA, CreateMetadatFMECACommand>().ReverseMap();
        CreateMap<MetadataFMECA, UpdateMetadatFMECACommand>().ReverseMap();
    }

}
