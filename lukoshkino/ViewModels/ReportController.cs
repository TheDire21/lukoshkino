using ClosedXML.Excel;
using lukoshkino.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize(Roles = "Admin")]
[ApiController]
[Microsoft.AspNetCore.Mvc.Route("api/report")]
public class ReportController : ControllerBase
{
    private readonly IDbContextFactory<ApplicationContext> _dbContextFactory;
    public ReportController(IDbContextFactory<ApplicationContext> dbFactoryService)
    {
        _dbContextFactory = dbFactoryService;
    }

    [HttpGet("download")]
    public IActionResult Download()
    {
        using var workbook = new XLWorkbook();
        var ws = workbook.Worksheets.Add("Отчет");

        // Заголовки
        ws.Cell(1, 1).Value = "Id";
        ws.Cell(1, 2).Value = "Название";
        ws.Cell(1, 3).Value = "Категория";
        ws.Cell(1, 4).Value = "Количество";

        ws.Row(1).Style.Font.Bold = true;

        // Данные
        var data = GetReportData();
        for (int i = 0; i < data.Count; i++)
        {
            ws.Cell(i + 2, 1).Value = data[i].Id;
            ws.Cell(i + 2, 2).Value = data[i].Name;
            ws.Cell(i + 2, 3).Value = data[i].Category;
            ws.Cell(i + 2, 4).Value = data[i].Quantity;
        }

        ws.Columns().AdjustToContents();

        using var stream = new MemoryStream();
        workbook.SaveAs(stream);
        stream.Position = 0;

        return File(
            stream.ToArray(),
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            $"report_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
        );
    }

    private List<ReportRow> GetReportData()
    {
        using (var ac = _dbContextFactory.CreateDbContext())
        {
            return ac.Products.Select(x => new ReportRow() { Id = x.Id, Name = x.Name, Category = x.Category.Name, Quantity = x.Quantity }).ToList();
        }
    }

    private class ReportRow
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Category { get; set; } = "";
        public decimal Quantity { get; set; }
    }
}
