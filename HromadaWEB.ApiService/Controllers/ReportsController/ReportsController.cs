using Microsoft.AspNetCore.Mvc;
using HromadaWEB.Infrastructure.Interfaces.Evaluations;
using HromadaWEB.Infrastructure.Interfaces.Indicators;
using HromadaWEB.Infrastructure.Interfaces.Templates;
using HromadaWEB.Infrastructure.Interfaces.EvaluationDirections;
using HromadaWEB.Core.Repositories;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using HromadaWEB.Models.Entities;

[Route("api/report")]
[ApiController]
public class ReportController : ControllerBase
{
    private readonly IEvaluationRepository _evaluationRepository;
    private readonly ITemplateRepository _templateRepository;
    private readonly IIndicatorRepository _indicatorRepository;
    private readonly IEvaluationDirectionRepository _evaluationDirectionRepository;
    private readonly IUserRepository _userRepository;

    public ReportController(IEvaluationRepository evaluationRepository,
                            ITemplateRepository templateRepository,
                            IIndicatorRepository indicatorRepository,
                            IEvaluationDirectionRepository evaluationDirectionRepository,
                            IUserRepository userRepository)
    {
        _evaluationRepository = evaluationRepository;
        _templateRepository = templateRepository;
        _indicatorRepository = indicatorRepository;
        _evaluationDirectionRepository = evaluationDirectionRepository;
        _userRepository = userRepository;
    }

    [HttpGet("generate-pdf")]
    public async Task<IActionResult> GeneratePdf()
    {
        try
        {
            var evaluations = await _evaluationRepository.GetAllAsync();
            var templates = await _templateRepository.GetAllAsync();
            var indicators = await _indicatorRepository.GetAllAsync();
            var evaluationDirections = await _evaluationDirectionRepository.GetAllAsync();

            var userIds = evaluations.Select(e => e.UserId)
                                     .Union(templates.Select(t => t.CreatedById))
                                     .Distinct()
                                     .ToList();

            var users = new Dictionary<Guid, string>();
            foreach (var userId in userIds)
            {
                var user = await _userRepository.GetByIdAsync(userId);
                if (user != null)
                    users[userId] = user.Username;
            }

            byte[] pdfBytes = GenerateReport(evaluations, templates, indicators, evaluationDirections, users);
            return File(pdfBytes, "application/pdf", "SummaryReport.pdf");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Помилка під час генерації PDF: {ex.Message}");
        }
    }

    private byte[] GenerateReport(IEnumerable<Evaluation> evaluations,
                                  IEnumerable<Template> templates,
                                  IEnumerable<Indicator> indicators,
                                  IEnumerable<EvaluationDirection> evaluationDirections,
                                  Dictionary<Guid, string> users)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        return Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(50);
                page.Header().Text("Підсумковий звіт")
                    .FontSize(20)
                    .SemiBold()
                    .FontFamily(Fonts.Arial)
                    .AlignCenter();

                page.Content().Column(col =>
                {
                    // Оцінки
                    col.Item().Text("Оцінки").FontSize(16).SemiBold();
                    foreach (var eval in evaluations)
                    {
                        string username = users.ContainsKey(eval.UserId) ? users[eval.UserId] : "Невідомий користувач";
                        col.Item().Text($"Користувач: {username}, Оцінка: {eval.Score}, Дата: {eval.CreatedAt}")
                                  .FontSize(12);
                    }

                    // Шаблони
                    col.Item().Text("Шаблони").FontSize(16).SemiBold();
                    foreach (var template in templates)
                    {
                        string createdBy = users.ContainsKey(template.CreatedById) ? users[template.CreatedById] : "Невідомий користувач";
                        col.Item().Text($"Назва: {template.Title}, Опис: {template.Description}, Створено: {createdBy}, Дата: {template.CreatedAt}")
                                  .FontSize(12);
                    }

                    // Індикатори
                    col.Item().Text("Індикатори").FontSize(16).SemiBold();
                    var indicatorData = from indicator in indicators
                                        join direction in evaluationDirections on indicator.DirectionId equals direction.Id
                                        select new
                                        {
                                            indicator.Code,
                                            indicator.Name,
                                            indicator.Background,
                                            indicator.Source,
                                            indicator.MaxScore,
                                            DirectionName = direction.Name,
                                            DirectionWeight = direction.Weight
                                        };

                    foreach (var data in indicatorData)
                    {
                        col.Item().Text($"Код: {data.Code}, Назва: {data.Name}, Підстава: {data.Background}, Джерело: {data.Source}, Максимальний бал: {data.MaxScore}, Напрям: {data.DirectionName}, Вага: {data.DirectionWeight}")
                                  .FontSize(12);
                    }
                });

                page.Footer().AlignCenter().Text($"Дата генерації: {DateTime.Now:dd.MM.yyyy}");
            });
        }).GeneratePdf();
    }
}