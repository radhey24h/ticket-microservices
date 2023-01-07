using AutoMapper;
using FMECA.Application.Features.FMECA.Commands.Insert;
using FMECA.Application.Features.FMECA.Commands.Update;
using FMECA.Application.Features.FMECA.Queries.GetAllMetadatFMECA;
using FMECA.Application.Features.FMECA.Queries.GetMyOpenFMECA;
using FMECA.Application.Features.FMECAReport.Commands.Insert;
using FMECA.Application.Features.FMECAReport.Commands.Update;
using DOMAIN=FMECA.Domain.Entities;

namespace FMECA.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DOMAIN.FMECA, MyOpenFMECADTO>().ReverseMap();
        CreateMap<DOMAIN.FMECA, CreateFMECACommand>().ReverseMap();
        CreateMap<DOMAIN.FMECA, UpdateFMECACommand>().ReverseMap();
        CreateMap<DOMAIN.FMECAReport, FMECAReportDTO>().ReverseMap();
        CreateMap<DOMAIN.FMECAReport, CreateFMECAReportCommand>().ReverseMap();
        CreateMap<DOMAIN.FMECAReport, UpdateFMECAReportCommand>().ReverseMap();
    }

}
