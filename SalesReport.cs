using System.Text;

public static class SalesReport
{
    public static void GenerateReport()
    {
        Dictionary<string, decimal> sales = new()
        {
            { "January.txt", 1500.50m },
            { "February.txt", 2300.75m },
            { "March.txt", 1750.25m }
        };

        decimal totalSales = sales.Values.Sum();

        StringBuilder report = new();

        report.AppendLine("Sales Summary");
        report.AppendLine("----------------------------");
        report.AppendLine($"Total Sales: {totalSales:C}");
        report.AppendLine();
        report.AppendLine("Details:");

        foreach (var sale in sales)
        {
            report.AppendLine($"{sale.Key}: {sale.Value:C}");
        }

        File.WriteAllText("SalesSummary.txt", report.ToString());

        Console.WriteLine("Sales report generated!");
    }
}