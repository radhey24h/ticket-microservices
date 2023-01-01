using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Application.Features.FMECA.Queries.GetAllFMECA;
using Ticket.Domain.Entities;

namespace Ticket.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<FMECA, FMECADTO>().ReverseMap();
    }

}
