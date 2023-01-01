using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Application.Features.FMECA.Queries.GetAllFMECA
{
    public class GetAllFMECAQuery : IRequest<List<FMECADTO>>
    {
        public string UserId { get; set; }
        public GetAllFMECAQuery(string userId)
        {
            UserId = userId ?? throw new ArgumentNullException(nameof(userId));
        }
    }
}
