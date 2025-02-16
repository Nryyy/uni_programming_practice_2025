using HromadaWEB.Models.Entities;
using MediatR;

namespace HromadaWEB.Service.Commands.Evaluations
{
    public record CreateEvaluationCommand(Evaluation Evaluation) : IRequest;
}
