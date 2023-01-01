using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Application.Features.FMECA.Queries
{
    public class GetAllFMECAQueryHandler : IRequestHandler<GetAllFMECAQuery, List<FMECADTO>>
    {
        public Task<List<FMECADTO>> Handle(GetAllFMECAQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
