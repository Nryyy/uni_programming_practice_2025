using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HromadaWEB.Service.Commands.User
{
    public record UpdateUserCommand(Models.Entities.User User) : IRequest;
}
