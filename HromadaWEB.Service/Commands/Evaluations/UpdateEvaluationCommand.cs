using HromadaWEB.Models.Entities;
using MediatR;

namespace HromadaWEB.Service.Commands.Evaluations
{
    public record UpdateEvaluationCommand(Evaluation Evaluation) : IRequest;
}
