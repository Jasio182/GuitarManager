using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Domain
{
    public class GetInstalledStringsRequest : IRequest<GetInstalledStringsResponse>
    {
    }
}
