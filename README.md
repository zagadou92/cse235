CSE325 W01 - Develop .NET Applications with C#
Student
DAGBAME FRANCK ZAGADOU

Additional Pizza Added
{
  "id": 4,
  "name": "Chicken BBQ",
  "isGlutenFree": false
}
CRUD Operations
GET
Request:

GET /Pizza
Response: 

200 OK
[
  {
    "id": 1,
    "name": "Classic Italian",
    "isGlutenFree": false
  },
  {
    "id": 2,
    "name": "Veggie",
    "isGlutenFree": true
  },
  {
    "id": 3,
    "name": "Hawaiian",
    "isGlutenFree": false
  },
  {
    "id": 4,
    "name": "Chicken BBQ",
    "isGlutenFree": false
  }
]
POST
Request:

POST /Pizza
{
  "name": "Pepperoni",
  "isGlutenFree": false
}
Response:

201 Created
{
  "id": 5,
  "name": "Pepperoni",
  "isGlutenFree": false
}
PUT
Request:

PUT /Pizza/5
{
  "id": 5,
  "name": "Pepperoni Deluxe",
  "isGlutenFree": true
}
Response:

204 No Content
DELETE
Request:

DELETE /Pizza/5
Response:

204 No Content
Sales Summary Function
public static void Generate()
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
}
Sales Summary Output
Sales Summary
----------------------------
Total Sales: $5,551.50

Details:
January.txt: $1,500.50
February.txt: $2,300.75
March.txt: $1,750.25
