var builder = WebApplication.CreateBuilder(args);

// =============================
// Services
// =============================

// Ajout des contrôleurs
builder.Services.AddControllers();

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuration HTTPS
builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 44336;
});

var app = builder.Build();

// =============================
// Pipeline HTTP
// =============================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Active HTTPS en production
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// =============================
// Génération du rapport de ventes
// =============================

try
{
    SalesReport.GenerateReport();
    Console.WriteLine("Sales report generated successfully!");
}
catch (Exception ex)
{
    Console.WriteLine($"Error generating report: {ex.Message}");
}

// =============================
// Démarrage de l'application
// =============================

Console.WriteLine("Contoso Pizza API is running...");
app.Run();